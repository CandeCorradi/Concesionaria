using Concesionaria.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApi1.Repositorio;

namespace Concesionaria.Services
{
    internal class ApiRest
    {
        private static readonly HttpClient Cliente = new HttpClient();

        // Base de la API (sin la colección)
        private const string UrlBase = "https://cinesoftwareisp-a633.restdb.io/rest/concesionaria";

        // Atención: mover la API key a configuración / variable de entorno en producción
        private const string ApiKey = "e3aa8c8646e510e1df586b60308931d116ed7";
        static ApiRest()
        {
            // Configuración del HttpClient para todas las llamadas
            Cliente.BaseAddress = new System.Uri(UrlBase);
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Cliente.DefaultRequestHeaders.Add("x-apikey", ApiKey);
        }

        //------------------CRUD-------AUTOS----------------------------------//

        //FUNCIÓN DE CONSULTA (GET)
        public static async Task<List<Auto>> ObtenerTodosLosAutosAsync()
        {
            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync("");

                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoJson = await respuesta.Content.ReadAsStringAsync();
                    var lista = JsonSerializer.Deserialize<List<Auto>>(contenidoJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return lista ?? new List<Auto>();
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al consultar API: {respuesta.StatusCode}. Detalle: {errorContent}", "Error de Conexión");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión de red: {ex.Message}", "Error de Red");
            }

            return new List<Auto>();
        }

        //FUNCIÓN DE AGREGAR (POST)
        public static async Task<bool> CrearNuevoAutoAsync(Auto nuevoAuto)
        {
            string jsonPayload = JsonSerializer.Serialize(nuevoAuto);
            var contenido = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage respuesta = await Cliente.PostAsync("", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al crear el auto: {respuesta.StatusCode}\nDetalle: {errorContent}", "Error POST");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión al intentar crear: {ex.Message}", "Error de Red");
                return false;
            }
        }

        //FUNCIÓN DE MODIFICACIÓN (PUT)
        public static async Task<bool> ActualizarAutoAsync(Auto autoData)
        {
            if (string.IsNullOrEmpty(autoData.Id))
            {
                MessageBox.Show("No se puede actualizar sin un ID de auto.", "Error de Actualización");
                return false;
            }
            string jsonPayload = JsonSerializer.Serialize(autoData);
            var contenido = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                string urlCompleta = $"{UrlBase}/{autoData.Id}";
                HttpResponseMessage respuesta = await Cliente.PutAsync(urlCompleta, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar el auto: {respuesta.StatusCode}\nDetalle: {errorContent}", "Error PUT");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión al intentar actualizar: {ex.Message}", "Error de Red");
                return false;
            }
        }

        //FUNCIÓN DE ELIMINACIÓN (DELETE)
        public static async Task<bool> EliminarAutoAsync(string idAuto)
        {
            if (string.IsNullOrEmpty(idAuto))
            {
                MessageBox.Show("No se puede eliminar sin un ID.", "Error de Eliminación");
                return false;
            }

            try
            {
                string urlCompleta = $"{UrlBase}/{idAuto}";
                HttpResponseMessage respuesta = await Cliente.DeleteAsync(urlCompleta);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar el auto: {respuesta.StatusCode}\nDetalle: {errorContent}", "Error DELETE - Detalle Final");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión de red: {ex.Message}", "Error de Red");
                return false;
            }
        }

        //--------------CRUD-----------PROPIETARIOS----------------------------//

        // FUNCIÓN DE CONSULTA (GET)
        public static async Task<List<Propietario>> ObtenerTodosLosPropietariosAsync()
        {
            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync("propietario");

                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoJson = await respuesta.Content.ReadAsStringAsync();
                    var lista = JsonSerializer.Deserialize<List<Propietario>>(contenidoJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return lista ?? new List<Propietario>();
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al consultar API de Propietarios: {respuesta.StatusCode}. Detalle: {errorContent}", "Error de Conexión");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión de red (Propietarios): {ex.Message}", "Error de Red");
            }

            return new List<Propietario>();
        }

        // FUNCIÓN DE AGREGAR (POST)
        public static async Task<bool> CrearNuevoPropietarioAsync(Propietario nuevoPropietario)
        {
            string jsonPayload = JsonSerializer.Serialize(nuevoPropietario);
            var contenido = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                // Endpoint: "propietario" (Correcto)
                HttpResponseMessage respuesta = await Cliente.PostAsync("propietario", contenido);

                if (respuesta.IsSuccessStatusCode) return true;

                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al crear el propietario: {respuesta.StatusCode}\nDetalle: {errorContent}", "Error POST Propietario");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión al intentar crear el propietario: {ex.Message}", "Error de Red");
                return false;
            }
        }

        // FUNCIÓN DE MODIFICACIÓN (PUT)
        public static async Task<bool> ActualizarPropietarioAsync(Propietario propietarioAActualizar)
        {
            if (string.IsNullOrEmpty(propietarioAActualizar.Id))
            {
                MessageBox.Show("No se puede actualizar sin un ID de propietario.", "Error de Actualización");
                return false;
            }

            string jsonPayload = JsonSerializer.Serialize(propietarioAActualizar);
            var contenido = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                // Usar el endpoint de la colección 'propietario' en vez de UrlBase
                string endpoint = $"propietario/{propietarioAActualizar.Id}";
                HttpResponseMessage respuesta = await Cliente.PutAsync(endpoint, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar el propietario: {respuesta.StatusCode}\nDetalle: {errorContent}", "Error PUT");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión al intentar actualizar: {ex.Message}", "Error de Red");
                return false;
            }
        }

        // FUNCIÓN DE ELIMINACIÓN (DELETE)
        public static async Task<bool> EliminarPropietarioAsync(string idPropietario)
        {
            if (string.IsNullOrEmpty(idPropietario))
            {
                MessageBox.Show("No se puede eliminar sin un ID.", "Error de Eliminación");
                return false;
            }

            try
            {                
                string endpoint = $"propietario/{idPropietario}";
                HttpResponseMessage respuesta = await Cliente.DeleteAsync(endpoint);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar el propietario: {respuesta.StatusCode}\nDetalle: {errorContent}", "Error DELETE - Detalle Final");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión de red: {ex.Message}", "Error de Red");
                return false;
            }
        }
    }

}



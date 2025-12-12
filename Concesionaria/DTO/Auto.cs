using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json; //acá esta el objeto HttpClient
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using WinFormApi1; //estan nuestro objetos. Data Transfer Object = DTO

namespace WinFormApi1.Repositorio
{
    public class Auto
    {        
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int Potencia { get; set; }
        public decimal Precio_USD { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}

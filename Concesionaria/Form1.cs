using Concesionaria.DTO;
using Concesionaria.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApi1.Repositorio;

namespace Concesionaria
{
    public partial class Form1 : Form
    {
        private List<Auto> _listaAutosCache = new List<Auto>();
        private bool _esModoEdicion;
        private string _idAutoSeleccionado = string.Empty;
        private bool _propietarioModoEdicion = false;
        private string _idPropietarioSeleccionado = string.Empty;

        public Form1()
        {
            InitializeComponent();
            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;

            DataGridAutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridAutos.MultiSelect = false;
            DataGridAutos.ReadOnly = true;
            DataGridAutos.AllowUserToAddRows = false;
            DataGridAutos.ClearSelection();
        }

        //------------------AUTOS------------------//

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private async Task CargarDatosEnGrilla()
        {
            _listaAutosCache = await ApiRest.ObtenerTodosLosAutosAsync() ?? new List<Auto>();
            AplicarFiltroYActualizarGrilla(string.Empty);
        }


        private async Task CargarDatosEnGrilla(string textoBusqueda)
        {
            if (_listaAutosCache == null || !_listaAutosCache.Any())
            {
                await CargarDatosEnGrilla();
                return;
            }

            AplicarFiltroYActualizarGrilla(textoBusqueda);
        }


        private void AplicarFiltroYActualizarGrilla(string textoBusqueda)
        {
            IEnumerable<Auto> resultado = _listaAutosCache;

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                string t = textoBusqueda.Trim().ToLowerInvariant();
                resultado = resultado.Where(a =>
                    (!string.IsNullOrEmpty(a.Id) && a.Id.ToLowerInvariant().Contains(t)) ||
                    (!string.IsNullOrEmpty(a.Marca) && a.Marca.ToLowerInvariant().Contains(t)) ||
                    (!string.IsNullOrEmpty(a.Modelo) && a.Modelo.ToLowerInvariant().Contains(t)) ||
                    a.Anio.ToString().Contains(t) ||
                    a.Potencia.ToString().Contains(t) ||
                    a.Precio_USD.ToString().Contains(t)
                );
            }

            DataGridAutos.DataSource = null;
            DataGridAutos.DataSource = resultado.ToList();

            if (DataGridAutos.Columns.Contains("Id"))
            {
                DataGridAutos.Columns["Id"].Visible = false;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            TabControlAutos.SelectedTab = TabListado;
            await CargarDatosEnGrilla();
            TabControlAutos.SelectedIndex = 0;
            await CargarPropietariosEnComboBox();
            await CargarDatosPropietariosEnGrilla();
        }

        private async void TxtBusqueda_TextChanged(object? sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text;
            await CargarDatosEnGrilla(textoBusqueda);
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Mantener compatibilidad con el botón Buscar: realiza el mismo filtrado
            string textoBusqueda = txtBusqueda.Text.Trim();
            await CargarDatosEnGrilla(textoBusqueda);

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Mostrando todos los modelos.", "Consulta Completa");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            _esModoEdicion = false;
            _idAutoSeleccionado = string.Empty;
            LimpiarCamposCarga();
            TabControlAutos.SelectedTab = TabEditar;
        }

        private void LimpiarCamposCarga()
        {
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtAnio.Text = string.Empty;
            txtPotencia.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtDNI.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
            TxtCiudad.Text = string.Empty;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Auto autoData = RecolectarDatosDelFormulario();
            bool exito = false;

            if (autoData == null)
            {
                return;
            }

            if (!_esModoEdicion)
            {
                exito = await Services.ApiRest.CrearNuevoAutoAsync(autoData);
            }
            else
            {
                autoData.Id = _idAutoSeleccionado;
                exito = await Services.ApiRest.ActualizarAutoAsync(autoData);
            }

            if (exito)
            {
                MessageBox.Show("Operación de Guardado exitosa.", "Éxito");
                TabControlAutos.SelectedTab = TabListado;
                LimpiarCamposCarga();
                await CargarDatosEnGrilla();
            }
            else
            {
                MessageBox.Show("Fallo la operación de guardado. Revisa la conexión o los datos.", "Error");
            }
        }


        private Auto? RecolectarDatosDelFormulario()
        {
            string marca = txtMarca.Text?.Trim() ?? string.Empty;
            string modelo = txtModelo.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(marca))
            {
                MessageBox.Show("Ingrese la marca.", "Validación");
                txtMarca.Focus();
                return null;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                MessageBox.Show("Ingrese el modelo.", "Validación");
                txtModelo.Focus();
                return null;
            }

            if (!int.TryParse(txtAnio.Text?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int anio))
            {
                MessageBox.Show("Ingrese un año válido (número entero).", "Validación");
                txtAnio.Focus();
                return null;
            }

            if (!int.TryParse(txtPotencia.Text?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int potencia))
            {
                MessageBox.Show("Ingrese una potencia válida (número entero).", "Validación");
                txtPotencia.Focus();
                return null;
            }

            if (!decimal.TryParse(txtPrecio.Text?.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal precio))
            {
                if (!decimal.TryParse(txtPrecio.Text?.Trim(), out precio))
                {
                    MessageBox.Show("Ingrese un precio válido (ej: 19999.99).", "Validación");
                    txtPrecio.Focus();
                    return null;
                }
            }

            string propietarioId = null;
            DTO.Propietario propietarioSeleccionado = null;

            if (CmbPropietario.SelectedItem is DTO.Propietario seleccionado)
            {
                propietarioSeleccionado = seleccionado;
                propietarioId = seleccionado.Id;
            }

            var auto = new Auto
            {
                Id = null,
                Marca = marca,
                Modelo = modelo,
                Anio = anio,
                Potencia = potencia,
                Precio_USD = precio,
                Nombre = propietarioSeleccionado?.Nombre,
                Apellido = propietarioSeleccionado?.Apellido
            };


            if (_esModoEdicion && !string.IsNullOrEmpty(_idAutoSeleccionado))
            {
                auto.Id = _idAutoSeleccionado;
            }

            return auto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TabControlAutos.SelectedTab = TabListado;
            LimpiarCamposCarga();
            _esModoEdicion = false;
            _idAutoSeleccionado = string.Empty;
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DataGridAutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un auto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow filaSeleccionada = DataGridAutos.SelectedRows[0];
            Auto autoAEliminar = filaSeleccionada.DataBoundItem as Auto;

            if (autoAEliminar == null || string.IsNullOrEmpty(autoAEliminar.Id))
            {
                MessageBox.Show("No se pudo obtener la información completa del auto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el auto {autoAEliminar.Marca} {autoAEliminar.Modelo}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                bool exito = await ApiRest.EliminarAutoAsync(autoAEliminar.Id);

                if (exito)
                {
                    MessageBox.Show("Auto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarDatosEnGrilla();
                }
                else
                {
                    MessageBox.Show("❌ La eliminación falló. Por favor, revise los mensajes de error anteriores para ver el detalle.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DataGridAutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un auto de la lista para modificar.", "Advertencia");
                return;
            }

            DataGridViewRow filaSeleccionada = DataGridAutos.SelectedRows[0];
            Auto autoAEditar = filaSeleccionada.DataBoundItem as Auto;

            if (autoAEditar == null || string.IsNullOrEmpty(autoAEditar.Id))
            {
                MessageBox.Show("No se pudo obtener la información completa del auto.", "Error");
                return;
            }

            _esModoEdicion = true;
            _idAutoSeleccionado = autoAEditar.Id;

            txtMarca.Text = autoAEditar.Marca;
            txtModelo.Text = autoAEditar.Modelo;
            txtAnio.Text = autoAEditar.Anio.ToString();
            txtPotencia.Text = autoAEditar.Potencia.ToString();
            txtPrecio.Text = autoAEditar.Precio_USD.ToString(System.Globalization.CultureInfo.InvariantCulture);

            TabControlAutos.SelectedTab = TabEditar;
        }

        //----------------PROPIETARIOS----------------//
        private DTO.Propietario? RecolectarDatosPropietario()
        {
            string nombre = TxtNombre.Text?.Trim() ?? string.Empty;
            string dniText = TxtDNI.Text?.Trim() ?? string.Empty;
            string ciudad = TxtCiudad.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dniText))
            {
                MessageBox.Show("Nombre e Identificación (DNI) son obligatorios.", "Validación");
                return null;
            }

            if (!int.TryParse(dniText, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número entero válido.", "Error de Formato");
                TxtDNI.Focus();
                return null;
            }
            if (!int.TryParse(TxtTelefono.Text, out int telefono))
            {
                MessageBox.Show("El Teléfono debe ser un número entero válido.", "Error de Formato");
                TxtTelefono.Focus();
                return null;
            }

            if (string.IsNullOrWhiteSpace(ciudad) || string.IsNullOrWhiteSpace(ciudad))
            {
                MessageBox.Show("Nombre e Identificación (DNI) son obligatorios.", "Validación");
                return null;
            }

            var propietario = new DTO.Propietario
            {
                Id = null,
                Nombre = nombre,
                Apellido = TxtApellido.Text,
                DNI = dni,
                Telefono = telefono,
                Ciudad = ciudad
            };

            if (_propietarioModoEdicion)
            {
                propietario.Id = _idPropietarioSeleccionado;
            }

            return propietario;
        }

        private async void BtnGuardarPropietario_Click(object sender, EventArgs e)
        {
            DTO.Propietario? propietarioData = RecolectarDatosPropietario();
            bool exito = false;

            if (propietarioData == null)
            {
                return;
            }

            if (!_propietarioModoEdicion)
            {
                exito = await Services.ApiRest.CrearNuevoPropietarioAsync(propietarioData);
            }
            else
            {
                propietarioData.Id = _idPropietarioSeleccionado;
                exito = await Services.ApiRest.ActualizarPropietarioAsync(propietarioData);
            }

            if (exito)
            {
                MessageBox.Show("Operación de Guardado exitosa.", "Éxito");
                TabControlAutos.SelectedTab = TabPropietario;
                LimpiarCamposCarga();

                // REFRESH: actualizar tanto la grilla como el ComboBox para que reflejen cambios
                await CargarDatosPropietariosEnGrilla();
                await CargarPropietariosEnComboBox();
            }
            else
            {
                MessageBox.Show("Fallo la operación de guardado. Revisa la conexión o los datos.", "Error");
            }
        }

        private async Task CargarPropietariosEnComboBox()
        {
            List<DTO.Propietario> listaPropietarios = await Services.ApiRest.ObtenerTodosLosPropietariosAsync();
            CmbPropietario.DataSource = null;
            CmbPropietario.DataSource = listaPropietarios;
            CmbPropietario.DisplayMember = "NombreCompleto";
            CmbPropietario.ValueMember = "Id";
            // Mantener sin selección al refrescar para evitar cambios inesperados
            CmbPropietario.SelectedIndex = -1;
        }

        private async Task CargarDatosPropietariosEnGrilla()
        {
            List<DTO.Propietario> listaPropietarios = await Services.ApiRest.ObtenerTodosLosPropietariosAsync();

            // Asegurar que el DataGrid genere columnas automáticamente si no se definieron en el diseñador
            DataGridPropietarios.AutoGenerateColumns = true;

            DataGridPropietarios.DataSource = null;
            DataGridPropietarios.DataSource = listaPropietarios;

            if (DataGridPropietarios.Columns.Count > 0)
            {
                if (DataGridPropietarios.Columns.Contains("Id"))
                {
                    DataGridPropietarios.Columns["Id"].Visible = true;
                }

                if (DataGridPropietarios.Columns.Contains("NombreCompleto"))
                {
                    DataGridPropietarios.Columns["NombreCompleto"].Visible = false;
                }
            }
        }

        private void LimpiarCamposPropietario()
        {
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtDNI.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
        }

        private void DataGridPropietarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridPropietarios.SelectedRows.Count == 0) return;

            // Obtener el objeto Propietario de la fila seleccionada
            DTO.Propietario propSeleccionado = (DTO.Propietario)DataGridPropietarios.SelectedRows[0].DataBoundItem;

            // 1. Cargar datos en los TextBoxes
            TxtNombre.Text = propSeleccionado.Nombre;
            TxtApellido.Text = propSeleccionado.Apellido;
            TxtDNI.Text = propSeleccionado.DNI.ToString();
            TxtTelefono.Text = propSeleccionado.Telefono.ToString();

            // 2. Establecer el estado: Modo Edición
            _propietarioModoEdicion = true;
            _idPropietarioSeleccionado = propSeleccionado.Id;
        }

        private void BtnCancelarPropietario_Click(object sender, EventArgs e)
        {
            TabControlAutos.SelectedTab = TabListado;
            LimpiarCamposCarga();
            _propietarioModoEdicion = false;
            _idPropietarioSeleccionado = string.Empty;
        }

        private void BtnModProp_Click(object sender, EventArgs e)
        {
            if (DataGridPropietarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un propietario de la lista para modificar.", "Advertencia");
                return;
            }

            DataGridViewRow filaSeleccionada = DataGridPropietarios.SelectedRows[0];
            Propietario? propietarioAEditar = filaSeleccionada.DataBoundItem as Propietario;

            if (propietarioAEditar == null || string.IsNullOrEmpty(propietarioAEditar.Id))
            {
                MessageBox.Show("No se pudo obtener la información completa del propietario.", "Error");
                return;
            }

            _propietarioModoEdicion = true;
            _idPropietarioSeleccionado = propietarioAEditar.Id;

            TxtNombre.Text = propietarioAEditar.Nombre;
            TxtApellido.Text = propietarioAEditar.Apellido;
            TxtDNI.Text = propietarioAEditar.DNI.ToString();
            TxtTelefono.Text = propietarioAEditar.Telefono.ToString();

            TabControlAutos.SelectedTab = TabPropietario;
        }

        private async void BtnEliminarProp_Click(object sender, EventArgs e)
        {
            if (DataGridPropietarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un propietario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow filaSeleccionada = DataGridPropietarios.SelectedRows[0];
            DTO.Propietario propietarioAEliminar = filaSeleccionada.DataBoundItem as DTO.Propietario;

            if (propietarioAEliminar == null || string.IsNullOrEmpty(propietarioAEliminar.Id))
            {
                MessageBox.Show("No se pudo obtener la información completa del propietario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el propietario {propietarioAEliminar.Nombre} {propietarioAEliminar.Apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                bool exito = await ApiRest.EliminarPropietarioAsync(propietarioAEliminar.Id);

                if (exito)
                {
                    MessageBox.Show("Propietario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // REFRESH: actualizar grilla y ComboBox después de eliminar
                    await CargarDatosPropietariosEnGrilla();
                    await CargarPropietariosEnComboBox();
                }
                else
                {
                    MessageBox.Show("❌ La eliminación falló. Por favor, revise los mensajes de error anteriores para ver el detalle.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

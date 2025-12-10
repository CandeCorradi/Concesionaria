namespace Concesionaria
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            BtnBuscar = new Button();
            txtBusqueda = new TextBox();
            label3 = new Label();
            BtnAgregar = new Button();
            BtnModificar = new Button();
            BtnEliminar = new Button();
            BtnSalir = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            TabControlAutos = new TabControl();
            TabListado = new TabPage();
            DataGridAutos = new DataGridView();
            TabEditar = new TabPage();
            label14 = new Label();
            CmbPropietario = new ComboBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtPrecio = new TextBox();
            txtPotencia = new TextBox();
            txtAnio = new TextBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            TabPropietario = new TabPage();
            DataGridPropietarios = new DataGridView();
            BtnCancelarPropietario = new Button();
            BtnGuardarPropietario = new Button();
            TxtTelefono = new TextBox();
            TxtDNI = new TextBox();
            TxtApellido = new TextBox();
            TxtNombre = new TextBox();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            TabControlAutos.SuspendLayout();
            TabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridAutos).BeginInit();
            TabEditar.SuspendLayout();
            TabPropietario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridPropietarios).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(209, 9);
            label1.Name = "label1";
            label1.Size = new Size(283, 80);
            label1.TabIndex = 2;
            label1.Text = "Conautos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(340, 81);
            label2.Name = "label2";
            label2.Size = new Size(126, 23);
            label2.TabIndex = 3;
            label2.Text = "Concesionaria";
            // 
            // BtnBuscar
            // 
            BtnBuscar.BackColor = SystemColors.ActiveBorder;
            BtnBuscar.Location = new Point(569, 154);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 4;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = SystemColors.MenuBar;
            txtBusqueda.ForeColor = SystemColors.Desktop;
            txtBusqueda.Location = new Point(243, 154);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(315, 23);
            txtBusqueda.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(176, 158);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 6;
            label3.Text = "Consultar:";
            // 
            // BtnAgregar
            // 
            BtnAgregar.BackColor = SystemColors.ActiveBorder;
            BtnAgregar.Location = new Point(569, 208);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(75, 23);
            BtnAgregar.TabIndex = 8;
            BtnAgregar.Text = "&Agregar";
            BtnAgregar.UseVisualStyleBackColor = false;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // BtnModificar
            // 
            BtnModificar.BackColor = SystemColors.ActiveBorder;
            BtnModificar.Location = new Point(569, 249);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(75, 23);
            BtnModificar.TabIndex = 9;
            BtnModificar.Text = "&Modificar";
            BtnModificar.UseVisualStyleBackColor = false;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.BackColor = SystemColors.ActiveBorder;
            BtnEliminar.Location = new Point(569, 291);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(75, 23);
            BtnEliminar.TabIndex = 10;
            BtnEliminar.Text = "&Eliminar";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.BackColor = SystemColors.ActiveBorder;
            BtnSalir.Location = new Point(570, 467);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(75, 23);
            BtnSalir.TabIndex = 11;
            BtnSalir.Text = "&Salir";
            BtnSalir.UseVisualStyleBackColor = false;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(537, 25);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 12;
            label4.Text = "Todos los modelos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(548, 43);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 13;
            label5.Text = "nuevos y usados";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(564, 81);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 14;
            label6.Text = "3498 - 486523";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(544, 63);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 15;
            label7.Text = "Ruta N°11 km230";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(520, 98);
            label8.Name = "label8";
            label8.Size = new Size(124, 15);
            label8.TabIndex = 16;
            label8.Text = "conautos@gmail.com";
            // 
            // TabControlAutos
            // 
            TabControlAutos.Controls.Add(TabListado);
            TabControlAutos.Controls.Add(TabEditar);
            TabControlAutos.Controls.Add(TabPropietario);
            TabControlAutos.Location = new Point(12, 183);
            TabControlAutos.Name = "TabControlAutos";
            TabControlAutos.SelectedIndex = 0;
            TabControlAutos.Size = new Size(551, 307);
            TabControlAutos.TabIndex = 17;
            // 
            // TabListado
            // 
            TabListado.Controls.Add(DataGridAutos);
            TabListado.Location = new Point(4, 24);
            TabListado.Name = "TabListado";
            TabListado.Padding = new Padding(3);
            TabListado.Size = new Size(543, 279);
            TabListado.TabIndex = 0;
            TabListado.Text = "Listado";
            TabListado.UseVisualStyleBackColor = true;
            // 
            // DataGridAutos
            // 
            DataGridAutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridAutos.Location = new Point(0, 0);
            DataGridAutos.Name = "DataGridAutos";
            DataGridAutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridAutos.Size = new Size(543, 279);
            DataGridAutos.TabIndex = 8;
            // 
            // TabEditar
            // 
            TabEditar.Controls.Add(label14);
            TabEditar.Controls.Add(CmbPropietario);
            TabEditar.Controls.Add(btnCancelar);
            TabEditar.Controls.Add(btnGuardar);
            TabEditar.Controls.Add(txtPrecio);
            TabEditar.Controls.Add(txtPotencia);
            TabEditar.Controls.Add(txtAnio);
            TabEditar.Controls.Add(txtModelo);
            TabEditar.Controls.Add(txtMarca);
            TabEditar.Controls.Add(label13);
            TabEditar.Controls.Add(label12);
            TabEditar.Controls.Add(label11);
            TabEditar.Controls.Add(label10);
            TabEditar.Controls.Add(label9);
            TabEditar.Location = new Point(4, 24);
            TabEditar.Name = "TabEditar";
            TabEditar.Padding = new Padding(3);
            TabEditar.Size = new Size(543, 279);
            TabEditar.TabIndex = 1;
            TabEditar.Text = "Edición";
            TabEditar.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(62, 185);
            label14.Name = "label14";
            label14.Size = new Size(68, 15);
            label14.TabIndex = 13;
            label14.Text = "Propietario:";
            // 
            // CmbPropietario
            // 
            CmbPropietario.FormattingEnabled = true;
            CmbPropietario.Location = new Point(133, 180);
            CmbPropietario.Name = "CmbPropietario";
            CmbPropietario.Size = new Size(300, 23);
            CmbPropietario.TabIndex = 12;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(358, 241);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(134, 241);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(133, 151);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(300, 23);
            txtPrecio.TabIndex = 9;
            // 
            // txtPotencia
            // 
            txtPotencia.Location = new Point(133, 122);
            txtPotencia.Name = "txtPotencia";
            txtPotencia.Size = new Size(300, 23);
            txtPotencia.TabIndex = 8;
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(133, 93);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(300, 23);
            txtAnio.TabIndex = 7;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(133, 64);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(300, 23);
            txtModelo.TabIndex = 6;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(133, 35);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(300, 23);
            txtMarca.TabIndex = 5;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(87, 154);
            label13.Name = "label13";
            label13.Size = new Size(43, 15);
            label13.TabIndex = 4;
            label13.Text = "Precio:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(74, 125);
            label12.Name = "label12";
            label12.Size = new Size(56, 15);
            label12.TabIndex = 3;
            label12.Text = "Potencia:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(98, 96);
            label11.Name = "label11";
            label11.Size = new Size(32, 15);
            label11.TabIndex = 2;
            label11.Text = "Año:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(79, 67);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 1;
            label10.Text = "Modelo:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(87, 38);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 0;
            label9.Text = "Marca:";
            // 
            // TabPropietario
            // 
            TabPropietario.Controls.Add(DataGridPropietarios);
            TabPropietario.Controls.Add(BtnCancelarPropietario);
            TabPropietario.Controls.Add(BtnGuardarPropietario);
            TabPropietario.Controls.Add(TxtTelefono);
            TabPropietario.Controls.Add(TxtDNI);
            TabPropietario.Controls.Add(TxtApellido);
            TabPropietario.Controls.Add(TxtNombre);
            TabPropietario.Controls.Add(label15);
            TabPropietario.Controls.Add(label16);
            TabPropietario.Controls.Add(label17);
            TabPropietario.Controls.Add(label18);
            TabPropietario.Location = new Point(4, 24);
            TabPropietario.Name = "TabPropietario";
            TabPropietario.Size = new Size(543, 279);
            TabPropietario.TabIndex = 2;
            TabPropietario.Text = "Propietario";
            TabPropietario.UseVisualStyleBackColor = true;
            // 
            // DataGridPropietarios
            // 
            DataGridPropietarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridPropietarios.Location = new Point(3, 4);
            DataGridPropietarios.Name = "DataGridPropietarios";
            DataGridPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridPropietarios.Size = new Size(537, 172);
            DataGridPropietarios.TabIndex = 19;
            DataGridPropietarios.CellContentClick += DataGridPropietarios_CellContentClick;
            // 
            // BtnCancelarPropietario
            // 
            BtnCancelarPropietario.Location = new Point(357, 240);
            BtnCancelarPropietario.Name = "BtnCancelarPropietario";
            BtnCancelarPropietario.Size = new Size(75, 23);
            BtnCancelarPropietario.TabIndex = 18;
            BtnCancelarPropietario.Text = "Cancelar";
            BtnCancelarPropietario.UseVisualStyleBackColor = true;
            BtnCancelarPropietario.Click += BtnCancelarPropietario_Click;
            // 
            // BtnGuardarPropietario
            // 
            BtnGuardarPropietario.Location = new Point(133, 240);
            BtnGuardarPropietario.Name = "BtnGuardarPropietario";
            BtnGuardarPropietario.Size = new Size(75, 23);
            BtnGuardarPropietario.TabIndex = 17;
            BtnGuardarPropietario.Text = "Guardar";
            BtnGuardarPropietario.UseVisualStyleBackColor = true;
            BtnGuardarPropietario.Click += BtnGuardarPropietario_Click;
            // 
            // TxtTelefono
            // 
            TxtTelefono.Location = new Point(357, 211);
            TxtTelefono.Name = "TxtTelefono";
            TxtTelefono.Size = new Size(162, 23);
            TxtTelefono.TabIndex = 16;
            // 
            // TxtDNI
            // 
            TxtDNI.Location = new Point(86, 211);
            TxtDNI.Name = "TxtDNI";
            TxtDNI.Size = new Size(162, 23);
            TxtDNI.TabIndex = 15;
            // 
            // TxtApellido
            // 
            TxtApellido.Location = new Point(357, 182);
            TxtApellido.Name = "TxtApellido";
            TxtApellido.Size = new Size(162, 23);
            TxtApellido.TabIndex = 14;
            // 
            // TxtNombre
            // 
            TxtNombre.Location = new Point(86, 183);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(162, 23);
            TxtNombre.TabIndex = 13;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(300, 215);
            label15.Name = "label15";
            label15.Size = new Size(55, 15);
            label15.TabIndex = 12;
            label15.Text = "Teléfono:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(54, 215);
            label16.Name = "label16";
            label16.Size = new Size(30, 15);
            label16.TabIndex = 11;
            label16.Text = "DNI:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(301, 186);
            label17.Name = "label17";
            label17.Size = new Size(54, 15);
            label17.TabIndex = 10;
            label17.Text = "Apellido:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(30, 187);
            label18.Name = "label18";
            label18.Size = new Size(54, 15);
            label18.TabIndex = 9;
            label18.Text = "Nombre:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(654, 502);
            Controls.Add(TabControlAutos);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(BtnSalir);
            Controls.Add(BtnEliminar);
            Controls.Add(BtnModificar);
            Controls.Add(BtnAgregar);
            Controls.Add(label3);
            Controls.Add(txtBusqueda);
            Controls.Add(BtnBuscar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Conautos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            TabControlAutos.ResumeLayout(false);
            TabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridAutos).EndInit();
            TabEditar.ResumeLayout(false);
            TabEditar.PerformLayout();
            TabPropietario.ResumeLayout(false);
            TabPropietario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridPropietarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button BtnBuscar;
        private TextBox txtBusqueda;
        private Label label3;
        private Button BtnAgregar;
        private Button BtnModificar;
        private Button BtnEliminar;
        private Button BtnSalir;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TabControl TabControlAutos;
        private TabPage TabListado;
        private TabPage TabEditar;
        private DataGridView DataGridAutos;
        private Button btnCancelar;
        private Button btnGuardar;
        private TextBox txtPrecio;
        private TextBox txtPotencia;
        private TextBox txtAnio;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TabPage TabPropietario;
        private Label label14;
        private ComboBox CmbPropietario;
        private Button BtnCancelarPropietario;
        private Button BtnGuardarPropietario;
        private TextBox TxtTelefono;
        private TextBox TxtDNI;
        private TextBox TxtApellido;
        private TextBox TxtNombre;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private DataGridView DataGridPropietarios;
    }
}

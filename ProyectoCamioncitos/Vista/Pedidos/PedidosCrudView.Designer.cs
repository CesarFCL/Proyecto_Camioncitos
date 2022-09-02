namespace ProyectoCamioncitos.Vista.FacturasEnvios
{
    partial class PedidosCrudView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarFacturas = new System.Windows.Forms.TextBox();
            this.tblPedidos = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.txtDireccionDestinatario = new System.Windows.Forms.TextBox();
            this.lblDireccionDestinatario = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtRucCliente = new System.Windows.Forms.TextBox();
            this.txtDetallesEnvio = new System.Windows.Forms.TextBox();
            this.cboxIntraprovincial = new System.Windows.Forms.ComboBox();
            this.lblEnvioIntraprovincial = new System.Windows.Forms.Label();
            this.lblEstadoEnvio = new System.Windows.Forms.Label();
            this.txtTelefonoDestinatario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCiDestinatario = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboxEstadoEnvio = new System.Windows.Forms.ComboBox();
            this.dtpFechaFinalizacionEnvio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinalizacionEnvio = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RucCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFinalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoCamioncitos.Properties.Resources.search2;
            this.pictureBox1.Location = new System.Drawing.Point(1023, 302);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(486, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 32);
            this.label1.TabIndex = 33;
            this.label1.Text = "PEDIDOS";
            // 
            // txtBuscarFacturas
            // 
            this.txtBuscarFacturas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarFacturas.Location = new System.Drawing.Point(877, 303);
            this.txtBuscarFacturas.Name = "txtBuscarFacturas";
            this.txtBuscarFacturas.Size = new System.Drawing.Size(140, 23);
            this.txtBuscarFacturas.TabIndex = 32;
            // 
            // tblPedidos
            // 
            this.tblPedidos.AllowUserToAddRows = false;
            this.tblPedidos.AllowUserToDeleteRows = false;
            this.tblPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FechaFactura,
            this.RucCliente,
            this.Costo,
            this.CIDestinatario,
            this.Estado,
            this.FechaFinalizacion});
            this.tblPedidos.Location = new System.Drawing.Point(12, 331);
            this.tblPedidos.MultiSelect = false;
            this.tblPedidos.Name = "tblPedidos";
            this.tblPedidos.ReadOnly = true;
            this.tblPedidos.Size = new System.Drawing.Size(1032, 230);
            this.tblPedidos.TabIndex = 31;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(684, 271);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(137, 36);
            this.btnLimpiar.TabIndex = 55;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(245, 269);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(137, 38);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(464, 271);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(137, 36);
            this.btnEliminar.TabIndex = 53;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(32, 269);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(137, 38);
            this.btnGuardar.TabIndex = 52;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaFactura.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFactura.Location = new System.Drawing.Point(181, 105);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(119, 23);
            this.dtpFechaFactura.TabIndex = 56;
            this.dtpFechaFactura.Value = new System.DateTime(2022, 7, 10, 0, 0, 0, 0);
            // 
            // txtDireccionDestinatario
            // 
            this.txtDireccionDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionDestinatario.Location = new System.Drawing.Point(520, 165);
            this.txtDireccionDestinatario.Name = "txtDireccionDestinatario";
            this.txtDireccionDestinatario.Size = new System.Drawing.Size(497, 23);
            this.txtDireccionDestinatario.TabIndex = 51;
            // 
            // lblDireccionDestinatario
            // 
            this.lblDireccionDestinatario.AutoSize = true;
            this.lblDireccionDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionDestinatario.Location = new System.Drawing.Point(339, 167);
            this.lblDireccionDestinatario.Name = "lblDireccionDestinatario";
            this.lblDireccionDestinatario.Size = new System.Drawing.Size(176, 16);
            this.lblDireccionDestinatario.TabIndex = 50;
            this.lblDireccionDestinatario.Text = "DIRECCION DESTINATARIO";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(118, 225);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(182, 23);
            this.txtCosto.TabIndex = 49;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(29, 229);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(73, 16);
            this.lblCosto.TabIndex = 47;
            this.lblCosto.Text = "COSTO ($)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "FECHA FACTURA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(339, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 32);
            this.label5.TabIndex = 44;
            this.label5.Text = "DETALLES\r\nDEL ENVIO\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "RUC CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "PESO (kg)";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(29, 79);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(20, 16);
            this.lblID.TabIndex = 41;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(118, 76);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(182, 23);
            this.txtID.TabIndex = 37;
            // 
            // txtPeso
            // 
            this.txtPeso.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeso.Location = new System.Drawing.Point(118, 193);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(182, 23);
            this.txtPeso.TabIndex = 38;
            // 
            // txtRucCliente
            // 
            this.txtRucCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucCliente.Location = new System.Drawing.Point(118, 134);
            this.txtRucCliente.Name = "txtRucCliente";
            this.txtRucCliente.Size = new System.Drawing.Size(182, 23);
            this.txtRucCliente.TabIndex = 39;
            // 
            // txtDetallesEnvio
            // 
            this.txtDetallesEnvio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetallesEnvio.Location = new System.Drawing.Point(419, 194);
            this.txtDetallesEnvio.Multiline = true;
            this.txtDetallesEnvio.Name = "txtDetallesEnvio";
            this.txtDetallesEnvio.Size = new System.Drawing.Size(598, 54);
            this.txtDetallesEnvio.TabIndex = 40;
            // 
            // cboxIntraprovincial
            // 
            this.cboxIntraprovincial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIntraprovincial.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIntraprovincial.FormattingEnabled = true;
            this.cboxIntraprovincial.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cboxIntraprovincial.Location = new System.Drawing.Point(204, 163);
            this.cboxIntraprovincial.Name = "cboxIntraprovincial";
            this.cboxIntraprovincial.Size = new System.Drawing.Size(96, 24);
            this.cboxIntraprovincial.TabIndex = 58;
            // 
            // lblEnvioIntraprovincial
            // 
            this.lblEnvioIntraprovincial.AutoSize = true;
            this.lblEnvioIntraprovincial.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvioIntraprovincial.Location = new System.Drawing.Point(29, 167);
            this.lblEnvioIntraprovincial.Name = "lblEnvioIntraprovincial";
            this.lblEnvioIntraprovincial.Size = new System.Drawing.Size(169, 16);
            this.lblEnvioIntraprovincial.TabIndex = 57;
            this.lblEnvioIntraprovincial.Text = "ENVIO INTRAPROVINCIAL";
            // 
            // lblEstadoEnvio
            // 
            this.lblEstadoEnvio.AutoSize = true;
            this.lblEstadoEnvio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoEnvio.Location = new System.Drawing.Point(715, 108);
            this.lblEstadoEnvio.Name = "lblEstadoEnvio";
            this.lblEstadoEnvio.Size = new System.Drawing.Size(102, 16);
            this.lblEstadoEnvio.TabIndex = 59;
            this.lblEstadoEnvio.Text = "ESTADO ENVIO";
            // 
            // txtTelefonoDestinatario
            // 
            this.txtTelefonoDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoDestinatario.Location = new System.Drawing.Point(520, 134);
            this.txtTelefonoDestinatario.Name = "txtTelefonoDestinatario";
            this.txtTelefonoDestinatario.Size = new System.Drawing.Size(168, 23);
            this.txtTelefonoDestinatario.TabIndex = 62;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(339, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 16);
            this.label9.TabIndex = 61;
            this.label9.Text = "TELEFONO DESTINATARIO";
            // 
            // txtCiDestinatario
            // 
            this.txtCiDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiDestinatario.Location = new System.Drawing.Point(520, 105);
            this.txtCiDestinatario.Name = "txtCiDestinatario";
            this.txtCiDestinatario.Size = new System.Drawing.Size(168, 23);
            this.txtCiDestinatario.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(339, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.label10.TabIndex = 63;
            this.label10.Text = "CI DESTINATARIO";
            // 
            // cboxEstadoEnvio
            // 
            this.cboxEstadoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEstadoEnvio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEstadoEnvio.FormattingEnabled = true;
            this.cboxEstadoEnvio.Items.AddRange(new object[] {
            "Finalizado",
            "Pendiente"});
            this.cboxEstadoEnvio.Location = new System.Drawing.Point(838, 103);
            this.cboxEstadoEnvio.Name = "cboxEstadoEnvio";
            this.cboxEstadoEnvio.Size = new System.Drawing.Size(179, 24);
            this.cboxEstadoEnvio.TabIndex = 65;
            // 
            // dtpFechaFinalizacionEnvio
            // 
            this.dtpFechaFinalizacionEnvio.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaFinalizacionEnvio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinalizacionEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinalizacionEnvio.Location = new System.Drawing.Point(909, 134);
            this.dtpFechaFinalizacionEnvio.Name = "dtpFechaFinalizacionEnvio";
            this.dtpFechaFinalizacionEnvio.Size = new System.Drawing.Size(108, 23);
            this.dtpFechaFinalizacionEnvio.TabIndex = 67;
            this.dtpFechaFinalizacionEnvio.Value = new System.DateTime(2022, 7, 10, 0, 0, 0, 0);
            // 
            // lblFechaFinalizacionEnvio
            // 
            this.lblFechaFinalizacionEnvio.AutoSize = true;
            this.lblFechaFinalizacionEnvio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinalizacionEnvio.Location = new System.Drawing.Point(715, 137);
            this.lblFechaFinalizacionEnvio.Name = "lblFechaFinalizacionEnvio";
            this.lblFechaFinalizacionEnvio.Size = new System.Drawing.Size(190, 16);
            this.lblFechaFinalizacionEnvio.TabIndex = 66;
            this.lblFechaFinalizacionEnvio.Text = "FECHA FINALIZACION ENVIO";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 110;
            // 
            // FechaFactura
            // 
            this.FechaFactura.HeaderText = "Fecha Factura";
            this.FechaFactura.Name = "FechaFactura";
            this.FechaFactura.ReadOnly = true;
            this.FechaFactura.Width = 175;
            // 
            // RucCliente
            // 
            this.RucCliente.HeaderText = "RUC Cliente";
            this.RucCliente.Name = "RucCliente";
            this.RucCliente.ReadOnly = true;
            this.RucCliente.Width = 125;
            // 
            // Costo
            // 
            this.Costo.HeaderText = "Costo ($)";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 125;
            // 
            // CIDestinatario
            // 
            this.CIDestinatario.HeaderText = "CI Destinatario";
            this.CIDestinatario.Name = "CIDestinatario";
            this.CIDestinatario.ReadOnly = true;
            this.CIDestinatario.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado de Envio";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 150;
            // 
            // FechaFinalizacion
            // 
            this.FechaFinalizacion.HeaderText = "Fecha Finalizacion Envio";
            this.FechaFinalizacion.Name = "FechaFinalizacion";
            this.FechaFinalizacion.ReadOnly = true;
            this.FechaFinalizacion.Width = 175;
            // 
            // PedidosCrudView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 573);
            this.Controls.Add(this.dtpFechaFinalizacionEnvio);
            this.Controls.Add(this.lblFechaFinalizacionEnvio);
            this.Controls.Add(this.cboxEstadoEnvio);
            this.Controls.Add(this.txtCiDestinatario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTelefonoDestinatario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblEstadoEnvio);
            this.Controls.Add(this.cboxIntraprovincial);
            this.Controls.Add(this.lblEnvioIntraprovincial);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpFechaFactura);
            this.Controls.Add(this.txtDireccionDestinatario);
            this.Controls.Add(this.lblDireccionDestinatario);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtRucCliente);
            this.Controls.Add(this.txtDetallesEnvio);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarFacturas);
            this.Controls.Add(this.tblPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PedidosCrudView";
            this.Text = "FacturasEnviosCrudView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBuscarFacturas;
        public System.Windows.Forms.DataGridView tblPedidos;
        public System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.DateTimePicker dtpFechaFactura;
        public System.Windows.Forms.TextBox txtDireccionDestinatario;
        public System.Windows.Forms.Label lblDireccionDestinatario;
        public System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtPeso;
        public System.Windows.Forms.TextBox txtRucCliente;
        public System.Windows.Forms.TextBox txtDetallesEnvio;
        public System.Windows.Forms.ComboBox cboxIntraprovincial;
        public System.Windows.Forms.Label lblEnvioIntraprovincial;
        public System.Windows.Forms.Label lblEstadoEnvio;
        public System.Windows.Forms.TextBox txtTelefonoDestinatario;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtCiDestinatario;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cboxEstadoEnvio;
        public System.Windows.Forms.DateTimePicker dtpFechaFinalizacionEnvio;
        public System.Windows.Forms.Label lblFechaFinalizacionEnvio;
        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn RucCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFinalizacion;
    }
}
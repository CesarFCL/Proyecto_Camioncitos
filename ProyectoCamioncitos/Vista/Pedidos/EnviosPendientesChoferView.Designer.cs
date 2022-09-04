namespace ProyectoCamioncitos.Vista.Pedidos
{
    partial class EnviosPendientesChoferView
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
            this.btnFinalizarEnvio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarFacturas = new System.Windows.Forms.TextBox();
            this.tblEnvios = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RucCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFinalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtRucCliente = new System.Windows.Forms.TextBox();
            this.txtDireccionCliente = new System.Windows.Forms.TextBox();
            this.gbClienteDatos = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefonoDestinatario = new System.Windows.Forms.TextBox();
            this.txtDireccionDestinatario = new System.Windows.Forms.TextBox();
            this.txtCiDestinatario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxMatricula = new System.Windows.Forms.GroupBox();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblEnvios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbClienteDatos.SuspendLayout();
            this.gboxMatricula.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinalizarEnvio
            // 
            this.btnFinalizarEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnFinalizarEnvio.FlatAppearance.BorderSize = 0;
            this.btnFinalizarEnvio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.btnFinalizarEnvio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnFinalizarEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarEnvio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarEnvio.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarEnvio.Location = new System.Drawing.Point(19, 321);
            this.btnFinalizarEnvio.Name = "btnFinalizarEnvio";
            this.btnFinalizarEnvio.Size = new System.Drawing.Size(224, 38);
            this.btnFinalizarEnvio.TabIndex = 57;
            this.btnFinalizarEnvio.Text = "FINALIZAR ENVIO";
            this.btnFinalizarEnvio.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 32);
            this.label1.TabIndex = 55;
            this.label1.Text = "ENVIOS PENDIENTES";
            // 
            // txtBuscarFacturas
            // 
            this.txtBuscarFacturas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarFacturas.Location = new System.Drawing.Point(12, 88);
            this.txtBuscarFacturas.Name = "txtBuscarFacturas";
            this.txtBuscarFacturas.Size = new System.Drawing.Size(140, 23);
            this.txtBuscarFacturas.TabIndex = 54;
            // 
            // tblEnvios
            // 
            this.tblEnvios.AllowUserToAddRows = false;
            this.tblEnvios.AllowUserToDeleteRows = false;
            this.tblEnvios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblEnvios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEnvios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEnvios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FechaFactura,
            this.RucCliente,
            this.Estado,
            this.CIDestinatario,
            this.FechaFinalizacion});
            this.tblEnvios.Location = new System.Drawing.Point(12, 117);
            this.tblEnvios.MultiSelect = false;
            this.tblEnvios.Name = "tblEnvios";
            this.tblEnvios.ReadOnly = true;
            this.tblEnvios.Size = new System.Drawing.Size(655, 444);
            this.tblEnvios.TabIndex = 53;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // FechaFactura
            // 
            this.FechaFactura.HeaderText = "Fecha Factura";
            this.FechaFactura.Name = "FechaFactura";
            this.FechaFactura.ReadOnly = true;
            // 
            // RucCliente
            // 
            this.RucCliente.HeaderText = "RUC Cliente";
            this.RucCliente.Name = "RucCliente";
            this.RucCliente.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Telefono Cliente";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // CIDestinatario
            // 
            this.CIDestinatario.HeaderText = "CI Destinatario";
            this.CIDestinatario.Name = "CIDestinatario";
            this.CIDestinatario.ReadOnly = true;
            // 
            // FechaFinalizacion
            // 
            this.FechaFinalizacion.HeaderText = "Telefono Destinatario";
            this.FechaFinalizacion.Name = "FechaFinalizacion";
            this.FechaFinalizacion.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoCamioncitos.Properties.Resources.search2;
            this.pictureBox1.Location = new System.Drawing.Point(158, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoCliente.Location = new System.Drawing.Point(189, 86);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.ReadOnly = true;
            this.txtTelefonoCliente.Size = new System.Drawing.Size(174, 23);
            this.txtTelefonoCliente.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 69;
            this.label4.Text = "RUC CLIENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "ID ENVIO";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(189, 28);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(174, 23);
            this.txtID.TabIndex = 65;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRucCliente
            // 
            this.txtRucCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucCliente.Location = new System.Drawing.Point(189, 57);
            this.txtRucCliente.Name = "txtRucCliente";
            this.txtRucCliente.ReadOnly = true;
            this.txtRucCliente.Size = new System.Drawing.Size(174, 23);
            this.txtRucCliente.TabIndex = 66;
            // 
            // txtDireccionCliente
            // 
            this.txtDireccionCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionCliente.Location = new System.Drawing.Point(19, 141);
            this.txtDireccionCliente.Multiline = true;
            this.txtDireccionCliente.Name = "txtDireccionCliente";
            this.txtDireccionCliente.ReadOnly = true;
            this.txtDireccionCliente.Size = new System.Drawing.Size(344, 40);
            this.txtDireccionCliente.TabIndex = 67;
            // 
            // gbClienteDatos
            // 
            this.gbClienteDatos.Controls.Add(this.btnLimpiar);
            this.gbClienteDatos.Controls.Add(this.label6);
            this.gbClienteDatos.Controls.Add(this.label7);
            this.gbClienteDatos.Controls.Add(this.txtTelefonoDestinatario);
            this.gbClienteDatos.Controls.Add(this.txtDireccionDestinatario);
            this.gbClienteDatos.Controls.Add(this.txtCiDestinatario);
            this.gbClienteDatos.Controls.Add(this.label8);
            this.gbClienteDatos.Controls.Add(this.label5);
            this.gbClienteDatos.Controls.Add(this.label3);
            this.gbClienteDatos.Controls.Add(this.txtID);
            this.gbClienteDatos.Controls.Add(this.btnFinalizarEnvio);
            this.gbClienteDatos.Controls.Add(this.txtTelefonoCliente);
            this.gbClienteDatos.Controls.Add(this.txtDireccionCliente);
            this.gbClienteDatos.Controls.Add(this.txtRucCliente);
            this.gbClienteDatos.Controls.Add(this.label2);
            this.gbClienteDatos.Controls.Add(this.label4);
            this.gbClienteDatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbClienteDatos.Location = new System.Drawing.Point(675, 192);
            this.gbClienteDatos.Name = "gbClienteDatos";
            this.gbClienteDatos.Size = new System.Drawing.Size(369, 369);
            this.gbClienteDatos.TabIndex = 77;
            this.gbClienteDatos.TabStop = false;
            this.gbClienteDatos.Text = "Datos Envio";
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
            this.btnLimpiar.Location = new System.Drawing.Point(264, 321);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 38);
            this.btnLimpiar.TabIndex = 85;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 16);
            this.label6.TabIndex = 84;
            this.label6.Text = "DIRECCION DESTINATARIO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 16);
            this.label7.TabIndex = 83;
            this.label7.Text = "TELEFONO DESTINATARIO";
            // 
            // txtTelefonoDestinatario
            // 
            this.txtTelefonoDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoDestinatario.Location = new System.Drawing.Point(189, 219);
            this.txtTelefonoDestinatario.Name = "txtTelefonoDestinatario";
            this.txtTelefonoDestinatario.ReadOnly = true;
            this.txtTelefonoDestinatario.Size = new System.Drawing.Size(174, 23);
            this.txtTelefonoDestinatario.TabIndex = 82;
            // 
            // txtDireccionDestinatario
            // 
            this.txtDireccionDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionDestinatario.Location = new System.Drawing.Point(19, 276);
            this.txtDireccionDestinatario.Multiline = true;
            this.txtDireccionDestinatario.Name = "txtDireccionDestinatario";
            this.txtDireccionDestinatario.ReadOnly = true;
            this.txtDireccionDestinatario.Size = new System.Drawing.Size(344, 39);
            this.txtDireccionDestinatario.TabIndex = 80;
            // 
            // txtCiDestinatario
            // 
            this.txtCiDestinatario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiDestinatario.Location = new System.Drawing.Point(189, 190);
            this.txtCiDestinatario.Name = "txtCiDestinatario";
            this.txtCiDestinatario.ReadOnly = true;
            this.txtCiDestinatario.Size = new System.Drawing.Size(174, 23);
            this.txtCiDestinatario.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 81;
            this.label8.Text = "CI DESTINATARIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "DIRECCION CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "TELEFONO CLIENTE";
            // 
            // gboxMatricula
            // 
            this.gboxMatricula.Controls.Add(this.btnLiberar);
            this.gboxMatricula.Controls.Add(this.txtMatricula);
            this.gboxMatricula.Controls.Add(this.label9);
            this.gboxMatricula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxMatricula.Location = new System.Drawing.Point(675, 117);
            this.gboxMatricula.Name = "gboxMatricula";
            this.gboxMatricula.Size = new System.Drawing.Size(369, 69);
            this.gboxMatricula.TabIndex = 78;
            this.gboxMatricula.TabStop = false;
            this.gboxMatricula.Text = "Vehiculo Asignado";
            // 
            // btnLiberar
            // 
            this.btnLiberar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnLiberar.FlatAppearance.BorderSize = 0;
            this.btnLiberar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.btnLiberar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiberar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberar.ForeColor = System.Drawing.Color.White;
            this.btnLiberar.Location = new System.Drawing.Point(219, 21);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(141, 38);
            this.btnLiberar.TabIndex = 71;
            this.btnLiberar.Text = "LIBERAR";
            this.btnLiberar.UseVisualStyleBackColor = false;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(86, 32);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.ReadOnly = true;
            this.txtMatricula.Size = new System.Drawing.Size(125, 23);
            this.txtMatricula.TabIndex = 69;
            this.txtMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 70;
            this.label9.Text = "Matrícula";
            // 
            // EnviosPendientesChoferView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 573);
            this.Controls.Add(this.gboxMatricula);
            this.Controls.Add(this.gbClienteDatos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarFacturas);
            this.Controls.Add(this.tblEnvios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnviosPendientesChoferView";
            this.Text = "EnviosPendientesChoferView";
            ((System.ComponentModel.ISupportInitialize)(this.tblEnvios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbClienteDatos.ResumeLayout(false);
            this.gbClienteDatos.PerformLayout();
            this.gboxMatricula.ResumeLayout(false);
            this.gboxMatricula.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnFinalizarEnvio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBuscarFacturas;
        public System.Windows.Forms.DataGridView tblEnvios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn RucCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFinalizacion;
        public System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtRucCliente;
        public System.Windows.Forms.TextBox txtDireccionCliente;
        private System.Windows.Forms.GroupBox gbClienteDatos;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtTelefonoDestinatario;
        public System.Windows.Forms.TextBox txtDireccionDestinatario;
        public System.Windows.Forms.TextBox txtCiDestinatario;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtMatricula;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnLiberar;
        public System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.GroupBox gboxMatricula;
    }
}
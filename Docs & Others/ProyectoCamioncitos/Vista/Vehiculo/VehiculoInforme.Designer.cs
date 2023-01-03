namespace ProyectoCamioncitos.Vista.Vehiculo
{
    partial class VehiculoInforme
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtBuscarPedidosAsignados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tblPedidosAsignados = new System.Windows.Forms.DataGridView();
            this.gbClienteDatos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPedidosAsignados)).BeginInit();
            this.gbClienteDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 19);
            this.label1.TabIndex = 66;
            this.label1.Text = "Combustible Gastado ($)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(94, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 27);
            this.textBox2.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 68;
            this.label3.Text = "Kilometraje";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(94, 178);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(161, 27);
            this.textBox3.TabIndex = 67;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ProyectoCamioncitos.Properties.Resources.search2;
            this.pictureBox3.Location = new System.Drawing.Point(940, 118);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 72;
            this.pictureBox3.TabStop = false;
            // 
            // txtBuscarPedidosAsignados
            // 
            this.txtBuscarPedidosAsignados.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarPedidosAsignados.Location = new System.Drawing.Point(818, 119);
            this.txtBuscarPedidosAsignados.Name = "txtBuscarPedidosAsignados";
            this.txtBuscarPedidosAsignados.Size = new System.Drawing.Size(104, 23);
            this.txtBuscarPedidosAsignados.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 46);
            this.label4.TabIndex = 70;
            this.label4.Text = "ENVIOS\r\nCOMPLETADOS HOY";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblPedidosAsignados
            // 
            this.tblPedidosAsignados.AllowUserToAddRows = false;
            this.tblPedidosAsignados.AllowUserToDeleteRows = false;
            this.tblPedidosAsignados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblPedidosAsignados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.tblPedidosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPedidosAsignados.Location = new System.Drawing.Point(589, 148);
            this.tblPedidosAsignados.MultiSelect = false;
            this.tblPedidosAsignados.Name = "tblPedidosAsignados";
            this.tblPedidosAsignados.ReadOnly = true;
            this.tblPedidosAsignados.Size = new System.Drawing.Size(372, 322);
            this.tblPedidosAsignados.TabIndex = 69;
            // 
            // gbClienteDatos
            // 
            this.gbClienteDatos.Controls.Add(this.button1);
            this.gbClienteDatos.Controls.Add(this.label1);
            this.gbClienteDatos.Controls.Add(this.textBox2);
            this.gbClienteDatos.Controls.Add(this.label3);
            this.gbClienteDatos.Controls.Add(this.textBox3);
            this.gbClienteDatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbClienteDatos.Location = new System.Drawing.Point(101, 148);
            this.gbClienteDatos.Name = "gbClienteDatos";
            this.gbClienteDatos.Size = new System.Drawing.Size(369, 322);
            this.gbClienteDatos.TabIndex = 73;
            this.gbClienteDatos.TabStop = false;
            this.gbClienteDatos.Text = "Gastos Diarios";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(111, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 38);
            this.button1.TabIndex = 74;
            this.button1.Text = "ENVIAR";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(409, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 32);
            this.label5.TabIndex = 75;
            this.label5.Text = "INFORME DIARIO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(88, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(398, 15);
            this.label6.TabIndex = 76;
            this.label6.Text = "*Asegurese de Enviar el informe de gastos diarios antes de finalizar el dia";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VehiculoInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 573);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbClienteDatos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtBuscarPedidosAsignados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tblPedidosAsignados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VehiculoInforme";
            this.Text = "VehiculoInforme";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPedidosAsignados)).EndInit();
            this.gbClienteDatos.ResumeLayout(false);
            this.gbClienteDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.TextBox txtBuscarPedidosAsignados;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView tblPedidosAsignados;
        private System.Windows.Forms.GroupBox gbClienteDatos;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
    }
}
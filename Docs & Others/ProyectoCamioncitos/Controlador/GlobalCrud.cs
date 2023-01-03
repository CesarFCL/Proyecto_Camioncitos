using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{

    //Clase con los métodos usados por los controladores de Cruds
    public class GlobalCrud
    {
        //Metodo Limpiar TextBoxs
        public void LimpiarTextBox(TextBox[] textboxs)
        {
            foreach (TextBox i in textboxs)
            {
                i.Text = "";
            }
        }

        //Metodo Limpiar ComboBoxs
        public void LimpiarComboBox(ComboBox[] comboboxs)
        {
            foreach (ComboBox i in comboboxs)
            {
                i.SelectedItem = null;
            }
        }

        //Metodo Habilitar Botones CRUD Fase Create
        public void BotonesFaseCreate(Button guardar, Button delete, Button edit)
        {
            guardar.Enabled = true;
            delete.Enabled = false;
            edit.Enabled = false;
        }

        //Metodo Habilitar Botones CRUD Fase Edit
        public void BotonesFaseEdit(Button guardar, Button delete, Button edit)
        {
            guardar.Enabled = false;
            delete.Enabled = true;
            edit.Enabled = true;
        }

        //Validar solo numeros
        public void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Ingrese solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        //Validar numeros decimales
        public void ValDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Solo poder poner un decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //Validar correo
        public void ValCorreoE(object sender, EventArgs e, TextBox correo)
        {
            try
            {
                if (!string.IsNullOrEmpty(correo.Text))
                {
                    new MailAddress(correo.Text);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Correo no valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Restricciones Globales
        public void NombreLimit(object sender, EventArgs e, TextBox Nombre)
        {
            Nombre.MaxLength = 50;
        }
        public void CelularLimit(object sender, EventArgs e, TextBox Celular)
        {
            Celular.MaxLength = 10;
        }
        public void CorreoLimit(object sender, EventArgs e, TextBox Correo)
        {
            Correo.MaxLength = 50;
        }
        public void DireccionLimit(object sender, EventArgs e, TextBox Direccion)
        {
            Direccion.MaxLength = 50;
        }

        //Restricciones Particulares Empleados
        public void CI_Limit(object sender, EventArgs e, TextBox CI)
        {
            CI.MaxLength = 10;
        }

        public void ApellidoLimit(object sender, EventArgs e, TextBox Apellido)
        {
            Apellido.MaxLength = 50;
        }

        public void PasswordLimit(object sender, EventArgs e, TextBox Password)
        {
            Password.MaxLength = 10;
        }

        //Restricciones Particulares Cliente
        public void RUC_Limit(object sender, EventArgs e, TextBox RUC)
        {
            RUC.MaxLength = 13;
        }

        //Restricciones Particulares Vehiculo
        public void MatriculaLimit(object sender, EventArgs e, TextBox Matricula)
        {
            Matricula.MaxLength = 10;
        }
        public void MarcaLimit(object sender, EventArgs e, TextBox Marca)
        {
            Marca.MaxLength = 20;
        }
        public void YearLimit(object sender, EventArgs e, TextBox Year)
        {
            Year.MaxLength = 5;
        }

        //Restricciones Particulares Envio
        public void PesoLimit(object sender, EventArgs e, TextBox Peso)
        {
            Peso.MaxLength = 8;
        }
    }
}

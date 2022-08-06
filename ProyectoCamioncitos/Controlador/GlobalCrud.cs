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
                return;
            }
        }

        //Validar correo
        public void ValCorreoE(object sender, EventArgs e, TextBox correo)
        {
            try
            {
                new MailAddress(correo.Text);
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
    }
}

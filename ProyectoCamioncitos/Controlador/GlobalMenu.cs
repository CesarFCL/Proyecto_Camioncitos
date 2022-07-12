using ProyectoCamioncitos.Vista;
using ProyectoCamioncitos.Vista.Conductor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    /*
     * La DVD no estoy seguro si este tipo de clases Global esta bien, pero avr en teoria si, no?
     * Son clases con los métodos generales que se usan en varios controlladores, entonces
     * para no repetir los mismos metodos en cada controlador Menu se hace una clase que los abarque (que seria esta)
     * y ya luego los controladores Menu heredan estos metodos y asi no se debe repetir estos metodos en cada
     * controlador Menu. La dvd nse, en mi cabeza suena bien y todo pero capaz y se debe hacer de otra forma xd
     */

    //Clase con los métodos usados por los controladores de menus
    public class GlobalMenu
    {
        //Metodo Cerrar Vista
        public void CerrarEvent(object sender, EventArgs e, Form vista)
        {
            LoginView VistaLogin = new LoginView();
            VistaLogin.Show();
            vista.Close();
        }

        //Método Minimizar Vista
        public void MinimizarEvent(object sender, EventArgs e, Form v)
        {
            v.WindowState = FormWindowState.Minimized;
        }

        //Método Mover Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void DragPanelEvent(object sender, MouseEventArgs e, Form v)
        {
            ReleaseCapture();
            SendMessage(v.Handle, 0x112, 0xf012, 0);
        }

        //Metodo abrir Nuevo Form en el panel del Menu
        public void AbrirForm(Form newForm, Panel p)
        {
            Form activeForm = null;
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            p.Controls.Add(newForm);
            p.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }

        //Método Cerrar Vista Abierta dentro del panel de Menu
        public void CerrarFormInternoEvent(object sender, EventArgs e, Panel p)
        {
            p.Dispose();
        }

        //Método activar color de boton
        public void ActiveColorBtn(Button button, PictureBox pic)
        {
            button.BackColor = Color.FromArgb(13, 93, 142);
            pic.BackColor = Color.FromArgb(13, 93, 142);
        }

        //Método desactivar color de boton
        public void InactiveColorBtn(Button button, PictureBox pic)
        {
            button.BackColor = Color.FromArgb(4, 41, 68);
            pic.BackColor = Color.FromArgb(4, 41, 68);
        }
    }
}

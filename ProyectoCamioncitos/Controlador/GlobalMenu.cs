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
        public void MinimizarEvent(object sender, EventArgs e, Form vista)
        {
            vista.WindowState = FormWindowState.Minimized;
        }

        //Método Mover Ventana
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void DragPanelEvent(object sender, MouseEventArgs e, Form v)
        {
            ReleaseCapture();
            SendMessage(v.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        //Metodo abrir Nuevo Form en el panel del Menu
        public void AbrirForm(Form newForm, Panel panel)
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
            panel.Controls.Add(newForm);
            panel.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }

        //Método Cerrar Vista Abierta dentro del panel de Menu
        public void CerrarFormInternoEvent(object sender, EventArgs e, Panel panel)
        {
            panel.Dispose();
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

using ProyectoCamioncitos.Vista;
using ProyectoCamioncitos.Vista.Conductor;
using System;
using System.Collections.Generic;
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
        public void Cerrar(Form v)
        {
            LoginView VistaLogin = new LoginView();
            VistaLogin.Show();
            v.Close();
        }

        //Método Minimizar Vista
        public void Minimizar(Form v)
        {
            v.WindowState = FormWindowState.Minimized;
        }

        //Método Mover Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void DragPanel(Form v)
        {
            ReleaseCapture();
            SendMessage(v.Handle, 0x112, 0xf012, 0);
        }

        //Metodo abrir form
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

        //Método Cerrar Vista Abierta dentro del panel Menu Secretaria
        public void CerrarFormInterno(Panel p)
        {
            p.Dispose();
        }
    }
}

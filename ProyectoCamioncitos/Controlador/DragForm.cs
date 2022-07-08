using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //NSE SI ESTA BIEN DECLARAR ESTA CLASE AQUI, (EN LOS CONTROLADORES), PERO COMO SE VA A
    //USAR EN LOS MENU CONTROLLERS POR AHORA ASI SE QUEDA
    //REVISAR LUEGO !!!!!!!
    public class DragForm
    {
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void DragPanel(Form form)
        {
            ReleaseCapture();
            SendMessage(form.Handle, 0x112, 0xf012, 0);
        }
    }
}

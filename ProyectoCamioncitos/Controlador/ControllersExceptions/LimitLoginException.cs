using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador.ControllersExceptions
{
    public class LimitLoginException:Exception
    {
        public LimitLoginException()
        {
            MessageBox.Show("Ha llegado al número máximo de intentos", "Limite de Intentos Excedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}

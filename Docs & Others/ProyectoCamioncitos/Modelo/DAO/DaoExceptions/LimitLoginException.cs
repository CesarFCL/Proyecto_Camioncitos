using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador.ControllersExceptions
{
    //Clase Exception lanzada al sobrepasar el limite de intentos de login permitidos
    //El resultado de esta excepción es que se cierre el programa
    public class LimitLoginException:Exception
    {
        public LimitLoginException()
        {
            MessageBox.Show("Limite de Intentos de Login Excedidos", "Limite de Intentos Excedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}

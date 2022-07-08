using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador.ControllersExceptions
{
    public class DatosIncompletosException: Exception
    {
        public DatosIncompletosException()
        {
            MessageBox.Show("Complete todos los campos !", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

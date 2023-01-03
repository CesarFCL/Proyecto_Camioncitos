using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador.ControllersExceptions
{
    //Clase Exception lanzada cuando no se han rellenado todos los textboxs.
    //El resultado de esta excepción es detener la ejecución de cualquier procedimiento antes de que se rellenen -
    // - todos los textboxs
    public class DatosIncompletosException: Exception
    {
        public DatosIncompletosException()
        {
            MessageBox.Show("Complete todos los campos !", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

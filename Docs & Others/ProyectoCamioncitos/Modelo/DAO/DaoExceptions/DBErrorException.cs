using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    //Clase Exception lanzada cuando se da algna excepción en la ejecución de un procedimiento almecenado.
    //El resultado de esta excepción es detener la ejecución del procedimiento y mostrar un mensaje avisando
    // - de que a habido algun problema o conflicto con la base de datos
    public class DBErrorException : Exception
    {
        public DBErrorException()
        {
            MessageBox.Show("Ha habido algun problema/conflicto con la base de datos!" + Environment.NewLine + 
                "Intentelo de nuevo o pongase en contacto con el DBA", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

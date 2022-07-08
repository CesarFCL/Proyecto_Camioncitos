using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    public class DBErrorException : Exception
    {
        public DBErrorException()
        {
            MessageBox.Show("Ha habido algun problema/conflicto con la base de datos!" + Environment.NewLine + 
                "Intentelo de nuevo o pongase en contacto con el DBA", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

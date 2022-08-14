using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    public class DenyChangeDisponibilidad : Exception
    {
        public DenyChangeDisponibilidad()
        {
            MessageBox.Show("Usted posee un vehiculo vinculado actualmente, " +
                "libere el vehiculo en uso para poder cambiar su estado de disponibilidad !", 
                "Error al Cambiar Disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

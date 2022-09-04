using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    //Clase Exception lanzada al momento en que un Chofer intenta cambiar su disponibilidad de "ocupado" a "disponible" -
    // - y tiene un vehiculo asignado.
    //El resultado de esta excepción es que se niegue el cambio de disponibilidad del Chofer
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

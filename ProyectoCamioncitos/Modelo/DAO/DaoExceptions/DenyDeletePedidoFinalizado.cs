using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    //Clase Exception lanzada al intentar eliminar un pedido finalizado
    //El resultado de esta excepción es que se niegue el intento de eliminacion del pedido
    public class DenyDeletePedidoFinalizado : Exception
    {
        public DenyDeletePedidoFinalizado()
        {
            MessageBox.Show("No se puede eliminar un pedido finalizado", "Error al Eliminar Pedido",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

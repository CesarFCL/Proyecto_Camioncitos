using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    //Clase Exception lanzada al intentar editar un pedido finalizado
    //El resultado de esta excepción es que se niegue el intento de edicion del pedido
    public class DenyEditPedidoFinalizado : Exception
    {
        public DenyEditPedidoFinalizado()
        {
            MessageBox.Show("No se puede editar un pedido finalizado", "Error al Editar Pedido",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

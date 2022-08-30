using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    public class DenyDeletePedidoFinalizado : Exception
    {
        public DenyDeletePedidoFinalizado()
        {
            MessageBox.Show("No se puede eliminar un pedido finalizado", "Error al Eliminar Pedido",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

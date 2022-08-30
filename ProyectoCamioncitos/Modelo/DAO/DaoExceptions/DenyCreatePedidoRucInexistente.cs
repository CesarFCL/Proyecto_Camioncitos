using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    public class DenyCreatePedidoRucInexistente : Exception
    {
        public DenyCreatePedidoRucInexistente()
        {
            MessageBox.Show("RUC  de Cliente no encontrado", "Error al Crear Pedido",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

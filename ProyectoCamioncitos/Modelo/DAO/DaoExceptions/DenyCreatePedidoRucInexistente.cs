using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    //Clase Exception lanzada al intentar crear un pedido con el RUC de un cliente no registrado en el sistema
    //El resultado de esta excepción es que se niegue el intento de creacion del pedido
    public class DenyCreatePedidoRucInexistente : Exception
    {
        public DenyCreatePedidoRucInexistente()
        {
            MessageBox.Show("RUC  de Cliente no encontrado", "Error al Crear Pedido",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

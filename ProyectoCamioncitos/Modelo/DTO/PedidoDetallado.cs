using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    public class PedidoDetallado : Pedido
    {
        //ATRIBUTOS
        private string _NombreCliente;
        private string _DireccionCliente;
        private string _TelefonoCliente;

        //Getters y Setters
        public string NombreCliente { get => _NombreCliente; set => _NombreCliente = value; }
        public string DireccionCliente { get => _DireccionCliente; set => _DireccionCliente = value; }
        public string TelefonoCliente { get => _TelefonoCliente; set => _TelefonoCliente = value; }
    }
}

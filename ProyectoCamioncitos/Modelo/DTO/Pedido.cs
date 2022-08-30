using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    public class Pedido
    {
        //ATRIBUTOS
        private int _ID;
        private DateTime _Fecha;
        private string _RucCliente;
        private string _Detalles;
        private string _Peso;
        private string _EnvioIntraprovincial;
        private float _Costo;

        //Getters y Setters
        public int ID { get => _ID; set => _ID = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string RucCliente { get => _RucCliente; set => _RucCliente = value; }
        public string Detalles { get => _Detalles; set => _Detalles = value; }
        public string Peso { get => _Peso; set => _Peso = value; }
        public string EnvioIntraprovincial { get => _EnvioIntraprovincial; set => _EnvioIntraprovincial = value; }
        public float Costo { get => _Costo; set => _Costo = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    public class Envio
    {
        //ATRIBUTOS
        private int _Id;
        private string _DireccionDestinatario;
        private string _CiDestinatario;
        private string _TelefonoDestinatario;
        private string _Estado;
        private string _FechaFinalizacion;

        //Getters y Setters
        public int Id { get => _Id; set => _Id = value; }
        public string DireccionDestinatario { get => _DireccionDestinatario; set => _DireccionDestinatario = value; }
        public string CiDestinatario { get => _CiDestinatario; set => _CiDestinatario = value; }
        public string TelefonoDestinatario { get => _TelefonoDestinatario; set => _TelefonoDestinatario = value; }
        public  string Estado { get => _Estado; set => _Estado = value; }
        public string FechaFinalizacion { get => _FechaFinalizacion; set => _FechaFinalizacion = value; }
    }
}

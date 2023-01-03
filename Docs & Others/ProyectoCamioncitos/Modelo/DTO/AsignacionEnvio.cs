using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    public class AsignacionEnvio
    {
        //ATRIBUTOS

        int _IDPedido;
        string _CIChofer;

        //Getters y Setters

        public int IDPedido { get => _IDPedido; set => _IDPedido = value; }
        public string CIChofer { get => _CIChofer; set => _CIChofer = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    public class AsignacionChoferVehiculo
    {
        //ATRIBUTOS

        string _CI;
        string _Matricula;

        //Getters y Setters

        public string CI { get => _CI; set => _CI = value; }
        public string Matricula { get => _Matricula; set => _Matricula = value; }
    }
}

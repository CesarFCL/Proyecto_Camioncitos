using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    public class Admin : Empleado
    {
        //Getters y Setters
        public new string Cargo { set => _Cargo = "Admin"; }
    }
}

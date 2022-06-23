using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DTO
{
    internal class Empleado
    {
        //ATRIBUTOS
        string _CI;
        string _Nombre;
        string _Apellido;
        string _Celular;
        int _Edad;
        string _Correo;
        string _Direccion;
        string _Contraseña;

        //Getters y Setters
        public string CI { get => _CI; set => _CI = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Celular { get => _Celular; set => _Celular = value; }
        public int Edad { get => _Edad; set => _Edad = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
    }
}

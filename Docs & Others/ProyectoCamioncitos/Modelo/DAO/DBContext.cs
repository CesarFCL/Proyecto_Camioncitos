using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Coneccion con la BD
    public class DBContext
    {
        //IMPORTANTE CAMBIAR RUTA A LA RUTA DE "TU" BASE DE DATOS

        //Ruta de conexion
        protected SqlConnection Conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Proyecto_Camioncitos;Trusted_Connection=True;");

        //Reader
        protected SqlDataReader Reader;

        //Comandos
        protected SqlCommand Comando = new SqlCommand();
    }
}

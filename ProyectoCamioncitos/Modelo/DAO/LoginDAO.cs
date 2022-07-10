using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;
using ProyectoCamioncitos.Modelo.DTO;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase Login Data Access Object
    //Aqui se ejecutan todos los procesos que involucren a la BD para el Controlador del Login
    public class LoginDAO : DBContext
    {

        //Metodo para Loguear al Empleado al Sistema
        public Empleado LoginEmpleado(string CI, string Password, int Intentos)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "LoginEmpleado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CI", CI);
            Comando.Parameters.AddWithValue("@CONTRASEÑA", Password);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            if (!Reader.Read())
            {
                throw new DenyLoginException(Intentos.ToString());
            }

            Empleado DatosEmpleadoLogueado = new Empleado()
            {
                Nombre = Reader["Nombre"].ToString(),
                Apellido = Reader["Apellido"].ToString(),
                CI = Reader["CI"].ToString(),
                Cargo = Reader["CARGO"].ToString()
            };

            Reader.Close();
            Conexion.Close();
            return DatosEmpleadoLogueado;
        }

        /*
         public Empleado ObtenerDatosEmpleado(SqlDataReader LoginResult)
        {
            Empleado EmpleadoLogueado = new Empleado();
            EmpleadoLogueado.Nombre = LoginResult["Nombre"].ToString();
            EmpleadoLogueado.Apellido = LoginResult["Apellido"].ToString();
            EmpleadoLogueado.CI = LoginResult["CI"].ToString();
            EmpleadoLogueado.Cargo = LoginResult["CARGO"].ToString();
            return EmpleadoLogueado;
        }
         */
    }
}

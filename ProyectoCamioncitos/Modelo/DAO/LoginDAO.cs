using ProyectoCamioncitos.Controlador;
using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase Login Data Access Object
    //Aqui se ejecutan todos los procesos que involucren a la BD para el Controlador del Login
    public class LoginDAO : DBContext
    {
        public SqlDataReader LoginResult;
        SqlCommand Comando = new SqlCommand();

        //Metodo para Loguear al Empleado al Sistema
        public Empleado LoginEmpleado(string CI, string Password, int Intentos)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "LoginEmpleado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CI", CI);
            Comando.Parameters.AddWithValue("@CONTRASEÑA", Password);
            Conexion.Open();
            LoginResult = Comando.ExecuteReader();

            if (!LoginResult.Read())
            {
                throw new DenyLoginException(Intentos.ToString());
            }

            Empleado DatosEmpleadoLogueado = ObtenerDatosEmpleado(LoginResult);

            LoginResult.Close();
            Conexion.Close();
            return DatosEmpleadoLogueado;
        }
        /*
         public List<string> ObtenerDatosEmpleado(SqlDataReader LoginResult)
        {
            List<string> DatosEmpleadoLogueado = new List<string>();
            DatosEmpleadoLogueado.Add(LoginResult["Nombre"].ToString());
            DatosEmpleadoLogueado.Add(LoginResult["Apellido"].ToString());
            DatosEmpleadoLogueado.Add(LoginResult["CI"].ToString());
            DatosEmpleadoLogueado.Add(LoginResult["CARGO"].ToString());
            return DatosEmpleadoLogueado;
        }
         
         */
        public Empleado ObtenerDatosEmpleado(SqlDataReader LoginResult)
        {
            Empleado EmpleadoLogueado = new Empleado();
            EmpleadoLogueado.Nombre = LoginResult["Nombre"].ToString();
            EmpleadoLogueado.Apellido = LoginResult["Apellido"].ToString();
            EmpleadoLogueado.CI = LoginResult["CI"].ToString();
            EmpleadoLogueado.Cargo = LoginResult["CARGO"].ToString();
            return EmpleadoLogueado;
        }
    }
}

using ProyectoCamioncitos.Controlador;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase Login Data Access Object
    //Aqui se ejecutan todos los procesos que involucren a la BD para el Controlador del Login
    class LoginDAO : DBContext
    {
        SqlDataReader LoginResult;
        SqlCommand Comando = new SqlCommand();

        //Metodo para Logear al Empleado al Sistema
        public List<String> LoginEmpleado(string CI, string Password)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "LoginEmpleado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CI", CI);
            Comando.Parameters.AddWithValue("@CONTRASEÑA", Password);
            Conexion.Open();
            LoginResult = Comando.ExecuteReader();
            List<string> EmpleadoR = new List<string>();

            // REVISAR ESTO !! ESTO NSE SI ESTE BIEN IMPLEMENTADO
            // PERO FUNCIONA ASI QUE POR AHORA NO TOCAR :3

            if (LoginResult.Read())
            {
                EmpleadoR.Add(LoginResult.GetString(0));
                EmpleadoR.Add(LoginResult.GetString(1));
                EmpleadoR.Add(LoginResult.GetString(2));
                EmpleadoR.Add(LoginResult.GetString(3));
                LogOpen vista0 = new LogPropietario();
                vista0.OpenView(EmpleadoR);
                LogOpen vista = new LogSecretaria();
                vista.OpenView(EmpleadoR);
                LogOpen vista2 = new LogChofer();
                vista2.OpenView(EmpleadoR);
            }
            LoginResult.Close();
            Conexion.Close();
            return EmpleadoR;
        }
    }
    //Clase Abtsracta Para los Tipos de Login
    abstract class LogOpen
    {
        public abstract void OpenView(List<string> t_empleado);
    }
    //Clase Tipo Login Secretaria
    class LogSecretaria: LogOpen
    {
        public override void OpenView(List<string> t_empleado)
        {
            if (t_empleado[3] == "Secretaria")
            {
                SecretariaMenuView VistaSecretaria = new SecretariaMenuView();
                VistaSecretaria.Show();
                VistaSecretaria.txtNombre.Text = t_empleado[0];
                VistaSecretaria.txtApellido.Text = t_empleado[1];
                VistaSecretaria.txtCI.Text = t_empleado[2];
            }
        }
    }
    //Clase Tipo Login Chofer
    class LogChofer : LogOpen
    {
        public override void OpenView(List<string> t_empleado)
        {
            if (t_empleado[3] == "Chofer")
            {
                //Proceso
            }
        }
    }
    //Clase Tipo Login Propietario
    class LogPropietario : LogOpen
    {
        public override void OpenView(List<string> t_empleado)
        {
            if (t_empleado[3] == "Propietario")
            {
                //Proceso
            }
        }
    }
}

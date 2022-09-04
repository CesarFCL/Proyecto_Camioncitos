using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;
using ProyectoCamioncitos.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase Secretaria Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD y el objeto secretaria
    public class SecretariaDAO : DBContext
    {
        //METODOS CRUD

        //Metodo Leer Secretaria
        public List<Secretaria> ObtenerSecretaria(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerSecretaria";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Secretaria> ListaSecretaria = new List<Secretaria>();
            while (Reader.Read())
            {
                ListaSecretaria.Add(new Secretaria
                {
                    CI = Reader["Cedula"].ToString(),
                    Nombre = Reader["Nombre"].ToString(),
                    Apellido = Reader["Apellido"].ToString(),
                    Celular = Reader["Celular"].ToString(),
                    FechaNacimiento = DateTime.Parse(Reader["Fecha de Nacimiento"].ToString()),
                    Correo = Reader["Correo"].ToString(),
                    Direccion = Reader["Direccion"].ToString()
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaSecretaria;
        }

        //Metodo Crear Secretaria
        public bool Create(string CI, string Nombre, string Apellido, string Celular,
            string Fecha_N, string Correo, string Direccion, string Contraseña)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "CrearEmpleado";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI", CI);
                Comando.Parameters.AddWithValue("@NOMBRE", Nombre);
                Comando.Parameters.AddWithValue("@APELLIDO", Apellido);
                Comando.Parameters.AddWithValue("@CELULAR", Celular);
                Comando.Parameters.AddWithValue("@FECHA_N", Fecha_N);
                Comando.Parameters.AddWithValue("@CORREO", Correo);
                Comando.Parameters.AddWithValue("@DIRECCION", Direccion);
                Comando.Parameters.AddWithValue("@CONTRASEÑA", Contraseña);
                Comando.Parameters.AddWithValue("@TIPO", "Secretaria");
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                throw new DBErrorException(); ;
            }
        }

        //Método Eliminar Secretaria
        public bool Delete(string CI)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "EliminarEmpleado";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI", CI);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Método Modificar Secretaria
        public bool Update(string CI, string Nombre, string Apellido, string Celular, string Fecha_N, string Correo, string Direccion)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "ModificarEmpleado";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI", CI);
                Comando.Parameters.AddWithValue("@NOMBRE", Nombre);
                Comando.Parameters.AddWithValue("@APELLIDO", Apellido);
                Comando.Parameters.AddWithValue("@CELULAR", Celular);
                Comando.Parameters.AddWithValue("@FECHA_N", Fecha_N);
                Comando.Parameters.AddWithValue("@CORREO", Correo);
                Comando.Parameters.AddWithValue("@DIRECCION", Direccion);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }
    }
}

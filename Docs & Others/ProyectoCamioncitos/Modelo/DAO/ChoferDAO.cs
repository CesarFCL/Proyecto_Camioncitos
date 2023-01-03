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
    //Clase Chofer Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD y el objeto chofer
    public class ChoferDAO : DBContext
    {
        //METODOS CRUD

        //Metodo Leer Chofer
        public List<Chofer> ObtenerChofer(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerChofer";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Chofer> ListaChofer = new List<Chofer>();
            while (Reader.Read())
            {
                ListaChofer.Add(new Chofer
                {
                    CI = Reader["Cedula"].ToString(),
                    Nombre = Reader["Nombre"].ToString(),
                    Apellido = Reader["Apellido"].ToString(),
                    Celular = Reader["Celular"].ToString(),
                    FechaNacimiento = DateTime.Parse(Reader["Fecha de Nacimiento"].ToString()),
                    Correo = Reader["Correo"].ToString(),
                    Direccion = Reader["Direccion"].ToString(),
                    Disponibilidad = Reader["Disponibilidad"].ToString()
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaChofer;
        }

        //Metodo Leer Chofer Disponible
        public List<Chofer> ObtenerChoferDisponible(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerChoferDisponible";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Chofer> ListaChofer = new List<Chofer>();
            while (Reader.Read())
            {
                ListaChofer.Add(new Chofer
                {
                    CI = Reader["Cedula"].ToString(),
                    Nombre = Reader["Nombre"].ToString(),
                    Apellido = Reader["Apellido"].ToString(),
                    Celular = Reader["Celular"].ToString(),
                    FechaNacimiento = DateTime.Parse(Reader["Fecha de Nacimiento"].ToString()),
                    Correo = Reader["Correo"].ToString(),
                    Direccion = Reader["Direccion"].ToString(),
                    Disponibilidad = Reader["Disponibilidad"].ToString()
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaChofer;
        }

        //Metodo Crear Chofer
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
                Comando.Parameters.AddWithValue("@TIPO", "Chofer");
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

        //Método Eliminar Chofer
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

        //Método Modificar Chofer
        public bool Update(string CI, string Nombre, string Apellido, string Celular, string Fecha_N, string Correo, string Direccion, string Disponibilidad)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "ModificarChofer";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI", CI);
                Comando.Parameters.AddWithValue("@NOMBRE", Nombre);
                Comando.Parameters.AddWithValue("@APELLIDO", Apellido);
                Comando.Parameters.AddWithValue("@CELULAR", Celular);
                Comando.Parameters.AddWithValue("@FECHA_N", Fecha_N);
                Comando.Parameters.AddWithValue("@CORREO", Correo);
                Comando.Parameters.AddWithValue("@DIRECCION", Direccion);
                Comando.Parameters.AddWithValue("@DISPONIBILIDAD", Disponibilidad);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Método Modificar Disponibilidad Chofer
        public bool UpdateDisponibilidad(string CI, string Disponibilidad)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ModificarDisponibilidadChofer";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CI", CI);
            Comando.Parameters.AddWithValue("@DISPONIBILIDAD", Disponibilidad);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            bool Resultado = false;

            if (Reader.Read())
            {
                Resultado = bool.Parse(Reader["Resultado"].ToString());
            }
            if (!Resultado)
            {
                throw new DenyChangeDisponibilidad();
            }
            Reader.Close();
            Conexion.Close();
            return true;
        }
    }
}

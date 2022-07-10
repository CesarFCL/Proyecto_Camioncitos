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
    //Clase Vehiculo Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD para el Controlador del CRUD Vehiculo
    public class VehiculoDAO : DBContext
    {

        //METODOS CRUD

        //Metodo Leer Vehiculo
        public List<Vehiculo> VerRegistros(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerVehiculo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Vehiculo> ListaVehiculo = new List<Vehiculo>();
            while (Reader.Read())
            {
                ListaVehiculo.Add(new Vehiculo
                {
                    Matricula = Reader["MATRICULA"].ToString(),
                    Marca = Reader["MARCA"].ToString(),
                    Year = Reader["AÑO"].ToString(),
                    Tipo = Reader["TIPO"].ToString(),
                    Disponibilidad = Reader["DISPONIBILIDAD"].ToString(),
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaVehiculo;
        }

        //Metodo Crear Vehiculo
        public bool Create(string Matricula, string Marca, string Year, string Tipo)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "CrearVehiculo";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@MATRICULA", Matricula);
                Comando.Parameters.AddWithValue("@MARCA", Marca);
                Comando.Parameters.AddWithValue("@AÑO", Year);
                Comando.Parameters.AddWithValue("@TIPO", Tipo);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Método Eliminar Vehiculo
        public bool Delete(string Matricula)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "EliminarVehiculo";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@MATRICULA", Matricula);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Método Modificar Vehiculo
        public bool Update(string Matricula, string Marca, string Year, string Tipo, string Disponibilidad)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "ModificarVehiculo";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@MATRICULA", Matricula);
                Comando.Parameters.AddWithValue("@MARCA", Marca);
                Comando.Parameters.AddWithValue("@AÑO", Year);
                Comando.Parameters.AddWithValue("@TIPO", Tipo);
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

        //Método Cargar Lista de Tipos de Vehiculos
        public List<string> CargarListaTipos()
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "Lista_Tipos_Vehiculos";
            Comando.CommandType = CommandType.StoredProcedure;
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<string> ListaVehiculo = new List<string>();
            while (Reader.Read())
            {
                ListaVehiculo.Add(Reader["NOMBRE"].ToString());
            }
            if (ListaVehiculo.Count == 0)
            {
                throw new DBErrorException();
            }
            return ListaVehiculo;
        }
    }
}

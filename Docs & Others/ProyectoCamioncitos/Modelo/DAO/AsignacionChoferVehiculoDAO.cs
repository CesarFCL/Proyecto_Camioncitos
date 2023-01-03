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
    //Clase Asignacion Chofer Vehiculo Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD y el objeto AsignacionChoferVehiculo
    public class AsignacionChoferVehiculoDAO : DBContext
    {

        //METODOS CRUD

        //Metodo Leer VinculoChoferVehiculo
        public List<AsignacionChoferVehiculo> ObtenerVinculoChoferVehiculo(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerVinculoChoferVehiculo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<AsignacionChoferVehiculo> ListaVehiculo = new List<AsignacionChoferVehiculo>();
            while (Reader.Read())
            {
                ListaVehiculo.Add(new AsignacionChoferVehiculo
                {
                    CI = Reader["CEDULA CHOFER"].ToString(),
                    Matricula = Reader["MATRICULA VEHICULO"].ToString()
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaVehiculo;
        }

        //Metodo Crear VinculoChoferVehiculo
        public bool Create(string CI, string Matricula)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "UnirChoferVehiculo";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI_CHOFER", CI);
                Comando.Parameters.AddWithValue("@MATRICULA_VEHICULO", Matricula);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Método Eliminar VinculoChoferVehiculo
        public bool Delete(string CI, string Matricula)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "DesvincularChoferVehiculo";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI_CHOFER", CI);
                Comando.Parameters.AddWithValue("@MATRICULA_VEHICULO", Matricula);
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

using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;
using ProyectoCamioncitos.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase Asignacion de Envios Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD y el objeto AsignacionEnvio
    public class AsignarEnviosDAO : DBContext
    {

        //METODOS CRUD

        //Metodo Leer Envios Asignados
        public List<AsignacionEnvio> ObtenerEnviosAsignados(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerEnvioAsignado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<AsignacionEnvio> ListaEnviosAsignados = new List<AsignacionEnvio>();
            while (Reader.Read())
            {
                ListaEnviosAsignados.Add(new AsignacionEnvio
                {
                    IDPedido = Int32.Parse(Reader["ID Envio"].ToString()),
                    CIChofer = Reader["CI Chofer"].ToString()
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaEnviosAsignados;
        }

        //Metodo Crear Asignación Envio
        public bool Create(int ID_Pedido, string CI_Chofer)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "AsignarEnvio";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_PEDIDO", ID_Pedido);
                Comando.Parameters.AddWithValue("@CI_CHOFER", CI_Chofer);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                throw new DBErrorException();
            }
        }

        //Método Eliminar Asignacion Envio
        public bool Delete(int ID_Pedido, string CI_Chofer)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "EliminarAsignacionEnvio";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_PEDIDO", ID_Pedido);
                Comando.Parameters.AddWithValue("@CI_CHOFER", CI_Chofer);
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

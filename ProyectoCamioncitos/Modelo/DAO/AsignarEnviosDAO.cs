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
    //Aqui se ejecutan todos los procesos que involucren a la BD para la tabla que Vincula al Chofer con un Envio
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

        public List<Tuple<PedidoDetallado, Envio>> ObtenerEnviosAsignadosParticularesDetallados(string CI, string condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerEnviosPendientesDetalladosChofer";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CI", CI);
            Comando.Parameters.AddWithValue("@Condicion", condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Tuple<PedidoDetallado, Envio>> ListaPedidoEnvio = new List<Tuple<PedidoDetallado, Envio>>();
            while (Reader.Read())
            {
                ListaPedidoEnvio.Add(new Tuple<PedidoDetallado, Envio>(
                    new PedidoDetallado
                    {
                        ID = Int32.Parse(Reader["ID"].ToString()),
                        Fecha = DateTime.Parse(Reader["Fecha"].ToString()),
                        RucCliente = Reader["RUC Cliente"].ToString(),
                        NombreCliente = Reader["Nombre Cliente"].ToString(),
                        DireccionCliente = Reader["Direccion Cliente"].ToString(),
                        TelefonoCliente = Reader["Telefono Cliente"].ToString(),
                        Detalles = Reader["Detalles"].ToString(),
                        Peso = Reader["Peso"].ToString(),
                        EnvioIntraprovincial = Reader["Envio Intraprovincial"].ToString(),
                        Costo = float.Parse(Reader["Costo"].ToString())
                    }, new Envio
                    {
                        Id = Int32.Parse(Reader["ID"].ToString()),
                        DireccionDestinatario = Reader["Direccion Destinatario"].ToString(),
                        CiDestinatario = Reader["CI Destinatario"].ToString(),
                        TelefonoDestinatario = Reader["Telefono Destinatario"].ToString(),
                        Estado = Reader["Estado"].ToString(),
                        FechaFinalizacion = Reader["Fecha Finalizacion"].ToString()
                    }));
            }
            Reader.Close();
            Conexion.Close();
            return ListaPedidoEnvio;
        }

        //Metodo Crear Asignacion Envio
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

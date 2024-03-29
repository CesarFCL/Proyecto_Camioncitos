﻿using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;
using ProyectoCamioncitos.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase PedidoEnvio Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD y los objetos pedido y envio
    public class PedidoEnvioDAO : DBContext
    {

        //METODOS CRUD

        //Metodo Leer Pedidos
        public List<Tuple<Pedido, Envio>> ObtenerPedidoEnvio(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerPedidoEnvio";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Tuple<Pedido, Envio>> ListaPedidoEnvio = new List<Tuple<Pedido, Envio>>();
            while (Reader.Read())
            {
                ListaPedidoEnvio.Add(new Tuple<Pedido, Envio>(
                    new Pedido
                    {
                        ID = Int32.Parse(Reader["ID"].ToString()),
                        Fecha = DateTime.Parse(Reader["Fecha"].ToString()),
                        RucCliente = Reader["RUC Cliente"].ToString(),
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

        //Metodo Leer Pedidos Particular
        public List<Tuple<Pedido, Envio>> ObtenerPedidoEnvioParticular(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerPedidoEnvioParticular";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Tuple<Pedido, Envio>> ListaPedidoEnvio = new List<Tuple<Pedido, Envio>>();
            while (Reader.Read())
            {
                ListaPedidoEnvio.Add(new Tuple<Pedido, Envio>(
                    new Pedido
                    {
                        ID = Int32.Parse(Reader["ID"].ToString()),
                        Fecha = DateTime.Parse(Reader["Fecha"].ToString()),
                        RucCliente = Reader["RUC Cliente"].ToString(),
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

        //Metodo Leer Pedidos Detallados
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

        //Metodo Crear PedidoEnvio
        public bool Create(string Fecha, string Ruc_Cliente, string Detalles, string Peso,
            string Envio_Intraprovincial, string Direccion_Destinatario, string CI_Destinatario, string Telefono_Destinatario)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "CrearPedidoEnvio";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FECHA", Fecha);
                Comando.Parameters.AddWithValue("@RUC_CLIENTE", Ruc_Cliente);
                Comando.Parameters.AddWithValue("@DETALLES", Detalles);
                Comando.Parameters.AddWithValue("@PESO", Peso);
                Comando.Parameters.AddWithValue("@ENVIO_INTRAPROVINCIAL", Envio_Intraprovincial);
                Comando.Parameters.AddWithValue("@DIRECCION_DESTINATARIO", Direccion_Destinatario);
                Comando.Parameters.AddWithValue("@CI_DESTINATARIO", CI_Destinatario);
                Comando.Parameters.AddWithValue("@TELEFONO_DESTINATARIO", Telefono_Destinatario);
                Conexion.Open();
                Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    if (Reader["ExistRUC"].ToString() == "False")
                    {
                        throw new DenyCreatePedidoRucInexistente();
                    }
                }
                Conexion.Close();
                return true;
            }
            catch (DenyCreatePedidoRucInexistente){ return false; }
            catch (Exception)
            {
                throw new DBErrorException();
            }
        }

        //Método Eliminar PedidoEnvio
        public bool Delete(string ID)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "EliminarPedidoEnvio";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", ID);
                Conexion.Open();
                Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    if (Reader["Pedido Finalizado"].ToString() == "True")
                    {
                        throw new DenyDeletePedidoFinalizado();
                    }
                }
                Conexion.Close();
                return true; ;
            }
            catch (DenyDeletePedidoFinalizado) { return false; }
            catch (Exception){
                throw new DBErrorException();
            }
        }

        //Método Modificar PedidoEnvio
        public bool Update(int ID, string Detalles, string Peso, string Envio_Intraprovincial, 
            string Direccion_Destinatario, string Telefono_Destinatario, string Estado)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "ModificarPedidoEnvio";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", ID);
                Comando.Parameters.AddWithValue("@DETALLES", Detalles);
                Comando.Parameters.AddWithValue("@PESO", Peso);
                Comando.Parameters.AddWithValue("@ENVIO_INTRAPROVINCIAL", Envio_Intraprovincial);
                Comando.Parameters.AddWithValue("@DIRECCION_DESTINATARIO", Direccion_Destinatario);
                Comando.Parameters.AddWithValue("@TELEFONO_DESTINATARIO", Telefono_Destinatario);
                Comando.Parameters.AddWithValue("@ESTADO", Estado);
                Conexion.Open();
                Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    if (Reader["PostEstado"].ToString() == "True")
                    {
                        throw new DenyEditPedidoFinalizado();
                    }
                }
                Conexion.Close();
                return true;
            }
            catch (DenyEditPedidoFinalizado) { return false; }
            catch (Exception)
            {
                throw new DBErrorException();
            }
        }

        //Método Finalizar Envio
        public bool UpdateFinalizarEnvio(int ID_Envio)
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "FinalizarEnvio";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_ENVIO", ID_Envio);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Metodo Leer Pedidos Pendientes
        public List<Tuple<Pedido, Envio>> ObtenerPedidoEnvioPendiente(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerPedidoEnvioPendienteNoAsignado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Tuple<Pedido, Envio>> ListaPedidoEnvio = new List<Tuple<Pedido, Envio>>();
            while (Reader.Read())
            {
                ListaPedidoEnvio.Add(new Tuple<Pedido, Envio>(
                    new Pedido
                    {
                        ID = Int32.Parse(Reader["ID"].ToString()),
                        Fecha = DateTime.Parse(Reader["Fecha"].ToString()),
                        RucCliente = Reader["RUC Cliente"].ToString(),
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
    }
}

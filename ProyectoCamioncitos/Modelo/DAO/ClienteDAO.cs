using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCamioncitos.Modelo.DTO;
using System.Data;
using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;

namespace ProyectoCamioncitos.Modelo.DAO
{
    //Clase Cliente Data Acces Object
    //Aqui se ejecutan todos los procesos que involucren a la BD para el Controlador del CRUD Cliente
    public class ClienteDAO :DBContext
    {
        //METODOS CRUD

        //Metodo Leer Csuario
        public List<Cliente> VerRegistros(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ObtenerCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            Reader = Comando.ExecuteReader();

            List<Cliente> ListaCliente = new List<Cliente>();//Lista generica
            while (Reader.Read())
            {
                ListaCliente.Add(new Cliente
                {
                    RUC = Reader.GetString(0),
                    Nombre = Reader.GetString(1),
                    Telefono = Reader.GetString(2),
                    Correo = Reader.GetString(3),
                    Direccion = Reader.GetString(4),
                });
            }
            Reader.Close();
            Conexion.Close();
            return ListaCliente;
        }

        //Metodo Crear Cliente
        public bool Create(string RUC, string Nombre, string Telefono, string Correo, string Direccion) 
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "CrearCliente";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@RUC", RUC);
                Comando.Parameters.AddWithValue("@NOMBRE", Nombre);
                Comando.Parameters.AddWithValue("@TELEFONO", Telefono);
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

        //Método Eliminar Cliente
        public bool Delete(string RUC) 
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "EliminarCliente";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@RUC", RUC);
                Conexion.Open();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new DBErrorException();
            }
        }

        //Método Modificar Cliente
        public bool Update(string RUC, string Nombre, string Telefono, string Correo, string Direccion) 
        {
            try
            {
                Comando.Connection = Conexion;
                Comando.CommandText = "ModificarCliente";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@RUC", RUC);
                Comando.Parameters.AddWithValue("@NOMBRE", Nombre);
                Comando.Parameters.AddWithValue("@TELEFONO", Telefono);
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

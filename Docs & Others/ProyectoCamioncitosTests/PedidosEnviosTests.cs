using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DAO.DaoExceptions;
using ProyectoCamioncitos.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCamioncitos.Modelo.DAO.Tests
{
    [TestClass()]
    public class PedidosEnviosTests
    {
        //Tests Relacionados a las Pedidos y Envios

        [TestMethod()]
        public void ObtencionCorrectaPedidoTest()
        {
            //Preparacion

            List<Tuple<Pedido, Envio>> pedidoExpected = new List<Tuple<Pedido, Envio>>();

            pedidoExpected.Add(new Tuple<Pedido, Envio>(
                    new Pedido
                    {
                        ID = 39, //El ID puede cambiar, dependera de en que momento fue ingresaod este pedido a la BD.
                        Fecha = DateTime.Parse("2022-08-29"),
                        RucCliente = "1231231231231",
                        Detalles = "5 paquetes de 6 Cocacolas de 5L",
                        Peso = "50",
                        EnvioIntraprovincial = "No",
                        Costo = 94.5F
                    }, new Envio
                    {
                        Id = 39, //El ID puede cambiar, dependera de en que momento fue ingresaod este pedido a la BD.
                        DireccionDestinatario = "Muy lejos",
                        CiDestinatario = "1234567890",
                        TelefonoDestinatario = "0990634712",
                        Estado = "Pendiente",
                        FechaFinalizacion = "",
                    }));

            //Ejecucion

            PedidoEnvioDAO pedidoDAO = new PedidoEnvioDAO();
            List<Tuple<Pedido, Envio>> pedidoTest = pedidoDAO.ObtenerPedidoEnvio("39");

            //Evaluacion

            Assert.AreEqual(pedidoExpected[0].Item1.ID, pedidoTest[0].Item1.ID);
            Assert.AreEqual(pedidoExpected[0].Item1.Fecha, pedidoTest[0].Item1.Fecha);
            Assert.AreEqual(pedidoExpected[0].Item1.RucCliente, pedidoTest[0].Item1.RucCliente);
            Assert.AreEqual(pedidoExpected[0].Item1.Detalles, pedidoTest[0].Item1.Detalles);
            Assert.AreEqual(pedidoExpected[0].Item1.Peso, pedidoTest[0].Item1.Peso);
            Assert.AreEqual(pedidoExpected[0].Item1.EnvioIntraprovincial, pedidoTest[0].Item1.EnvioIntraprovincial);
            Assert.AreEqual(pedidoExpected[0].Item1.Costo, pedidoTest[0].Item1.Costo);
            Assert.AreEqual(pedidoExpected[0].Item2.Id, pedidoTest[0].Item2.Id);
            Assert.AreEqual(pedidoExpected[0].Item2.DireccionDestinatario, pedidoTest[0].Item2.DireccionDestinatario);
            Assert.AreEqual(pedidoExpected[0].Item2.CiDestinatario, pedidoTest[0].Item2.CiDestinatario);
            Assert.AreEqual(pedidoExpected[0].Item2.TelefonoDestinatario, pedidoTest[0].Item2.TelefonoDestinatario);
            Assert.AreEqual(pedidoExpected[0].Item2.Estado, pedidoTest[0].Item2.Estado);
            Assert.AreEqual(pedidoExpected[0].Item2.FechaFinalizacion, pedidoTest[0].Item2.FechaFinalizacion);
        }

        [TestMethod()]
        public void ObtencionPedidoNoEncontradoTest()
        {
            //Ejecucion

            PedidoEnvioDAO pedidoDAO = new PedidoEnvioDAO();
            List<Tuple<Pedido, Envio>> pedidoTest = pedidoDAO.ObtenerPedidoEnvio("398");

            //Evaluacion

            if (pedidoTest.Count == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CrearNuevoPedidoCorrectamenteTest()
        {
            /*
             * pedido ejecuta el método Create con 8 parametros (Fecha Pedido, Ruc Cliente, Detalles, Peso, Is Envio Provincial,
             * Direccion Destinatario, CI Destinatario, Telefono Destinatario)
             * Si se realiza la creacion del pedido correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            Assert.IsTrue(pedido.Create("2022-08-29", "1231231231231", "Algo de 1 kg", "1", "No", "Muy lejos", "3231", "3232"));
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBCreatePedidoTest()
        {
            /*
             * pedido ejecuta el método Create con 8 parametros (Fecha Pedido, Ruc Cliente, Detalles, Peso, Is Envio Provincial,
             * Direccion Destinatario, CI Destinatario, Telefono Destinatario)
             * Si se realiza la creacion del pedido correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            pedido.Create("Test", "1231231231231", "Test", "Test", "Test", "Test", "Test", "Test");
        }

        [TestMethod]
        public void DenyCreatePedidoTest()
        {
            /*
             * pedido ejecuta el método Create con 8 parametros (Fecha Pedido, Ruc Cliente, Detalles, Peso, Is Envio Provincial,
             * Direccion Destinatario, CI Destinatario, Telefono Destinatario)
             * Si se realiza la creacion del pedido correctamente el metodo Create devuelve true, en caso de que el
             * RUC del cliente no se encuentre registrado de devuelve false, caso contrario se lanza una excepcion
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            Assert.IsFalse(pedido.Create("Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod()]
        public void ModificarPedidoCorrectamenteTest()
        {
            /*
             * pedido ejecuta el método Update con 7 parametros (ID, Detalles, Peso, IsEnvio Intraprovincial,
             * Direccion Destinatario, Telefono Destinatario, Estado)
             * Si se realiza la modificacion del pedido correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            pedido.Update(1, "Test", "Test", "Test", "Test", "Test", "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBEditPedidoTest()
        {
            /*
             * pedido ejecuta el método Update con 7 parametros (ID, Detalles, Peso, IsEnvio Intraprovincial,
             * Direccion Destinatario, Telefono Destinatario, Estado)
             * Si se realiza la modificacion del pedido correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            pedido.Update(39, "Test", "Test", "Test", "Test", "Test", "Test");
        }

        [TestMethod]
        public void DenyEditPedidoFinalizadooTest()
        {
            /*
             * pedido ejecuta el método Update con 7 parametros (ID, Detalles, Peso, IsEnvio Intraprovincial,
             * Direccion Destinatario, Telefono Destinatario, Estado)
             * Si se realiza la modificacion del pedido correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion, en caso de que el Pedido Este finalizado
             * se negara la edicion del pedido y se retornara false
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            //El pedido debe estar en estado finalizado
            Assert.IsFalse(pedido.Update(41, "Test", "Test", "Test", "Test", "Test", "Finalizado"));
        }

        [TestMethod()]
        public void EliminarPedidoCorrectamenteTest()
        {
            /*
             * pedido ejecuta el método Delete con 1 parametros (ID)
             * Si se realiza la eliminacion del pedido correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            pedido.Delete("1");
        }

        [TestMethod]
        public void DenyEliminarPedidoFinalizadooTest()
        {
            /*
             * pedido ejecuta el método Delete con 1 parametros (ID)
             * Si se realiza la eliminacion del pedido correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion, en caso de que el Pedido Este finalizado
             * se negara la eliminacion del pedido y se retornara false
             */
            PedidoEnvioDAO pedido = new PedidoEnvioDAO();
            //El pedido debe estar en estado finalizado
            Assert.IsFalse(pedido.Delete("41"));
        }
    }
}

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
    public class ClientesTests
    {
        //Tests Relacionados a los Clientes

        [TestMethod()]
        public void ObtencionCorrectaClienteTest()
        {

            //Preparacion

            List<Cliente> clienteExpected = new List<Cliente>();

            clienteExpected.Add(new Cliente
            {
                RUC = "1231231231231",
                Nombre = "Coca-Cola-Company",
                Telefono = "1231231231",
                Correo = "coca_cola@cocacola.com",
                Direccion = "La Luna",
            });

            //Ejecucion

            ClienteDAO clienteDAO = new ClienteDAO();
            List<Cliente> clienteTest = clienteDAO.ObtenerCliente("1231231231231");

            //Evaluacion

            Assert.AreEqual(clienteExpected[0].RUC, clienteTest[0].RUC);
            Assert.AreEqual(clienteExpected[0].Nombre, clienteTest[0].Nombre);
            Assert.AreEqual(clienteExpected[0].Telefono, clienteTest[0].Telefono);
            Assert.AreEqual(clienteExpected[0].Correo, clienteTest[0].Correo);
            Assert.AreEqual(clienteExpected[0].Direccion, clienteTest[0].Direccion);
        }

        [TestMethod()]
        public void ObtencionClienteNoEncontradoTest()
        {
            //Ejecucion

            ClienteDAO clienteDAO = new ClienteDAO();
            List<Cliente> clienteTest = clienteDAO.ObtenerCliente("ABC12345");

            //Evaluacion

            if (clienteTest.Count == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CrearNuevoClienteCorrectamenteTest()
        {
            /*
             * cliente ejecuta el método Create con 5 parametros (RUC, Nombre, Telefono, Correo, Direccion)
             * Si se realiza la creacion del cliente correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            ClienteDAO cliente = new ClienteDAO();
            Assert.IsTrue(cliente.Create("Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBCreateClienteTest()
        {
            /*
             * cliente ejecuta el método Create con 5 parametros (RUC, Nombre, Telefono, Correo, Direccion)
             * Si se realiza la creacion del cliente correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            ClienteDAO cliente = new ClienteDAO();
            cliente.Create("123123123123123123123", "Test", "Test", "Test", "Test");
        }

        [TestMethod()]
        public void ModificarClienteCorrectamenteTest()
        {
            /*
             * cliente ejecuta el método Update con 5 parametros (RUC, Nombre, Telefono, Correo, Direccion)
             * Si se realiza la modificacion del cliente correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            ClienteDAO cliente = new ClienteDAO();
            Assert.IsTrue(cliente.Update("Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod()]
        public void EliminarClienteCorrectamenteTest()
        {
            /*
             * cliente ejecuta el método Delete con 1 parametros (RUC)
             * Si se realiza la eliminacion del cliente correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion
             */
            ClienteDAO cliente = new ClienteDAO();
            Assert.IsTrue(cliente.Delete("Test"));
        }
    }
}
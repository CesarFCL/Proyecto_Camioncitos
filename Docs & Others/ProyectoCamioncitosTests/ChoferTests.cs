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
    public class ChoferTests
    {
        //Tests Relacionados a los Choferes

        [TestMethod()]
        public void ObtencionCorrectaChoferTest()
        {

            //Preparacion

            List<Chofer> choferExpected = new List<Chofer>();

            choferExpected.Add(new Chofer
            {
                CI = "1111111111",
                Nombre = "Jesus",
                Apellido = "Monserrate",
                Celular = "1231231231",
                FechaNacimiento = DateTime.Parse("2001-06-19"),
                Correo = "jesus@gmail.com",
                Direccion = "En su casa",
                Disponibilidad = "Disponible"
            });

            //Ejecucion

            ChoferDAO choferDAO = new ChoferDAO();
            List<Chofer> choferTest = choferDAO.ObtenerChofer("1111111111");

            //Evaluacion

            Assert.AreEqual(choferExpected[0].CI, choferTest[0].CI);
            Assert.AreEqual(choferExpected[0].Nombre, choferTest[0].Nombre);
            Assert.AreEqual(choferExpected[0].Apellido, choferTest[0].Apellido);
            Assert.AreEqual(choferExpected[0].Celular, choferTest[0].Celular);
            Assert.AreEqual(choferExpected[0].FechaNacimiento, choferTest[0].FechaNacimiento);
            Assert.AreEqual(choferExpected[0].Correo, choferTest[0].Correo);
            Assert.AreEqual(choferExpected[0].Direccion, choferTest[0].Direccion);
            Assert.AreEqual(choferExpected[0].Disponibilidad, choferTest[0].Disponibilidad);
        }

        [TestMethod()]
        public void ObtencionChoferNoEncontradoTest()
        {
            //Ejecucion

            ChoferDAO choferDAO = new ChoferDAO();
            List<Chofer> choferTest = choferDAO.ObtenerChofer("ABC12345");

            //Evaluacion

            if (choferTest.Count == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CrearNuevoChoferCorrectamenteTest()
        {
            /*
             * chofer ejecuta el método Create con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Contraseña)
             * Si se realiza la creacion del chofer correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            ChoferDAO chofer = new ChoferDAO();
            Assert.IsTrue(chofer.Create("Test", "Test", "Test", "Test", "2001-06-1", "Test", "Test", "Test"));
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBCreateChoferTest()
        {
            /*
             * chofer ejecuta el método Create con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Contraseña)
             * Si se realiza la creacion del chofer correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            ChoferDAO chofer = new ChoferDAO();
            chofer.Create("1111111111", "Test", "Test", "Test", "Test", "Test", "Test", "Test");
        }

        [TestMethod()]
        public void ModificarChoferCorrectamenteTest()
        {
            /*
             * chofer ejecuta el método Update con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Disponibilidad)
             * Si se realiza la modificacion del chofer correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            ChoferDAO chofer = new ChoferDAO();
            chofer.Update("Test", "Test", "Test", "Test", "2001-06-1", "Test", "Test", "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBEditChoferTest()
        {
            /*
             * chofer ejecuta el método Update con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Disponibilidad)
             * Si se realiza la modificacion del chofer correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            ChoferDAO chofer = new ChoferDAO();
            Assert.IsTrue(chofer.Update("1111111111", "Test", "Test", "Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod()]
        public void EliminarChoferCorrectamenteTest()
        {
            /*
             * chofer ejecuta el método Delete con 1 parametros (CI)
             * Si se realiza la eliminacion del chofer correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion
             */
            ChoferDAO chofer = new ChoferDAO();
            Assert.IsTrue(chofer.Delete("Test"));
        }
    }
}
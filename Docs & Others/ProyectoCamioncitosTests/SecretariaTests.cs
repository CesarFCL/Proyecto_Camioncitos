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
    public class SecretariaTests
    {
        //Tests Relacionados a las Secretarias

        [TestMethod()]
        public void ObtencionCorrectaSecretariaTest()
        {

            //Preparacion

            List<Secretaria> secretariaExpected = new List<Secretaria>();

            secretariaExpected.Add(new Secretaria
            {
                CI = "1719963470",
                Nombre = "Luis",
                Apellido = "Vera",
                Celular = "9090909090",
                FechaNacimiento = DateTime.Parse("2001-03-15"),
                Correo = "luis@gmail.com",
                Direccion = "Muy muy lejos"
            });

            //Ejecucion

            SecretariaDAO secretariaDAO = new SecretariaDAO();
            List<Secretaria> secretariaTest = secretariaDAO.ObtenerSecretaria("1719963470");

            //Evaluacion

            Assert.AreEqual(secretariaExpected[0].CI, secretariaTest[0].CI);
            Assert.AreEqual(secretariaExpected[0].Nombre, secretariaTest[0].Nombre);
            Assert.AreEqual(secretariaExpected[0].Apellido, secretariaTest[0].Apellido);
            Assert.AreEqual(secretariaExpected[0].Celular, secretariaTest[0].Celular);
            Assert.AreEqual(secretariaExpected[0].FechaNacimiento, secretariaTest[0].FechaNacimiento);
            Assert.AreEqual(secretariaExpected[0].Correo, secretariaTest[0].Correo);
            Assert.AreEqual(secretariaExpected[0].Direccion, secretariaTest[0].Direccion);
        }

        [TestMethod()]
        public void ObtencionSecretariaNoEncontradoTest()
        {
            //Ejecucion

            SecretariaDAO secretariaDAO = new SecretariaDAO();
            List<Secretaria> secretariaTest = secretariaDAO.ObtenerSecretaria("ABC12345");

            //Evaluacion

            if (secretariaTest.Count == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CrearNuevoSecretariaCorrectamenteTest()
        {
            /*
             * secretaria ejecuta el método Create con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Contraseña)
             * Si se realiza la creacion de la secretaria correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            Assert.IsTrue(secretaria.Create("Test0", "Test", "Test", "Test", "2001-03-15", "Test", "Test", "Test"));
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBCreateSecretariaTest()
        {
            /*
             * secretaria ejecuta el método Create con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Contraseña)
             * Si se realiza la creacion de la secretaria correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            secretaria.Create("1111111116", "Test", "Test", "Test", "Test", "Test", "Test", "Test");
        }

        [TestMethod()]
        public void ModificarSecretariaCorrectamenteTest()
        {
            /*
             * secretaria ejecuta el método Update con 7 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion)
             * Si se realiza la modificacion de la secretaria correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            Assert.IsTrue(secretaria.Update("Test", "Test", "Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBEditSecretariaTest()
        {
            /*
             * secretaria ejecuta el método Update con 7 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion)
             * Si se realiza la modificacion de la secretaria correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            Assert.IsTrue(secretaria.Update("1719963470", "Test", "Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod()]
        public void EliminarSecretariaCorrectamenteTest()
        {
            /*
             * secretaria ejecuta el método Delete con 1 parametros (CI)
             * Si se realiza la eliminacion de la secretaria correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            Assert.IsTrue(secretaria.Delete("Test"));

        }
    }
}
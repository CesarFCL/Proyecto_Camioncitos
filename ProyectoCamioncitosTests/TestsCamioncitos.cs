using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoCamioncitos.Controlador.ControllersExceptions;
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
    public class TestsCamioncitos
    {
        //--------------------------------------------------------TESTS LOGIN------------------------------------------------------------

        [TestMethod]
        [ExpectedException(typeof(DenyLoginException))]
        public void DenyLoginEmpleadoTest()
        {
            /*
             * loginDAO ejecuta el método LoginEmpleado con 3 parametros (Cedula, Contraseña, Numero de Intento de Login)
             * Si el login se ejecuta correctamente el metodo LoginEmpleado devuelve una lista con los datos del
             * Empleado logueado, en caso contrario se lanza una excepcion del tipo DenyLoginException y en caso de que
             * el número de intentos de login sea -1 se lanza una excepcion del tipo LimitLoginException
             */

            LoginDAO loginDAO = new LoginDAO();
            Empleado vehiculoTest = loginDAO.LoginEmpleado("1719963470", "12" , 3);
        }

        [TestMethod]
        [ExpectedException(typeof(LimitLoginException))]
        public void LimitLoginEmpleadoTest()
        {
            /*
             * loginDAO ejecuta el método LoginEmpleado con 3 parametros (Cedula, Contraseña, Numero de Intento de Login)
             * Si el login se ejecuta correctamente el metodo LoginEmpleado devuelve una lista con los datos del
             * Empleado logueado, en caso contrario se lanza una excepcion del tipo DenyLoginException y en caso de que
             * el número de intentos de login sea -1 se lanza una excepcion del tipo LimitLoginException
             */

            LoginDAO loginDAO = new LoginDAO();
            Empleado vehiculoTest = loginDAO.LoginEmpleado("1719963470", "12", -1);
        }

        [TestMethod()]
        public void LoginSuccessfullEmpleadoTest()
        {
            //Preparacion

            Empleado vehiculoExpected = new Empleado(){Nombre = "Cesar", Apellido = "Carrion", CI = "2222222222", Cargo ="Admin"};

            //Ejecución

            LoginDAO loginDAO = new LoginDAO();
            Empleado vehiculoTest = loginDAO.LoginEmpleado("2222222222", "1234", 3);

            //Evaluación

            Assert.AreEqual(vehiculoExpected.CI, vehiculoTest.CI);
            Assert.AreEqual(vehiculoExpected.Nombre, vehiculoTest.Nombre);
            Assert.AreEqual(vehiculoExpected.Apellido, vehiculoTest.Apellido);
            Assert.AreEqual(vehiculoExpected.Cargo, vehiculoTest.Cargo);
        }

        //------------------------------------------------------------TESTS VEHICULOS----------------------------------------------------

        [TestMethod()]
        public void ObtencionCorrectaVehiculoTest()
        {

            //Preparacion

            List<Vehiculo> vehiculoExpected = new List<Vehiculo>();

            vehiculoExpected.Add(new Vehiculo
            {
                Matricula = "ABC1234",
                Marca = "Toyota",
                Year = "2017",
                Tipo = "Camioneta",
                Disponibilidad = "Disponible",
            });

            //Ejecucion

            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            List<Vehiculo> vehiculoTest = vehiculoDAO.VerRegistros("ABC1234");

            //Evaluacion

            Assert.AreEqual(vehiculoExpected[0].Matricula, vehiculoTest[0].Matricula);
            Assert.AreEqual(vehiculoExpected[0].Marca, vehiculoTest[0].Marca);
            Assert.AreEqual(vehiculoExpected[0].Year, vehiculoTest[0].Year);
            Assert.AreEqual(vehiculoExpected[0].Tipo, vehiculoTest[0].Tipo);
            Assert.AreEqual(vehiculoExpected[0].Disponibilidad, vehiculoTest[0].Disponibilidad);
        }

        [TestMethod()]
        public void ObtencionVehiculoNoEncontradoTest()
        {
            //Ejecucion

            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            List<Vehiculo> vehiculoTest = vehiculoDAO.VerRegistros("ABC12345");

            //Evaluacion

            if (vehiculoTest.Count == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CargarTiposVehiculosCorrectamenteTest()
        {
            //Preparación

            List<string> ListExpected = new List<string> { "Camion", "Camioneta"};

            //Ejecución
            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            List<string> ListTest = vehiculoDAO.CargarListaTiposVehiculos();

            //Evaluación
            Assert.IsTrue(ListTest.Contains(ListExpected[0]));
            Assert.IsTrue(ListTest.Contains(ListExpected[1]));
        }

        [TestMethod()]
        public void CrearNuevoVehiculoCorrectamenteTest()
        {
            /*
             * vehiculo ejecuta el método Create con 4 parametros (Matricula, Marca, Año, TipoVehiculo)
             * Si se realiza la creacion del vehiculo correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            VehiculoDAO vehiculo = new VehiculoDAO();
            Assert.IsTrue(vehiculo.Create("DGH893","Ferrari","2015","Camion"));
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBCreateVehiculoTest()
        {
            /*
             * vehiculo ejecuta el método Create con 4 parametros (Matricula, Marca, Año, TipoVehiculo)
             * Si se realiza la creacion del vehiculo correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            VehiculoDAO vehiculo = new VehiculoDAO();
            vehiculo.Create("ABC1234", "Ferrari", "2015", "Camion");
        }

        [TestMethod()]
        public void ModificarVehiculoCorrectamenteTest()
        {
            /*
             * vehiculo ejecuta el método Update con 5 parametros (Matricula, Marca, Año, TipoVehiculo, Disponibilidad)
             * Si se realiza la edicion del vehiculo correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            VehiculoDAO vehiculo = new VehiculoDAO();
            Assert.IsTrue(vehiculo.Update("DGH893", "Ferrari", "2015", "Camion", "Disponible"));
        }

        [TestMethod()]
        public void EliminarVehiculoCorrectamenteTest()
        {
            /*
             * vehiculo ejecuta el método Delete con 1 parametro (Matricula)
             * Si se realiza la eliminacion del vehiculo correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion
             */
            VehiculoDAO vehiculo = new VehiculoDAO();
            Assert.IsTrue(vehiculo.Delete("DGH893"));
        }

        //--------------------------------------------------------TESTS CLIENTES---------------------------------------------------------

        [TestMethod()]
        public void ObtencionCorrectaClienteTest()
        {

            //Preparacion

            List<Cliente> clienteExpected = new List<Cliente>();

            clienteExpected.Add(new Cliente
            {
                RUC = "123123123",
                Nombre = "Coca-Cola-Company",
                Telefono = "1231231232",
                Correo = "coca_cola@cocacola.com",
                Direccion = "La Luna",
            });

            //Ejecucion

            ClienteDAO clienteDAO = new ClienteDAO();
            List<Cliente> clienteTest = clienteDAO.VerRegistros("123123123");

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
            List<Cliente> clienteTest = clienteDAO.VerRegistros("ABC12345");

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
            cliente.Create("123123123", "Test", "Test", "Test", "Test");
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

        //----------------------------------------------------------TESTS CHOFER---------------------------------------------------------

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
                FechaNacimiento = DateTime.Parse("2001-06-21"),
                Correo = "jesus@gmail.com",
                Direccion = "En su casa",
                Disponibilidad = "Disponible"
            });

            //Ejecucion

            ChoferDAO choferDAO = new ChoferDAO();
            List<Chofer> choferTest = choferDAO.VerRegistros("1111111111");

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
            List<Chofer> choferTest = choferDAO.VerRegistros("ABC12345");

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

        //--------------------------------------------------------TESTS SECRETARIA---------------------------------------------------

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
                Celular = "909090909",
                FechaNacimiento = DateTime.Parse("2001-03-20"),
                Correo = "luis@gmail.com",
                Direccion = "Muy muy lejos"
            });

            //Ejecucion

            SecretariaDAO secretariaDAO = new SecretariaDAO();
            List<Secretaria> secretariaTest = secretariaDAO.VerRegistros("1719963470");

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

            SecretariaDAO secretariaDAO= new SecretariaDAO();
            List<Secretaria> secretariaTest = secretariaDAO.VerRegistros("ABC12345");

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
             * Si se realiza la creacion del chofer correctamente el metodo Create devuelve true,
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
             * chofer ejecuta el método Create con 8 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion, Contraseña)
             * Si se realiza la creacion del chofer correctamente el metodo Create devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            secretaria.Create("1111111116", "Test", "Test", "Test", "Test", "Test", "Test", "Test");
        }

        [TestMethod()]
        public void ModificarSecretariaCorrectamenteTest()
        {
            /*
             * chofer ejecuta el método Update con 7 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion)
             * Si se realiza la modificacion del chofer correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            secretaria.Update("Test", "Test", "Test", "Test", "2001-03-15", "Test", "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(DBErrorException))]
        public void ConflictoDBEditSecretariaTest()
        {
            /*
             * chofer ejecuta el método Update con 7 parametros (CI, Nombre, Apellido, Celular, Fecha Nacimiento, Correo, Direccion)
             * Si se realiza la modificacion del chofer correctamente el metodo Update devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            Assert.IsTrue(secretaria.Update("1719963470", "Test", "Test", "Test", "Test", "Test", "Test"));
        }

        [TestMethod()]
        public void EliminarSecretariaCorrectamenteTest()
        {
            /*
             * chofer ejecuta el método Delete con 1 parametros (CI)
             * Si se realiza la eliminacion del chofer correctamente el metodo Delete devuelve true,
             * caso contrario se lanza una excepcion
             */
            SecretariaDAO secretaria = new SecretariaDAO();
            Assert.IsTrue(secretaria.Delete("Test"));

        }
    }
}
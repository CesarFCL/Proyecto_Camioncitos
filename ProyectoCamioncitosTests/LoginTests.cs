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
    public class LoginTests
    {
        //Tests Relacionados al Login del sistema

        [TestMethod]
        [ExpectedException(typeof(DenyLoginException))]
        public void DenyLoginEmpleadoTest()
        {
            // loginDAO ejecuta el método LoginEmpleado con 3 parametros (Cedula, Contraseña, Numero de Intento de Login)
            // Si el login se ejecuta correctamente el metodo LoginEmpleado devuelve una lista con los datos del
            // Empleado logueado, en caso contrario se lanza una excepcion del tipo DenyLoginException y en caso de que
            // el número de intentos de login sea -1 se lanza una excepcion del tipo LimitLoginException

            LoginDAO loginDAO = new LoginDAO();
            Empleado vehiculoTest = loginDAO.LoginEmpleado("1719963470", "12", 3);
        }

        [TestMethod]
        [ExpectedException(typeof(LimitLoginException))]
        public void LimitLoginEmpleadoTest()
        {
            // loginDAO ejecuta el método LoginEmpleado con 3 parametros (Cedula, Contraseña, Numero de Intento de Login)
            // Si el login se ejecuta correctamente el metodo LoginEmpleado devuelve una lista con los datos del
            // Empleado logueado, en caso contrario se lanza una excepcion del tipo DenyLoginException y en caso de que
            // el número de intentos de login sea -1 se lanza una excepcion del tipo LimitLoginException

            LoginDAO loginDAO = new LoginDAO();
            Empleado vehiculoTest = loginDAO.LoginEmpleado("1719963470", "12", -1);
        }

        [TestMethod()]
        public void LoginSuccessfullEmpleadoTest()
        {
            //Preparacion

            Empleado vehiculoExpected = new Empleado() { Nombre = "Cesar", Apellido = "Carrion", CI = "2222222222", Cargo = "Admin" };

            //Ejecución

            LoginDAO loginDAO = new LoginDAO();
            Empleado vehiculoTest = loginDAO.LoginEmpleado("2222222222", "1234", 3);

            //Evaluación

            Assert.AreEqual(vehiculoExpected.CI, vehiculoTest.CI);
            Assert.AreEqual(vehiculoExpected.Nombre, vehiculoTest.Nombre);
            Assert.AreEqual(vehiculoExpected.Apellido, vehiculoTest.Apellido);
            Assert.AreEqual(vehiculoExpected.Cargo, vehiculoTest.Cargo);
        }
    }
}

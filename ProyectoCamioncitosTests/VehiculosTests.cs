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
    public class VehiculosTests
    {
        //Tests Relacionados a los Vehiculos

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
            List<Vehiculo> vehiculoTest = vehiculoDAO.ObtenerVehiculo("ABC1234");

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
            List<Vehiculo> vehiculoTest = vehiculoDAO.ObtenerVehiculo("ABC12345");

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

            List<string> ListExpected = new List<string> { "Camion", "Camioneta" };

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
            Assert.IsTrue(vehiculo.Create("DGH893", "Ferrari", "2015", "Camion"));
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
    }
}

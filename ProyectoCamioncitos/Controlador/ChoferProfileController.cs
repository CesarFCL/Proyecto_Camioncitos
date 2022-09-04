using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Chofer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Chofer
    class ChoferProfileController : GlobalCrud
    {
        ChoferProfileView Vista;
        ChoferMenuView Menu;
        //Constructor
        public ChoferProfileController(ChoferProfileView view, ChoferMenuView choferMenu)
        {
            Menu = choferMenu;
            Vista = view;

            //inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarChofer();
        }

        //Método Cargar Chofer
        public void CargarChofer()
        {
            ChoferDAO chofer = new ChoferDAO();
            List<Chofer> choferActual = chofer.ObtenerChofer(Menu.txtCI.Text);

            Vista.txtCI.Text = choferActual[0].CI;
            Vista.txtNombre.Text = choferActual[0].Nombre;
            Vista.txtApellido.Text = choferActual[0].Apellido;
            Vista.txtCelular.Text = choferActual[0].Celular;
            Vista.dtpFechaNacimiento.Value = choferActual[0].FechaNacimiento;
            Vista.txtCorreo.Text = choferActual[0].Correo;
            Vista.txtDireccion.Text = choferActual[0].Direccion;
            Menu.pStatus.BackColor = choferActual[0].Disponibilidad == "Disponible" ? Color.FromArgb(0, 255, 0) : Color.FromArgb(255, 0, 0);
        }
    }
}

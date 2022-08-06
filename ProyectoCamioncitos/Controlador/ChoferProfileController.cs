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
            Vista.btnEditar.Click += new EventHandler(UpdateChoferEvent);

            Vista.txtCI.TextChanged += delegate (object sender, EventArgs e) { CI_Limit(sender, e, Vista.txtCI); };
            Vista.txtNombre.TextChanged += delegate (object sender, EventArgs e) { NombreLimit(sender, e, Vista.txtNombre); };
            Vista.txtApellido.TextChanged += delegate (object sender, EventArgs e) { ApellidoLimit(sender, e, Vista.txtApellido); };
            Vista.txtCelular.TextChanged += delegate (object sender, EventArgs e) { CelularLimit(sender, e, Vista.txtCelular); };
            Vista.txtCorreo.TextChanged += delegate (object sender, EventArgs e) { CorreoLimit(sender, e, Vista.txtCorreo); };
            Vista.txtDireccion.TextChanged += delegate (object sender, EventArgs e) { DireccionLimit(sender, e, Vista.txtDireccion); };

            Vista.txtCI.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCelular.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCorreo.Leave += delegate (object sender, EventArgs e) { ValCorreoE(sender, e, Vista.txtCorreo); };
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarChofer();
        }

        //Evento Buscar Chofer
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarChofer();
        }

        //Evento Modificar Chofer
        public void UpdateChoferEvent(object sender, EventArgs e)
        {
            try
            {
                ValUpdateChofer();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la informacion del chofer con cedula: " + Vista.txtCI.Text, "Editar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateChofer();
                    CargarChofer();
                }
            }
            catch { }
        }

        //Metodo Validacion Datos Completos Update Chofer
        public void ValUpdateChofer()
        {
            //Se asegura que todos los datos de los textbox esten completos
            TextBox[] textboxsUpdate = new TextBox[] { Vista.txtCI, Vista.txtNombre, Vista.txtApellido, Vista.txtCelular,
                Vista.txtCorreo, Vista.txtDireccion};
            bool datosCompletos = !textboxsUpdate.Any(X => String.IsNullOrEmpty(X.Text));

            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Update Chofer
        public void UpdateChofer()
        {
            try
            {
                ChoferDAO chofer = new ChoferDAO();
                string Disponibilidad = Menu.pStatus.BackColor == Color.FromArgb(0, 255, 0) ? "Disponible" : "No Disponible";
                chofer.Update(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text,
                    Vista.txtCelular.Text, Vista.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"), Vista.txtCorreo.Text, Vista.txtDireccion.Text, Disponibilidad);
            }
            catch { }
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

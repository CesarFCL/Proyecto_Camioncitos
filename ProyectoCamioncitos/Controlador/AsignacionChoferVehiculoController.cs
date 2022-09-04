using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Chofer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista AsignacionChoferVehiculo
    class AsignacionChoferVehiculoController
    {
        AsignacionChoferVehiculoView Vista;
        TextBox[] textboxs;

        //Constructor
        public AsignacionChoferVehiculoController(AsignacionChoferVehiculoView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtCI, Vista.txtMatricula};

            //inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarChofer.TextChanged += new EventHandler(BusquedaChoferEvent);
            Vista.txtBuscarVehiculo.TextChanged += new EventHandler(BusquedaVehiculoEvent);
            Vista.txtBuscarChoferEnUso.TextChanged += new EventHandler(BusquedaVinculoChoferVehiculoEvent);

            Vista.tblChofer.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectChoferEvent);
            Vista.tblVehiculos.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectVehiculoEvent);
            Vista.tblChoferesConVehiculosAsignados.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectVinculoChoferVehiculoEvent);

            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnVincular.Click += new EventHandler(VincularChoferVehiculoEvent);
            Vista.btnDesvincular.Click += new EventHandler(DesvincularChoferVehiculoEvent);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarChofer();
            CargarVehiculos();
            CargarVinculoChoferVehiculo();
            Limpiar();
        }

        //Evento Buscar Chofer
        public void BusquedaChoferEvent(object sender, EventArgs e)
        {
            CargarChofer();
        }
        //Evento Buscar Vehiculo
        public void BusquedaVehiculoEvent(object sender, EventArgs e)
        {
            CargarVehiculos();
        }
        //Evento Buscar Vinculo Chofer Vehiculo
        public void BusquedaVinculoChoferVehiculoEvent(object sender, EventArgs e)
        {
            CargarVinculoChoferVehiculo();
        }

        //Evento Seleccion Fila Chofer
        public void SelectChoferEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Chofer a los textboxs
            if (Vista.tblChofer.SelectedRows.Count > 0)
            {
                ChoferDAO chofer = new ChoferDAO();
                List<Chofer> ChoferResult = chofer.ObtenerChoferDisponible(Vista.tblChofer.CurrentRow.Cells[1].Value.ToString());
                Vista.txtCI.Text = ChoferResult[0].CI;

                Vista.btnVincular.Enabled = true;
            }
        }
        //Evento Seleccion Fila Vehiculo
        public void SelectVehiculoEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Vehiculo a los textboxs
            if (Vista.tblVehiculos.SelectedRows.Count > 0)
            {
                VehiculoDAO vehiculo = new VehiculoDAO();
                List<Vehiculo> vehiculoResult = vehiculo.ObtenerVehiculoDisponible(Vista.tblVehiculos.CurrentRow.Cells[0].Value.ToString());
                Vista.txtMatricula.Text = vehiculoResult[0].Matricula;

                Vista.btnVincular.Enabled = true;
            }
        }
        //Evento Seleccion Fila Vinculo Chofer Vehiculo
        public void SelectVinculoChoferVehiculoEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Vinculo Chofer Vehiculo a los textboxs
            if (Vista.tblChoferesConVehiculosAsignados.SelectedRows.Count > 0)
            {
                AsignacionChoferVehiculoDAO vinculoChoferVehiculo = new AsignacionChoferVehiculoDAO();
                List<AsignacionChoferVehiculo> vinculoChoferVehiculoResult = vinculoChoferVehiculo.ObtenerVinculoChoferVehiculo(Vista.tblChoferesConVehiculosAsignados.CurrentRow.Cells[0].Value.ToString());
                Vista.txtCI.Text = vinculoChoferVehiculoResult[0].CI;
                Vista.txtMatricula.Text = vinculoChoferVehiculoResult[0].Matricula;

                Vista.btnVincular.Enabled = false;
                Vista.btnDesvincular.Enabled = true;

                Vista.tblChofer.Enabled = false;
                Vista.tblVehiculos.Enabled = false;
            }
        }

        //Evento Limpiar Datos
        public void LimpiarEvent(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Evento Crear Vinculo Chofer Vehiculo
        public void VincularChoferVehiculoEvent(object sender, EventArgs e)
        {
            try
            {
                ValTextboxsCompletos();
                DialogResult dialogResult = MessageBox.Show("Vincular Chofer con cedula: " + Vista.txtCI.Text + " con vehiculo con matricula: " + Vista.txtMatricula.Text + " ?", "Crear Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    VincularChoferVehiculo();
                    CargarChofer();
                    CargarVehiculos();
                    CargarVinculoChoferVehiculo();
                    Limpiar();
                }
            }
            catch { }
        }

        //Metodo Validacion textboxs completos
        public void ValTextboxsCompletos()
        {
            //Se asegura que todos los datos de los textbox esten completos

            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Vincular Chofer Vehiculo
        public void VincularChoferVehiculo()
        {
            try
            {
                AsignacionChoferVehiculoDAO vinculoChoferVehiculo = new AsignacionChoferVehiculoDAO();
                vinculoChoferVehiculo.Create(Vista.txtCI.Text, Vista.txtMatricula.Text);
            }
            catch { }
        }

        //Evento Desvincular Chofer Vehiculo
        public void DesvincularChoferVehiculoEvent(object sender, EventArgs e)
        {
            ValTextboxsCompletos();
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer desvincular al chofer con cedula: " + Vista.txtCI.Text + " y el vehículo con matricula: " + Vista.txtMatricula.Text, "Eliminar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DesvincularChoferVehiculo();
                CargarChofer();
                CargarVehiculos();
                CargarVinculoChoferVehiculo();
                Limpiar();
            }
        }

        //Método Desvincular Chofer Vehiculo
        public void DesvincularChoferVehiculo()
        {
            try
            {
                AsignacionChoferVehiculoDAO vinculoChoferVehiculo = new AsignacionChoferVehiculoDAO();
                vinculoChoferVehiculo.Delete(Vista.txtCI.Text, Vista.txtMatricula.Text);
            }
            catch { }
        }

        //Método limpiar txts
        public void Limpiar()
        {
            Vista.tblChofer.ClearSelection();
            Vista.tblVehiculos.ClearSelection();
            Vista.tblChoferesConVehiculosAsignados.ClearSelection();

            Vista.txtCI.Text = "";
            Vista.txtMatricula.Text = "";

            Vista.btnVincular.Enabled = false;
            Vista.btnDesvincular.Enabled = false;

            Vista.tblChofer.Enabled = true;
            Vista.tblVehiculos.Enabled = true;
        }

        //Método Cargar Chofer
        public void CargarChofer()
        {
            ChoferDAO chofer = new ChoferDAO();
            Vista.tblChofer.DataSource =
                chofer.ObtenerChoferDisponible(Vista.txtBuscarChofer.Text);

            Vista.tblChofer.Columns["Contraseña"].Visible = false;
            Vista.tblChofer.Columns["Celular"].Visible = false;
            Vista.tblChofer.Columns["FechaNacimiento"].Visible = false;
            Vista.tblChofer.Columns["Correo"].Visible = false;
            Vista.tblChofer.Columns["Direccion"].Visible = false;
            Vista.tblChofer.Columns["Cargo"].Visible = false;

            Vista.tblChofer.Columns["CI"].DisplayIndex = 0;
            Vista.tblChofer.Columns["Disponibilidad"].DisplayIndex = 3;
        }

        //Método Cargar Vehiculos
        public void CargarVehiculos()
        {
            VehiculoDAO vehiculo = new VehiculoDAO();
            Vista.tblVehiculos.DataSource =
                vehiculo.ObtenerVehiculoDisponible(Vista.txtBuscarVehiculo.Text);

            Vista.tblVehiculos.Columns["Year"].Visible = false;
        }

        //Método Cargar Choferes vinculados a Vehiculos
        public void CargarVinculoChoferVehiculo()
        {
            AsignacionChoferVehiculoDAO vinculoChoferVehiculoDAO = new AsignacionChoferVehiculoDAO();
            Vista.tblChoferesConVehiculosAsignados.DataSource =
                vinculoChoferVehiculoDAO.ObtenerVinculoChoferVehiculo(Vista.txtBuscarChoferEnUso.Text);
        }
    }
}

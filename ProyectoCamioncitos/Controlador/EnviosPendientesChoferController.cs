using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Chofer;
using ProyectoCamioncitos.Vista.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Pedidos
    class EnviosPendientesChoferController : GlobalCrud
    {
        EnviosPendientesChoferView Vista;
        ChoferMenuView Menu;
        TextBox[] textboxs;

        //Constructor 
        public EnviosPendientesChoferController(EnviosPendientesChoferView view, ChoferMenuView choferMenu)
        {
            Vista = view;
            Menu = choferMenu;
            textboxs = new TextBox[] { Vista.txtID, Vista.txtRucCliente, Vista.txtTelefonoCliente,Vista.txtDireccionCliente, Vista.txtCiDestinatario,
            Vista.txtTelefonoDestinatario, Vista.txtDireccionDestinatario};

            //Inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarFacturas.TextChanged += new EventHandler(BusquedaEvent);
            Vista.tblEnvios.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectPedidossEvent);
            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnLiberar.Click += new EventHandler(LiberarEvent);
            Vista.btnFinalizarEnvio.Click += new EventHandler(FinalizarEnvioEvent);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarEnvios();
            CargarVehiculoAsignado();
            Limpiar();
        }

        //Evento Buscar Pedidos
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarEnvios();
        }

        //Método Cargar Pedidos
        public void CargarEnvios()
        {
            Vista.tblEnvios.Rows.Clear();
            AsignarEnviosDAO Envio = new AsignarEnviosDAO();
            List<Tuple<PedidoDetallado, Envio>> ListaEnvio = Envio.ObtenerEnviosAsignadosParticularesDetallados(Menu.txtCI.Text,Vista.txtBuscarFacturas.Text);

            foreach (var tuples in ListaEnvio)
            {
                Vista.tblEnvios.Rows.Add(tuples.Item1.ID, tuples.Item1.Fecha.ToString("dd-MM-yyyy"), tuples.Item1.RucCliente, tuples.Item1.TelefonoCliente,
                    tuples.Item2.CiDestinatario, tuples.Item2.TelefonoDestinatario);
            }
        }

        //Evento Seleccion Fila Factura
        public void SelectPedidossEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Factura a los textboxs
            if (Vista.tblEnvios.SelectedRows.Count > 0)
            {
                AsignarEnviosDAO Envio = new AsignarEnviosDAO();
                List<Tuple<PedidoDetallado, Envio>> EnvioResult = Envio.ObtenerEnviosAsignadosParticularesDetallados(Menu.txtCI.Text, Vista.tblEnvios.CurrentRow.Cells[0].Value.ToString());

                Vista.txtID.Text = EnvioResult[0].Item1.ID.ToString();
                Vista.txtRucCliente.Text = EnvioResult[0].Item1.RucCliente.ToString();
                Vista.txtTelefonoCliente.Text = EnvioResult[0].Item1.TelefonoCliente.ToString();
                Vista.txtDireccionCliente.Text = EnvioResult[0].Item1.DireccionCliente.ToString();
                Vista.txtCiDestinatario.Text = EnvioResult[0].Item2.CiDestinatario.ToString();
                Vista.txtTelefonoDestinatario.Text = EnvioResult[0].Item2.TelefonoDestinatario.ToString();
                Vista.txtDireccionDestinatario.Text = EnvioResult[0].Item2.DireccionDestinatario.ToString();

                Vista.btnFinalizarEnvio.Enabled = true;
            }
        }

        //Evento Limpiar Datos
        public void LimpiarEvent(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Método limpiar txts
        public void Limpiar()
        {
            LimpiarTextBox(textboxs);

            Vista.btnFinalizarEnvio.Enabled = false;
        }

        //Método cargar vehículo asignado
        public void CargarVehiculoAsignado()
        {
            AsignacionChoferVehiculoDAO vinculoChoferVehiculo = new AsignacionChoferVehiculoDAO();
            List<AsignacionChoferVehiculo> vehiculoAsignado = vinculoChoferVehiculo.ObtenerVinculoChoferVehiculo(Menu.txtCI.Text);
            Vista.txtMatricula.Text = vehiculoAsignado.Any()? vehiculoAsignado[0].Matricula.ToString():string.Empty;
            Vista.gboxMatricula.Visible = !String.IsNullOrEmpty(Vista.txtMatricula.Text);
        }

        //Evento Liberar Vehiculo
        public void LiberarEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer LIBERAR el vehiculo asignado con MATRICULA: " + Vista.txtMatricula.Text, "Liberar Vehiculo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Liberar();
                CargarVehiculoAsignado();
                Limpiar();
            }
            Liberar();
        }

        //Método liberar vehiculo
        public void Liberar()
        {
            try
            {
                AsignacionChoferVehiculoDAO vinculoChoferVehiculo = new AsignacionChoferVehiculoDAO();
                vinculoChoferVehiculo.Delete(Menu.txtCI.Text, Vista.txtMatricula.Text);
            }
            catch { }
        }

        //Evento Finalizar Envio
        public void FinalizarEnvioEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer FINALIZAR el envio con ID: " + Vista.txtID.Text, "Finalizar Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                FinalizarEnvio();
                CargarEnvios();
                Limpiar();
            }
            Liberar();
        }

        //Método finalizar envio
        public void FinalizarEnvio()
        {
            try
            {
                PedidoEnvioDAO envio = new PedidoEnvioDAO();
                envio.UpdateFinalizarEnvio(int.Parse(Vista.txtID.Text));
            }
            catch { }
        }
    }
}

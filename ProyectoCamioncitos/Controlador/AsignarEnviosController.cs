using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista AsignacionChoferVehiculo
    class AsignarEnviosController
    {
        AsignarEnviosView Vista;
        TextBox[] textboxs;

        //Constructor
        public AsignarEnviosController(AsignarEnviosView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtCiChofer, Vista.txtIdEnvio };

            //inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarChofer.TextChanged += new EventHandler(BusquedaChoferEvent);
            Vista.txtBuscarEnviosPendientes.TextChanged += new EventHandler(BusquedaEnviosPendientesEvent);
            Vista.txtBuscarEnviosAsignados.TextChanged += new EventHandler(BusquedaEnviosAsignadosEvent);

            Vista.tblChofer.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectChoferEvent);
            Vista.tblEnviosPendientes.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectEnviosPendientesEvent);
            Vista.tblEnviosAsignados.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectEnviosAsignadosEvent);

            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnVincular.Click += new EventHandler(AsignarEnvioEvent);
            Vista.btnDesvincular.Click += new EventHandler(EliminarAsignacionEnvioEvent);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarChofer();
            CargarEnviosPendientes();
            CargarEnviosAsignados();
            Limpiar();
        }

        //Evento Buscar Chofer
        public void BusquedaChoferEvent(object sender, EventArgs e)
        {
            CargarChofer();
        }
        //Evento Buscar Vehiculo
        public void BusquedaEnviosPendientesEvent(object sender, EventArgs e)
        {
            CargarEnviosPendientes();
        }
        //Evento Buscar Envios Asignados
        public void BusquedaEnviosAsignadosEvent(object sender, EventArgs e)
        {
            CargarEnviosAsignados();
        }

        //Método Obtener CI Chofer
        public void ObtenerCiChofer()
        {
            ChoferDAO chofer = new ChoferDAO();
            List<Chofer> ChoferResult = chofer.ObtenerChofer(Vista.tblChofer.CurrentRow.Cells[1].Value.ToString());
            Vista.txtCiChofer.Text = ChoferResult[0].CI;
        }

        //Evento Seleccion Fila Chofer
        public void SelectChoferEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Chofer a los textboxs
            if (Vista.tblChofer.SelectedRows.Count > 0)
            {
                ObtenerCiChofer();
                Vista.btnVincular.Enabled = true;
            }
        }

        //Método Obtener ID Envio
        public void ObtenerIdEnvio()
        {
            PedidoEnvioDAO envioPendiente = new PedidoEnvioDAO();
            List<Tuple<Pedido, Envio>> envioPendienteResult = envioPendiente.ObtenerPedidoEnvioParticular(Vista.tblEnviosPendientes.CurrentRow.Cells[0].Value.ToString());
            Vista.txtIdEnvio.Text = envioPendienteResult[0].Item1.ID.ToString();
        }

        //Evento Seleccion Fila Envios Pendientes
        public void SelectEnviosPendientesEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Envios Pendientes a los textboxs
            if (Vista.tblEnviosPendientes.SelectedRows.Count > 0)
            {
                ObtenerIdEnvio();
                Vista.btnVincular.Enabled = true;
            }
        }

        //Método Obtener CI e ID de Envio Asignado
        public void ObtenerIdCIEnvioAsignado()
        {
            AsignarEnviosDAO asignarEnvio = new AsignarEnviosDAO();
            List<AsignacionEnvio> envioAsignadoResult = asignarEnvio.ObtenerEnviosAsignados(Vista.tblEnviosAsignados.CurrentRow.Cells[0].Value.ToString());
            Vista.txtCiChofer.Text = envioAsignadoResult[0].CIChofer;
            Vista.txtIdEnvio.Text = envioAsignadoResult[0].IDPedido.ToString();
        }

        //Evento Seleccion Fila Envios Asignados
        public void SelectEnviosAsignadosEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Envios Asignados a los textboxs
            if (Vista.tblEnviosAsignados.SelectedRows.Count > 0)
            {
                ObtenerIdCIEnvioAsignado();

                Vista.btnVincular.Enabled = false;
                Vista.btnDesvincular.Enabled = true;

                Vista.tblChofer.Enabled = false;
                Vista.tblEnviosPendientes.Enabled = false;
            }
        }

        //Evento Limpiar Datos
        public void LimpiarEvent(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Evento Crear Asignacion Envio
        public void AsignarEnvioEvent(object sender, EventArgs e)
        {
            try
            {
                ValTextboxsCompletos();
                DialogResult dialogResult = MessageBox.Show("Asignar ENVIOS con ID: " + Vista.txtIdEnvio.Text + " con el CHOFER con CI: " + Vista.txtCiChofer.Text + " ?", "Asignar Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    AsignarEnvio();
                    CargarChofer();
                    CargarEnviosPendientes();
                    CargarEnviosAsignados();
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

        //Método Asignr Envio
        public void AsignarEnvio()
        {
            try
            {
                AsignarEnviosDAO asignarEnvios = new AsignarEnviosDAO();
                asignarEnvios.Create(int.Parse(Vista.txtIdEnvio.Text), Vista.txtCiChofer.Text);
            }
            catch { }
        }

        //Evento Eliminar Asignacion Envio
        public void EliminarAsignacionEnvioEvent(object sender, EventArgs e)
        {
            ValTextboxsCompletos();
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer eliminar la asignacion del ENVIO con ID: " + Vista.txtIdEnvio.Text + " con el CHOFER con CI: " + Vista.txtCiChofer.Text, "Eliminar Asignacion de Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                EliminarAsignacionEnvio();
                CargarChofer();
                CargarEnviosPendientes();
                CargarEnviosAsignados();
                Limpiar();
            }
        }

        //Método Eliminar Asignacion Envio
        public void EliminarAsignacionEnvio()
        {
            try
            {
                AsignarEnviosDAO asignarEnvios = new AsignarEnviosDAO();
                asignarEnvios.Delete(int.Parse(Vista.txtIdEnvio.Text), Vista.txtCiChofer.Text);
            }
            catch { }
        }

        //Método limpiar txts
        public void Limpiar()
        {
            Vista.tblChofer.ClearSelection();
            Vista.tblEnviosPendientes.ClearSelection();
            Vista.tblEnviosAsignados.ClearSelection();

            Vista.txtCiChofer.Text = "";
            Vista.txtIdEnvio.Text = "";

            Vista.btnVincular.Enabled = false;
            Vista.btnDesvincular.Enabled = false;

            Vista.tblChofer.Enabled = true;
            Vista.tblEnviosPendientes.Enabled = true;
        }

        //Método Cargar Chofer
        public void CargarChofer()
        {
            ChoferDAO chofer = new ChoferDAO();
            Vista.tblChofer.DataSource =
                chofer.ObtenerChofer(Vista.txtBuscarChofer.Text);

            Vista.tblChofer.Columns["Contraseña"].Visible = false;
            Vista.tblChofer.Columns["Celular"].Visible = false;
            Vista.tblChofer.Columns["FechaNacimiento"].Visible = false;
            Vista.tblChofer.Columns["Correo"].Visible = false;
            Vista.tblChofer.Columns["Direccion"].Visible = false;
            Vista.tblChofer.Columns["Cargo"].Visible = false;

            Vista.tblChofer.Columns["CI"].DisplayIndex = 0;
            Vista.tblChofer.Columns["Disponibilidad"].DisplayIndex = 3;
        }

        //Método Cargar Envios Pendientes
        public void CargarEnviosPendientes()
        {
            Vista.tblEnviosPendientes.Rows.Clear();
            PedidoEnvioDAO pedidoEnvio = new PedidoEnvioDAO();
            List<Tuple<Pedido, Envio>> ListaPedidoEnvio = pedidoEnvio.ObtenerPedidoEnvioPendiente(Vista.txtBuscarEnviosPendientes.Text);

            foreach (var tuples in ListaPedidoEnvio)
            {
                Vista.tblEnviosPendientes.Rows.Add(tuples.Item1.ID, tuples.Item1.Fecha.ToString("dd-MM-yyyy"), tuples.Item1.RucCliente, tuples.Item1.Costo,
                    tuples.Item2.DireccionDestinatario, tuples.Item2.CiDestinatario, tuples.Item2.Estado);
            }
        }

        //Método Cargar Envios Asignados
        public void CargarEnviosAsignados()
        {
            AsignarEnviosDAO asignarEnviosDAO = new AsignarEnviosDAO();
            Vista.tblEnviosAsignados.DataSource =
                asignarEnviosDAO.ObtenerEnviosAsignados(Vista.txtBuscarEnviosAsignados.Text);
        }
    }
}

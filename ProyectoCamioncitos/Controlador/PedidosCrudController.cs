using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.FacturasEnvios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Pedidos
    class PedidosCrudController : GlobalCrud
    {
        PedidosCrudView Vista;
        TextBox[] textboxs;
        ComboBox[] comboboxs;

        //Constructor
        public PedidosCrudController(PedidosCrudView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtID, Vista.txtRucCliente, Vista.txtPeso,Vista.txtCosto, Vista.txtCiDestinatario,
            Vista.txtTelefonoDestinatario, Vista.txtDireccionDestinatario, Vista.txtDetallesEnvio};
            comboboxs = new ComboBox[] { Vista.cboxIntraprovincial, Vista.cboxEstadoEnvio };

            //Inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarFacturas.TextChanged += new EventHandler(BusquedaEvent);
            Vista.tblPedidos.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectPedidossEvent);
            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnGuardar.Click += new EventHandler(CreatePedidoEvent);
            Vista.btnEliminar.Click += new EventHandler(DeletePedidoEvent);
            Vista.btnEditar.Click += new EventHandler(UpdatePedidoEvent);

            Vista.txtRucCliente.TextChanged += delegate (object sender, EventArgs e) { RUC_Limit(sender, e, Vista.txtRucCliente); };
            Vista.txtCiDestinatario.TextChanged += delegate (object sender, EventArgs e) { CI_Limit(sender, e, Vista.txtCiDestinatario); };
            Vista.txtTelefonoDestinatario.TextChanged += delegate (object sender, EventArgs e) { CelularLimit(sender, e, Vista.txtTelefonoDestinatario); };
            Vista.txtPeso.TextChanged += delegate (object sender, EventArgs e) { PesoLimit(sender, e, Vista.txtPeso); };

            Vista.txtRucCliente.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCiDestinatario.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtTelefonoDestinatario.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtPeso.KeyPress += new KeyPressEventHandler(ValDecimal_KeyPress);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarPedidos();
            Limpiar();
        }

        //Evento Buscar Pedidos
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        //Método Cargar Pedidos
        public void CargarPedidos()
        {
            Vista.tblPedidos.Rows.Clear();
            PedidoEnvioDAO pedidoEnvio = new PedidoEnvioDAO();
            List<Tuple<Pedido, Envio>> ListaPedidoEnvio = pedidoEnvio.ObtenerPedidoEnvio(Vista.txtBuscarFacturas.Text);

            foreach (var tuples in ListaPedidoEnvio)
            {
                Vista.tblPedidos.Rows.Add(tuples.Item1.ID, tuples.Item1.Fecha.ToString("dd-MM-yyyy"),tuples.Item1.RucCliente,tuples.Item1.Costo,
                    tuples.Item2.DireccionDestinatario,tuples.Item2.CiDestinatario,tuples.Item2.Estado,
                    DateTime.TryParse(tuples.Item2.FechaFinalizacion.ToString(), out DateTime dt) ?
                                                       dt.ToString("dd-MM-yyyy") : tuples.Item2.FechaFinalizacion.ToString());
            }
        }

        //Evento Seleccion Fila Pedidos
        public void SelectPedidossEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Pedidos a los textboxs
            if (Vista.tblPedidos.SelectedRows.Count > 0)
            {
                PedidoEnvioDAO facturaEnvio = new PedidoEnvioDAO();
                List<Tuple<Pedido, Envio>> FacturaResult = facturaEnvio.ObtenerPedidoEnvio(Vista.tblPedidos.CurrentRow.Cells[0].Value.ToString());

                Vista.txtID.Text = FacturaResult[0].Item1.ID.ToString();
                Vista.dtpFechaFactura.Value = FacturaResult[0].Item1.Fecha;
                Vista.txtRucCliente.Text = FacturaResult[0].Item1.RucCliente;
                Vista.cboxIntraprovincial.SelectedItem = FacturaResult[0].Item1.EnvioIntraprovincial;
                Vista.txtPeso.Text = FacturaResult[0].Item1.Peso.ToString().Replace(',', '.');
                Vista.txtCosto.Text = FacturaResult[0].Item1.Costo.ToString().Replace(',', '.');
                Vista.txtCiDestinatario.Text = FacturaResult[0].Item2.CiDestinatario;
                Vista.txtTelefonoDestinatario.Text = FacturaResult[0].Item2.TelefonoDestinatario;
                Vista.txtDireccionDestinatario.Text = FacturaResult[0].Item2.DireccionDestinatario;
                Vista.txtDetallesEnvio.Text = FacturaResult[0].Item1.Detalles;
                Vista.cboxEstadoEnvio.SelectedItem = FacturaResult[0].Item2.Estado;
                Vista.dtpFechaFinalizacionEnvio.Value = DateTime.TryParseExact(FacturaResult[0].Item2.FechaFinalizacion,
                                                       "yyyy-dd-MM",
                                                       CultureInfo.InvariantCulture,
                                                       DateTimeStyles.None, out DateTime dt) ?
                                                       DateTime.Parse(FacturaResult[0].Item2.FechaFinalizacion) : DateTime.Now;

                BotonesFaseEdit(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

                Vista.lblCosto.Visible = true;
                Vista.txtCosto.Visible = true;
                Vista.lblID.Visible = true;
                Vista.txtID.Visible = true;
                Vista.lblEstadoEnvio.Visible = true;
                Vista.cboxEstadoEnvio.Visible = true;
                Vista.cboxEstadoEnvio.Enabled = true;
                Vista.dtpFechaFinalizacionEnvio.Visible = Vista.cboxEstadoEnvio.SelectedItem.ToString() == "Pendiente" ? false : true;
                Vista.lblFechaFinalizacionEnvio.Visible = Vista.dtpFechaFinalizacionEnvio.Visible == true ? true : false;
                Vista.lblFechaFinalizacionEnvio.Enabled = Vista.dtpFechaFinalizacionEnvio.Visible == true ? true : false;
                Vista.txtRucCliente.ReadOnly = true;
                Vista.txtCiDestinatario.ReadOnly = true;
                Vista.dtpFechaFactura.Enabled = false;
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
            LimpiarComboBox(comboboxs);

            BotonesFaseCreate(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

            Vista.tblPedidos.ClearSelection();

            Vista.dtpFechaFactura.Value = DateTime.Now;
            Vista.dtpFechaFinalizacionEnvio.Value = DateTime.Now;
            Vista.lblCosto.Visible = false;
            Vista.txtCosto.Visible = false;
            Vista.lblID.Visible = false;
            Vista.txtID.Visible = false;
            Vista.lblEstadoEnvio.Visible = false;
            Vista.cboxEstadoEnvio.Visible = false;
            Vista.cboxEstadoEnvio.Enabled = false;
            Vista.lblFechaFinalizacionEnvio.Visible = false;
            Vista.dtpFechaFinalizacionEnvio.Visible = false;
            Vista.dtpFechaFinalizacionEnvio.Enabled = false;
            Vista.txtRucCliente.ReadOnly = false;
            Vista.txtCiDestinatario.ReadOnly = false;
            Vista.dtpFechaFactura.Enabled = true;
        }
        
        //Evento Crear Pedido
        public void CreatePedidoEvent(object sender, EventArgs e)
        {
            try
            {
                ValCreatePedido();
                DialogResult dialogResult = MessageBox.Show("Crear Nuevo Pedido?", "Crear Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CreatePedido();
                    CargarPedidos();
                    Limpiar();
                }
            }
            catch { }
        }

        //Método Validar que los Datos esten completos al Crear un Pedido
        public void ValCreatePedido()
        {
            TextBox[]  textboxCreate = new TextBox[] { Vista.txtRucCliente, Vista.txtPeso, Vista.txtCiDestinatario,
            Vista.txtTelefonoDestinatario, Vista.txtDireccionDestinatario, Vista.txtDetallesEnvio};
            ComboBox[] comboboxCreate = new ComboBox[] { Vista.cboxIntraprovincial };
            bool datosCompletos = !textboxCreate.Any(X => String.IsNullOrEmpty(X.Text))
                && !comboboxCreate.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Crear Pedido
        public void CreatePedido()
        {
            try
            {
                PedidoEnvioDAO pedido = new PedidoEnvioDAO();
                pedido.Create(Vista.dtpFechaFactura.Value.ToString("yyyy-MM-dd"),Vista.txtRucCliente.Text,Vista.txtDetallesEnvio.Text,
                    Vista.txtPeso.Text, Vista.cboxIntraprovincial.SelectedItem.ToString(),Vista.txtDireccionDestinatario.Text, 
                    Vista.txtCiDestinatario.Text, Vista.txtTelefonoDestinatario.Text);
            }
            catch { }
        }

        //Evento Eliminar Pedido
        public void DeletePedidoEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer eliminar el pedido del cliente con RUC: " + 
                Vista.txtRucCliente.Text, "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeletePedido();
                CargarPedidos();
                Limpiar();
            }
        }

        //Método Eliminar Pedido
        public void DeletePedido()
        {
            try
            {
                PedidoEnvioDAO pedido = new PedidoEnvioDAO();
                pedido.Delete(Vista.txtID.Text);
            }
            catch { }
        }

        //Evento Modificar Pedido
        public void UpdatePedidoEvent(object sender, EventArgs e)
        {
            try
            {
                ValUpdatePedido();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la informacion del " +
                    "pedido con ID: " + Vista.txtID.Text, "Editar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdatePedido();
                    CargarPedidos();
                    Limpiar();
                }
            }
            catch { }
        }

        //Método Validar que los Datos esten completos al Editar un Pedido
        public void ValUpdatePedido()
        {
            //Se asegura que todos los datos de los textbox esten completos
            TextBox[] textboxUpdate = new TextBox[] { Vista.txtID, Vista.txtDetallesEnvio, Vista.txtPeso, 
                Vista.txtDireccionDestinatario,Vista.txtTelefonoDestinatario};
            ComboBox[] comboboxUpdate = new ComboBox[] { Vista.cboxIntraprovincial, Vista.cboxEstadoEnvio };
            bool datosCompletos = !textboxUpdate.Any(X => String.IsNullOrEmpty(X.Text))
                && !comboboxUpdate.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Update Pedido
        public void UpdatePedido()
        {
            try
            {
                PedidoEnvioDAO pedido = new PedidoEnvioDAO();
                pedido.Update(int.Parse(Vista.txtID.Text),Vista.txtDetallesEnvio.Text, Vista.txtPeso.Text,
                    Vista.cboxIntraprovincial.SelectedItem.ToString(),Vista.txtDireccionDestinatario.Text, 
                    Vista.txtTelefonoDestinatario.Text, Vista.cboxEstadoEnvio.SelectedItem.ToString());
            }
            catch { }
        }
    }
}

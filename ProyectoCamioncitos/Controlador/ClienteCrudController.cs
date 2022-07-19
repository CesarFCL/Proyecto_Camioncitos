using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Cliente
    class ClienteCrudController : GlobalCrud
    {
        ClienteCrudView Vista;
        TextBox[] textboxs;

        //Constructor
        public ClienteCrudController(ClienteCrudView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtRUC, Vista.txtNombre, Vista.txtTelefono,
                Vista.txtCorreo, Vista.txtDireccion};

            //Inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarCliente.TextChanged += new EventHandler(BusquedaEvent);
            Vista.tblClientes.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectClientEvent);
            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnGuardar.Click += new EventHandler(CreateClienteEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteClienteEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateClienteEvent);

            Vista.txtRUC.TextChanged += new EventHandler(RucLimit);
            Vista.txtNombre.TextChanged += delegate (object sender, EventArgs e) { NombreLimit(sender, e, Vista.txtNombre); };
            Vista.txtTelefono.TextChanged += delegate (object sender, EventArgs e) { CelularLimit(sender, e, Vista.txtTelefono); };
            Vista.txtCorreo.TextChanged += delegate (object sender, EventArgs e) { CorreoLimit(sender, e, Vista.txtCorreo); };
            Vista.txtDireccion.TextChanged += delegate (object sender, EventArgs e) { DireccionLimit(sender, e, Vista.txtDireccion); };

            Vista.txtRUC.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtTelefono.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCorreo.Leave += delegate (object sender, EventArgs e) { ValCorreoE(sender, e, Vista.txtCorreo); };
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarClientes();
            Limpiar();
        }

        //Evento Buscar Clientes
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarClientes();
        }

        //Evento Seleccion Fila Cliente
        public void SelectClientEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Cliente a los textboxs
            if (Vista.tblClientes.SelectedRows.Count > 0)
            {
                ClienteDAO cliente = new ClienteDAO();
                List<Cliente> ClienteResult = cliente.ObtenerCliente(Vista.tblClientes.CurrentRow.Cells[0].Value.ToString());
                Vista.txtRUC.Text = ClienteResult[0].RUC;
                Vista.txtNombre.Text = ClienteResult[0].Nombre;
                Vista.txtTelefono.Text = ClienteResult[0].Telefono;
                Vista.txtCorreo.Text = ClienteResult[0].Correo;
                Vista.txtDireccion.Text = ClienteResult[0].Direccion;

                BotonesFaseEdit(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

                Vista.txtRUC.Enabled = false;
            }
        }

        //Evento Limpiar Datos
        public void LimpiarEvent(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Evento Crear Cliente
        public void CreateClienteEvent(object sender, EventArgs e)
        {
            try
            {
                ValDatosCompletos();
                DialogResult dialogResult = MessageBox.Show("Crear Nuevo Cliente?", "Crear Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateCliente();
                    CargarClientes();
                    Limpiar();
                }
            }
            catch { }
        }

        //Metodo Validacion Datos Completos Sirve tanto para Crear Cliente como para Update
        public void ValDatosCompletos()
        {
            //Se asegura que todos los datos de los textbox esten completos
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Crear Cliente
        public void CreateCliente()
        {
            try
            {
                ClienteDAO cliente = new ClienteDAO();
                cliente.Create(Vista.txtRUC.Text, Vista.txtNombre.Text, Vista.txtTelefono.Text,
                Vista.txtCorreo.Text, Vista.txtDireccion.Text);
            }
            catch { }
        }

        //Evento Eliminar Cliente
        public void DeleteClienteEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer eliminar al Cliente con RUC: " + Vista.txtRUC.Text, "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteCliente();
                CargarClientes();
                Limpiar();
            }
        }

        //Método Eliminar Cliente
        public void DeleteCliente()
        {
            try
            {
                ClienteDAO cliente = new ClienteDAO();
                cliente.Delete(Vista.txtRUC.Text);
            }
            catch { }
        }

        //Evento Modificar Cliente
        public void UpdateClienteEvent(object sender, EventArgs e)
        {
            try
            {
                ValDatosCompletos();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la informacion del Cliente con cedula: " + Vista.txtRUC.Text, "Editar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateCliente();
                    CargarClientes();
                    Limpiar();
                }
            }
            catch { }
        }

        //Método Update Cliente
        public void UpdateCliente()
        {
            try
            {
                ClienteDAO cliente = new ClienteDAO();
                cliente.Update(Vista.txtRUC.Text, Vista.txtNombre.Text, Vista.txtTelefono.Text,
                Vista.txtCorreo.Text, Vista.txtDireccion.Text);
            }
            catch { }
        }

        //Método Cargar Clientes
        public void CargarClientes()
        {
            ClienteDAO cliente = new ClienteDAO();
            Vista.tblClientes.DataSource =
                cliente.ObtenerCliente(Vista.txtBuscarCliente.Text);
        }

        //Método limpiar txts
        public void Limpiar()
        {
            LimpiarTextBox(textboxs);

            Vista.tblClientes.ClearSelection();
            Vista.btnEditar.Enabled = false;
            Vista.btnGuardar.Enabled = true;
            Vista.btnEliminar.Enabled = false;
            Vista.txtRUC.Enabled = true;
        }

        //Restricciones particulares Cliente
        public void RucLimit(object sender, EventArgs e)
        {
            Vista.txtRUC.MaxLength = 13;
        }
    }
}

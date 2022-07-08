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
    class ClienteCrudController
    {
        ClienteCrudView Vista;

        //Constructor
        public ClienteCrudController(ClienteCrudView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.Load += new EventHandler(Load);
            Vista.txtBuscarCliente.TextChanged += new EventHandler(Busqueda);
            Vista.tblClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgvClientes_SelectedRows);
            Vista.btnLimpiar.Click += new EventHandler(btnLimpiar);
            Vista.btnGuardar.Click += new EventHandler(CreateClienteEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteClienteEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateClienteEvent);

            Vista.txtRUC.TextChanged += new EventHandler(txtRuc_TextChanged);
            Vista.txtNombre.TextChanged += new EventHandler(txtNombre_TextChanged);
            Vista.txtTelefono.TextChanged += new EventHandler(txtTelefono_TextChanged);
            Vista.txtCorreo.TextChanged += new EventHandler(txtCorreo_TextChanged);
            Vista.txtDireccion.TextChanged += new EventHandler(txtDireccion_TextChanged);

            Vista.txtRUC.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtTelefono.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCorreo.Leave += new EventHandler(ValCorreo);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void Load(object sender, EventArgs e)
        {
            CargarClientes();
            Limpiar();
        }

        //Evento Buscar Clientes
        public void Busqueda(object sender, EventArgs e)
        {
            CargarClientes();
        }

        //Evento Seleccion Fila Cliente
        public void dgvClientes_SelectedRows(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Cliente a los textboxs
            if (Vista.tblClientes.SelectedRows.Count > 0)
            {
                ClienteDAO db = new ClienteDAO();
                List<Cliente> ClienteR = db.VerRegistros(Vista.tblClientes.CurrentRow.Cells[0].Value.ToString());
                Vista.txtRUC.Text = ClienteR[0].RUC;
                Vista.txtNombre.Text = ClienteR[0].Nombre;
                Vista.txtTelefono.Text = ClienteR[0].Telefono;
                Vista.txtCorreo.Text = ClienteR[0].Correo;
                Vista.txtDireccion.Text = ClienteR[0].Direccion;

                Vista.btnEditar.Enabled = true;
                Vista.btnGuardar.Enabled = false;
                Vista.btnEliminar.Enabled = true;
                Vista.txtRUC.Enabled = false;
            }
        }

        //Evento Limpiar Datos
        public void btnLimpiar(object sender, EventArgs e)
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
            TextBox[] textboxs = new TextBox[] { Vista.txtRUC, Vista.txtNombre, Vista.txtTelefono,
                Vista.txtCorreo, Vista.txtDireccion};
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
                ClienteDAO db = new ClienteDAO();
                db.Create(Vista.txtRUC.Text, Vista.txtNombre.Text, Vista.txtTelefono.Text,
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
                ClienteDAO db = new ClienteDAO();
                db.Delete(Vista.txtRUC.Text);
            }
            catch { }
        }

        //Evento Modificar Cliente
        //ESTO MUY PROBABLEMENTE SE TENGA QUE REFACTORIZAR !!!!!!!
        public void UpdateClienteEvent(object sender, EventArgs e)
        {
            try
            {
                ValDatosCompletos();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la infomacion del Cliente con cedula: " + Vista.txtRUC.Text, "Editar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                ClienteDAO db = new ClienteDAO();
                db.Update(Vista.txtRUC.Text, Vista.txtNombre.Text, Vista.txtTelefono.Text,
                Vista.txtCorreo.Text, Vista.txtDireccion.Text);
            }
            catch { }
        }

        //Método Cargar Clientes
        public void CargarClientes()
        {
            ClienteDAO db = new ClienteDAO();
            Vista.tblClientes.DataSource =
                db.VerRegistros(Vista.txtBuscarCliente.Text);
        }

        //Método limpiar txts
        public void Limpiar()
        {
            Vista.txtRUC.Text = "";
            Vista.txtNombre.Text = "";
            Vista.txtTelefono.Text = "";
            Vista.txtCorreo.Text = "";
            Vista.txtDireccion.Text = "";

            Vista.tblClientes.ClearSelection();
            Vista.btnEditar.Enabled = false;
            Vista.btnGuardar.Enabled = true;
            Vista.btnEliminar.Enabled = false;
            Vista.txtRUC.Enabled = true;
        }

        //Restricciones
        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            Vista.txtRUC.MaxLength = 13;
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Vista.txtNombre.MaxLength = 50;
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            Vista.txtTelefono.MaxLength = 10;
        }
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            Vista.txtCorreo.MaxLength = 50;
        }
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            Vista.txtDireccion.MaxLength = 50;
        }

        //Validaciones
        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Ingrese solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void ValCorreo(object sender, EventArgs e)
        {
            try
            {
                new MailAddress(Vista.txtCorreo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Correo no valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

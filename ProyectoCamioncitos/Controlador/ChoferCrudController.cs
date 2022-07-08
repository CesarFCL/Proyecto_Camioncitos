using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Conductor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Chofer
    class ChoferCrudController
    {
        ChoferCrudView Vista;

        //Constructor
        public ChoferCrudController(ChoferCrudView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.Load += new EventHandler(Load);
            Vista.txtBuscarChofer.TextChanged += new EventHandler(Busqueda);
            Vista.tblChofer.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgvChofer_SelectedRows);
            Vista.btnLimpiar.Click += new EventHandler(btnLimpiar);
            Vista.btnNuevoChofer.Click += new EventHandler(CreateChoferEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteChoferEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateChoferEvent);

            Vista.txtCI.TextChanged += new EventHandler(txtCI_TextChanged);
            Vista.txtNombre.TextChanged += new EventHandler(txtNombre_TextChanged);
            Vista.txtApellido.TextChanged += new EventHandler(txtApellido_TextChanged);
            Vista.txtCelular.TextChanged += new EventHandler(txtCelular_TextChanged);
            Vista.txtEdad.TextChanged += new EventHandler(txtEdad_TextChanged);
            Vista.txtCorreo.TextChanged += new EventHandler(txtCorreo_TextChanged);
            Vista.txtDireccion.TextChanged += new EventHandler(txtDireccion_TextChanged);

            Vista.txtCI.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCelular.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtEdad.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCorreo.Leave += new EventHandler(ValCorreo);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void Load(object sender, EventArgs e)
        {
            CargarChofer();
            Limpiar();
        }

        //Evento Buscar Chofer
        public void Busqueda(object sender, EventArgs e)
        {
            CargarChofer();
        }

        //Evento Seleccion Fila Chofer
        public void dgvChofer_SelectedRows(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Chofer a los textboxs
            if (Vista.tblChofer.SelectedRows.Count > 0)
            {
                ChoferDAO db = new ChoferDAO();
                List<Chofer> ChoferR = db.VerRegistros(Vista.tblChofer.CurrentRow.Cells[1].Value.ToString());
                Vista.txtCI.Text = ChoferR[0].CI;
                Vista.txtNombre.Text = ChoferR[0].Nombre;
                Vista.txtApellido.Text = ChoferR[0].Apellido;
                Vista.txtCelular.Text = ChoferR[0].Celular;
                Vista.txtEdad.Text = ChoferR[0].Edad.ToString();
                Vista.txtCorreo.Text = ChoferR[0].Correo;
                Vista.txtDireccion.Text = ChoferR[0].Direccion;
                Vista.cboxDisponibilidad.SelectedItem = ChoferR[0].Disponibilidad;

                Vista.btnEditar.Enabled = true;
                Vista.btnNuevoChofer.Enabled = false;
                Vista.btnEliminar.Enabled = true;

                Vista.txtPassword.Visible = false;
                Vista.txtPassword.Enabled = false;
                Vista.lblPassword.Visible = false;
                Vista.txtCI.Enabled = false;
                Vista.cboxDisponibilidad.Visible = true;
                Vista.cboxDisponibilidad.Enabled = true;
                Vista.lblDisponibilidad.Visible = true;
            }
        }

        //Evento Limpiar Datos
        public void btnLimpiar(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Evento Crear Chofer
        public void CreateChoferEvent(object sender, EventArgs e)
        {
            try
            {
                ValCreateChofer();
                DialogResult dialogResult = MessageBox.Show("Crear Nuevo Chofer?", "Crear Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateChofer();
                    CargarChofer();
                    Limpiar();
                }
            }
            catch { }
        }

        //Metodo Validacion Datos Completos Create Chofer
        public void ValCreateChofer()
        {
            //Se asegura que todos los datos de los textbox esten completos
            TextBox[] textboxs = new TextBox[] { Vista.txtCI, Vista.txtNombre, Vista.txtApellido, Vista.txtCelular,
                Vista.txtEdad, Vista.txtCorreo, Vista.txtDireccion, Vista.txtPassword};
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Crear Chofer
        public void CreateChofer()
        {
            try
            {
                ChoferDAO db = new ChoferDAO();
                db.Create(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text, Vista.txtCelular.Text,
                Vista.txtEdad.Text, Vista.txtCorreo.Text, Vista.txtDireccion.Text, Vista.txtPassword.Text);
            }
            catch { }
        }

        //Evento Eliminar Chofer
        public void DeleteChoferEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer eliminar al chofer con cedula: " + Vista.txtCI.Text, "Eliminar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteChofer();
                CargarChofer();
                Limpiar();
            }
        }

        //Método Eliminar Chofer
        public void DeleteChofer()
        {
            try
            {
                ChoferDAO db = new ChoferDAO();
                db.Delete(Vista.txtCI.Text);
            }
            catch { }
        }

        //Evento Modificar Chofer
        public void UpdateChoferEvent(object sender, EventArgs e)
        {
            try
            {
                ValUpdateChofer();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la infomacion del chofer con cedula: " + Vista.txtCI.Text, "Editar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateChofer();
                    CargarChofer();
                    Limpiar();
                }
            }
            catch { }
        }

        //Metodo Validacion Datos Completos Update Chofer
        public void ValUpdateChofer()
        {
            //Se asegura que todos los datos de los textbox esten completos
            TextBox[] textboxs = new TextBox[] { Vista.txtCI, Vista.txtNombre, Vista.txtApellido, Vista.txtCelular,
                Vista.txtEdad, Vista.txtCorreo, Vista.txtDireccion};
            ComboBox[] combobox = new ComboBox[] { Vista.cboxDisponibilidad };
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text))
                && !combobox.Any(X => String.IsNullOrEmpty(X.Text));

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
                ChoferDAO db = new ChoferDAO();
                db.Update(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text,
                    Vista.txtCelular.Text, Vista.txtEdad.Text, Vista.txtCorreo.Text, Vista.txtDireccion.Text,
                    Vista.cboxDisponibilidad.SelectedItem.ToString());

            }
            catch { }
        }

        //Método limpiar txts
        public void Limpiar()
        {
            Vista.txtCI.Text = "";
            Vista.txtNombre.Text = "";
            Vista.txtApellido.Text = "";
            Vista.txtCelular.Text = "";
            Vista.txtEdad.Text = "";
            Vista.txtCorreo.Text = "";
            Vista.txtDireccion.Text = "";
            Vista.txtPassword.Text = "";
            Vista.cboxDisponibilidad.SelectedItem = null;

            Vista.tblChofer.ClearSelection();

            Vista.btnEditar.Enabled = false;
            Vista.btnEliminar.Enabled = false;
            Vista.btnNuevoChofer.Enabled = true;

            Vista.txtPassword.Visible = true;
            Vista.txtPassword.Enabled = true;
            Vista.lblPassword.Visible = true;
            Vista.txtCI.Enabled = true;
            Vista.cboxDisponibilidad.Enabled = false;
            Vista.cboxDisponibilidad.Visible = false;
            Vista.lblDisponibilidad.Visible = false;
        }

        //Método Cargar Chofer
        public void CargarChofer()
        {
            ChoferDAO db = new ChoferDAO();
            Vista.tblChofer.DataSource =
                db.VerRegistros(Vista.txtBuscarChofer.Text);

            Vista.tblChofer.Columns["Contraseña"].Visible = false;
            Vista.tblChofer.Columns["Celular"].Visible = false;
            Vista.tblChofer.Columns["Edad"].Visible = false;
            Vista.tblChofer.Columns["Correo"].Visible = false;
            Vista.tblChofer.Columns["Direccion"].Visible = false;
            Vista.tblChofer.Columns["Cargo"].Visible = false;

            Vista.tblChofer.Columns["CI"].DisplayIndex = 0;
            Vista.tblChofer.Columns["Disponibilidad"].DisplayIndex = 3;
        }

        //Restricciones
        private void txtCI_TextChanged(object sender, EventArgs e)
        {
            Vista.txtCI.MaxLength = 10;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Vista.txtNombre.MaxLength = 50;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            Vista.txtApellido.MaxLength = 50;
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            Vista.txtCelular.MaxLength = 10;
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            Vista.txtEdad.MaxLength = 3;
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

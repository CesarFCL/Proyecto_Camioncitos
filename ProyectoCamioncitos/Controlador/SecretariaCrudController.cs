using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Secretaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Secretaria
    class SecretariaCrudController
    {
        SecretariaCrudView Vista;

        //Constructor
        public SecretariaCrudController(SecretariaCrudView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.Load += new EventHandler(Load);
            Vista.txtBuscarSecretaria.TextChanged += new EventHandler(Busqueda);
            Vista.tblSecretaria.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvSecretaria_SelectedRows);
            Vista.btnLimpiar.Click += new EventHandler(btnLimpiar);
            Vista.btnGuardar.Click += new EventHandler(CreateSecretariaEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteSecretariaEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateSecretariaEvent);

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
            CargarSecretaria();
            Limpiar();
        }

        //Evento Buscar Secretaria
        public void Busqueda(object sender, EventArgs e)
        {
            CargarSecretaria();
        }

        //Evento Seleccion Fila Secretaria
        public void dgvSecretaria_SelectedRows(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Secretaria a los textboxs
            if (Vista.tblSecretaria.SelectedRows.Count > 0)
            {
                SecretariaDAO db = new SecretariaDAO();
                List<Secretaria> SecretariaR = db.VerRegistros(Vista.tblSecretaria.CurrentRow.Cells[1].Value.ToString());
                Vista.txtCI.Text = SecretariaR[0].CI;
                Vista.txtNombre.Text = SecretariaR[0].Nombre;
                Vista.txtApellido.Text = SecretariaR[0].Apellido;
                Vista.txtCelular.Text = SecretariaR[0].Celular;
                Vista.txtEdad.Text = SecretariaR[0].Edad.ToString();
                Vista.txtCorreo.Text = SecretariaR[0].Correo;
                Vista.txtDireccion.Text = SecretariaR[0].Direccion;

                Vista.btnEditar.Enabled = true;
                Vista.btnGuardar.Enabled = false;
                Vista.btnEliminar.Enabled = true;

                Vista.txtPassword.Visible = false;
                Vista.txtPassword.Enabled = false;
                Vista.lblPassword.Visible = false;
                Vista.txtCI.Enabled = false;
            }
        }

        //Evento Limpiar Datos
        public void btnLimpiar(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Evento Crear Secretaria
        public void CreateSecretariaEvent(object sender, EventArgs e)
        {
            try
            {
                ValCreateSecretaria();
                DialogResult dialogResult = MessageBox.Show("Crear Nueva Secretaria?", "Crear Secretaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateSecretaria();
                    CargarSecretaria();
                    Limpiar();
                }
            }
            catch { }
        }

        //Metodo Validacion Datos Completos Create Secretaria
        public void ValCreateSecretaria()
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

        //Método Crear Secretaria
        public void CreateSecretaria()
        {
            try
            {
                SecretariaDAO db = new SecretariaDAO();
                db.Create(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text, Vista.txtCelular.Text,
                Vista.txtEdad.Text, Vista.txtCorreo.Text, Vista.txtDireccion.Text, Vista.txtPassword.Text);
            }
            catch { }
        }

        //Evento Eliminar Secretaria
        public void DeleteSecretariaEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer eliminar la secretaria con cedula: " + Vista.txtCI.Text, "Eliminar Secretaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteSecretaria();
                CargarSecretaria();
                Limpiar();
            }
        }

        //Método Eliminar Secretaria
        public void DeleteSecretaria()
        {
            try
            {
                SecretariaDAO db = new SecretariaDAO();
                db.Delete(Vista.txtCI.Text);
            }
            catch { }
        }

        //Evento Modificar Secretaria
        public void UpdateSecretariaEvent(object sender, EventArgs e)
        {
            try
            {
                ValUpdateSecretaria();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la informacion de la secretaria con cedula: " + Vista.txtCI.Text, "Editar Secretaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateSecretaria();
                    CargarSecretaria();
                    Limpiar();
                }
            }
            catch { }
        }

        //Metodo Validacion Datos Completos Update Chofer
        public void ValUpdateSecretaria()
        {
            //Se asegura que todos los datos de los textbox esten completos
            TextBox[] textboxs = new TextBox[] { Vista.txtCI, Vista.txtNombre, Vista.txtApellido, Vista.txtCelular,
                Vista.txtEdad, Vista.txtCorreo, Vista.txtDireccion};
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text));

            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Update Chofer
        public void UpdateSecretaria()
        {
            try
            {
                SecretariaDAO db = new SecretariaDAO();
                db.Update(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text,
                    Vista.txtCelular.Text, Vista.txtEdad.Text, Vista.txtCorreo.Text, Vista.txtDireccion.Text);

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

            Vista.tblSecretaria.ClearSelection();

            Vista.btnEditar.Enabled = false;
            Vista.btnEliminar.Enabled = false;
            Vista.btnGuardar.Enabled = true;

            Vista.txtPassword.Visible = true;
            Vista.txtPassword.Enabled = true;
            Vista.lblPassword.Visible = true;
            Vista.txtCI.Enabled = true;
        }

        //Método Cargar Secretaria
        public void CargarSecretaria()
        {
            SecretariaDAO db = new SecretariaDAO();
            Vista.tblSecretaria.DataSource =
                db.VerRegistros(Vista.txtBuscarSecretaria.Text);

            Vista.tblSecretaria.Columns["Contraseña"].Visible = false;
            Vista.tblSecretaria.Columns["Celular"].Visible = false;
            Vista.tblSecretaria.Columns["Edad"].Visible = false;
            Vista.tblSecretaria.Columns["Correo"].Visible = false;
            Vista.tblSecretaria.Columns["Direccion"].Visible = false;
            Vista.tblSecretaria.Columns["Cargo"].Visible = false;
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

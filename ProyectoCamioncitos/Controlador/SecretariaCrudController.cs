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
    class SecretariaCrudController : GlobalCrud
    {
        SecretariaCrudView Vista;
        TextBox[] textboxs;

        //Constructor
        public SecretariaCrudController(SecretariaCrudView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtCI, Vista.txtNombre, Vista.txtApellido, Vista.txtCelular,
                Vista.txtCorreo, Vista.txtDireccion, Vista.txtPassword};

            //Inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarSecretaria.TextChanged += new EventHandler(BusquedaEvent);
            Vista.tblSecretaria.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectSecretariaEvent);
            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnGuardar.Click += new EventHandler(CreateSecretariaEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteSecretariaEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateSecretariaEvent);

            Vista.txtCI.TextChanged += delegate (object sender, EventArgs e) { CI_Limit(sender, e, Vista.txtCI); };
            Vista.txtNombre.TextChanged += delegate (object sender, EventArgs e) { NombreLimit(sender, e, Vista.txtNombre); };
            Vista.txtApellido.TextChanged += delegate (object sender, EventArgs e) { ApellidoLimit(sender, e, Vista.txtApellido); };
            Vista.txtCelular.TextChanged += delegate (object sender, EventArgs e) { CelularLimit(sender, e, Vista.txtCelular); };
            Vista.txtCorreo.TextChanged += delegate (object sender, EventArgs e) { CorreoLimit(sender, e, Vista.txtCorreo); };
            Vista.txtDireccion.TextChanged += delegate (object sender, EventArgs e) { DireccionLimit(sender, e, Vista.txtDireccion); };
            Vista.txtPassword.TextChanged += delegate (object sender, EventArgs e) { PasswordLimit(sender, e, Vista.txtDireccion); };

            Vista.txtCI.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCelular.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtCorreo.Leave += delegate (object sender, EventArgs e) { ValCorreoE(sender, e, Vista.txtCorreo); };
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarSecretaria();
            Limpiar();
        }

        //Evento Buscar Secretaria
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarSecretaria();
        }

        //Método Obtener Datos Secretaria
        public void ObtenerDatosSecretaria()
        {
            SecretariaDAO secretaria = new SecretariaDAO();
            List<Secretaria> SecretariaResult = secretaria.ObtenerSecretaria(Vista.tblSecretaria.CurrentRow.Cells[1].Value.ToString());
            Vista.txtCI.Text = SecretariaResult[0].CI;
            Vista.txtNombre.Text = SecretariaResult[0].Nombre;
            Vista.txtApellido.Text = SecretariaResult[0].Apellido;
            Vista.txtCelular.Text = SecretariaResult[0].Celular;
            Vista.dtpFechaNacimiento.Value = SecretariaResult[0].FechaNacimiento;
            Vista.txtCorreo.Text = SecretariaResult[0].Correo;
            Vista.txtDireccion.Text = SecretariaResult[0].Direccion;
        }

        //Evento Seleccion Fila Secretaria
        public void SelectSecretariaEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Secretaria a los textboxs
            if (Vista.tblSecretaria.SelectedRows.Count > 0)
            {
                ObtenerDatosSecretaria();

                BotonesFaseEdit(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

                Vista.txtPassword.Visible = false;
                Vista.txtPassword.Enabled = false;
                Vista.lblPassword.Visible = false;
                Vista.txtCI.Enabled = false;
            }
        }

        //Evento Limpiar Datos
        public void LimpiarEvent(object sender, EventArgs e)
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
                SecretariaDAO secretaria = new SecretariaDAO();
                secretaria.Create(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text, Vista.txtCelular.Text,
                Vista.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"), Vista.txtCorreo.Text, Vista.txtDireccion.Text, Vista.txtPassword.Text);
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
                SecretariaDAO secretaria = new SecretariaDAO();
                secretaria.Delete(Vista.txtCI.Text);
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

        //Metodo Validacion Datos Completos Update Secretaria
        public void ValUpdateSecretaria()
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

        //Método Update Secretaria
        public void UpdateSecretaria()
        {
            try
            {
                SecretariaDAO secretaria = new SecretariaDAO();
                secretaria.Update(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text,
                    Vista.txtCelular.Text, Vista.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"), Vista.txtCorreo.Text, Vista.txtDireccion.Text);

            }
            catch { }
        }

        //Método limpiar txts
        public void Limpiar()
        {
            LimpiarTextBox(textboxs);

            BotonesFaseCreate(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

            Vista.tblSecretaria.ClearSelection();

            Vista.dtpFechaNacimiento.Value = DateTime.Now;
            Vista.txtPassword.Visible = true;
            Vista.txtPassword.Enabled = true;
            Vista.lblPassword.Visible = true;
            Vista.txtCI.Enabled = true;
        }

        //Método Cargar Secretaria
        public void CargarSecretaria()
        {
            SecretariaDAO secretaria = new SecretariaDAO();
            Vista.tblSecretaria.DataSource =
                secretaria.ObtenerSecretaria(Vista.txtBuscarSecretaria.Text);

            //Columnas que no necesitan ser visualizadas en la tabla
            Vista.tblSecretaria.Columns["Contraseña"].Visible = false;
            Vista.tblSecretaria.Columns["Celular"].Visible = false;
            Vista.tblSecretaria.Columns["FechaNacimiento"].Visible = false;
            Vista.tblSecretaria.Columns["Correo"].Visible = false;
            Vista.tblSecretaria.Columns["Direccion"].Visible = false;
            Vista.tblSecretaria.Columns["Cargo"].Visible = false;
        }
    }
}

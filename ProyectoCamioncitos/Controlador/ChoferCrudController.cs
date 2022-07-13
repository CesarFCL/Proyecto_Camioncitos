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
    class ChoferCrudController : GlobalCrud
    {
        ChoferCrudView Vista;
        TextBox[] textboxs;
        //Constructor
        public ChoferCrudController(ChoferCrudView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtCI, Vista.txtNombre, Vista.txtApellido, Vista.txtCelular, 
                Vista.txtCorreo, Vista.txtDireccion, Vista.txtPassword};

            //inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarChofer.TextChanged += new EventHandler(BusquedaEvent);
            Vista.tblChofer.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectChoferEvent);
            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnGuardar.Click += new EventHandler(CreateChoferEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteChoferEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateChoferEvent);

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
            CargarChofer();
            Limpiar();
        }

        //Evento Buscar Chofer
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarChofer();
        }

        //Evento Seleccion Fila Chofer
        public void SelectChoferEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Chofer a los textboxs
            if (Vista.tblChofer.SelectedRows.Count > 0)
            {
                ChoferDAO chofer = new ChoferDAO();
                List<Chofer> ChoferResult = chofer.VerRegistros(Vista.tblChofer.CurrentRow.Cells[1].Value.ToString());
                Vista.txtCI.Text = ChoferResult[0].CI;
                Vista.txtNombre.Text = ChoferResult[0].Nombre;
                Vista.txtApellido.Text = ChoferResult[0].Apellido;
                Vista.txtCelular.Text = ChoferResult[0].Celular;
                Vista.dtpFechaNacimiento.Value = ChoferResult[0].FechaNacimiento;
                Vista.txtCorreo.Text = ChoferResult[0].Correo;
                Vista.txtDireccion.Text = ChoferResult[0].Direccion;
                Vista.cboxDisponibilidad.SelectedItem = ChoferResult[0].Disponibilidad;

                BotonesFaseEdit(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

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
        public void LimpiarEvent(object sender, EventArgs e)
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

            bool datosCompletos = textboxs.Any(X => String.IsNullOrEmpty(X.Text));
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
                ChoferDAO chofer = new ChoferDAO();
                chofer.Create(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text, Vista.txtCelular.Text,
                Vista.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"), Vista.txtCorreo.Text, Vista.txtDireccion.Text, Vista.txtPassword.Text);
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
                ChoferDAO chofer = new ChoferDAO();
                chofer.Delete(Vista.txtCI.Text);
            }
            catch { }
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
                    Limpiar();
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
            ComboBox[] comboboxUpdate = new ComboBox[] { Vista.cboxDisponibilidad };
            bool datosCompletos = !textboxsUpdate.Any(X => String.IsNullOrEmpty(X.Text))
                && !comboboxUpdate.Any(X => String.IsNullOrEmpty(X.Text));

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
                chofer.Update(Vista.txtCI.Text, Vista.txtNombre.Text, Vista.txtApellido.Text,
                    Vista.txtCelular.Text, Vista.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"), Vista.txtCorreo.Text, Vista.txtDireccion.Text,
                    Vista.cboxDisponibilidad.SelectedItem.ToString());

            }
            catch { }
        }

        //Método limpiar txts
        public void Limpiar()
        {
            LimpiarTextBox(textboxs);

            Vista.dtpFechaNacimiento.Value = DateTime.Now;

            BotonesFaseCreate(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

            Vista.tblChofer.ClearSelection();

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
            ChoferDAO chofer = new ChoferDAO();
            Vista.tblChofer.DataSource =
                chofer.VerRegistros(Vista.txtBuscarChofer.Text);

            Vista.tblChofer.Columns["Contraseña"].Visible = false;
            Vista.tblChofer.Columns["Celular"].Visible = false;
            Vista.tblChofer.Columns["FechaNacimiento"].Visible = false;
            Vista.tblChofer.Columns["Correo"].Visible = false;
            Vista.tblChofer.Columns["Direccion"].Visible = false;
            Vista.tblChofer.Columns["Cargo"].Visible = false;

            Vista.tblChofer.Columns["CI"].DisplayIndex = 0;
            Vista.tblChofer.Columns["Disponibilidad"].DisplayIndex = 3;
        }
    }
}

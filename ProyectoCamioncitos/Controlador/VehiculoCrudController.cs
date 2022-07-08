using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista CRUD Vehiculo
    class VehiculoCrudController
    {
        VehiculoCrudView Vista;

        //Constructor
        public VehiculoCrudController(VehiculoCrudView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.Load += new EventHandler(Load);
            Vista.txtBuscarVehiculo.TextChanged += new EventHandler(Busqueda);
            Vista.tblVehiculos.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvVehiculos_SelectedRows);
            Vista.btnLimpiar.Click += new EventHandler(btnLimpiar);
            Vista.btnGuardar.Click += new EventHandler(CreateVehicleEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteVehicleEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateVehicleEvent);

            Vista.txtMatricula.TextChanged += new EventHandler(txtMatricula_TextChanged);
            Vista.txtMarca.TextChanged += new EventHandler(txtMarca_TextChanged);
            Vista.txtYear.TextChanged += new EventHandler(txtYear_TextChanged);

            Vista.txtYear.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void Load(object sender, EventArgs e)
        {
            CargarVehiculos();
            CargarCboxTipo();
            Limpiar();
        }

        //Evento Buscar Vehiculos
        public void Busqueda(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        //Evento Seleccion Fila Vehiculo
        public void dgvVehiculos_SelectedRows(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Vehiculo a los textboxs
            if (Vista.tblVehiculos.SelectedRows.Count > 0)
            {
                VehiculoDAO db = new VehiculoDAO();
                List<Vehiculo> VehiculoR = db.VerRegistros(Vista.tblVehiculos.CurrentRow.Cells[0].Value.ToString());
                Vista.txtMatricula.Text = VehiculoR[0].Matricula;
                Vista.txtMarca.Text = VehiculoR[0].Marca;
                Vista.txtYear.Text = VehiculoR[0].Year;
                Vista.cboxTipo.SelectedItem = VehiculoR[0].Tipo;
                Vista.cboxDisponibilidad.SelectedItem = VehiculoR[0].Disponibilidad;

                Vista.btnEditar.Enabled = true;
                Vista.btnGuardar.Enabled = false;
                Vista.btnEliminar.Enabled = true;
                Vista.txtMatricula.Enabled = false;
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

        //Evento Crear Vehiculo
        public void CreateVehicleEvent (object sender, EventArgs e)
        {
            try
            {
                ValCreateVehicle();
                DialogResult dialogResult = MessageBox.Show("Crear Nuevo Vehiculo?", "Crear Vehiculo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateVehicle();
                    CargarVehiculos();
                    Limpiar();
                }
            }
            catch { }
        }

        //Método Validar que los Datos esten completos al Crear un vehiculo
        public void ValCreateVehicle()
        {
            TextBox[] textboxs = new TextBox[] { Vista.txtMatricula, Vista.txtMarca, Vista.txtYear };
            ComboBox[] combobox = new ComboBox[] { Vista.cboxTipo };
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text))
                && !combobox.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Crear Vehiculo
        public void CreateVehicle()
        {
            try
            {
                VehiculoDAO db = new VehiculoDAO();
                db.Create(Vista.txtMatricula.Text, Vista.txtMarca.Text, Vista.txtYear.Text, Vista.cboxTipo.SelectedItem.ToString());
            }
            catch { }
        }

        //Evento Eliminar Vehiculo
        public void DeleteVehicleEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer eliminar al vehiculo con matricula: " + Vista.txtMatricula.Text, "Eliminar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteVehicle();
                CargarVehiculos();
                Limpiar();
            }
        }

        //Método Eliminar Vehiculo
        public void DeleteVehicle()
        {
            try
            {
                VehiculoDAO db = new VehiculoDAO();
                db.Delete(Vista.txtMatricula.Text);
            }
            catch { }
        }

        //Evento Modificar Vehiculo
        //ESTO MUY PROBABLEMENTE SE TENGA QUE REFACTORIZAR !!!!!!!
        public void UpdateVehicleEvent(object sender, EventArgs e)
        {
            try
            {
                ValUpdateVehicle();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la infomacion del vehiculo con matricula: " + Vista.txtMatricula.Text, "Editar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateVehicle();
                    CargarVehiculos();
                    Limpiar();
                }
            }
            catch { }
        }

        //Método Update Vehiculo
        public void UpdateVehicle()
        {
            try
            {
                VehiculoDAO db = new VehiculoDAO(); ;
                db.Update(Vista.txtMatricula.Text, Vista.txtMarca.Text, Vista.txtYear.Text,
                    Vista.cboxTipo.SelectedItem.ToString(), Vista.cboxDisponibilidad.SelectedItem.ToString());
            }
            catch { }
        }

        //Método Validar que los Datos esten completos al Actualizar un vehiculo
        public void ValUpdateVehicle()
        {
            TextBox[] textboxs = new TextBox[] { Vista.txtMatricula, Vista.txtMarca, Vista.txtYear };
            ComboBox[] combobox = new ComboBox[] { Vista.cboxDisponibilidad, Vista.cboxTipo };
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text))
                && !combobox.Any(X => String.IsNullOrEmpty(X.Text));
            if (!datosCompletos)
            {
                throw new DatosIncompletosException();
            }
        }

        //Método Cargar Vehiculos
        public void CargarVehiculos()
        {
            VehiculoDAO db = new VehiculoDAO();
            Vista.tblVehiculos.DataSource =
                db.VerRegistros(Vista.txtBuscarVehiculo.Text);

            Vista.tblVehiculos.Columns["Year"].Visible = false;
        }
        //Método limpiar txts
        public void Limpiar()
        {
            Vista.txtMatricula.Text = "";
            Vista.txtMarca.Text = "";
            Vista.txtYear.Text = "";
            Vista.cboxTipo.SelectedItem = null;
            Vista.cboxDisponibilidad.SelectedItem = null;

            Vista.tblVehiculos.ClearSelection();
            Vista.btnEditar.Enabled = false;
            Vista.btnGuardar.Enabled = true;
            Vista.btnEliminar.Enabled = false;
            Vista.txtMatricula.Enabled = true;
            Vista.cboxDisponibilidad.Enabled = false;
            Vista.cboxDisponibilidad.Visible = false;
            Vista.lblDisponibilidad.Visible = false;
        }

        //Metodo Cargar el combobox de tipos de vehiculos
        public void CargarCboxTipo()
        {
            try
            {
                VehiculoDAO db = new VehiculoDAO();
                Vista.cboxTipo.DataSource = db.CargarListaTipos();
            }
            catch
            {
                Vista.Close();
            }
        }

        //Restricciones
        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            Vista.txtMatricula.MaxLength = 10;
        }
        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            Vista.txtMarca.MaxLength = 20;
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            Vista.txtYear.MaxLength = 5;
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
    }
}

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
    class VehiculoCrudController : GlobalCrud
    {
        VehiculoCrudView Vista;
        TextBox[] textboxs;
        ComboBox[] combobox;

        //Constructor
        public VehiculoCrudController(VehiculoCrudView view)
        {
            Vista = view;
            textboxs = new TextBox[] { Vista.txtMatricula, Vista.txtMarca, Vista.txtYear };
            combobox = new ComboBox[] { Vista.cboxDisponibilidad, Vista.cboxTipo };

            //Inicializar eventos
            Vista.Load += new EventHandler(LoadEvent);
            Vista.txtBuscarVehiculo.TextChanged += new EventHandler(BusquedaEvent);
            Vista.tblVehiculos.CellMouseClick += new DataGridViewCellMouseEventHandler(SelectVehicleEvent);
            Vista.btnLimpiar.Click += new EventHandler(LimpiarEvent);
            Vista.btnGuardar.Click += new EventHandler(CreateVehicleEvent);
            Vista.btnEliminar.Click += new EventHandler(DeleteVehicleEvent);
            Vista.btnEditar.Click += new EventHandler(UpdateVehicleEvent);

            Vista.txtMatricula.TextChanged += new EventHandler(MatriculaLimit);
            Vista.txtMarca.TextChanged += new EventHandler(MarcaLimit);
            Vista.txtYear.TextChanged += new EventHandler(YearLimit);

            Vista.txtYear.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
        }

        //Evento Cargar Vista para cuanto es abierta la Vista
        public void LoadEvent(object sender, EventArgs e)
        {
            CargarVehiculos();
            CargarCboxTiposVehiculos();
            Limpiar();
        }

        //Evento Buscar Vehiculos
        public void BusquedaEvent(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        //Evento Seleccion Fila Vehiculo
        public void SelectVehicleEvent(object sender, EventArgs e)
        {
            //Pasa los datos de la fila seleccionada de la tabla Vehiculo a los textboxs
            if (Vista.tblVehiculos.SelectedRows.Count > 0)
            {
                VehiculoDAO vehiculo = new VehiculoDAO();
                List<Vehiculo> VehiculoResult = vehiculo.VerRegistros(Vista.tblVehiculos.CurrentRow.Cells[0].Value.ToString());
                Vista.txtMatricula.Text = VehiculoResult[0].Matricula;
                Vista.txtMarca.Text = VehiculoResult[0].Marca;
                Vista.txtYear.Text = VehiculoResult[0].Year;
                Vista.cboxTipo.SelectedItem = VehiculoResult[0].Tipo;
                Vista.cboxDisponibilidad.SelectedItem = VehiculoResult[0].Disponibilidad;

                BotonesFaseEdit(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

                Vista.txtMatricula.Enabled = false;
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

        //Evento Crear Vehiculo
        public void CreateVehicleEvent(object sender, EventArgs e)
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
            ComboBox[] comboboxCreate = new ComboBox[] { Vista.cboxTipo };
            bool datosCompletos = !textboxs.Any(X => String.IsNullOrEmpty(X.Text))
                && !comboboxCreate.Any(X => String.IsNullOrEmpty(X.Text));
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
                VehiculoDAO vehiculo = new VehiculoDAO();
                vehiculo.Create(Vista.txtMatricula.Text, Vista.txtMarca.Text, Vista.txtYear.Text, Vista.cboxTipo.SelectedItem.ToString());
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
                VehiculoDAO vehiculo = new VehiculoDAO();
                vehiculo.Delete(Vista.txtMatricula.Text);
            }
            catch { }
        }

        //Evento Modificar Vehiculo
        public void UpdateVehicleEvent(object sender, EventArgs e)
        {
            try
            {
                ValUpdateVehicle();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de querer editar la informacion del vehiculo con matricula: " + Vista.txtMatricula.Text, "Editar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                VehiculoDAO vehiculo = new VehiculoDAO(); ;
                vehiculo.Update(Vista.txtMatricula.Text, Vista.txtMarca.Text, Vista.txtYear.Text,
                    Vista.cboxTipo.SelectedItem.ToString(), Vista.cboxDisponibilidad.SelectedItem.ToString());
            }
            catch { }
        }

        //Método Validar que los Datos esten completos al Actualizar un vehiculo
        public void ValUpdateVehicle()
        {
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
            VehiculoDAO vehiculo = new VehiculoDAO();
            Vista.tblVehiculos.DataSource =
                vehiculo.VerRegistros(Vista.txtBuscarVehiculo.Text);

            Vista.tblVehiculos.Columns["Year"].Visible = false;
        }
        //Método limpiar txts
        public void Limpiar()
        {
            LimpiarTextBox(textboxs);
            LimpiarComboBox(combobox);

            Vista.tblVehiculos.ClearSelection();

            BotonesFaseCreate(Vista.btnGuardar, Vista.btnEliminar, Vista.btnEditar);

            Vista.txtMatricula.Enabled = true;
            Vista.cboxDisponibilidad.Enabled = false;
            Vista.cboxDisponibilidad.Visible = false;
            Vista.lblDisponibilidad.Visible = false;
        }

        //Metodo Cargar el combobox de tipos de vehiculos
        public void CargarCboxTiposVehiculos()
        {
            try
            {
                VehiculoDAO vehiculo = new VehiculoDAO();
                Vista.cboxTipo.DataSource = vehiculo.CargarListaTiposVehiculos();
            }
            catch
            { }
        }

        //Restricciones Particulares Vehiculo
        public void MatriculaLimit(object sender, EventArgs e)
        {
            Vista.txtMatricula.MaxLength = 10;
        }
        public void MarcaLimit(object sender, EventArgs e)
        {
            Vista.txtMarca.MaxLength = 20;
        }
        public void YearLimit(object sender, EventArgs e)
        {
            Vista.txtYear.MaxLength = 5;
        }
    }
}

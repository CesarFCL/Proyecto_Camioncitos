using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista.Chofer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista Menu Chofer
    public class ChoferMenuController : GlobalMenu
    {
        ChoferMenuView Vista;
        //Constructor
        public ChoferMenuController(ChoferMenuView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.pCerrar.Click += delegate (object sender, EventArgs e) { CerrarEvent(sender, e, Vista); };
            Vista.btnSalir.Click += delegate (object sender, EventArgs e) { CerrarEvent(sender, e, Vista); };
            Vista.pMinimizar.Click += delegate (object sender, EventArgs e) { MinimizarEvent(sender, e, Vista); };
            Vista.btnInforme.Click += new EventHandler(AbrirFormChoferStatusEvent);
            Vista.btnEncargos.Click += new EventHandler(AbrirFormChoferStatusEvent);
            Vista.btnPerfil.Click += new EventHandler(AbrirFormChoferStatusEvent);
            Vista.FormClosed += delegate (object sender, FormClosedEventArgs e) { CerrarFormInternoEvent(sender, e, Vista.panelForms); };
            Vista.TopPanel.MouseDown += delegate (object sender, MouseEventArgs e) { DragPanelEvent(sender, e, Vista); };
            Vista.Load += new EventHandler(ActualizarStatusChoferEvent);
            Vista.pStatus.Click += new EventHandler(CambiarStatusChoferEvent);
        }

        //Evento Abrir Vista Chofer Status
        public void AbrirFormChoferStatusEvent(object sender, EventArgs e)
        {
            AbrirForm(new ChoferProfileView(Vista), Vista.panelForms);

            ActiveColorBtn(Vista.btnPerfil, Vista.picChofer);
            InactiveColorBtn(Vista.btnInforme, Vista.picCliente);
            InactiveColorBtn(Vista.btnEncargos, Vista.picVehiculo);
        }

        //Evento Abrir Vista 
        public void AbrirFormChoferInformeEventt(object sender, EventArgs e)
        {

            ActiveColorBtn(Vista.btnInforme, Vista.picCliente);
            InactiveColorBtn(Vista.btnPerfil, Vista.picChofer);
            InactiveColorBtn(Vista.btnEncargos, Vista.picVehiculo);
        }

        //Evento Abrir Vista
        public void AbrirFormChoferEncargosEvent(object sender, EventArgs e)
        {

            ActiveColorBtn(Vista.btnEncargos, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnPerfil, Vista.picChofer);
            InactiveColorBtn(Vista.btnInforme, Vista.picCliente);
        }

        //Evento Abrir Vista Disponibilidad Chofer Vehiculo
        public void AbrirFormDisponibilidadEvent(object sender, EventArgs e)
        {
        }

        //Evento Actualizar Status
        public void ActualizarStatusChoferEvent(object sender, EventArgs e)
        {
            ActualizarStatuChofer();
        }

        //Evento Cambiar Status
        public void CambiarStatusChoferEvent(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de querer cambiar a " + ObtenerDisponibilidadObjetivo(), "Editar Disponibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                UpdateDisponibilidadChofer();
                ActualizarStatuChofer();
            }
        }

        //Método modificar disponibilidad chofer
        public void UpdateDisponibilidadChofer()
        {
            try
            {
                ChoferDAO chofer = new ChoferDAO();
                chofer.UpdateDisponibilidad(Vista.txtCI.Text, ObtenerDisponibilidadObjetivo());
            }
            catch { }
        }

        //Método actualizar disponibilidad chofer
        public void ActualizarStatuChofer()
        {
            ChoferDAO chofer = new ChoferDAO();
            List<Chofer> ChoferResult = chofer.ObtenerChofer(Vista.txtCI.Text);
            Vista.pStatus.BackColor = ChoferResult[0].Disponibilidad == "Disponible" ? Color.FromArgb(0, 255, 0) : Color.FromArgb(255, 0, 0);
        }

        //Método actualizar disponibilidad chofer
        public string ObtenerDisponibilidadObjetivo()
        {
            string DisponibilidadObjetivo = Vista.pStatus.BackColor == Color.FromArgb(0, 255, 0) ? "No Disponible" : "Disponible";
            return DisponibilidadObjetivo;
        }
    }
}

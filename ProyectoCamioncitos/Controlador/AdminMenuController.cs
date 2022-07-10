using ProyectoCamioncitos.Vista;
using ProyectoCamioncitos.Vista.Conductor;
using ProyectoCamioncitos.Vista.Secretaria;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista Menu Secretaria
    public class AdminMenuController: GlobalMenu
    {
        AdminMenuView Vista;
        //Constructor
        public AdminMenuController(AdminMenuView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.pCerrar.Click += new EventHandler(CerrarE);
            Vista.btnSalir.Click += new EventHandler(CerrarE);
            Vista.pMinimizar.Click += new EventHandler(MinimizarE);
            Vista.btnCliente.Click += new EventHandler(AbrirFormClientesE);
            Vista.btnVehiculo.Click += new EventHandler(AbrirFormVehiculoE);
            Vista.btnChofer.Click += new EventHandler(AbrirFormChoferE);
            Vista.btnSecretaria.Click += new EventHandler(AbrirFormSecretariaE);
            Vista.FormClosed += new FormClosedEventHandler(CerrarFormInternoE);
            Vista.pTop.MouseDown += new MouseEventHandler(DragPanelE);
        }

        //Evento Cerrar Vista
        public void CerrarE(object sender, EventArgs e)
        {
            Cerrar(Vista);
        }
        //Evento Minimizar Vista
        public void MinimizarE(object sender, EventArgs e)
        {
            Minimizar(Vista);
        }
        //Evento Abrir Vista CRUD Cliente
        public void AbrirFormClientesE(object sender, EventArgs e)
        {
            AbrirForm(new ClienteCrudView(), Vista.panelForms);
            Vista.btnCliente.BackColor = Color.FromArgb(13, 93, 142);
            Vista.btnVehiculo.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnChofer.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnSecretaria.BackColor = Color.FromArgb(4, 41, 68);
        }
        //Evento Abrir Vista CRUD Vehiculo
        public void AbrirFormVehiculoE(object sender, EventArgs e)
        {
            AbrirForm(new VehiculoCrudView(), Vista.panelForms);
            Vista.btnVehiculo.BackColor = Color.FromArgb(13, 93, 142);
            Vista.btnCliente.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnChofer.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnSecretaria.BackColor = Color.FromArgb(4, 41, 68);
        }

        //Evento Abrir Vista CRUD Secretaria
        public void AbrirFormSecretariaE(object sender, EventArgs e)
        {
            AbrirForm(new SecretariaCrudView(), Vista.panelForms);
            Vista.btnSecretaria.BackColor = Color.FromArgb(13, 93, 142);
            Vista.btnVehiculo.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnCliente.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnChofer.BackColor = Color.FromArgb(4, 41, 68);
        }

        //Evento Abrir Vista CRUD Chofer
        public void AbrirFormChoferE(object sender, EventArgs e)
        {
            AbrirForm(new ChoferCrudView(), Vista.panelForms);
            Vista.btnChofer.BackColor = Color.FromArgb(13, 93, 142);
            Vista.btnCliente.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnVehiculo.BackColor = Color.FromArgb(4, 41, 68);
            Vista.btnSecretaria.BackColor = Color.FromArgb(4, 41, 68);
        }
        //Evento Cerrar Vista Abierta dentro del panel Menu Secretaria
        public void CerrarFormInternoE(object sender, EventArgs e)
        {
            CerrarFormInterno(Vista.panelForms);
        }
        //Evento Mover Ventana
        private void DragPanelE(object sender, MouseEventArgs e)
        {
            DragPanel(Vista);
        }
    }
}

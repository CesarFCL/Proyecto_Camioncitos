using ProyectoCamioncitos.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista Menu Secretaria
    class SecretariaMenuController
    {
        SecretariaMenuView Vista;
        //Constructor
        public SecretariaMenuController(SecretariaMenuView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.pCerrar.Click += new EventHandler(Cerrar);
            Vista.pMinimizar.Click += new EventHandler(Minimizar);
            Vista.btnCliente.Click += new EventHandler(AbrirFormClientes);
            Vista.FormClosed += new System.Windows.Forms.FormClosedEventHandler(CerrarFormInterno);
        }

        //Evento Cerrar Vista
        public void Cerrar(object sender, EventArgs e)
        {
            LoginView VistaLogin = new LoginView();
            VistaLogin.Show();
            Vista.Close();
        }
        //Evento Minimizar Vista
        public void Minimizar(object sender, EventArgs e)
        {
            Vista.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        //Evento Abrir Vista CRUD Cliente
        public void AbrirFormClientes(object sender, EventArgs e)
        {
            AbrirForm(new ClienteCrudView());
        }
        //Cerrar Vista Abierta dentro del panel Menu Secretaria
        public void CerrarFormInterno(object sender, EventArgs e)
        {
            Vista.panelForms.Dispose();
        }
        //Método para abrir un form en el panel del Menu
        // !! Probablemente se deba implementar como una clase aparte
        // !! Ya que tambien se debera implementar en otras clases Menu
        public void AbrirForm(Form newForm)
        {
            Form activeForm = null;
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm=newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            Vista.panelForms.Controls.Add(newForm);
            Vista.panelForms.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }
    }
}

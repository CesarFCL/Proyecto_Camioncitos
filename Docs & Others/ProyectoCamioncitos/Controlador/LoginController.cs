using ProyectoCamioncitos.Controlador.ControllersExceptions;
using ProyectoCamioncitos.Modelo.DAO;
using ProyectoCamioncitos.Modelo.DTO;
using ProyectoCamioncitos.Vista;
using ProyectoCamioncitos.Vista.Chofer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista del Login
    class LoginController
    {
        LoginView Vista;
        int IntentosLogin = 4;
        //Constructor
        public LoginController(LoginView view)
        {
            Vista = view;

            //inicializar eventos
            Vista.FormClosed += CerrarPrograma;
            Vista.pSalir.Click += new EventHandler(CerrarEvent);
            Vista.pMinimizar.Click += new EventHandler(MinimizarEvent);
            Vista.btnIniciarSesion.Click += new EventHandler(LoginEvent);
            Vista.txtUser.TextChanged += new EventHandler(UserLimit);
            Vista.txtPassword.TextChanged += new EventHandler(PasswordLimit);
            Vista.txtUser.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);

            Vista.MouseDown += new MouseEventHandler(DragPanelEvent);
            Vista.pBlue.MouseDown += new MouseEventHandler(DragPanelEvent);
        }

        //Evento Cerrar Vista
        public void CerrarEvent(object sender, EventArgs e)
        {
            Vista.Close();
        }

        //Evento Minimizar Vista
        public void MinimizarEvent(object sender, EventArgs e)
        {
            Vista.WindowState = FormWindowState.Minimized;
        }

        //Evento Login
        public void LoginEvent(object sender, EventArgs e)
        {
            Login();
        }

        //Evento Mover Ventana
        private void DragPanelEvent(object sender, MouseEventArgs e)
        {
            GlobalMenu gb = new GlobalMenu();
            gb.DragPanelEvent(sender, e, Vista);
        }

        //Metodo Login
        public void Login()
        {
            try
            {
                DisminuirIntentos();
                LoginDAO login = new LoginDAO();
                Empleado EmpleadoResult = login.LoginEmpleado(Vista.txtUser.Text, Vista.txtPassword.Text, IntentosLogin);

                LogOpen vistaAdmin = new LogAdmin();
                vistaAdmin.OpenView(EmpleadoResult);
                LogOpen vistaSecretaria = new LogSecretaria();
                vistaSecretaria.OpenView(EmpleadoResult);
                LogOpen vistaChofer = new LogChofer();
                vistaChofer.OpenView(EmpleadoResult);

                Vista.Close();
            }
            catch { }
        }

        //Método Login Fallido
        public void DisminuirIntentos()
        {
            IntentosLogin--;
        }

        //Cuando detecta que no hay ninguna ventana abierta cierra el programa
        public void CerrarPrograma(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= CerrarPrograma;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += CerrarPrograma;
            }
        }
        
        //Restricciones
        private void UserLimit(object sender, EventArgs e)
        {
            Vista.txtUser.MaxLength = 10;
        }

        private void PasswordLimit(object sender, EventArgs e)
        {
            Vista.txtPassword.MaxLength = 10;
        }

        //Validaciones
        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalCrud gb = new GlobalCrud();
            gb.OnlyNumbers_KeyPress(sender, e);
        }
    }

    //Probablemente las clases de aqui para abajo deban ir como otro apartado en el controlador ??

    //Clase Abtsracta Para los Tipos de Login
    abstract class LogOpen
    {
        public abstract void OpenView(Empleado EmpleadoLogin);

        protected void EnviarDatos(TextBox txtNombre, TextBox txtApellido, TextBox txtCI, Empleado EmpleadoLogin)
        {
            txtNombre.Text = EmpleadoLogin.Nombre;
            txtApellido.Text = EmpleadoLogin.Apellido;
            txtCI.Text = EmpleadoLogin.CI;
        }
    }
    //Clase Tipo Login Secretaria
    class LogSecretaria : LogOpen
    {
        public override void OpenView(Empleado EmpleadoLogin)
        {
            if (EmpleadoLogin.Cargo.Equals("Secretaria"))
            {
                SecretariaMenuView VistaSecretaria = new SecretariaMenuView();
                VistaSecretaria.Show();
                EnviarDatos(VistaSecretaria.txtNombre,VistaSecretaria.txtApellido, VistaSecretaria.txtCI, EmpleadoLogin);
            }
        }
    }
    //Clase Tipo Login Chofer
    class LogChofer : LogOpen
    {
        public override void OpenView(Empleado EmpleadoLogin)
        {
            if (EmpleadoLogin.Cargo == "Chofer")
            {
                ChoferMenuView VistaChofer = new ChoferMenuView();
                VistaChofer.Show();
                EnviarDatos(VistaChofer.txtNombre, VistaChofer.txtApellido, VistaChofer.txtCI, EmpleadoLogin);
            }
        }
    } 

    //Clase Tipo Login Admin
    class LogAdmin : LogOpen
    {
        public override void OpenView(Empleado EmpleadoLogin)
        {
            if (EmpleadoLogin.Cargo == "Admin")
            {
                AdminMenuView VistaAdmin = new AdminMenuView();
                VistaAdmin.Show();
                EnviarDatos(VistaAdmin.txtNombre, VistaAdmin.txtApellido, VistaAdmin.txtCI, EmpleadoLogin);
            }
        }
    }
}

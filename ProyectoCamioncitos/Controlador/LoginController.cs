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
    //Controlador de la Vista del Login
    class LoginController
    {
        LoginView Vista;
        int IntentosLogin = 3;
        //Constructor
        public LoginController(LoginView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.pSalir.Click += new EventHandler(Cerrar);
            Vista.pMinimizar.Click += new EventHandler(Minimizar);
            Vista.btnIniciarSesion.Click += new EventHandler(LoginBtn);
            Vista.txtUser.TextChanged += new EventHandler(txtUser_TextChanged);
            Vista.txtUser.KeyPress += new KeyPressEventHandler(OnlyNumbers_KeyPress);
            Vista.txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);

            Vista.MouseDown += new MouseEventHandler(DragPanel);
            Vista.pBlue.MouseDown += new MouseEventHandler(DragPanel);
        }

        //Evento Cerrar Vista
        public void Cerrar(object sender, EventArgs e)
        {
            Vista.Close();
        }

        //Evento Minimizar Vista
        public void Minimizar(object sender, EventArgs e)
        {
            Vista.WindowState = FormWindowState.Minimized;
        }

        //Evento Login
        public void LoginBtn(object sender, EventArgs e)
        {
            Login();
        }

        //Evento Mover Ventana
        private void DragPanel(object sender, MouseEventArgs e)
        {
            GlobalMenu gb = new GlobalMenu();
            gb.DragPanel(Vista);
        }

        //Metodo Login
        public void Login()
        {
            try
            {
                LoginDAO Login = new LoginDAO();
                Empleado EmpleadoR = Login.LoginEmpleado(Vista.txtUser.Text, Vista.txtPassword.Text, IntentosLogin);

                //La DVD no se si esto este bien emplementado
                //Porbablemente se tenga que refactorizar o algo xd !!!
                LogOpen vistaP = new LogPropietario();
                vistaP.OpenView(EmpleadoR);
                LogOpen vistaS = new LogSecretaria();
                vistaS.OpenView(EmpleadoR);
                LogOpen vistaC = new LogChofer();
                vistaC.OpenView(EmpleadoR);

                Vista.Close();

            }
            catch
            {
                LoginFallido();
            }
        }

        //Método Login Fallido
        public void LoginFallido()
        {
            IntentosLogin--;
            try
            {
                if (IntentosLogin == -1)
                {
                    throw new LimitLoginException();
                }
            }
            catch
            {
                //Aqui en realidad deberia ir algo como que se niega el acceso al usuario que se intenta entrar
                //o algun tipo de tiempo de espera pero si eso se implementara despues, por ahora esto sirve :3
                Console.WriteLine("Sistema cerrado por Limite de intentos de Login");
            }
        }

        //Restricciones
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            Vista.txtUser.MaxLength = 10;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Vista.txtPassword.MaxLength = 10;
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

    //Clase Abtsracta Para los Tipos de Login
    abstract class LogOpen
    {
        public abstract void OpenView(Empleado t_empleado);
    }
    //Clase Tipo Login Secretaria
    class LogSecretaria : LogOpen
    {
        public override void OpenView(Empleado t_empleado)
        {
            if (t_empleado.Cargo.Equals("Secretaria"))
            {
                SecretariaMenuView VistaSecretaria = new SecretariaMenuView();
                VistaSecretaria.Show();
                VistaSecretaria.txtNombre.Text = t_empleado.Nombre;
                VistaSecretaria.txtApellido.Text = t_empleado.Apellido;
                VistaSecretaria.txtCI.Text = t_empleado.CI;
            }
        }
    }
    //Clase Tipo Login Chofer
    class LogChofer : LogOpen
    {
        public override void OpenView(Empleado t_empleado)
        {
            if (t_empleado.Cargo == "Chofer")
            {
                //Proceso
            }
        }
    } 

    //Clase Tipo Login Propietario
    class LogPropietario : LogOpen
    {
        public override void OpenView(Empleado t_empleado)
        {
            if (t_empleado.Cargo == "Admin")
            {
                AdminMenuView VistaSecretaria = new AdminMenuView();
                VistaSecretaria.Show();
                VistaSecretaria.txtNombre.Text = t_empleado.Nombre;
                VistaSecretaria.txtApellido.Text = t_empleado.Apellido;
                VistaSecretaria.txtCI.Text = t_empleado.CI;
            }
        }
    }
}

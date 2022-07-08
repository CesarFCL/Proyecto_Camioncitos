using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Modelo.DAO.DaoExceptions
{
    public class DenyLoginException : Exception
    {
        public DenyLoginException(string mensaje) : base(mensaje)
        {
            MessageBox.Show("CI o Contraseña Incorrecto." + Environment.NewLine + "Intentos Restantes: " + mensaje,
                "Login Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

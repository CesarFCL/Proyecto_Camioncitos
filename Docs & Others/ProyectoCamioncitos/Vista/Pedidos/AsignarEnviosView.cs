using ProyectoCamioncitos.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Vista.Pedidos
{
    //Vista Asignar Envios
    public partial class AsignarEnviosView : Form
    {
        public AsignarEnviosView()
        {
            InitializeComponent();
            //Vista a Controlador
            AsignarEnviosController ctrl = new AsignarEnviosController(this);
        }
    }
}

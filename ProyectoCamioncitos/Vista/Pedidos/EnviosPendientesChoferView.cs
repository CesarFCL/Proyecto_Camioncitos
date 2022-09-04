using ProyectoCamioncitos.Controlador;
using ProyectoCamioncitos.Vista.Chofer;
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
    //Vista Envios Pendientes
    public partial class EnviosPendientesChoferView : Form
    {
        public EnviosPendientesChoferView(ChoferMenuView choferMenu)
        {
            InitializeComponent();
            //Vista a Controlador
            EnviosPendientesChoferController ctrl = new EnviosPendientesChoferController(this, choferMenu);
        }
    }
}

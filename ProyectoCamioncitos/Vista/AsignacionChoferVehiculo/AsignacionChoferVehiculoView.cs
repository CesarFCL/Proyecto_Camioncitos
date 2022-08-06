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

namespace ProyectoCamioncitos.Vista.Chofer
{
    //Vista Disponibilidad Chofer Vehiculo
    public partial class AsignacionChoferVehiculoView : Form
    {
        public AsignacionChoferVehiculoView()
        {
            InitializeComponent();
            //Vista a Controlador
            AsignacionChoferVehiculoController ctrl = new AsignacionChoferVehiculoController(this);
        }
    }
}

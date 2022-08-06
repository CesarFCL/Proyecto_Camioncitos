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
    //Vista Menu Secretaria
    public partial class ChoferMenuView : Form
    {
        public ChoferMenuView()
        {
            InitializeComponent();
            //Vista a Controlador
            ChoferMenuController ctrl = new ChoferMenuController(this);
        }
    }
}

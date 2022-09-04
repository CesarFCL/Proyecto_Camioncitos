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

namespace ProyectoCamioncitos.Vista.Secretaria
{
    //Vista CRUD Secretaria
    public partial class SecretariaCrudView : Form
    {
        public SecretariaCrudView()
        {
            InitializeComponent();
            //Vista a Controlador
            SecretariaCrudController ctrl = new SecretariaCrudController(this);
        }
    }
}

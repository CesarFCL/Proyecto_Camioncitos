﻿using ProyectoCamioncitos.Controlador;
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
    //Vista Perfil Chofer
    public partial class ChoferProfileView : Form
    {
        public ChoferProfileView(ChoferMenuView choferMenu)
        {
            InitializeComponent();
            //Vista a Controlador
            ChoferProfileController ctrl = new ChoferProfileController(this, choferMenu);
        }
    }
}

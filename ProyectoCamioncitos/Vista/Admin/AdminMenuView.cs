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

namespace ProyectoCamioncitos.Vista
{
    //Vista Menu Admin
    public partial class AdminMenuView : Form
    {
        public AdminMenuView()
        {
            InitializeComponent();
            //Vista a Controlador
            AdminMenuController ctrl = new AdminMenuController(this);
        }
    }
}

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

namespace ProyectoCamioncitos.Vista.FacturasEnvios
{
    //Vista CRUD Pedidos
    public partial class PedidosCrudView : Form
    {
        public PedidosCrudView()
        {
            InitializeComponent();
            //Vista a Controlador
            PedidosCrudController ctrl = new PedidosCrudController(this);
        }
    }
}

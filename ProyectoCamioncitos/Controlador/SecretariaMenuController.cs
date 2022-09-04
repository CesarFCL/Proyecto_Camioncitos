﻿using ProyectoCamioncitos.Vista;
using ProyectoCamioncitos.Vista.Chofer;
using ProyectoCamioncitos.Vista.Conductor;
using ProyectoCamioncitos.Vista.FacturasEnvios;
using ProyectoCamioncitos.Vista.Pedidos;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCamioncitos.Controlador
{
    //Controlador de la Vista Menu Secretaria
    public class SecretariaMenuController : GlobalMenu
    {
        SecretariaMenuView Vista;
        //Constructor
        public SecretariaMenuController(SecretariaMenuView view)
        {
            Vista = view;
            //inicializar eventos
            Vista.pCerrar.Click += delegate (object sender, EventArgs e) { CerrarEvent(sender, e, Vista); };
            Vista.btnSalir.Click += delegate (object sender, EventArgs e) { CerrarEvent(sender, e, Vista); };
            Vista.pMinimizar.Click += delegate (object sender, EventArgs e) { MinimizarEvent(sender, e, Vista); };
            Vista.btnCliente.Click += new EventHandler(AbrirFormClientesEvent);
            Vista.btnVehiculo.Click += new EventHandler(AbrirFormVehiculoEvent);
            Vista.btnChofer.Click += new EventHandler(AbrirFormChoferEvent);
            Vista.btnFacturas.Click += new EventHandler(AbrirFormPedidosEvent);
            Vista.btnAsignarChoferVehiculo.Click += new EventHandler(AbrirFormAsignarChoferVehiculoEvent);
            Vista.btnAsignarEnvios.Click += new EventHandler(AbrirFormAsignarEnviosEvent);
            Vista.FormClosed += delegate (object sender, FormClosedEventArgs e) { CerrarFormInternoEvent(sender, e, Vista.panelForms); };       
            Vista.TopPanel.MouseDown += delegate (object sender, MouseEventArgs e) { DragPanelEvent(sender, e, Vista); };
        }

        //Evento Abrir Vista CRUD Cliente
        public void AbrirFormClientesEvent(object sender, EventArgs e)
        {
            AbrirForm(new ClienteCrudView(), Vista.panelForms);

            ActiveColorBtn(Vista.btnCliente, Vista.picCliente);
            InactiveColorBtn(Vista.btnVehiculo, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnChofer, Vista.picChofer);
            InactiveColorBtn(Vista.btnAsignarChoferVehiculo, Vista.picAsignacionChoferVehiculo);
            InactiveColorBtn(Vista.btnFacturas, Vista.picFacturas);
            InactiveColorBtn(Vista.btnAsignarEnvios, Vista.picAsignarEnvios);
        }
        //Evento Abrir Vista CRUD Pedidos
        public void AbrirFormPedidosEvent(object sender, EventArgs e)
        {
            AbrirForm(new PedidosCrudView(), Vista.panelForms);

            ActiveColorBtn(Vista.btnFacturas, Vista.picFacturas);
            InactiveColorBtn(Vista.btnCliente, Vista.picCliente);
            InactiveColorBtn(Vista.btnVehiculo, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnChofer, Vista.picChofer);
            InactiveColorBtn(Vista.btnAsignarChoferVehiculo, Vista.picAsignacionChoferVehiculo);
            InactiveColorBtn(Vista.btnAsignarEnvios, Vista.picAsignarEnvios);
        }

        //Evento Abrir Vista CRUD Vehiculo
        public void AbrirFormVehiculoEvent(object sender, EventArgs e)
        {
            AbrirForm(new VehiculoCrudView(), Vista.panelForms);

            ActiveColorBtn(Vista.btnVehiculo, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnCliente, Vista.picCliente);
            InactiveColorBtn(Vista.btnChofer, Vista.picChofer);
            InactiveColorBtn(Vista.btnAsignarChoferVehiculo, Vista.picAsignacionChoferVehiculo);
            InactiveColorBtn(Vista.btnFacturas, Vista.picFacturas);
            InactiveColorBtn(Vista.btnAsignarEnvios, Vista.picAsignarEnvios);
        }

        //Evento Abrir Vista CRUD Chofer
        public void AbrirFormChoferEvent(object sender, EventArgs e)
        {
            AbrirForm(new ChoferCrudView(), Vista.panelForms);

            ActiveColorBtn(Vista.btnChofer, Vista.picChofer);
            InactiveColorBtn(Vista.btnCliente, Vista.picCliente);
            InactiveColorBtn(Vista.btnVehiculo, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnAsignarChoferVehiculo, Vista.picAsignacionChoferVehiculo);
            InactiveColorBtn(Vista.btnFacturas, Vista.picFacturas);
            InactiveColorBtn(Vista.btnAsignarEnvios, Vista.picAsignarEnvios);
        }

        //Evento Abrir Vista Asignar Chofer Vehiculo
        public void AbrirFormAsignarChoferVehiculoEvent(object sender, EventArgs e)
        {
            AbrirForm(new AsignacionChoferVehiculoView(), Vista.panelForms);

            ActiveColorBtn(Vista.btnAsignarChoferVehiculo, Vista.picAsignacionChoferVehiculo);
            InactiveColorBtn(Vista.btnChofer, Vista.picChofer);
            InactiveColorBtn(Vista.btnCliente, Vista.picCliente);
            InactiveColorBtn(Vista.btnVehiculo, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnFacturas, Vista.picFacturas);
            InactiveColorBtn(Vista.btnAsignarEnvios, Vista.picAsignarEnvios);
        }

        //Evento Abrir Vista Asignar Envios
        public void AbrirFormAsignarEnviosEvent(object sender, EventArgs e)
        {
            AbrirForm(new AsignarEnviosView(), Vista.panelForms);

            ActiveColorBtn(Vista.btnAsignarEnvios, Vista.picAsignarEnvios);
            InactiveColorBtn(Vista.btnAsignarChoferVehiculo, Vista.picAsignacionChoferVehiculo);
            InactiveColorBtn(Vista.btnChofer, Vista.picChofer);
            InactiveColorBtn(Vista.btnCliente, Vista.picCliente);
            InactiveColorBtn(Vista.btnVehiculo, Vista.picVehiculo);
            InactiveColorBtn(Vista.btnFacturas, Vista.picFacturas);
        }
    }
}

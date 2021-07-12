﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace TPC_Comercio
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        public bool validarCampos()
        {
            bool hola = true;
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var fechaNac = txtFecha.Text;
            var telefono = txtTelefono.Text;
            var direccion = txtDireccion.Text;

            if (!(nombre != null && nombre != "")) hola = false;
            if (!(apellido != null && apellido != "")) hola = false;
            if (!(fechaNac != null && fechaNac != "")) hola = false;
            if (!(telefono != null && telefono != "")) hola = false;
            if (!(direccion != null && direccion != "")) hola = false;
            



            return hola;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var fechaNac = txtFecha.Text;
            var telefono = txtTelefono.Text;
            var direccion = txtDireccion.Text;
            try
            {
                if (validarCampos())
                {
                    cliente.Nombre = nombre;
                    cliente.Apellido = apellido;
                    cliente.FechaNac = DateTime.Parse(fechaNac);
                    cliente.Telefono = int.Parse(telefono);
                    cliente.Direccion = direccion;
                    clienteNegocio.agregar(cliente);
                    Response.Redirect("Clientes.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
using System;
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
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var fechaNac = Request.Form["fechaNac"];
            var telefono = Request.Form["telefono"];
            var direccion = Request.Form["direccion"];
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
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }
        public bool validarCampos()
        {
            bool hola = true;
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var fechaNac = Request.Form["fechaNac"];
            var telefono = Request.Form["telefono"];
            var direccion = Request.Form["direccion"];

            if (!(nombre != null && nombre != "")) hola = false;
            if (!(apellido != null && apellido != "")) hola = false;
            if (!(fechaNac != null && fechaNac != "")) hola = false;
            if (!(telefono != null && telefono != "")) hola = false;
            if (!(direccion != null && direccion != "")) hola = false;
            



            return hola;
        }
    }
}
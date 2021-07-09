using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace TPC_Comercio
{
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = (int)Session["idCliente"];
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente = negocio.getCliente(id);
            /*
            Request.Form["nombre"] = cliente.Nombre;
            Request.Form["apellido"] = cliente.Apellido;
            Request.Form["fechaNac"] = cliente.FechaNac.ToString();
            Request.Form["direccion"] = cliente.Direccion;
            Request.Form["telefono"] = cliente.Telefono.ToString();
            */
            nombre.Value = cliente.Nombre;
            apellido.Value = cliente.Apellido;
            fechaNac.Value = cliente.FechaNac.ToString();
            direccion.Value = cliente.Direccion;
            telefono.Value = cliente.Telefono.ToString();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Producto> listaProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            
            listaProductos = productoNegocio.listar();
            Session.Add("listaProductos", listaProductos);
            var id = Request.Form["id"];
            lblEjemplo.InnerText = id;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
                      
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("index.aspx");
        }   
    }
}
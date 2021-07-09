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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            List<Producto> listado = (List<Producto>)Session["listaProductos"];
            Producto seleccionado = listado.Find(x => x.Id == id);
            lblNombre.Text = seleccionado.Nombre;
            //lblMarca.Text = seleccionado.Marca.Nombre;
            //lblCategoria.Text = seleccionado.Categoria.Nombre;
            lblPorcGanancia.Text = Convert.ToString(seleccionado.PorcGanancia);
            lblStockMinimo.Text = Convert.ToString(seleccionado.StockMinimo);
            imgseleccionado.Src = seleccionado.UrlImagen;

            var eliminar = Request.Form["eliminar"];
            var editar = Request.Form["editar"];
            ProductoNegocio negocio = new ProductoNegocio();

            if (eliminar == "Eliminar")
            {
                negocio.eliminar(id);
                Response.Redirect("Productos.aspx");
            }
            if (editar=="Editar")
            {
                seleccionado.Nombre = lblNombre.Text;
                seleccionado.PorcGanancia = int.Parse(lblPorcGanancia.Text);
                seleccionado.StockMinimo = int.Parse(lblStockMinimo.Text);
                seleccionado.UrlImagen = imgseleccionado.Src;
                Response.Redirect("Productos.aspx");
            }
        }
    }
}
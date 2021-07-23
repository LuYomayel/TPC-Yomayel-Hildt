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
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            ProductoNegocio productoNegocio = new ProductoNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                listaProductos = productoNegocio.listar();
                Session.Add("listaProductos", listaProductos);
                gvProductos.DataSource = listaProductos;
                gvProductos.DataBind();
                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
            
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            try
            {
                int index = e.RowIndex;
                listaProductos = productoNegocio.listar();
                producto = listaProductos[index];



                productoNegocio.eliminar(producto.Id);
                listaProductos = productoNegocio.listar();
                gvProductos.DataSource = listaProductos;
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            try
            {
                int index = e.NewEditIndex;
                listaProductos = productoNegocio.listar();
                producto = listaProductos[index];
                Session.Add("idProducto", producto.Id);
                Response.Redirect("ModificarProducto.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
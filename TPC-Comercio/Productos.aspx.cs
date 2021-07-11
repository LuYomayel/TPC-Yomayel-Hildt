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
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            listaProductos = productoNegocio.listar();
            Session.Add("listaProductos", listaProductos);
            gvProductos.DataSource = listaProductos;
            gvProductos.DataBind();
            var id = Request.Form["id"];
            
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

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(e.Values[0]);
                ProductoNegocio productoNegocio = new ProductoNegocio();
                
                if (id != 0)
                productoNegocio.eliminar(id);
                listaProductos = productoNegocio.listar();
                gvProductos.DataSource = listaProductos;
                gvProductos.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                //gvClientes.EditIndex = e.NewEditIndex;
                //gvClientes.DataBind();
                int id = int.Parse(gvProductos.Rows[e.NewEditIndex].Cells[0].Text);
                Session.Add("idProducto", id);
                Response.Redirect("ModificarProducto.aspx");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
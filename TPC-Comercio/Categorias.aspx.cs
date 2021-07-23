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
    public partial class Categorias : System.Web.UI.Page
    {
        public List<Categoria> listaCategorias;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                listaCategorias = categoriaNegocio.listar();
                gvCategorias.DataSource = listaCategorias;
                gvCategorias.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                //gvClientes.EditIndex = e.NewEditIndex;
                //gvClientes.DataBind();
                int index = e.NewEditIndex;
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Categoria categoria = new Categoria();

                listaCategorias = categoriaNegocio.listar();
                categoria = listaCategorias[index];
                int id = categoria.Id;

                Session.Add("idCategoria", id);
                Response.Redirect("ModificarCategoria.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();
            try
            {

                int index = e.RowIndex;
                listaCategorias = categoriaNegocio.listar();
                categoria = listaCategorias[index];
                categoriaNegocio.eliminar(categoria.Id);
                listaCategorias = categoriaNegocio.listar();
                gvCategorias.DataSource = listaCategorias;
                gvCategorias.DataBind();
               
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
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
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            listaCategorias = categoriaNegocio.listar();
            gvCategorias.DataSource = listaCategorias;
            gvCategorias.DataBind();
        }

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                //gvClientes.EditIndex = e.NewEditIndex;
                //gvClientes.DataBind();
                int id = int.Parse(gvCategorias.Rows[e.NewEditIndex].Cells[0].Text);
                Session.Add("idCategoria", id);
                Response.Redirect("ModificarCategoria.aspx");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            int id = 0;
            try
            {
                
                    id = Convert.ToInt32(e.Values[0]);

                if (id != 0)
                {
                    categoriaNegocio.eliminar(id);
                    listaCategorias = categoriaNegocio.listar();
                    gvCategorias.DataSource = listaCategorias;
                    gvCategorias.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
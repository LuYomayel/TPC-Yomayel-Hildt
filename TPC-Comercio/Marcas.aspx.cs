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
    public partial class Marcas : System.Web.UI.Page
    {
        public List<Marca> listaMarcas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                listaMarcas = marcaNegocio.listar();
                gvMarcas.DataSource = listaMarcas;
                gvMarcas.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        

        protected void gvMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                //gvClientes.EditIndex = e.NewEditIndex;
                //gvClientes.DataBind();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Marca marca = new Marca();

                int index = e.NewEditIndex;
                listaMarcas = marcaNegocio.listar();
                marca = listaMarcas[index];
                Session.Add("idMarca", marca.Id);
                Response.Redirect("ModificarMarca.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void gvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { 
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = new Marca();
            try
            {
                int index = e.RowIndex;
                listaMarcas = marcaNegocio.listar();
                marca = listaMarcas[index];
                
                
                
                    marcaNegocio.eliminar(marca.Id);
                    listaMarcas = marcaNegocio.listar();
                    gvMarcas.DataSource = listaMarcas;
                    gvMarcas.DataBind();
                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
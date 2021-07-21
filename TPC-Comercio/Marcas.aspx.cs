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
                int id = int.Parse(gvMarcas.Rows[e.NewEditIndex].Cells[0].Text);
                Session.Add("idMarca", id);
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
            int id = 0;
            try
            {
                
                id = Convert.ToInt32(e.Values[0]);
                
                if (id != 0)
                {
                    marcaNegocio.eliminar(id);
                    listaMarcas = marcaNegocio.listar();
                    gvMarcas.DataSource = listaMarcas;
                    gvMarcas.DataBind();
                }
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
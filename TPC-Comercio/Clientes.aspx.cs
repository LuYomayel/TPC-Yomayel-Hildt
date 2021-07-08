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
    public partial class Clientes : System.Web.UI.Page
    {
        
        public List<Cliente> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                
                lista = negocio.listar();
                gvClientes.DataSource = lista;
                gvClientes.DataBind();
                
                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }
        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            
            try
            {
                
                int id = Convert.ToInt32(e.Values[0]);
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                if(id != 0)
                clienteNegocio.eliminar(id);
            }
            catch (Exception ex)
            {
                Message.Text = ex.ToString();
                throw;
            }
            
        }

        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*
            if (e.Row.RowType == DataControlRowType.Header)
            {
                
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
            */
        }

        
    }
}
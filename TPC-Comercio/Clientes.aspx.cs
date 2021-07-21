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

        
        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            
            try
            {
                string cuit = e.Values[0].ToString();
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                if(cuit != null || cuit != "")
                clienteNegocio.eliminar(cuit);
                lista = clienteNegocio.listar();
                gvClientes.DataSource = lista;
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                
                string cuit = gvClientes.Rows[e.NewEditIndex].Cells[0].Text;
                Session.Add("cuitCliente", cuit);
                Response.Redirect("ModificarCliente.aspx", false);
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
            Response.Redirect("AgregarCliente.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
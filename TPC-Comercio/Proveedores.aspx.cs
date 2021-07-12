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
    public partial class Proveedores : System.Web.UI.Page
    {
        public List<Proveedor> listaProveedores;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            try
            {
                listaProveedores = proveedorNegocio.listar();

                gvProveedores.DataSource = listaProveedores;
                gvProveedores.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void gvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                string cuit = e.Values[0].ToString();
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

                if (cuit != null || cuit != "")
                    proveedorNegocio.eliminar(cuit);
                listaProveedores = proveedorNegocio.listar();
                gvProveedores.DataSource = listaProveedores;
                gvProveedores.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                string cuit = gvProveedores.Rows[e.NewEditIndex].Cells[0].Text;
                Session.Add("cuitProveedor", cuit);
                Response.Redirect("ModificarProveedor.aspx", false);
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
            Response.Redirect("AgregarProveedor.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
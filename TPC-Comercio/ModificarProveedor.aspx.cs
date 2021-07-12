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
    public partial class ModificarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();
            try
            {
                int id = (int)Session["idProveedor"];
                proveedor = negocio.GetProveedor(id);
                if (!Page.IsPostBack)
                {
                    txtDescripcion.Text = proveedor.Descripcion;
                    txtRazon.Text = proveedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            try
            {
                proveedor.Id = (int)Session["idProveedor"];
                proveedor.RazonSocial = txtRazon.Text;
                proveedor.Descripcion = txtDescripcion.Text;
                proveedorNegocio.actualizar(proveedor);
                Response.Redirect("Proveedores.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            

        }
    }
}
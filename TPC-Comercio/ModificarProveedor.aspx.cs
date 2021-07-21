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
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();
            try
            {
                string cuit = (string)Session["cuitProveedor"];
                proveedor = negocio.GetProveedor(cuit);
                if (!Page.IsPostBack)
                {
                    txtDescripcion.Text = proveedor.Descripcion;
                    txtRazon.Text = proveedor.RazonSocial;
                    txtEmail.Text = proveedor.Email;
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
                proveedor.Cuit = (string)Session["cuitProveedor"];
                proveedor.RazonSocial = txtRazon.Text;
                proveedor.Descripcion = txtDescripcion.Text;
                proveedor.Email = txtEmail.Text;
                proveedorNegocio.actualizar(proveedor);
                Response.Redirect("Proveedores.aspx", false);
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
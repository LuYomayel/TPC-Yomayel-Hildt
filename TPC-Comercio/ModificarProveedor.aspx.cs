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
            int id = (int)Session["idProveedor"];
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();
            proveedor = negocio.GetProveedor(id);
            if (!Page.IsPostBack)
            {
                txtDescripcion.Text = proveedor.Descripcion;
                txtRazon.Text = proveedor.RazonSocial;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            proveedor.Id = (int)Session["idProveedor"];
            proveedor.RazonSocial = txtRazon.Text;
            proveedor.Descripcion = txtDescripcion.Text;
            proveedorNegocio.actualizar(proveedor);
            Response.Redirect("Proveedores.aspx");

        }
    }
}
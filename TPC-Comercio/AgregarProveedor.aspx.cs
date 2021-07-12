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
    public partial class AgregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        bool validarCampos()
        {
            bool hola=true;
            var razonSocial = txtRazon.Text;
            var descripcion = txtDescripcion.Text;

            if (razonSocial == null || razonSocial == "") hola = false;
            if (descripcion == null || descripcion == "") hola = false;

            return hola;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            var razonSocial = txtRazon.Text;
            var descripcion = txtDescripcion.Text;
            try
            {
                if (validarCampos())
                {
                    proveedor.RazonSocial = razonSocial;
                    proveedor.Descripcion = descripcion;

                    proveedorNegocio.agregar(proveedor);
                    Response.Redirect("Proveedores.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
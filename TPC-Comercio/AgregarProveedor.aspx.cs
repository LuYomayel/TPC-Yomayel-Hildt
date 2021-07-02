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
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            var razonSocial = Request.Form["razonSocial"];
            var descripcion = Request.Form["descripcion"];

            if (validarCampos())
            {
                proveedor.RazonSocial = razonSocial;
                proveedor.Descripcion = descripcion;

                proveedorNegocio.agregar(proveedor);
            }
        }

        bool validarCampos()
        {
            bool hola=true;
            var razonSocial = Request.Form["razonSocial"];
            var descripcion = Request.Form["descripcion"];

            if (razonSocial == null || razonSocial == "") hola = false;
            if (descripcion == null || descripcion == "") hola = false;

            return hola;
        }
    }
}
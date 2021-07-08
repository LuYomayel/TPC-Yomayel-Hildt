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
            listaProveedores = proveedorNegocio.listar();

            gvProveedores.DataSource = listaProveedores;
            gvProveedores.DataBind();
        }

        protected void gvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(e.Values[0]);
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

                if (id != 0)
                    proveedorNegocio.eliminar(id);
                listaProveedores = proveedorNegocio.listar();
                gvProveedores.DataSource = listaProveedores;
                gvProveedores.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
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
    public partial class Ventas : System.Web.UI.Page
    {
        public List<Transaccion> transacciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            transacciones = transaccionNegocio.listarVentas();
            gvVentas.DataSource = transacciones;
            gvVentas.DataBind();
        }

        protected void gvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            Transaccion transaccion = new Transaccion();
            transacciones = transaccionNegocio.listarVentas();
            if (e.CommandName == "Detalle")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                transaccion = transacciones[index];
                int id = transaccion.Id;
                Session.Add("idTransaccion", id);
                Response.Redirect("DetalleTransaccion.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarVenta.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
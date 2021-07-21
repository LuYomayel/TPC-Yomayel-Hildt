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
    public partial class Compras : System.Web.UI.Page
    {
        public List<Transaccion> transacciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            transacciones = transaccionNegocio.listarCompras();
            gvCompras.DataSource = transacciones;
            gvCompras.DataBind();
        }

        protected void gvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            Transaccion transaccion = new Transaccion();
            transacciones = transaccionNegocio.listarCompras();
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
            Response.Redirect("AgregarCompra.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
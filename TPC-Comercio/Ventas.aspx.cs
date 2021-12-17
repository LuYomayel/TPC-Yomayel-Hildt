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
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión primero.");
                Response.Redirect("Error.aspx", false);
            }
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            transacciones = transaccionNegocio.listarVentas((Usuario)Session["usuario"]);
            gvVentas.DataSource = transacciones;
            gvVentas.DataBind();
            Message.Text = "";
        }

        protected void gvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            Transaccion transaccion = new Transaccion();
            transacciones = transaccionNegocio.listarVentas((Usuario)Session["usuario"]);
            if (e.CommandName == "Detalle")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                transaccion = transacciones[index];
                int id = transaccion.Id;
                Session.Add("idTransaccion", id);
                Response.Redirect("Factura.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            Message.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Message.Text = "";
            Response.Redirect("AgregarVenta.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /*protected void gvventas_rowdeleting(object sender, gridviewdeleteeventargs e)
        {
            if (session["usuario"] != null && ((dominio.usuario)session["usuario"]).tipousuario == dominio.tipousuario.admin)
            {
                try
                {
                    int index = e.rowindex;
                    transaccionnegocio transaccionnegocio = new transaccionnegocio();
                    transaccion transaccion = new transaccion();
                    transacciones = transaccionnegocio.listarventas((usuario)session["usuario"]);
                    transaccion = transacciones[index];

                    detallenegocio detallenegocio = new detallenegocio();
                    list<detalle> listadetalle = new list<detalle>();
                    listadetalle = detallenegocio.listarcomprasid(transaccion.id);

                    foreach (detalle item in listadetalle)
                    {
                        detallenegocio.eliminar(item.id);
                    }
                    transaccionnegocio.eliminar(transaccion.id);
                    transacciones = transaccionnegocio.listarventas((usuario)session["usuario"]);
                    gvventas.datasource = transacciones;
                    gvventas.databind();
                }
                catch (exception ex)
                {

                    session.add("error", ex.tostring());
                    response.redirect("error.aspx");
                }
            }
            else
            {
                message.text = "solo los administradores pueden eliminar ventas.";
            }
        }*/

        protected void btnFactura_Click(object sender, EventArgs e)
        {

        }
    }
}
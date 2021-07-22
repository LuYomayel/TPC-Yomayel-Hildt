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
            transacciones = transaccionNegocio.listarVentas();
            gvVentas.DataSource = transacciones;
            gvVentas.DataBind();
            Message.Text = "";
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
            Message.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Message.Text = "";
            Response.Redirect("AgregarVenta.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void gvVentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN)
            {
                try
                {
                    int index = e.RowIndex;
                    TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                    Transaccion transaccion = new Transaccion();
                    transacciones = transaccionNegocio.listarVentas();
                    transaccion = transacciones[index];

                    DetalleNegocio detalleNegocio = new DetalleNegocio();
                    List<Detalle> listaDetalle = new List<Detalle>();
                    listaDetalle = detalleNegocio.listarComprasID(transaccion.Id);

                    foreach (Detalle item in listaDetalle)
                    {
                        detalleNegocio.eliminar(item.Id);
                    }
                    transaccionNegocio.eliminar(transaccion.Id);
                    transacciones = transaccionNegocio.listarVentas();
                    gvVentas.DataSource = transacciones;
                    gvVentas.DataBind();
                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Message.Text = "Solo los administradores pueden eliminar Ventas.";
            }
        }
    }
}
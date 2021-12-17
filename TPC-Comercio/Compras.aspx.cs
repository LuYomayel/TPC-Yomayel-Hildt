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
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión primero.");
                Response.Redirect("Error.aspx", false);
            }
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

        /*protected void gvCompras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN)
            {


                try
                {
                    int index = e.RowIndex;
                    TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                    Transaccion transaccion = new Transaccion();
                    transacciones = transaccionNegocio.listarCompras();
                    transaccion = transacciones[index];

                    DetalleNegocio detalleNegocio = new DetalleNegocio();
                    List<Detalle> listaDetalle = new List<Detalle>();
                    listaDetalle = detalleNegocio.listarComprasID(transaccion.Id);

                    foreach (Detalle item in listaDetalle)
                    {
                        detalleNegocio.eliminar(item.Id);
                    }
                    transaccionNegocio.eliminar(transaccion.Id);
                    transacciones = transaccionNegocio.listarCompras();
                    gvCompras.DataSource = transacciones;
                    gvCompras.DataBind();
                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Message.Text = "Solo los administradores pueden eliminar Compras";
            }
        }*/
    }
}
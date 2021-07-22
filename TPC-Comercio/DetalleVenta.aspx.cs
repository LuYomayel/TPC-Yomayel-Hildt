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
    public partial class DetalleVenta : System.Web.UI.Page
    {
        public List<Detalle> listaDetalles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión primero.");
                Response.Redirect("Error.aspx", false);
            }
            int id = (int)Session["idTransaccion"];
            DetalleNegocio detalleNegocio = new DetalleNegocio();
            listaDetalles = detalleNegocio.listarComprasID(id);
            gvDetalles.DataSource = listaDetalles;
            gvDetalles.DataBind();
            decimal total = 0;
            foreach (Detalle item in listaDetalles)
            {
                total += item.PrecioParcial;
            }

            lblTotal.Text = "Total: $" + total.ToString();
        }
    }
}
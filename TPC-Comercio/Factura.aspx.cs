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
    public partial class Factura : System.Web.UI.Page
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
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            Transaccion transaccion = new Transaccion();
            DetalleNegocio detalleNegocio = new DetalleNegocio();
            listaDetalles = detalleNegocio.listarComprasID(id);
            transaccion = transaccionNegocio.GetVenta(id);
            if (!IsPostBack)
            {
                lblNroFactura.Text = transaccion.Id.ToString();
            }
        }
    }
}
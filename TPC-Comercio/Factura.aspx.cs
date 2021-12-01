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
            try
            {
                int id = (int)Session["idTransaccion"];
                TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                Transaccion transaccion = new Transaccion();
                DetalleNegocio detalleNegocio = new DetalleNegocio();
                listaDetalles = detalleNegocio.listarComprasID(id);
                transaccion = transaccionNegocio.GetVenta(id);
                Cliente cliente = new Cliente();
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                cliente = clienteNegocio.getCliente(transaccion.Cliente.Cuit); 
                if (!IsPostBack)
                {
                    lblNroFactura.Text = transaccion.Id.ToString();
                    lblCuit.Text = cliente.Cuit;
                    lblDireccion.Text = cliente.Direccion;
                    lblTelefono.Text = cliente.Telefono.ToString();
                    lblFechaHoy.Text = "23/07/2021";
                    lblVendedor.Text = transaccion.Vendedor.User;

                    gvDetalle.DataSource = listaDetalles;
                    gvDetalle.DataBind();
                    decimal total = 0;
                    foreach (Detalle item in listaDetalles)
                    {
                        total += item.PrecioParcial;
                    }

                    lblTotal.Text = total.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace TPC_Comercio
{
    public partial class AgregarVenta : System.Web.UI.Page
    {
        public List<Detalle> listaDetalles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (listaDetalles == null)
                    listaDetalles = new List<Detalle>();
                listaDetalles = (List<Detalle>)Session["listaDetalles"];
                Detalle detalle = new Detalle();
                detalle = (Detalle)Session["Detalle"];

                List<Cliente> listaClientes;
                List<Producto> listaProductos;

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                listaClientes = clienteNegocio.listar();
                ddClientes.DataSource = listaClientes;
                ddClientes.DataTextField = "Nombre";
                ddClientes.DataValueField = "Cuit";
                ddClientes.DataBind();

                ProductoNegocio productoNegocio = new ProductoNegocio();
                listaProductos = productoNegocio.listar();
                ddProductos.DataSource = listaProductos;
                ddProductos.DataTextField = "Nombre";
                ddProductos.DataValueField = "Id";
                ddProductos.DataBind();
            }

            listaDetalles = (List<Detalle>)Session["listaDetalles"];
            if (listaDetalles != null)
            {
                gvDetalle.DataSource = listaDetalles;
                gvDetalle.DataBind();
            }
        }
        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            int id = int.Parse(ddProductos.SelectedValue);
            producto = productoNegocio.GetProducto(id);
            var cantidad = txtCantidad.Text;
            var precioUnitario = producto.UltPrecio;
            txtPrecioUnitario.Text = precioUnitario.ToString();
            if (cantidad != "")
            {
                decimal subtotal = precioUnitario * decimal.Parse(txtCantidad.Text);

                txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            listaDetalles = (List<Detalle>)Session["listaDetalles"];
            if (listaDetalles == null) listaDetalles = new List<Detalle>();
            Detalle detalle = new Detalle();
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            int id = int.Parse(ddProductos.SelectedValue);
            producto = productoNegocio.GetProducto(id);
            detalle.Cantidad = int.Parse(txtCantidad.Text);
            detalle.Producto = new Producto();
            detalle.Producto = producto;
            detalle.PrecioParcial = decimal.Parse(txtSubtotal.Text);
            detalle.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
            listaDetalles.Add(detalle);
            Session.Add("Detalle", detalle);
            Session.Add("listaDetalles", listaDetalles);
            txtCantidad.Text = "0";
            txtSubtotal.Text = "0";
            gvDetalle.DataSource = listaDetalles;
            gvDetalle.DataBind();
        }

        protected void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            Transaccion transaccion = new Transaccion();
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            List<Transaccion> listaTransacciones = new List<Transaccion>();
            listaTransacciones = transaccionNegocio.listarTransacciones();
            int idTransaccion = 1;
            foreach (Transaccion item in listaTransacciones)
            {
                idTransaccion = item.Id + 1;
            }
            transaccion.Tipo = "V";
            if (idTransaccion != 0)
                transaccion.Id = idTransaccion;
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            string id = ddClientes.SelectedValue;
            cliente = clienteNegocio.getCliente(id);
            transaccion.Cliente = cliente;
            transaccionNegocio.agregarVenta(transaccion);
            DetalleNegocio detalleNegocio = new DetalleNegocio();

            transaccion.listaDetalles = (List<Detalle>)Session["listaDetalles"];
            listaDetalles = (List<Detalle>)Session["listaDetalles"];
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            
            foreach (Detalle item in listaDetalles)
            {
                producto = item.Producto;
                producto.StockActual -= item.Cantidad;
                if (producto.StockActual < 0) producto.StockActual = 0;
                productoNegocio.stock_precio(producto);
                item.Transaccion = new Transaccion();
                item.Transaccion.Id = idTransaccion;
                detalleNegocio.agregar(item);
            }
            decimal PrecioTotal = 0;
            foreach (Detalle item in listaDetalles)
            {
                PrecioTotal += item.PrecioParcial;
            }
            transaccion.Monto = PrecioTotal;
            transaccionNegocio.update(transaccion, idTransaccion);
            Response.Redirect("Compras.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void ddProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            int id = int.Parse(ddProductos.SelectedValue);
            producto = productoNegocio.GetProducto(id);
            var cantidad = txtCantidad.Text;
            var precioUnitario = producto.UltPrecio;
            txtPrecioUnitario.Text = precioUnitario.ToString();
            if (cantidad != "")
            {
                decimal subtotal = precioUnitario * decimal.Parse(txtCantidad.Text);

                txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
        }
    }
}
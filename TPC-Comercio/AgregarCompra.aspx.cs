using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using Dominio;
using Negocio;
namespace TPC_Comercio
{
    public partial class AgregarCompra : System.Web.UI.Page
    {
        public List<Detalle> listaDetalles;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {   
                if(listaDetalles == null)
                listaDetalles = new List<Detalle>();
                listaDetalles = (List<Detalle>)Session["listaDetalles"];
                Detalle detalle = new Detalle();
                detalle = (Detalle)Session["Detalle"];

                List<Proveedor> listaProveedores;
                List<Producto> listaProductos;
                
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                listaProveedores = proveedorNegocio.listar();
                ddProveedor.DataSource = listaProveedores;
                ddProveedor.DataTextField = "RazonSocial";
                ddProveedor.DataValueField = "Cuit";
                ddProveedor.DataBind();

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
            detalle.PrecioUnitario = producto.UltPrecio;
            listaDetalles.Add(detalle);
            Session.Add("Detalle", detalle);
            Session.Add("listaDetalles", listaDetalles);
            txtCantidad.Text = "0";
            txtSubtotal.Text = "0";
            gvDetalle.DataSource = listaDetalles;
            gvDetalle.DataBind();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();

            int id = int.Parse(ddProductos.SelectedItem.Value);
            var cantidad = txtCantidad.Text;
            producto = productoNegocio.GetProducto(id);

            if (cantidad != "" && cantidad != "0,0")
            {
                decimal subtotal = producto.UltPrecio * decimal.Parse(txtCantidad.Text);

                txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
            
        }

        protected void ddProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();

            int id = int.Parse(ddProductos.SelectedItem.Value);
            var cantidad = txtCantidad.Text;
            producto = productoNegocio.GetProducto(id);

            if (cantidad != "") { 
            decimal subtotal = producto.UltPrecio * decimal.Parse(txtCantidad.Text);

            txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
        }

        protected void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            Transaccion transaccion = new Transaccion();
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            transaccion.Tipo = "C";
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            string id = ddProveedor.SelectedValue;
            proveedor = proveedorNegocio.GetProveedor(id);
            transaccion.Proveedor = proveedor;
            transaccionNegocio.agregar(transaccion);
            transaccionNegocio.GetTransaccion(id);
            transaccion.listaDetalles = (List<Detalle>)Session["listaDetalles"];
            listaDetalles = (List<Detalle>)Session["listaDetalles"];
            decimal PrecioTotal = 0;
            foreach(Detalle item in listaDetalles){
                PrecioTotal += item.PrecioParcial;
            }
            transaccion.Monto = PrecioTotal;

        }
    }
}
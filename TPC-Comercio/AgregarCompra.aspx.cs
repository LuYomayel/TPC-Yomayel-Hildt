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
        public List<Producto> listaProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión primero.");
                Response.Redirect("Error.aspx", false);
            }
            if (!IsPostBack)
            {   
                if(listaDetalles == null)
                listaDetalles = new List<Detalle>();
                listaDetalles = (List<Detalle>)Session["listaDetalles"];
                Detalle detalle = new Detalle();
                detalle = (Detalle)Session["Detalle"];

                List<Proveedor> listaProveedores;
                
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                listaProveedores = proveedorNegocio.listar();
                ddProveedor.DataSource = listaProveedores;
                ddProveedor.DataTextField = "RazonSocial";
                ddProveedor.DataValueField = "Cuit";
                ddProveedor.DataBind();


                ProductoNegocio productoNegocio = new ProductoNegocio();

                if (listaProductos == null)
                {
                    listaProductos = new List<Producto>();
                    listaProductos = productoNegocio.listar();
                    Session.Add("listaProductos", listaProductos);
                }
                else
                {
                    listaProductos = (List<Producto>)Session["listaProductos"];
                }
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
            if (txtCantidad.Text != "" && txtCantidad.Text != "0" && txtPrecioUnitario.Text != "" && txtPrecioUnitario.Text != "0")
            {
                listaDetalles = (List<Detalle>)Session["listaDetalles"];
                if (listaDetalles == null) listaDetalles = new List<Detalle>();
                Detalle detalle = new Detalle();
                Producto producto = new Producto();
                ProductoNegocio productoNegocio = new ProductoNegocio();
                int id = int.Parse(ddProductos.SelectedValue);
                producto = productoNegocio.GetProducto(id);
                producto.StockActual += int.Parse(txtCantidad.Text);
                producto.UltPrecio = decimal.Parse(txtPrecioUnitario.Text);

                detalle.Cantidad = int.Parse(txtCantidad.Text);
                detalle.Producto = new Producto();
                detalle.Producto = producto;
                detalle.PrecioParcial = decimal.Parse(txtSubtotal.Text);
                detalle.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                listaDetalles.Add(detalle);
                Session.Add("Detalle", detalle);
                Session.Add("listaDetalles", listaDetalles);

                listaProductos = (List<Producto>)Session["listaProductos"];
                listaProductos.Remove(listaProductos.Find(x => x.Id == producto.Id));
                Session.Add("listaProductos", listaProductos);
                ddProductos.DataSource = listaProductos;
                ddProductos.DataTextField = "Nombre";
                ddProductos.DataValueField = "Id";
                ddProductos.DataBind();

                txtCantidad.Text = "0";
                txtSubtotal.Text = "0";
                gvDetalle.DataSource = listaDetalles;
                gvDetalle.DataBind();
                btnAgregarTransaccion.Visible = true;
            }
            else
            {
                if (txtCantidad.Text == "" || txtCantidad.Text == "0")
                {
                    lblMessage.Text = "Debe ingresar una cantidad distinta de cero.";
                }
                if (txtPrecioUnitario.Text == "" || txtPrecioUnitario.Text == "0")
                {
                    lblMessage.Text = "Debe ingresar precio unitario distinto de cero.";
                }
                if ((txtPrecioUnitario.Text == "" || txtPrecioUnitario.Text == "0") && (txtCantidad.Text == "" || txtCantidad.Text == "0"))
                {
                    lblMessage.Text = "Todos los campos son obligatorios.";
                }
            }
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            

            
            var cantidad = txtCantidad.Text;
            var precioUnitario = txtPrecioUnitario.Text;
            if (cantidad != "" && precioUnitario != "")
            {
                decimal subtotal = decimal.Parse(txtPrecioUnitario.Text)* decimal.Parse(txtCantidad.Text);

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
            List<Transaccion> listaTransacciones = new List<Transaccion>();
            listaTransacciones = transaccionNegocio.listarTodasT();
            int idTransaccion = 1;
            foreach(Transaccion item in listaTransacciones)
            {
                idTransaccion = item.Id + 1;
            }
            transaccion.Tipo = "C";
            if(idTransaccion != 0)
            transaccion.Id = idTransaccion;
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            string id = ddProveedor.SelectedValue;
            proveedor = proveedorNegocio.GetProveedor(id);
            transaccion.Proveedor = proveedor;
            transaccionNegocio.agregarCompra(transaccion);
            DetalleNegocio detalleNegocio = new DetalleNegocio();

            transaccion.listaDetalles = (List<Detalle>)Session["listaDetalles"];
            listaDetalles = (List<Detalle>)Session["listaDetalles"];
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            
            foreach(Detalle item in listaDetalles)
            {
                producto = item.Producto;
                
                //producto.StockActual += item.Cantidad;
                producto.UltPrecio = item.PrecioUnitario;
                
                item.Transaccion = new Transaccion();
                item.Transaccion.Id = idTransaccion;
                
                
                    productoNegocio.stock_precio(producto);
                    detalleNegocio.agregar(item);
                
            }
            decimal PrecioTotal = 0;
            foreach(Detalle item in listaDetalles){
                
                PrecioTotal += item.PrecioParcial;
            }
            transaccion.Monto = PrecioTotal;
            transaccionNegocio.update(transaccion, idTransaccion);
            Session.Remove("listaDetalles");
            Response.Redirect("Compras.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            var cantidad = txtCantidad.Text;
            var precioUnitario = txtPrecioUnitario.Text;
            if (cantidad != "" && precioUnitario != "")
            {
                decimal subtotal = decimal.Parse(txtPrecioUnitario.Text) * decimal.Parse(txtCantidad.Text);

                txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
        }

        protected void gvDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.RowIndex);
                listaDetalles = (List<Detalle>)Session["listaDetalles"];
                Detalle detalle = new Detalle();
                detalle = listaDetalles[index];
                listaDetalles.Remove(detalle);
                Session.Add("listaDetalles", listaDetalles);
                gvDetalle.DataSource = listaDetalles;
                gvDetalle.DataBind();
                if (listaDetalles.Count == 0) btnAgregarTransaccion.Visible = false;
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
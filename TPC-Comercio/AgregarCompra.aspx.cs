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
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            txtPrecioUnitario.BorderColor = System.Drawing.Color.Gray;
            lblMessage.Text = "";
            try
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

                    decimal montoTotal = 0;
                    foreach(Detalle detalle1 in listaDetalles)
                    {
                        montoTotal += detalle1.PrecioParcial;
                    }
                    lblTotal.Text = montoTotal.ToString();
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
                        txtCantidad.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Debe ingresar una cantidad distinta de cero.";
                    }
                    if (txtPrecioUnitario.Text == "" || txtPrecioUnitario.Text == "0")
                    {
                        txtPrecioUnitario.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Debe ingresar precio unitario distinto de cero.";
                    }
                    if ((txtPrecioUnitario.Text == "" || txtPrecioUnitario.Text == "0") && (txtCantidad.Text == "" || txtCantidad.Text == "0"))
                    {
                        txtCantidad.BorderColor = System.Drawing.Color.Red;
                        txtPrecioUnitario.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Todos los campos son obligatorios.";
                    }
                }
            }
            catch (Exception ex)
            {

                int valor;

                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    if (!int.TryParse(txtCantidad.Text, out valor))
                    {
                        txtCantidad.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "La cantidad no puede contener letras.";
                    }
                    if (!int.TryParse(txtPrecioUnitario.Text, out valor))
                    {
                        txtPrecioUnitario.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "El precio unitario no puede contener letras.";
                    }
                    else
                    {
                        lblMessage.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                    }
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            txtPrecioUnitario.BorderColor = System.Drawing.Color.Gray;
            try
            {
                lblMessage.Text = "";
                txtCantidad.BorderColor = System.Drawing.Color.Gray;
                txtPrecioUnitario.BorderColor = System.Drawing.Color.Gray;


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
            catch (Exception ex)
            {
                int valor;

                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    if (!int.TryParse(txtCantidad.Text, out valor))
                    {
                        txtCantidad.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "La cantidad no puede contener letras.";
                    }
                    if (!int.TryParse(txtPrecioUnitario.Text, out valor))
                    {
                        txtPrecioUnitario.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "El precio unitario no puede contener letras.";
                    }
                    else
                    {
                        lblMessage.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                    }
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
                
            }
            
            
        }

        

        protected void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            txtPrecioUnitario.BorderColor = System.Drawing.Color.Gray;
            try
            {
                Transaccion transaccion = new Transaccion();
                TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                List<Transaccion> listaTransacciones = new List<Transaccion>();
                listaTransacciones = transaccionNegocio.listarTodasT();
                int idTransaccion = 1;
                foreach (Transaccion item in listaTransacciones)
                {
                    idTransaccion = item.Id + 1;
                }
                transaccion.Tipo = "C";
                if (idTransaccion != 0)
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


                foreach (Detalle item in listaDetalles)
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
                foreach (Detalle item in listaDetalles)
                {

                    PrecioTotal += item.PrecioParcial;
                }
                transaccion.Monto = PrecioTotal;
                transaccionNegocio.update(transaccion, idTransaccion);
                Session.Remove("listaDetalles");
                Response.Redirect("Compras.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                int valor;

                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    if (!int.TryParse(txtCantidad.Text, out valor))
                    {
                        txtCantidad.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "La cantidad no puede contener letras.";
                    }
                    if (!int.TryParse(txtPrecioUnitario.Text, out valor))
                    {
                        txtPrecioUnitario.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "El precio unitario no puede contener letras.";
                    }
                    else
                    {
                        lblMessage.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                    }
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            
        }

        protected void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            txtPrecioUnitario.BorderColor = System.Drawing.Color.Gray;
            lblMessage.Text = "";
            try
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
            catch (Exception ex)
            {

                int valor;
                
                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    if (!int.TryParse(txtCantidad.Text, out valor))
                    {
                        txtCantidad.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "La cantidad no puede contener letras.";
                    }
                    if (!int.TryParse(txtPrecioUnitario.Text, out valor))
                    {
                        txtPrecioUnitario.BorderColor = System.Drawing.Color.Red;
                        lblMessage.Text = "El precio unitario no puede contener letras.";
                    }
                    else
                    {
                        lblMessage.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                    }
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            
        }

        protected void gvDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            decimal montoTotal = 0;
            lblMessage.Text = "";
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
                if (listaDetalles.Count == 0)
                {
                    btnAgregarTransaccion.Visible = false;
                    lblTotal.Text = montoTotal.ToString();
                }

                else
                {
                    
                    foreach (Detalle detalle1 in listaDetalles)
                    {
                        montoTotal += detalle1.PrecioParcial;
                    }
                    lblTotal.Text = montoTotal.ToString();
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
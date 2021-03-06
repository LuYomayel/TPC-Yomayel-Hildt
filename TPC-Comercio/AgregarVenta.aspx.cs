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
        public List<Cliente> listaClientes;
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
                if (listaDetalles == null)
                    listaDetalles = new List<Detalle>();
                listaDetalles = (List<Detalle>)Session["detalleVenta"];
                Detalle detalle = new Detalle();
                detalle = (Detalle)Session["vDetalle"];

                
                
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                
                listaClientes = new List<Cliente>();
                listaClientes = clienteNegocio.listar();
                ddClientes.DataSource = listaClientes;
                ddClientes.DataTextField = "NombreCompleto";
                ddClientes.DataValueField = "Cuit";
                ddClientes.DataBind();

                ProductoNegocio productoNegocio = new ProductoNegocio();

                if(listaProductos == null)
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

            listaDetalles = (List<Detalle>)Session["detalleVenta"];
            if (listaDetalles != null)
            {
                gvDetalle.DataSource = listaDetalles;
                gvDetalle.DataBind();
            }
            
        }
        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            txtFecha.BorderColor = System.Drawing.Color.Gray;
            lblMessage.Text = "";
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = new Producto();
                int id = int.Parse(ddProductos.SelectedValue);
                producto = productoNegocio.GetProducto(id);
                var cantidad = txtCantidad.Text;
                decimal porcGanancia = Convert.ToDecimal(producto.PorcGanancia);
                decimal precioUnitario = producto.UltPrecio * ((porcGanancia / 100) + 1);
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtFecha.BorderColor = System.Drawing.Color.Gray;
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            lblMessage.Text = "";
            try
            {
                listaDetalles = (List<Detalle>)Session["detalleVenta"];
                if (listaDetalles == null) listaDetalles = new List<Detalle>();
                Detalle detalle = new Detalle();
                Producto producto = new Producto();
                ProductoNegocio productoNegocio = new ProductoNegocio();
                int id = int.Parse(ddProductos.SelectedValue);
                producto = productoNegocio.GetProducto(id);
                if (txtCantidad.Text == "" || txtCantidad.Text == "0" || int.Parse(txtCantidad.Text) < 0)
                {
                    txtCantidad.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Debe ingresar una cantidad mayor a 0";
                }
                else if (int.Parse(txtCantidad.Text) > producto.StockActual)
                {
                    txtCantidad.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "No se puede vender lo que no se tiene.";
                }


                else
                {
                    detalle.Cantidad = int.Parse(txtCantidad.Text);
                    detalle.Producto = new Producto();
                    detalle.Producto = producto;
                    detalle.PrecioParcial = decimal.Parse(txtSubtotal.Text);
                    detalle.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                    listaDetalles.Add(detalle);
                    Session.Add("vDetalle", detalle);
                    Session.Add("detalleVenta", listaDetalles);
                    listaProductos = (List<Producto>)Session["listaProductos"];
                    listaProductos.Remove(listaProductos.Find(x => x.Id == producto.Id));

                    Session.Add("listaProductos", listaProductos);
                    ddProductos.DataSource = listaProductos;
                    ddProductos.DataTextField = "Nombre";
                    ddProductos.DataValueField = "Id";
                    ddProductos.DataBind();
                    lblMessage.Text = "";
                    decimal montoTotal = 0;
                    foreach(Detalle detalle1 in listaDetalles)
                    {
                        montoTotal += detalle1.PrecioParcial;
                    }
                    lblTotal.Text = montoTotal.ToString();
                }

                txtCantidad.Text = "0";
                txtSubtotal.Text = "0";
                gvDetalle.DataSource = listaDetalles;
                gvDetalle.DataBind();
                btnAgregarTransaccion.Visible = true;
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
            txtFecha.BorderColor = System.Drawing.Color.Gray;
            try
            {
                if (txtFecha.Text != null)
                {
                    Usuario usuario = new Usuario();
                    usuario = (Usuario)Session["usuario"];
                    var fecha = txtFecha.Text;
                    Transaccion transaccion = new Transaccion();
                    transaccion.Vendedor = new Usuario();
                    transaccion.Vendedor = usuario;
                    TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                    List<Transaccion> listaTransacciones = new List<Transaccion>();
                    listaTransacciones = transaccionNegocio.listarTodasT();
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

                    transaccion.Fecha = DateTime.Parse(fecha);
                    transaccionNegocio.agregarVenta(transaccion);
                    DetalleNegocio detalleNegocio = new DetalleNegocio();

                    transaccion.listaDetalles = (List<Detalle>)Session["detalleVenta"];
                    listaDetalles = (List<Detalle>)Session["detalleVenta"];
                    Producto producto = new Producto();
                    ProductoNegocio productoNegocio = new ProductoNegocio();

                    foreach (Detalle item in listaDetalles)
                    {
                        producto = item.Producto;
                        producto.StockActual -= item.Cantidad;
                        if (producto.StockActual < 0) producto.StockActual = 0;
                        productoNegocio.stock(producto);
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
                    Session.Remove("detalleVenta");
                    Response.Redirect("Ventas.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    txtFecha.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Debe completar el campo de la fecha.";
                }
            }
            catch (Exception ex)
            {

                int valor;
                if(ex.Message.ToString() == "No se puede reconocer la cadena como valor DateTime válido.")
                {
                    txtFecha.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Debe completar el campo de la fecha.";
                }
                else if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
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

        protected void ddProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFecha.BorderColor = System.Drawing.Color.Gray;
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            try
            {
                lblMessage.Text = "";
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = new Producto();
                int id = int.Parse(ddProductos.SelectedValue);
                producto = productoNegocio.GetProducto(id);
                var cantidad = txtCantidad.Text;
                decimal porcGanancia = Convert.ToDecimal(producto.PorcGanancia);
                decimal precioUnitario = producto.UltPrecio * ((porcGanancia / 100) + 1);
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
            txtFecha.BorderColor = System.Drawing.Color.Gray;
            txtCantidad.BorderColor = System.Drawing.Color.Gray;
            try
            {
                lblMessage.Text = "";
                int index = Convert.ToInt32(e.RowIndex);
                listaDetalles = (List<Detalle>)Session["detalleVenta"];
                Detalle detalle = new Detalle();
                detalle = listaDetalles[index];
                listaDetalles.Remove(detalle);
                if (listaDetalles.Count == 0) btnAgregarTransaccion.Visible = false;
                Session.Add("detalleVenta", listaDetalles);
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
    }
}
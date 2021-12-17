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
    public partial class ModificarProducto : System.Web.UI.Page
    {

        public List<Producto> listaProductos;
        public List<Marca> listaMarcas;
        public List<Categoria> listaCategorias;
        Producto producto = new Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            int id = (int)Session["idProducto"];
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            try
            {
                listaCategorias = categoriaNegocio.listar();
                listaMarcas = marcaNegocio.listar();
                listaProductos = productoNegocio.listar();
                producto = listaProductos.Find(x => x.Id == id);
                if (!Page.IsPostBack)
                {
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.UltPrecio.ToString();
                    txtStockActual.Text = producto.StockActual.ToString();
                    txtPorc.Text = producto.PorcGanancia.ToString();
                    txtStock.Text = producto.StockMinimo.ToString();
                    

                    Marcas.DataSource = listaMarcas;
                    Marcas.DataTextField = "Nombre";
                    Marcas.DataValueField = "Id";
                    string idMarca = producto.Marca.Id.ToString();
                    Session.Add("idMarca", idMarca);
                    Marcas.DataBind();
                    Marcas.SelectedValue = idMarca;

                    Categorias.DataSource = listaCategorias;
                    string idCategoria = producto.Categoria.Id.ToString();
                    Session.Add("idCategoria", idCategoria);
                    Categorias.DataTextField = "Nombre";
                    Categorias.DataValueField = "Id";
                    Categorias.DataBind();
                    Categorias.SelectedValue = idCategoria;
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    lblError.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            volverBordes();
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            try
            {
                if (validarCampos())
                {
                    string idCategoria = (string)Session["idCategoria"];
                    string idMarca = (string)Session["idMarca"];
                    producto.Id = (int)Session["idProducto"];
                    producto.Nombre = txtNombre.Text;
                    producto.Descripcion = txtDescripcion.Text;
                    producto.PorcGanancia = int.Parse(txtPorc.Text);
                    producto.UltPrecio = decimal.Parse(txtPrecio.Text);
                    producto.StockMinimo = int.Parse(txtStock.Text);
                    producto.StockActual = int.Parse(txtStockActual.Text);
                    
                    producto.Marca = new Marca();
                    producto.Categoria = new Categoria();
                    if (Marcas.SelectedValue == null) producto.Marca.Id = int.Parse(idMarca);
                    else { producto.Marca.Id = int.Parse(Marcas.SelectedValue); }

                    if (Categorias.SelectedValue == null) producto.Categoria.Id = int.Parse(idCategoria);
                    else { producto.Categoria.Id = int.Parse(Categorias.SelectedValue); }

                    productoNegocio.actualizar(producto);
                    Response.Redirect("Productos.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                }
            }
            catch (Exception ex)
            {
                int valor;
                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    if (!int.TryParse(txtStock.Text, out valor))
                    {
                        txtStock.BorderColor = System.Drawing.Color.Red;
                        lblError.Text = "El stock minimo no puede contener letras.";
                    }
                    if (!int.TryParse(txtStockActual.Text, out valor))
                    {
                        txtStockActual.BorderColor = System.Drawing.Color.Red;
                        lblError.Text = "El stock actual no puede contener letras.";
                    }
                    if (!int.TryParse(txtPorc.Text, out valor))
                    {
                        txtPorc.BorderColor = System.Drawing.Color.Red;
                        lblError.Text = "El porcentaje de ganancia no puede contener letras.";
                    }
                    if (!int.TryParse(txtPrecio.Text, out valor))
                    {
                        txtPrecio.BorderColor = System.Drawing.Color.Red;
                        lblError.Text = "El precio no puede contener letras.";
                    }
                    lblError.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            
        }

        public bool validarCampos()
        {
            bool hola = true;
            var nombre = txtNombre.Text;
            var descripcion = txtDescripcion.Text;
            
            var precio = txtPrecio.Text;
            var stock = txtStock.Text;
            var stockActual = txtStockActual.Text;
            var porcGanancia = txtPorc.Text;
            var idMarca = Marcas.SelectedValue;
            var idCategoria = Categorias.SelectedValue;

            if (!(nombre != null && nombre != ""))
            {
                hola = false;
                txtNombre.BorderColor = System.Drawing.Color.Red;
            }
            if (!(descripcion != null && descripcion != ""))
            {
                hola = false;
                txtDescripcion.BorderColor = System.Drawing.Color.Red;
            }
            
            if (!(precio != null && precio != ""))
            {
                hola = false;
                txtPrecio.BorderColor = System.Drawing.Color.Red;
            }
            if (!(stock != null && stock != ""))
            {
                hola = false;
                txtStock.BorderColor = System.Drawing.Color.Red;
            }
            if (!(stockActual != null && stockActual != ""))
            {
                hola = false;
                txtStockActual.BorderColor = System.Drawing.Color.Red;
            }
            if (!(porcGanancia != null && porcGanancia != ""))
            {
                hola = false;
                txtPorc.BorderColor = System.Drawing.Color.Red;
            }
            if (!(idMarca != null && idMarca != ""))
            {
                hola = false;
                Marcas.BorderColor = System.Drawing.Color.Red;
            }
            if (!(idCategoria != null && idCategoria != ""))
            {
                hola = false;
                Categorias.BorderColor = System.Drawing.Color.Red;
            }



            return hola;
        }
        public void volverBordes()
        {
            txtNombre.BorderColor = System.Drawing.Color.Gray;
            txtDescripcion.BorderColor = System.Drawing.Color.Gray;
            
            txtPrecio.BorderColor = System.Drawing.Color.Gray;
            txtStock.BorderColor = System.Drawing.Color.Gray;
            txtStockActual.BorderColor = System.Drawing.Color.Gray;
            txtPorc.BorderColor = System.Drawing.Color.Gray;
            Marcas.BorderColor = System.Drawing.Color.Gray;
            Categorias.BorderColor = System.Drawing.Color.Gray;
        }
    }
}
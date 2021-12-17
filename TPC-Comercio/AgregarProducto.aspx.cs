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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        
        public List<Marca> listaMarcas;
        public List<Categoria> listaCategorias;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                listaMarcas = marcaNegocio.listar();
                listaCategorias = categoria.listar();
                ddCategorias.DataSource = listaCategorias;
                ddCategorias.DataValueField = "Id";
                ddCategorias.DataTextField = "Nombre";
                ddCategorias.DataBind();
                ddMarcas.DataSource = listaMarcas;
                ddMarcas.DataValueField = "Id";
                ddMarcas.DataTextField = "Nombre";
                ddMarcas.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
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
            var idMarca = ddMarcas.SelectedValue;
            var idCategoria = ddCategorias.SelectedValue;

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
                ddMarcas.BorderColor = System.Drawing.Color.Red;
            }
            if (!(idCategoria != null && idCategoria != ""))
            {
                hola = false;
                ddCategorias.BorderColor = System.Drawing.Color.Red;
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
            ddMarcas.BorderColor = System.Drawing.Color.Gray;
            ddCategorias.BorderColor = System.Drawing.Color.Gray;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            volverBordes();
            ProductoNegocio producto = new ProductoNegocio();
            Producto nuevo = new Producto();
            var nombre = txtNombre.Text;
            var descripcion = txtDescripcion.Text;
            
            var precio = txtPrecio.Text;
            var stock = txtStock.Text;
            var stockActual = txtStockActual.Text;
            var porcGanancia = txtPorc.Text;
            var idMarca = ddMarcas.SelectedValue;
            var idCategoria = ddCategorias.SelectedValue;
            try
            {
                if (validarCampos())
                {
                    
                    nuevo.Nombre = nombre;
                    nuevo.Descripcion = descripcion;
                   
                    nuevo.StockMinimo = int.Parse(stock);
                    nuevo.StockActual = int.Parse(stockActual);
                    nuevo.PorcGanancia = int.Parse(porcGanancia);
                    nuevo.UltPrecio = decimal.Parse(precio);
                    nuevo.Marca = new Marca(idMarca);
                    nuevo.Categoria = new Categoria(idCategoria);

                    producto.agregar(nuevo);
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
    }

    
}
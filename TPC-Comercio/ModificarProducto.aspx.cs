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
            int id = (int)Session["idProducto"];
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            listaCategorias = categoriaNegocio.listar();
            listaMarcas = marcaNegocio.listar();
            listaProductos = productoNegocio.listar();
            producto = listaProductos.Find(x => x.Id == id);
            if (!Page.IsPostBack)
            {
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                txtPorc.Text = producto.PorcGanancia.ToString();
                txtStock.Text = producto.StockMinimo.ToString();
                txtUrl.Text = producto.UrlImagen;

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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            string idCategoria = (string)Session["idCategoria"];
            string idMarca = (string)Session["idMarca"];
            producto.Id = (int)Session["idProducto"];
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.PorcGanancia = int.Parse(txtPorc.Text);
            producto.StockMinimo = int.Parse(txtStock.Text);
            producto.UrlImagen = txtUrl.Text;
            producto.Marca = new Marca();
            producto.Categoria = new Categoria();
            if(Marcas.SelectedValue == null)producto.Marca.Id = int.Parse(idMarca);
            else { producto.Marca.Id = int.Parse(Marcas.SelectedValue); }

            if (Categorias.SelectedValue == null) producto.Categoria.Id = int.Parse(idCategoria);
            else { producto.Categoria.Id = int.Parse(Categorias.SelectedValue); }

            productoNegocio.actualizar(producto);
            Response.Redirect("Productos.aspx");
        }
    }
}
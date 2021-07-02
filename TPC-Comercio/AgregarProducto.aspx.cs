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
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoria = new Negocio.CategoriaNegocio();
            ProductoNegocio producto = new ProductoNegocio();
            Producto nuevo = new Producto();
            var nombre = Request.Form["nombre"];
            var descripcion = Request.Form["descripcion"];
            var urlImagen = Request.Form["urlImagen"];
            
            var stock = (Request.Form["stock"]);
            var porcGanancia = Request.Form["porcGanancia"];
            var idMarca = (Request.Form["marcaSeleccionada"]);
            var idCategoria = (Request.Form["categoriaSeleccionada"]);
            /*
            nuevo.Nombre = Request.Form["nombre"];

            nuevo.Descripcion = Request.Form["descripcion"];

            nuevo.UrlImagen = Request.Form["urlImagen"];

            nuevo.StockMinimo = Convert.ToInt32(Request.Form["stock"]); 

            nuevo.PorcGanancia = Convert.ToInt32(Request.Form["porcGanancia"]);
            
            nuevo.Marca.Id = Convert.ToInt32(Request.Form["marcaSeleccionada"]);
            nuevo.Categoria.Id = Convert.ToInt32(Request.Form["categoriaSeleccionada"]);
            */


            lbl1.Text = nuevo.PorcGanancia.ToString();

            try
            {
                
                
                listaMarcas = marcaNegocio.listar();
                listaCategorias = categoria.listar();

                
                if (nombre != null ) nuevo.Nombre = nombre;
                if (descripcion != null) nuevo.Descripcion = descripcion;
                if (urlImagen != null) nuevo.UrlImagen = urlImagen;
                if (stock != null && stock != "") nuevo.StockMinimo = int.Parse(stock);
                if (porcGanancia != null && porcGanancia != "") nuevo.PorcGanancia = int.Parse(porcGanancia);
                if (idMarca != null && idMarca != "") nuevo.Marca = new Marca(idMarca);
                if (idCategoria != null && idCategoria != "") nuevo.Categoria = new Categoria(idCategoria);

                if (validarCampos())
                {
                    nuevo.Nombre = nombre;
                    nuevo.Descripcion = descripcion;
                    nuevo.UrlImagen = urlImagen;
                    nuevo.StockMinimo = int.Parse(stock);
                    nuevo.PorcGanancia = int.Parse(porcGanancia);
                    
                    nuevo.Marca = new Marca(idMarca);
                    nuevo.Categoria = new Categoria(idCategoria);
                   
                    producto.agregar(nuevo);
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            
            /*
                ProductoNegocio negocio = new ProductoNegocio();
                Producto nuevo = new Producto();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.PorcGanancia = Convert.ToInt32(txtPorcGanancia.Text);
                nuevo.StockMinimo = Convert.ToInt32(txtStock.Text);

                nuevo.Marca.Id = Convert.ToInt32(Request.Form["marcaSeleccionada"]);
                nuevo.Categoria.Id = Convert.ToInt32(Request.Form["categoriaSeleccionada"]);
                try
                {
                    negocio.agregar(nuevo);
                }
                catch (Exception)
                {

                    throw;
                }
            */

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            
        }

        public bool validarCampos()
        {
            bool hola = true;
            var nombre = Request.Form["nombre"];
            var descripcion = Request.Form["descripcion"];
            var urlImagen = Request.Form["urlImagen"];

            var stock = (Request.Form["stock"]);
            var porcGanancia = Request.Form["porcGanancia"];
            var idMarca = (Request.Form["marcaSeleccionada"]);
            var idCategoria = (Request.Form["categoriaSeleccionada"]);

            if (!(nombre != null && nombre != "")) hola = false;
            if (!(descripcion != null && descripcion != "")) hola = false;
            if (!(urlImagen != null && urlImagen!="")) hola = false;
            if (!(stock != null && stock != "")) hola = false;
            if (!(porcGanancia != null && porcGanancia != "")) hola = false;
            if (!(idMarca != null && idMarca != "")) hola = false;
            if (!(idCategoria != null && idCategoria != "")) hola = false;

            

            return hola;
        }
    }

    
}
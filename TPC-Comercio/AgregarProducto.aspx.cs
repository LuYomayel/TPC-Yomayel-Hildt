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
            try
            {
                listaMarcas = marcaNegocio.listar();
                listaCategorias = categoria.listar();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto nuevo = new Producto();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            //nuevo.Marca = parseInt(txtMarca.Text);
            //nuevo.Categoria = parseInt(txtCategoria.Text);

            var cantidad = ((TextBox)sender).Text;

            //nuevo.PorcGanancia =  cantidad;
            nuevo.UrlImagen = txtPorcGanancia.Text;
        }
    }
}
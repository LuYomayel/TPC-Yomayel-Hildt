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
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            categoria.Nombre = txtNombre.Text;
            categoriaNegocio.agregar(categoria);
            Response.Redirect("Categorias.aspx");
        }
    }
}
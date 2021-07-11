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
    public partial class ModificarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            marca.Id = (int)Session["idMarca"];
            marca.Nombre = txtNombre.Text;

            marcaNegocio.actualizar(marca);
            Response.Redirect("Marcas.aspx");
        }
    }
}
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
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                marca.Nombre = txtNombre.Text;
                if (txtNombre.Text == "")
                {
                    lblError.Text = "Este campo no puede ir vacío.";
                }
                else
                {
                    marcaNegocio.agregar(marca);
                    Response.Redirect("Marcas.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
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
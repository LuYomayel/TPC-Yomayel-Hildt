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
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = new Marca();
            
            try
            {
                if (!IsPostBack)
                {
                    int id = (int)Session["idMarca"];
                    marca = marcaNegocio.GetMarca(id);
                    txtNombre.Text = marca.Nombre;
                }
                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            txtNombre.BorderColor = System.Drawing.Color.Gray;
            Marca marca = new Marca();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            //txtNombre.Text = "hola";
            try
            {
                marca.Id = (int)Session["idMarca"];
                marca.Nombre = txtNombre.Text;
                if(txtNombre.Text != "")
                {
                    marcaNegocio.actualizar(marca);
                    Response.Redirect("Marcas.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    txtNombre.BorderColor = System.Drawing.Color.Red;
                    lblError.Text = "No puedes dejar campos vacios.";
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
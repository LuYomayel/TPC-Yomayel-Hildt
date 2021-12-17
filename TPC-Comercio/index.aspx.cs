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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Add("error", "Ya iniciaste sesion. Si desea iniciar sesión en una cuenta distinta haga click en el botón de abajo.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuario(txtUser.Text, txtPassword.Text, false);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Compras.aspx", false);
                }
                else
                {
                    lblError.Text = "Usuario o Contraseña incorrectos";
                    
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtUser_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
        }
    }
}
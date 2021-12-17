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
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();
            try
            {
                if (!IsPostBack)
                {
                    int id = (int)Session["idCategoria"];
                    categoria = categoriaNegocio.GetCategoria(id);
                    txtNombre.Text = categoria.Nombre;
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
            txtNombre.BorderColor = System.Drawing.Color.Gray;
            lblError.Text = "";
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                categoria.Id = (int)Session["idCategoria"];
                categoria.Nombre = txtNombre.Text;
                if(txtNombre.Text != "")
                {
                    categoriaNegocio.actualizar(categoria);
                    Response.Redirect("Categorias.aspx", false);
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
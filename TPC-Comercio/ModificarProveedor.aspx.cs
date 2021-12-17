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
    public partial class ModificarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();
            try
            {
                string cuit = (string)Session["cuitProveedor"];
                proveedor = negocio.GetProveedor(cuit);
                if (!Page.IsPostBack)
                {
                    txtDescripcion.Text = proveedor.Descripcion;
                    txtRazon.Text = proveedor.RazonSocial;
                    txtEmail.Text = proveedor.Email;
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
            volverBordes();
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            try
            {
                if (validarCampos())
                {
                    proveedor.Cuit = (string)Session["cuitProveedor"];
                    proveedor.RazonSocial = txtRazon.Text;
                    proveedor.Descripcion = txtDescripcion.Text;
                    proveedor.Email = txtEmail.Text;
                    proveedorNegocio.actualizar(proveedor);
                    Response.Redirect("Proveedores.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblError.Text = "Todos los campos son obligatorios";
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    lblError.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            

        }

        public bool validarCampos()
        {
            bool hola = true;
            
            var razonSocial = txtRazon.Text;
            var descripcion = txtDescripcion.Text;
            var email = txtEmail.Text;

            
            if (razonSocial == null || razonSocial == "")
            {
                hola = false;
                txtRazon.BorderColor = System.Drawing.Color.Red;
            }
            if (email == null || email == "")
            {
                hola = false;
                txtDescripcion.BorderColor = System.Drawing.Color.Red;
            }
            if (descripcion == null || descripcion == "")
            {
                hola = false;
                txtEmail.BorderColor = System.Drawing.Color.Red;
            }

            return hola;
        }
        public void volverBordes()
        {
            
            txtRazon.BorderColor = System.Drawing.Color.Gray;
            txtDescripcion.BorderColor = System.Drawing.Color.Gray;
            txtEmail.BorderColor = System.Drawing.Color.Gray;
        }
    }
}
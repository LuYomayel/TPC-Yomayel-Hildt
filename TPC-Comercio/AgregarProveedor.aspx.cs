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
    public partial class AgregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
        }

        public bool validarCampos()
        {
            bool hola=true;
            var cuit = txtCuit.Text;
            var razonSocial = txtRazon.Text;
            var descripcion = txtDescripcion.Text;
            var email = txtEmail.Text;

            if (cuit == null || cuit == "")
            {
                hola = false;
                txtCuit.BorderColor = System.Drawing.Color.Red;
            }
            if (razonSocial == null || razonSocial == "")
            {
                hola = false;
                txtRazon.BorderColor = System.Drawing.Color.Red;
            }
            if (email == null || email == "")
            {
                hola = false;
                txtEmail.BorderColor = System.Drawing.Color.Red;
            }
            if (descripcion == null || descripcion == "")
            {
                hola = false;
                txtDescripcion.BorderColor = System.Drawing.Color.Red;
            }

            return hola;
        }
        public void volverBordes()
        {
            txtCuit.BorderColor = System.Drawing.Color.Gray;
            txtRazon.BorderColor = System.Drawing.Color.Gray;
            txtDescripcion.BorderColor = System.Drawing.Color.Gray;
            txtEmail.BorderColor = System.Drawing.Color.Gray;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            volverBordes();
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            var cuit = txtCuit.Text;
            var razonSocial = txtRazon.Text;
            var descripcion = txtDescripcion.Text;
            var email = txtEmail.Text;
            try
            {
                if (validarCampos())
                {
                    proveedor.Cuit = cuit;
                    proveedor.RazonSocial = razonSocial;
                    proveedor.Descripcion = descripcion;
                    proveedor.Email = email;
                    proveedorNegocio.agregar(proveedor);
                    Response.Redirect("Proveedores.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.ToString() == "Violation of PRIMARY KEY constraint 'PK__Proveedo__AFA91787E9D0D179'. Cannot insert duplicate key in object 'dbo.Proveedores'. The duplicate key value is (2042886854).\r\nThe statement has been terminated.")
                {
                    txtCuit.BorderColor = System.Drawing.Color.Red;
                    lblError.Text = "Ese cuit ya ha sido ingresado.";
                }
                else if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
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
    }
}
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

        bool validarCampos()
        {
            bool hola=true;
            var cuit = txtCuit.Text;
            var razonSocial = txtRazon.Text;
            var descripcion = txtDescripcion.Text;
            var email = txtEmail.Text;

            if (cuit == null || cuit == "") hola = false;
            if (razonSocial == null || razonSocial == "") hola = false;
            if (email == null || email == "") hola = false;
            if (descripcion == null || descripcion == "") hola = false;

            return hola;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
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
    }
}
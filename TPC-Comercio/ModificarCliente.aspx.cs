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
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "Necesitas ser administrador.");
                Response.Redirect("Error.aspx", false);
            }
            string cuit = (string)Session["cuitCliente"];
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
                cliente = negocio.getCliente(cuit);

                if (!Page.IsPostBack)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtFecha.Text = String.Format("{0:yyyy-MM-dd}", cliente.FechaNac);
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono.ToString();
                    txtEmail.Text = cliente.Email;
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
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            volverBordes();
            lblError.Text = "";
            try
            {
                if (validarCampos())
                {
                    cliente.Cuit = (string)Session["cuitCliente"];
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.FechaNac = DateTime.Parse(txtFecha.Text);
                    cliente.Telefono = int.Parse(txtTelefono.Text);
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Email = txtEmail.Text;
                    clienteNegocio.actualizar(cliente);

                    Response.Redirect("Clientes.aspx", false);
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
        
        public bool validarCampos()
        {
            bool hola = true;

            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var fechaNac = txtFecha.Text;
            var telefono = txtTelefono.Text;
            var direccion = txtDireccion.Text;
            var email = txtEmail.Text;

            if (!(nombre != null && nombre != ""))
            {
                hola = false;
                txtNombre.BorderColor = System.Drawing.Color.Red;
    }
            if (!(apellido != null && apellido != ""))
            {
                hola = false;
                txtApellido.BorderColor = System.Drawing.Color.Red;
            }
            if (!(fechaNac != null && fechaNac != ""))
            {
                hola = false;
                txtFecha.BorderColor = System.Drawing.Color.Red;
            }
            if (!(telefono != null && telefono != ""))
            {
                hola = false;
                txtTelefono.BorderColor = System.Drawing.Color.Red;
            }
            if (!(direccion != null && direccion != ""))
            {
                hola = false;
                txtDireccion.BorderColor = System.Drawing.Color.Red;
            }
            if (!(email != null && email != ""))
            {
                hola = false;
                txtEmail.BorderColor = System.Drawing.Color.Red;
            }

            return hola;
        }
        public void volverBordes()
        {
            txtNombre.BorderColor = System.Drawing.Color.Gray;
            txtApellido.BorderColor = System.Drawing.Color.Gray;
            txtFecha.BorderColor = System.Drawing.Color.Gray;
            txtTelefono.BorderColor = System.Drawing.Color.Gray;
            txtDireccion.BorderColor = System.Drawing.Color.Gray;
            txtEmail.BorderColor = System.Drawing.Color.Gray;
        }
    }
}
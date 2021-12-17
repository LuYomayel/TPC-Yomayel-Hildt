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
    public partial class AgregarCliente : System.Web.UI.Page
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
            bool hola = true;
            var cuit = txtCuit.Text;
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var fechaNac = txtFecha.Text;
            var telefono = txtTelefono.Text;
            var direccion = txtDireccion.Text;
            var email = txtEmail.Text;

            if (!(cuit != null && cuit != ""))
            {
                hola = false;
                txtCuit.BorderColor = System.Drawing.Color.Red;
            }
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            volverBordes();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            var cuit = txtCuit.Text;
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var fechaNac = txtFecha.Text;
            var telefono = txtTelefono.Text;
            var direccion = txtDireccion.Text;
            var email = txtEmail.Text;
            try
            {
                if (validarCampos())
                {
                    cliente.Cuit = cuit;
                    cliente.Nombre = nombre;
                    cliente.Apellido = apellido;
                    cliente.FechaNac = DateTime.Parse(fechaNac);
                    cliente.Telefono = int.Parse(telefono);
                    cliente.Direccion = direccion;
                    cliente.Email = email;
                    clienteNegocio.agregar(cliente);
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
                int valor;
                if(ex.Message.ToString() == "Violation of PRIMARY KEY constraint 'PK__Clientes__AFA917879D116E53'. Cannot insert duplicate key in object 'dbo.Clientes'. The duplicate key value is (2042886854).\r\nThe statement has been terminated.")
                {
                    txtCuit.BorderColor = System.Drawing.Color.Red;
                    lblError.Text = "Ese cuit ya ha sido ingresado.";
                }
                else if (ex.Message.ToString() == ("La cadena de entrada no tiene el formato correcto."))
                {
                    if (!int.TryParse(txtTelefono.Text, out valor))
                    {
                        txtTelefono.BorderColor = System.Drawing.Color.Red;
                        lblError.Text = "El telefono no puede contener letras.";
                    }
                    else
                    {
                        lblError.Text = "Los datos ingresados no tienen el formato correcto. Asegurese de ingresar solamente numeros donde así se solicita.";
                    }
                }
                else
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
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
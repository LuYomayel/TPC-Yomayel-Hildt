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

            if (!(cuit != null && cuit != "")) hola = false;
            if (!(nombre != null && nombre != "")) hola = false;
            if (!(apellido != null && apellido != "")) hola = false;
            if (!(fechaNac != null && fechaNac != "")) hola = false;
            if (!(telefono != null && telefono != "")) hola = false;
            if (!(direccion != null && direccion != "")) hola = false;
            



            return hola;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
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
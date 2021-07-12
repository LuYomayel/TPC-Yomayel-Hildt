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

            int id = (int)Session["idCliente"];
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
                cliente = negocio.getCliente(id);

                if (!Page.IsPostBack)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtFecha.Text = String.Format("{0:yyyy-MM-dd}", cliente.FechaNac);
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono.ToString();
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
            try
            {
                cliente.Id = (int)Session["idCliente"];
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.FechaNac = DateTime.Parse(txtFecha.Text);
                cliente.Telefono = int.Parse(txtTelefono.Text);
                cliente.Direccion = txtDireccion.Text;
                clienteNegocio.actualizar(cliente);
                Response.Redirect("Clientes.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using Dominio;
using Negocio;
namespace TPC_Comercio
{
    public partial class AgregarCompra : System.Web.UI.Page
    {
        public List<Producto> cantProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (cantProductos == null)
                {
                    cantProductos = new List<Producto>();
                    Producto producto = new Producto();
                    cantProductos.Add(producto);
                }
                List<Proveedor> listaProveedores;
                List<Producto> listaProductos;

                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                listaProveedores = proveedorNegocio.listar();
                ddProveedor.DataSource = listaProveedores;
                ddProveedor.DataTextField = "RazonSocial";
                ddProveedor.DataValueField = "Cuit";
                ddProveedor.DataBind();

                ProductoNegocio productoNegocio = new ProductoNegocio();
                listaProductos = productoNegocio.listar();
                ddProductos.DataSource = listaProductos;
                ddProductos.DataTextField = "Nombre";
                ddProductos.DataValueField = "Id";
                ddProductos.DataBind();
            }
            


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            /*ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();

            int id = int.Parse(ddProductos.SelectedItem.Value);
            var cantidad = txtCantidad.Text;
            producto = productoNegocio.GetProducto(id);

            if (cantidad != "" && cantidad != "0,0")
            {
                decimal subtotal = producto.UltPrecio * decimal.Parse(txtCantidad.Text);

                txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
            */
        }

        protected void ddProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();

            int id = int.Parse(ddProductos.SelectedItem.Value);
            var cantidad = txtCantidad.Text;
            producto = productoNegocio.GetProducto(id);

            if (cantidad != "") { 
            decimal subtotal = producto.UltPrecio * decimal.Parse(txtCantidad.Text);

            txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }*/
        }

        protected void txtCantProd_TextChanged(object sender, EventArgs e)
        {
            int cantidad = int.Parse(txtCantProd.Text);
            if (cantProductos == null)
            {
                cantProductos = new List<Producto>();

            }
            for (int i = 0; i < cantidad; i++)
            {
                Producto producto = new Producto();
                cantProductos.Add(producto);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace TPC_Comercio
{
    public partial class Comisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión primero.");
                Response.Redirect("Error.aspx", false);
            }
            txtCantVentas1.Text = "1";
            List<Comision> listaComisiones = new List<Comision>();
            ComisionNegocio comisionNegocio = new ComisionNegocio();
            if(comisionNegocio.listarComisiones() != null)
            {
                listaComisiones = comisionNegocio.listarComisiones();
                txtCantVentas1.Text = "1";
                
                txtCantVentas2.Text = listaComisiones[0].CantVentas.ToString();
                txtCantVentas3.Text = listaComisiones[0].CantVentas++.ToString();
                txtCantVentas4.Text = listaComisiones[1].CantVentas.ToString();
                txtCantVentas5.Text = listaComisiones[2].CantVentas.ToString();
                txtComision1.Text = listaComisiones[0].Porcentaje.ToString();
                txtComision2.Text = listaComisiones[1].Porcentaje.ToString();
                txtComision3.Text = listaComisiones[2].Porcentaje.ToString();
            }
            

        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {

                ComisionNegocio comisionNegocio = new ComisionNegocio();
                comisionNegocio.eliminarComisiones();
                Comision comision = new Comision();
                comision.CantVentas = int.Parse(txtCantVentas2.Text);
                comision.Porcentaje = float.Parse(txtComision1.Text);
                comisionNegocio.cargarComisiones(comision);
                comision.CantVentas = int.Parse(txtCantVentas4.Text);
                comision.Porcentaje = float.Parse(txtComision2.Text);
                comisionNegocio.cargarComisiones(comision);
                comision.CantVentas = int.Parse(txtCantVentas5.Text);
                comision.Porcentaje = float.Parse(txtComision3.Text);
                comisionNegocio.cargarComisiones(comision);
            }
        }

        protected void txtCantVentas2_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(txtCantVentas2.Text) > 1)
            {
                int cantVentas2 = int.Parse(txtCantVentas2.Text) + 1;
                txtCantVentas3.Text = cantVentas2.ToString();
                txtCantVentas4.ReadOnly = false;
            }
        }

        protected void txtCantVentas4_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtCantVentas4.Text) > int.Parse(txtCantVentas3.Text))
            {
                int cantVentas2 = int.Parse(txtCantVentas4.Text) + 1;
                txtCantVentas5.Text = cantVentas2.ToString();
                
            }
        }
        public bool validarCampos()
        {
            bool xd=true;

            if (txtCantVentas1.Text == "") xd = false;
            if (txtCantVentas2.Text == "") xd = false;
            if (txtCantVentas3.Text == "") xd = false;
            if (txtCantVentas4.Text == "") xd = false;
            if (txtCantVentas5.Text == "") xd = false;
            
            if (txtComision1.Text == "") xd = false;
            if (txtComision1.Text == "") xd = false;
            if (txtComision1.Text == "") xd = false;

            return xd;
        }
    }
}
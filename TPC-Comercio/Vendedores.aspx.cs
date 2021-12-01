using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio
{
    public partial class Vendedores : System.Web.UI.Page
    {
        public List<Transaccion> transacciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión primero.");
                Response.Redirect("Error.aspx", false);
            }
            if (!Page.IsPostBack)
            {
                /*TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                transacciones = transaccionNegocio.listarTodasV();
                gvVentas.DataSource = transacciones;
                gvVentas.DataBind();


                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario1 = new Usuario(-1);
                List<Usuario> listaUsuarios = new List<Usuario>();
                listaUsuarios = usuarioNegocio.listarVendedores();
                listaUsuarios.Add(usuario1);
                ddlVendedores.DataSource = listaUsuarios;

                
                ddlVendedores.DataTextField = "User";
                ddlVendedores.DataValueField = "Id";
                ddlVendedores.DataBind();


                int[] CantVentas;
                CantVentas = new int[listaUsuarios.Count];

                for (int i = 0; i < 3; i++) CantVentas[i] = 0;
                double comisionPorc = 0, comisionTotal;

                foreach (Transaccion venta in transacciones)
                {
                    if (venta.Vendedor.User == "Vendedor1") CantVentas[0]++;
                    if (venta.Vendedor.User == "Vendedor2") CantVentas[1]++;
                    if (venta.Vendedor.User == "Vendedor3") CantVentas[2]++;
                }

                for (int j = 0; j < 3; j++)
                {
                    if (CantVentas[j] < 5) comisionPorc = 0.03;
                    else if (CantVentas[j] >= 5 && CantVentas[j] < 10) comisionPorc = 0.05;
                    else comisionPorc = 0.1;

                    listaUsuarios[j].ComisionPorc = comisionPorc;
                }

                for (int x = 0; x < transacciones.Count; x++)
                {
                    for (int j = 0; j < listaUsuarios.Count; j++) {
                        if (transacciones[x].Vendedor.User == listaUsuarios[j].User) transacciones[x].Vendedor.ComisionPorc = listaUsuarios[j].ComisionPorc;
                     }
                }

                double TotalComisiones=0;

                foreach (Transaccion venta in transacciones)
                {

                    comisionTotal = decimal.ToDouble(venta.Monto) * venta.Vendedor.ComisionPorc;
                    venta.Comision = comisionTotal;

                    TotalComisiones += comisionTotal;

                }

                lblTotal.Text = TotalComisiones.ToString();
                gvVentas.DataBind();*/
                mostrarTodasV();
                mostrarDdlVendedores();
            }
        }

        protected void ddlVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlVendedores.SelectedValue) == -1)
            {
                mostrarTodasV();
            }
            else
            {


                int CantVentas = 0;
                double comisionPorc, comisionTotal;
                TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario = usuarioNegocio.getVendedor(int.Parse(ddlVendedores.SelectedValue));
                transacciones = transaccionNegocio.listarVentas(usuario);

                foreach (Transaccion venta in transacciones)
                {
                    CantVentas++;
                }
                if (CantVentas < 5) comisionPorc = 0.03;
                else if (CantVentas >= 5 && CantVentas < 10) comisionPorc = 0.05;
                else comisionPorc = 0.1;

                double TotalComisiones = 0;

                foreach (Transaccion venta in transacciones)
                {
                    comisionTotal = decimal.ToDouble(venta.Monto) * comisionPorc;
                    venta.Comision = comisionTotal;

                    TotalComisiones += comisionTotal;
                }

                lblTotal.Text = TotalComisiones.ToString();

                gvVentas.DataSource = transacciones;
                gvVentas.DataBind();

            }
        }

        public void mostrarTodasV()
        {
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            
            Usuario usuario = new Usuario();
            
            transacciones = transaccionNegocio.listarTodasV();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            //Usuario usuario1 = new Usuario(-1);
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = usuarioNegocio.listarVendedores();
            

            int[] CantVentas;
            CantVentas = new int[listaUsuarios.Count];

            for (int i = 0; i < 3; i++) CantVentas[i] = 0;
            double comisionPorc = 0, comisionTotal;

            foreach (Transaccion venta in transacciones)
            {
                if (venta.Vendedor.User == "Vendedor1") CantVentas[0]++;
                if (venta.Vendedor.User == "Vendedor2") CantVentas[1]++;
                if (venta.Vendedor.User == "Vendedor3") CantVentas[2]++;
            }

            for (int j = 0; j < 3; j++)
            {
                if (CantVentas[j] < 5) comisionPorc = 0.03;
                else if (CantVentas[j] >= 5 && CantVentas[j] < 10) comisionPorc = 0.05;
                else comisionPorc = 0.1;

                listaUsuarios[j].ComisionPorc = comisionPorc;
            }

            for (int x = 0; x < transacciones.Count; x++)
            {
                for (int j = 0; j < listaUsuarios.Count; j++)
                {
                    if (transacciones[x].Vendedor.User == listaUsuarios[j].User) transacciones[x].Vendedor.ComisionPorc = listaUsuarios[j].ComisionPorc;
                }
            }

            double TotalComisiones = 0;

            foreach (Transaccion venta in transacciones)
            {

                comisionTotal = decimal.ToDouble(venta.Monto) * venta.Vendedor.ComisionPorc;
                venta.Comision = comisionTotal;

                TotalComisiones += comisionTotal;

            }

            lblTotal.Text = TotalComisiones.ToString();
            gvVentas.DataSource = transacciones;
            
            gvVentas.DataBind();
        }

        public void mostrarDdlVendedores()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario1 = new Usuario(-1);
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = usuarioNegocio.listarVendedores();
            listaUsuarios.Add(usuario1);
            ddlVendedores.DataSource = listaUsuarios;


            ddlVendedores.DataTextField = "User";
            ddlVendedores.DataValueField = "Id";
            ddlVendedores.DataBind();
        }
    }
}
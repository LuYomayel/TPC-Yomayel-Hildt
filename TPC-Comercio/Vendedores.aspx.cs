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
                ComisionNegocio comisionNegocio = new ComisionNegocio();
                List<Comision> listacomisiones = new List<Comision>();

                listacomisiones = comisionNegocio.listarComisiones();

                TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario = usuarioNegocio.getVendedor(int.Parse(ddlVendedores.SelectedValue));
                transacciones = transaccionNegocio.listarVentas(usuario);

                foreach (Transaccion venta in transacciones)
                {
                    usuario.CantVentas++;
                    CantVentas++;
                }

                bool entre = false;
                foreach (Comision comision in listacomisiones)
                {

                    if (usuario.CantVentas <= comision.CantVentas && entre == false)
                    {
                        usuario.ComisionPorc = comision.Porcentaje;
                        entre = true;
                        
                    }
                }
                  
                double TotalComisiones = 0;
                foreach (Transaccion transaccion in transacciones)
                {
                    
                    
                    transaccion.Comision = ((usuario.ComisionPorc) * Convert.ToDouble(transaccion.Monto)) / 100;
                    
                    
                    TotalComisiones += transaccion.Comision;
                }
                

                lblTotal.Text = TotalComisiones.ToString();

                gvVentas.DataSource = transacciones;
                gvVentas.DataBind();

            }
        }

        public void mostrarTodasV()
        {
            TransaccionNegocio transaccionNegocio = new TransaccionNegocio();
            
            transacciones = transaccionNegocio.listarTodasV();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = usuarioNegocio.listarVendedores();
            
            double comisionTotal;

            foreach (Transaccion venta in transacciones)
            {
                foreach(Usuario usuario in listaUsuarios)
                {
                    if (venta.Vendedor.User == usuario.User) usuario.CantVentas++;
                }
                
            }

            ComisionNegocio comisionNegocio = new ComisionNegocio();
            List<Comision> listacomisiones = new List<Comision>();

            listacomisiones = comisionNegocio.listarComisiones();


            bool entre = false;
            foreach (Usuario usuario1 in listaUsuarios)
            {
                foreach(Comision comision in listacomisiones)
                {
                    
                    if(usuario1.CantVentas <= comision.CantVentas && entre == false)
                    {
                        usuario1.ComisionPorc = comision.Porcentaje;
                        entre = true;
                    }
                }
                entre = false;
            }

            double TotalComisiones = 0;
            foreach (Transaccion transaccion in transacciones)
            {
                foreach(Usuario usuario1 in listaUsuarios)
                {
                    if(transaccion.Vendedor.User == usuario1.User)
                    {
                        transaccion.Comision = ((usuario1.ComisionPorc) * Convert.ToDouble(transaccion.Monto))/100;
                    }
                }
                TotalComisiones += transaccion.Comision;
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
            //listaUsuarios.Add(usuario1);
            listaUsuarios.Insert(0, usuario1);
            ddlVendedores.DataSource = listaUsuarios;


            ddlVendedores.DataTextField = "User";
            ddlVendedores.DataValueField = "Id";
            ddlVendedores.DataBind();
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Comisiones.aspx", false);
        }
    }
}
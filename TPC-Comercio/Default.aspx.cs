using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace TPC_Comercio
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            GridView1.DataSource = negocio.listar();
            GridView1.DataBind();
        }
    }
}
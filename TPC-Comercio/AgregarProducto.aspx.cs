﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Comercio
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        
        public List<Marca> listaMarcas;
        public List<Categoria> listaCategorias;

        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                listaMarcas = marcaNegocio.listar();
                listaCategorias = categoria.listar();
                ddCategorias.DataSource = listaCategorias;
                ddCategorias.DataValueField = "Id";
                ddCategorias.DataTextField = "Nombre";
                ddCategorias.DataBind();
                ddMarcas.DataSource = listaMarcas;
                ddMarcas.DataValueField = "Id";
                ddMarcas.DataTextField = "Nombre";
                ddMarcas.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        

        public bool validarCampos()
        {
            bool hola = true;
            var nombre = txtNombre.Text;
            var descripcion = txtDescripcion.Text;
            var urlImagen = txtUrl.Text;

            var stock = txtStock.Text;
            var porcGanancia = txtPorc.Text;
            var idMarca = ddMarcas.SelectedValue;
            var idCategoria = ddCategorias.SelectedValue;

            if (!(nombre != null && nombre != "")) hola = false;
            if (!(descripcion != null && descripcion != "")) hola = false;
            if (!(urlImagen != null && urlImagen!="")) hola = false;
            if (!(stock != null && stock != "")) hola = false;
            if (!(porcGanancia != null && porcGanancia != "")) hola = false;
            if (!(idMarca != null && idMarca != "")) hola = false;
            if (!(idCategoria != null && idCategoria != "")) hola = false;

            

            return hola;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio producto = new ProductoNegocio();
            Producto nuevo = new Producto();
            var nombre = txtNombre.Text;
            var descripcion = txtDescripcion.Text;
            var urlImagen = txtUrl.Text;

            var stock = txtStock.Text;
            var porcGanancia = txtPorc.Text;
            var idMarca = ddMarcas.SelectedValue;
            var idCategoria = ddCategorias.SelectedValue;
            try
            {
                if (validarCampos())
                {
                    
                    nuevo.Nombre = nombre;
                    nuevo.Descripcion = descripcion;
                    nuevo.UrlImagen = urlImagen;
                    nuevo.StockMinimo = int.Parse(stock);
                    nuevo.PorcGanancia = int.Parse(porcGanancia);

                    nuevo.Marca = new Marca(idMarca);
                    nuevo.Categoria = new Categoria(idCategoria);

                    producto.agregar(nuevo);
                    Response.Redirect("Productos.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }

    
}
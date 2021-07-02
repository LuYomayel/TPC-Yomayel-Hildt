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
            CategoriaNegocio categoria = new Negocio.CategoriaNegocio();
            ProductoNegocio producto = new ProductoNegocio();
            Producto nuevo = new Producto();
            var nombre = Request.Form["nombre"];
            var descripcion = Request.Form["descripcion"];
            var urlImagen = Request.Form["urlImagen"];
            
            var stock = (Request.Form["stock"]);
            var porcGanancia = Request.Form["porcGanancia"];
            var idMarca = (Request.Form["marcaSeleccionada"]);
            var idCategoria = (Request.Form["categoriaSeleccionada"]);
            

            try
            {
                
                
                listaMarcas = marcaNegocio.listar();
                listaCategorias = categoria.listar();

                
                if (nombre != null ) nuevo.Nombre = nombre;
                if (descripcion != null) nuevo.Descripcion = descripcion;
                if (urlImagen != null) nuevo.UrlImagen = urlImagen;
                if (stock != null && stock != "") nuevo.StockMinimo = int.Parse(stock);
                if (porcGanancia != null && porcGanancia != "") nuevo.PorcGanancia = int.Parse(porcGanancia);
                if (idMarca != null && idMarca != "") nuevo.Marca = new Marca(idMarca);
                if (idCategoria != null && idCategoria != "") nuevo.Categoria = new Categoria(idCategoria);

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
                }

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
            var nombre = Request.Form["nombre"];
            var descripcion = Request.Form["descripcion"];
            var urlImagen = Request.Form["urlImagen"];

            var stock = (Request.Form["stock"]);
            var porcGanancia = Request.Form["porcGanancia"];
            var idMarca = (Request.Form["marcaSeleccionada"]);
            var idCategoria = (Request.Form["categoriaSeleccionada"]);

            if (!(nombre != null && nombre != "")) hola = false;
            if (!(descripcion != null && descripcion != "")) hola = false;
            if (!(urlImagen != null && urlImagen!="")) hola = false;
            if (!(stock != null && stock != "")) hola = false;
            if (!(porcGanancia != null && porcGanancia != "")) hola = false;
            if (!(idMarca != null && idMarca != "")) hola = false;
            if (!(idCategoria != null && idCategoria != "")) hola = false;

            

            return hola;
        }
    }

    
}
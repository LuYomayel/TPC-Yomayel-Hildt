<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Comercio.Productos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <%foreach (Dominio.Producto item in listaProductos)
            { %>
        
            <div class="card" style="width: 18rem;">
                <img src="<% = item.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><% =item.Nombre %></h5>
                    <p class="card-text"><% =item.Descripcion  %></p>
                
                </div>
            </div>
        
        <% } %>
    

    <a class="btn btn-primary" href="AgregarProducto.aspx" role="button" >Agregar Producto</a>
    
</asp:Content>

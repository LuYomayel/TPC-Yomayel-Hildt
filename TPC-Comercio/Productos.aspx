<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Comercio.Productos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <form method="post">
            <%foreach (Dominio.Producto item in listaProductos)
            { %>
        
            <div class="card" style="width: 18rem;">
                <img src="<% = item.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><% =item.Nombre %></h5>
                    <p class="card-text"><% =item.Descripcion  %></p>
                    <p class="card-text"><% = item.Categoria %></p>
                    <p class="card-text"><% =item.Marca %></p>
                    <a class="btn btn-primary" href="DetalleProducto.aspx?id=<% = item.Id %>" role="button">Detalle</a>
                </div>
            </div>
        
        <% } %>
            <label id="lblEjemplo" runat="server"></label>
                </form>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    

    <a class="btn btn-primary" href="AgregarProducto.aspx" role="button" >Agregar Producto</a>
    
</asp:Content>

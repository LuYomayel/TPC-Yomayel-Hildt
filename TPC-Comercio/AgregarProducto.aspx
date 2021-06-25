<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Comercio.AgregarProducto" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
        <div class="form-group">
            <label >Nombre del producto</label>
            <asp:TextBox class="form-control" id="txtNombre" runat="server"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <asp:TextBox class="form-control" id="txtDescripcion" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Url Imagen</label>
            <asp:TextBox class="form-control" id="txtUrlImagen" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Porcentaje de ganancia</label>
            <asp:TextBox TextMode="Number" class="form-control" id="txtPorcGanancia" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Marca</label>
            
        
            <% foreach (Dominio.Marca item in listaMarcas)
                    { %>
            <select class="form-control">
                
                <option><% = item.Nombre %></option>
                
            </select>
            <% } %>
        </div>

        <div class="form-group">
            <label >Categoria</label>
            <% foreach (Dominio.Categoria item in listaCategorias)
                    { %>
            
                <select class="form-control" >
                <option><% = item.Nombre %></option>
                
            </select>
            <% } %>
        </div>
        
        <asp:button  runat="server" Text="Agregar Producto" ID="btnAgregar" OnClick="btnAgregar_Click"/> 
    </form>

</asp:Content>

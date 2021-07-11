<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="TPC_Comercio.ModificarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
            <label >Nombre del producto</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <asp:TextBox ID="txtDescripcion" runat="server" class="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Url Imagen</label>
            <asp:TextBox ID="txtUrl" runat="server" class="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Porcentaje de ganancia</label>
            <asp:TextBox ID="txtPorc" runat="server" class="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Stock Minimo</label>
            <asp:TextBox ID="txtStock" runat="server" class="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group" runat="server">
            <label >Marca</label>
            <asp:DropDownList ID="Marcas" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label >Categoria</label>
            <asp:DropDownList ID="Categorias" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>
        </div> 
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCategoria.aspx.cs" Inherits="TPC_Comercio.ModificarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label >Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox> 
    </div>
    <div>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary"/>
    </div> 
</asp:Content>

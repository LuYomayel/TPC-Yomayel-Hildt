<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="TPC_Comercio.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label >Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox> 
    </div>
    <div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/>
    </div> 
</asp:Content>

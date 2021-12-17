<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="TPC_Comercio.AgregarMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label >Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox> 
        <asp:Label ID="lblError" runat="server"  CssClass="red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/>
        
    </div> 
    
</asp:Content>

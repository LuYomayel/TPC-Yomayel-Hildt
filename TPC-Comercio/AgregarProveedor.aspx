<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="TPC_Comercio.AgregarProveedor" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-group">
            <label >Cuit</label>
            <asp:TextBox ID="txtCuit" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Razon Social</label>
            <asp:TextBox ID="txtRazon" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <asp:TextBox ID="txtDescripcion" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Email</label>
            <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/>
        </div> 
        <div>
            <asp:Label ID="lblError" runat="server" ></asp:Label>
        </div>
</asp:Content>

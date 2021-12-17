<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Comercio.AgregarCliente" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="form-group">
            <label >Cuit</label>
            
            <asp:TextBox class="form-control" id="txtCuit" runat="server" CssClass="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Nombre</label>
            
            <asp:TextBox class="form-control" id="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Apellido</label>
            
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Fecha de Nacimiento</label>
            
            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Direccion</label>
            
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Telefono</label>
            
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Email</label>
            
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblError" runat="server"  CssClass="text-danger"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
        </div> 
        

        
</asp:Content>

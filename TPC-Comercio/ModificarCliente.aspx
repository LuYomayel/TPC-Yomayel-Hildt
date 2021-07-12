<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="TPC_Comercio.ModificarCliente" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="form-group">
            <label >Nombre</label>
            
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Apellido</label>
            
            <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Fecha de Nacimiento</label>
            <asp:TextBox ID="txtFecha" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Direccion</label>
            
            <asp:TextBox ID="txtDireccion" runat="server" class="form-control"></asp:TextBox>
        </div>
    
        <div class="form-group">
            <label >Telefono</label>
            
            <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Email</label>
            
            <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
        </div>
        
        <div>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary"/>
        </div> 


        
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="TPC_Comercio.ModificarCliente" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="form-group">
            <label >Nombre</label>
            <input type="text" name="nombre" class="form-control" id="nombre" runat="server">
            
            
        </div>
        <div class="form-group">
            <label >Apellido</label>
            <input type="text" name="apellido" class="form-control" runat="server" id="apellido">
            
        </div>
        <div class="form-group">
            <label >Fecha de Nacimiento</label>
            <input type="date" name="fechaNac" class="form-control"  runat="server" id="fechaNac">
            
        </div>
        <div class="form-group">
            <label >Direccion</label>
            <input type="text" name="direccion" class="form-control" runat="server" id="direccion">
        </div>
        <div class="form-group">
            <label >Telefono</label>
            <input type="tel" name="telefono" class="form-control" runat="server" id="telefono">
        </div>
        
        <div>
            <label>&nbsp;</label>
            <input type="submit" value="Editar Cliente" class="btn btn-primary" name="editar"/>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
        </div> 


        
</asp:Content>

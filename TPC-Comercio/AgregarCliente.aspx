<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Comercio.AgregarCliente" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post">
        <div class="form-group">
            <label >Nombre</label>
            <input type="text" name="nombre" class="form-control">
            <%--<asp:TextBox class="form-control" id="txtNombre" runat="server"></asp:TextBox>--%>
            
        </div>
        <div class="form-group">
            <label >Apellido</label>
            <input type="text" name="apellido" class="form-control">
            
        </div>
        <div class="form-group">
            <label >Fecha de Nacimiento</label>
            <input type="date" name="fechaNac" class="form-control" >
            
        </div>
        <div class="form-group">
            <label >Direccion</label>
            <input type="text" name="direccion" class="form-control">
        </div>
        <div class="form-group">
            <label >Telefono</label>
            <input type="tel" name="telefono" class="form-control">
        </div>
        
        <div>
            <label>&nbsp;</label>
            <input type="submit" value="Agregar Cliente" class="btn btn-primary" />
            
        </div> 


        </form>
</asp:Content>

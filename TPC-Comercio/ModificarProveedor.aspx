<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProveedor.aspx.cs" Inherits="TPC_Comercio.ModificarProveedor" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post" class="form-group">

        <div class="form-group">
            <label >Razon Social</label>
            <input type="text" name="razonSocial" class="form-control" runat="server" id="razonSocial">
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <input type="text" name="descripcion" class="form-control" runat="server" id="descripcion">
            
        </div>
        <div>
            <label>&nbsp;</label>
            <input type="submit" value="Editar Proveedor" class="btn btn-primary" />
            
        </div> 
    </form>
</asp:Content>

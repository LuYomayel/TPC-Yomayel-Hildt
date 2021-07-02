<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="TPC_Comercio.AgregarProveedor" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form method="post" class="form-group">

        <div class="form-group">
            <label >Razon Social</label>
            <input type="text" name="razonSocial" class="form-control">
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <input type="text" name="descripcion" class="form-control">
            
        </div>
        <div>
            <label>&nbsp;</label>
            <input type="submit" value="Agregar Proveedor" class="btn btn-primary" />
            
        </div> 
    </form>

</asp:Content>

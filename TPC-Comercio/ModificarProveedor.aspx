<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProveedor.aspx.cs" Inherits="TPC_Comercio.ModificarProveedor" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

        <div class="form-group">
            <label >Razon Social</label>
            
            <asp:TextBox ID="txtRazon" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary"/>
        </div> 
    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMarca.aspx.cs" Inherits="TPC_Comercio.ModificarMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group">
            <label >Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox> 
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <div>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary"/>
    </div> 
</asp:Content>

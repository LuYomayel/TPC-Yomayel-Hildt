<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="TPC_Comercio.DetalleVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" >
        <Columns>
            <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto"/>
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario"/>
            <asp:BoundField DataField="PrecioParcial" HeaderText="Precio Parcial"/>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>S
</asp:Content>

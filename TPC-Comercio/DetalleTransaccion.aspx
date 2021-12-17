<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleTransaccion.aspx.cs" Inherits="TPC_Comercio.DetalleTransaccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" >
        <Columns>
            <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto"/>
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario"/>
            <asp:BoundField DataField="PrecioParcial" HeaderText="Precio Parcial"/>
        </Columns>
    </asp:GridView>
    <div class="row">
        <div class="col-9"></div>
        <div class="col-3">
            <asp:Label ID="lblTotal" runat="server" Text="Label" CssClass="h3"></asp:Label>
        </div>
    </div>
    
</asp:Content>

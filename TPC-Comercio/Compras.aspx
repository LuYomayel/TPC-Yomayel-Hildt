<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Comercio.Compras" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvCompras_RowCommand">
        <Columns>
            <asp:BoundField DataField="Monto" HeaderText="Monto"/>
            <asp:BoundField DataField="Proveedor.RazonSocial" HeaderText="Proveedor"/>
            <asp:ButtonField CommandName="Detalle" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Detalle" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Message" runat="server"></asp:Label>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Compra" OnClick="btnAgregar_Click"/>
</asp:Content>

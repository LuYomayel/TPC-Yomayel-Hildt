<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Comercio.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <<asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvVentas_RowCommand">
        <Columns>
            <asp:BoundField DataField="Monto" HeaderText="Monto"/>
            <asp:BoundField DataField="Cliente.Nombre" HeaderText="Cliente"/>
            <asp:ButtonField CommandName="Detalle" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Detalle" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Message" runat="server"></asp:Label>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Venta" OnClick="btnAgregar_Click"/>
</asp:Content>

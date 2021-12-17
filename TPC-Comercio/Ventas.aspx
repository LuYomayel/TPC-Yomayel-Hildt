<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Comercio.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ventas</h1>
    <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvVentas_RowCommand" >
        <Columns>
            <asp:BoundField DataField="Monto" HeaderText="Monto"/>
            <asp:BoundField DataField="Cliente.NombreCompleto" HeaderText="Cliente"/>
            <asp:ButtonField CommandName="Detalle" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Detalle" HeaderText="Detalle"/>
            <%--<asp:ButtonField CommandName="Delete" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Eliminar" HeaderText="Eliminar" />--%>
        </Columns>
    </asp:GridView>
    <p><asp:Label ID="Message" runat="server"></asp:Label></p>
    <p><asp:Button ID="btnAgregar" runat="server" Text="Agregar Venta" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/></p>
</asp:Content>

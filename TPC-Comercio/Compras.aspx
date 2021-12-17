<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Comercio.Compras" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Compras</h1>
    <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvCompras_RowCommand">
        <Columns>
            <asp:BoundField DataField="Monto" HeaderText="Monto"/>
            <asp:BoundField DataField="Proveedor.RazonSocial" HeaderText="Proveedor"/>
            <asp:ButtonField CommandName="Detalle" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Detalle" HeaderText="Detalle"/>
            
            <%--<asp:ButtonField CommandName="Delete" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Eliminar" HeaderText="Eliminar" />--%>
            
        </Columns>
    </asp:GridView>
    <p><asp:Label ID="Message" runat="server"></asp:Label></p>
    <p><asp:Button ID="btnAgregar" runat="server" Text="Agregar Compra" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/></p>
</asp:Content>

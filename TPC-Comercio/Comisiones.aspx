<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="TPC_Comercio.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Comisiones</h1>
        <p>Entre <asp:TextBox ID="txtCantVentas1" runat="server" TextMode="Number" ReadOnly="true"></asp:TextBox> y <asp:TextBox ID="txtCantVentas2" runat="server" OnTextChanged="txtCantVentas2_TextChanged" TextMode="Number" AutoPostBack="true"></asp:TextBox> ventas. Comision <asp:TextBox ID="txtComision1" runat="server" TextMode="Number"></asp:TextBox></p>
        <p>Entre <asp:TextBox ID="txtCantVentas3" runat="server" TextMode="Number" ReadOnly="true"></asp:TextBox> y <asp:TextBox ID="txtCantVentas4" runat="server" OnTextChanged="txtCantVentas4_TextChanged" TextMode="Number" ReadOnly="true" AutoPostBack="true"></asp:TextBox> ventas. Comision <asp:TextBox ID="txtComision2" runat="server" TextMode="Number"></asp:TextBox></p>
        <p>Entre <asp:TextBox ID="txtCantVentas5" runat="server" TextMode="Number" ReadOnly="true"></asp:TextBox> y <asp:TextBox ID="txtCantVentas6" runat="server"  TextMode="Number" ReadOnly="true" AutoPostBack="true"></asp:TextBox> ventas. Comision <asp:TextBox ID="txtComision3" runat="server" TextMode="Number"></asp:TextBox></p>
    </div>
    
    <asp:Button ID="btnComisiones" runat="server" Text="Button"  CssClass="btn btn-primary" OnClick="btnComisiones_Click"/>
</asp:Content>

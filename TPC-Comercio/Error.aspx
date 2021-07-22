<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Comercio.Error" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



        <div>
            <h1>Error</h1>
            <asp:Label ID="Lblerror" runat="server" Text="Label"></asp:Label>
            
        </div>
            <% if (Lblerror.Text == "Ya iniciaste sesion. Si desea iniciar sesión en una cuenta distinta haga click en el botón de abajo.")
                { %>
            <asp:Button ID="btnCerrarSession" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSession_Click" CssClass="btn btn-primary"/>
            <% } %>



</asp:Content>

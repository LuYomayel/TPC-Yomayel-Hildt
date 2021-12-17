<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPC_Comercio.WebForm1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Usuario</label>
            <asp:TextBox runat="server" id="txtUser" placeholder="username" CssClass="form-control" OnTextChanged="txtUser_TextChanged"/>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" placeholder="********" id="txtPassword" CssClass="form-control" TextMode="Password" OnTextChanged="txtPassword_TextChanged"/>
        </div>
        <div class="row"><asp:Label ID="lblError" runat="server" CssClass="h5 text-danger"></asp:Label> </div>
        <div class="row"><asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" cssclass="btn btn-primary"/></div>
        
    </div>
</asp:Content>

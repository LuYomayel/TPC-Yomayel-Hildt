﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCompra.aspx.cs" Inherits="TPC_Comercio.AgregarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            




            <div class="container">
                <div class="row">
                    <div class="col">
                            <asp:DropDownList ID="ddProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                </div>
                
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblCantProd" runat="server" Text="Cantidad de Productos a agregar:"></asp:Label>
                        <asp:TextBox ID="txtCantProd" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCantProd_TextChanged"></asp:TextBox>
                    </div>
                    
                </div>
            </div>
                <div class="container">
                    <%foreach (Dominio.Producto item in cantProductos)
                        { %>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
                            <asp:DropDownList ID="ddProductos" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddProductos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col">
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true" Text="0" ClientIDMode="Inherit"></asp:TextBox>
                        </div>
                        <div class="col">
                            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal:"></asp:Label>
                            <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control" ReadOnly="true" Text="0"></asp:TextBox>
                        </div>
                    </div>
                
            <%} %>
                    </div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
    
    
</asp:Content>
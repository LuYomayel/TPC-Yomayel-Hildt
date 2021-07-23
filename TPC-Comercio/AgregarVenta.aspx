﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarVenta.aspx.cs" Inherits="TPC_Comercio.AgregarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class=" container">
            
                <div class="row">
                    <div class="col form-group">
                            <asp:Label ID="lblProveedor" runat="server" Text="Cliente:"></asp:Label>
                            <asp:DropDownList ID="ddClientes" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                    <div class="row">
                        <div class="col form-group">
                            <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
                            <asp:DropDownList ID="ddProductos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddProductos_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col form-group">
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div class="col form-group">
                            <asp:Label ID="lblPrecioUnitario" runat="server" Text="Precio Unitario:"></asp:Label>
                            <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col form-group">
                            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal:"></asp:Label>
                            <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    
                    
                        <div class="col form-group mt-4">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" OnClick="btnAgregar_Click" CssClass="btn btn-primary form-control"/>
                        </div>
                    </div>
                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDeleting="gvDetalle_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Subtotal" DataField="PrecioParcial" />
                        <asp:ButtonField CommandName="Delete" HeaderText="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-primary" />
                    </Columns>
                </asp:GridView>
                </div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:Button ID="btnAgregarTransaccion" runat="server" Text="Agregar Venta" OnClick="btnAgregarTransaccion_Click" CssClass="btn btn-primary "/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
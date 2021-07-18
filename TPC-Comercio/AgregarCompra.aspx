<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCompra.aspx.cs" Inherits="TPC_Comercio.AgregarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class=" container">
            
                <div class="row">
                    <div class="col form-group">
                            <asp:DropDownList ID="ddProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                    <div class="row">
                        <div class="col form-group">
                            <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
                            <asp:DropDownList ID="ddProductos" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddProductos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col form-group">
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div class="col form-group">
                            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal:"></asp:Label>
                            <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    
                    
                        <div class="col form-group">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" OnClick="btnAgregar_Click" CssClass="btn btn-primary form-control"/>
                        </div>
                    </div>
                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Subtotal" DataField="PrecioParcial" />
                    </Columns>
                </asp:GridView>
                </div>
            <asp:Button ID="btnAgregarTransaccion" runat="server" Text="Agregar Compra" OnClick="btnAgregarTransaccion_Click" CssClass="btn btn-primary "/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

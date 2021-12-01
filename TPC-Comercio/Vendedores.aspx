<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendedores.aspx.cs" Inherits="TPC_Comercio.Vendedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lblVendedor" runat="server" Text="Vendedor:" ></asp:Label>
                    <asp:DropDownList ID="ddlVendedores" runat="server" class="form-control" OnSelectedIndexChanged="ddlVendedores_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                
            </div>
            
            
            <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="Vendedor.User" HeaderText="Vendedor" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                    <asp:BoundField DataField="Cliente.NombreCompleto" HeaderText="Cliente"/>
                   
                    <asp:BoundField DataField="Comision" HeaderText="Comision"/>
                    <%--<asp:ButtonField CommandName="Detalle" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Detalle" HeaderText="Detalle"/>
                    <asp:ButtonField CommandName="Delete" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Eliminar" HeaderText="Eliminar" />--%>
                </Columns>
            </asp:GridView>
            
            <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
            <asp:Label ID="lblTotal" runat="server" ></asp:Label>
            

        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

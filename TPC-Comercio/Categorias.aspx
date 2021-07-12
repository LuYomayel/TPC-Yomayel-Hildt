<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_Comercio.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvCategorias" runat="server" OnRowDeleting="gvCategorias_RowDeleting" OnRowEditing="gvCategorias_RowEditing" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Categoria" DataField="Nombre" />
                    <asp:ButtonField CommandName="Delete" ButtonType="Button"  Text="Eliminar" ControlStyle-CssClass="btn btn-primary" HeaderText="Eliminar"/>
                    <asp:ButtonField CommandName="Edit" ButtonType="Button" Text="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar"/>
            
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Categoria" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_Comercio.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowEditing="gvMarcas_RowEditing" OnRowDeleting="gvMarcas_RowDeleting">
                <Columns>
            
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Marca" />
                    <asp:ButtonField CommandName="Delete" ButtonType="Button"  Text="Eliminar" ControlStyle-CssClass="btn btn-primary" HeaderText="Eliminar"/>
                    <asp:ButtonField CommandName="Edit" ButtonType="Button" Text="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar"/>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Categoria" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
</asp:Content>

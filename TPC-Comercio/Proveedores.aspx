<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Comercio.Proveedores" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvProveedores" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowDeleting="gvProveedores_RowDeleting" OnRowEditing="gvProveedores_RowEditing">
                <Columns>
                    <asp:BoundField HeaderText="Cuit" DataField="Cuit"/>
                    <asp:BoundField HeaderText="Razon Social" DataField="razonSocial"/>
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-primary" HeaderText="Eliminar">
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar"/>
                    
                </Columns>
        
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>


    
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Proveedor" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>

</asp:Content>

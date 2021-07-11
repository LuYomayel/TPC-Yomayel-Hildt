<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Comercio.Proveedores" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvProveedores" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowDeleting="gvProveedores_RowDeleting" OnRowEditing="gvProveedores_RowEditing">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id"/>
                    <asp:BoundField HeaderText="Razon Social" DataField="razonSocial"/>
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-primary">
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Botón" />
                    
                </Columns>
        
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>


    

    <a class="btn btn-primary left" href="AgregarProveedor.aspx" role="button" >Agregar Proveedor</a>

</asp:Content>

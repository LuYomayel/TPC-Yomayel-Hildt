<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Comercio.Clientes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvClientes" runat="server" OnRowDeleting="gvClientes_RowDeleting" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowEditing="gvClientes_RowEditing">
                <Columns>
                    <asp:BoundField HeaderText="Cuit" DataField="Cuit" />
                    <asp:BoundField HeaderText="Nombre Completo" DataField="NombreCompleto" ControlStyle-CssClass="text-capitalize"/>
                    <asp:BoundField HeaderText="Direccion" DataField="Direccion"/>
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                    <asp:BoundField HeaderText="Email" DataField="Email" ControlStyle-CssClass="text-lowercase"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-primary" HeaderText="Eliminar">
                    
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar"/>
                </Columns>
        
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="Message" ForeColor="Red" runat="server" />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/>
</asp:Content>

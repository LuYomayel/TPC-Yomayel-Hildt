<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Comercio.Clientes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvClientes" runat="server" OnRowDeleting="gvClientes_RowDeleting" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowEditing="gvClientes_RowEditing">
                <Columns>
                    <asp:BoundField HeaderText="Cuit" DataField="Cuit" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                    <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNac"/>
                    <asp:BoundField HeaderText="Direccion" DataField="Direccion"/>
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-primary">
                    
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-primary" />
                </Columns>
        
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="Message" ForeColor="Red" runat="server" />
    
    

    <a href="AgregarCliente.aspx" class="btn btn-primary">Agregar Cliente</a>
</asp:Content>

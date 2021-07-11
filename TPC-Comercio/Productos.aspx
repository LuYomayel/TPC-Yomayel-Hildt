<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Comercio.Productos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowDeleting="gvProductos_RowDeleting" OnRowEditing="gvProductos_RowEditing">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="% de ganancia" DataField="porcGanancia" />
                    <asp:BoundField HeaderText="Stock Minimo" DataField="stockMinimo"/>
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre"/>
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" ControlStyle-CssClass="btn btn-primary"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Editar" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <a class="btn btn-primary" href="AgregarProducto.aspx" role="button" >Agregar Producto</a>
    




</asp:Content>

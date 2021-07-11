<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Comercio.Clientes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvClientes" runat="server" OnRowDeleting="gvClientes_RowDeleting" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowEditing="gvClientes_RowEditing">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-primary">
                    
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-primary" />
                </Columns>
        
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="Message" ForeColor="Red" runat="server" />
    <%--<table class="table ">
      <thead class="thead-dark">
          <tr>
          <th scope="col">#</th>
          <th scope="col">Nombre</th>
          <th scope="col">Apellido</th>
          <th scope="col">Telefono</th>
          <th scope="col">Eliminar</th>
        </tr>
      </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%#Eval("Id")%></th>
                        <td><%#Eval("Nombre")%></td>
                        <td><%#Eval("Apellido")%></td>
                        <td><%#Eval("Telefono")%></td>
                        <td><asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Id")%>' CssClass="btn btn-primary" AutoPostBack="true"/></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>--%>
    <%--
          <%foreach (Negocio.Cliente item in lista)
              { %>
        <tr>
          <th scope="row"><% = item.Id %></th>
          <td><% = item.Nombre %></td>
          <td><% = item.Apellido %></td>
          <td><% = item.Telefono %></td>
            
          <td></td>
        </tr>
      <%} %>
    </table>--%>
    

    <a href="AgregarCliente.aspx" class="btn btn-primary">Agregar Cliente</a>
</asp:Content>

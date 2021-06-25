<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Comercio.Clientes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table class="table ">
      <thead class="thead-dark">
          <tr>
          <th scope="col">#</th>
          <th scope="col">Nombre</th>
          <th scope="col">Apellido</th>
          <th scope="col">Telefono</th>
        </tr>
      </thead>
        <tbody>
          <%foreach (Negocio.Cliente item in lista)
              { %>
        <tr>
          <th scope="row"><% = item.Id %></th>
          <td><% = item.Nombre %></td>
          <td><% = item.Apellido %></td>
          <td><% = item.Telefono %></td>
        </tr>
      <%} %>
    </table>


    <asp:GridView ID="gvClientes" runat="server"></asp:GridView>
</asp:Content>

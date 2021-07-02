<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Comercio.Proveedores" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Razon Social</th>
      <th scope="col">Descripcion</th>
    </tr>
  </thead>
  <tbody>
      <%foreach (Dominio.Proveedor proveedor in listaProveedores)
          {
              %>
    <tr>
      <th scope="row"><% = proveedor.Id %></th>
      <td><% = proveedor.RazonSocial %></td>
      <td><% = proveedor.Descripcion %></td>
      
    </tr>
      <% }%>
    
  </tbody>
</table>

    <a class="btn btn-primary left" href="AgregarProveedor.aspx" role="button" >Agregar Proveedor</a>

</asp:Content>

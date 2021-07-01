<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Comercio.AgregarProducto" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
        <div class="form-group">
            <label >Nombre del producto</label>
            <asp:TextBox class="form-control" id="txtNombre" runat="server"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <asp:TextBox class="form-control" id="txtDescripcion" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Url Imagen</label>
            <asp:TextBox class="form-control" id="txtUrlImagen" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Porcentaje de ganancia</label>
            <asp:TextBox TextMode="Number" class="form-control" id="txtPorcGanancia" runat="server"></asp:TextBox>
        </div>
        <div class="form-group" runat="server">
            <label >Marca</label>
            
            <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>
            
            
            <select class="form-control" name="marcaSeleccionada">
                <% 
                    foreach (Dominio.Marca item in listaMarcas)
                    {
                        %>
                <option  value="<% =item.Nombre %>">   <% = item.Nombre %></option>
                
            
            <% } %>
            </select>


        </div>
        
        <div class="form-group">
            <label >Categoria</label>
            
            
                <select class="form-control" name="categoriaSeleccionada">
                    <% 
                        foreach (Dominio.Categoria item in listaCategorias)
                        {
                            %>
                <option value="<% =item.Nombre %>"> <% = item.Nombre %> </option>
                
            
            <% } %>
                    </select>
        </div>
        
        <asp:button  runat="server" Text="Agregar Producto" ID="btnAgregar" OnClick="btnAgregar_Click"/> 
    </form>

</asp:Content>

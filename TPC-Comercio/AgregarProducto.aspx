<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Comercio.AgregarProducto" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form method="post">
        <div class="form-group">
            <label >Nombre del producto</label>
            <input type="text" name="nombre" class="form-control">
            <%--<asp:TextBox class="form-control" id="txtNombre" runat="server"></asp:TextBox>--%>
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            <input type="text" name="descripcion" class="form-control">
            
        </div>
        <div class="form-group">
            <label >Url Imagen</label>
            <input type="text" name="urlImagen" class="form-control">
            
        </div>
        <div class="form-group">
            <label >Porcentaje de ganancia</label>
            <input type="number" name="porcGanancia" class="form-control">
        </div>
        <div class="form-group">
            <label >Stock Minimo</label>
            <input type="number" name="stock" class="form-control">
        </div>
        <div class="form-group" runat="server">
            <label >Marca</label>
            
            <select class="form-control" name="marcaSeleccionada" >
                
                <% 
                    foreach (Dominio.Marca item in listaMarcas)
                    {
                        %>
                <option value="<% =item.Id %>">   <% = item.Nombre %></option>
                
            
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
                <option value="<% =item.Id %>"> <% = item.Nombre %> </option>
                
            
            <% } %>
                    </select>
        </div>
        
        <div>
            <label>&nbsp;</label>
            <input type="submit" value="Agregar Producto" class="btn btn-primary" />
            
        </div> 


        </form>

        

</asp:Content>

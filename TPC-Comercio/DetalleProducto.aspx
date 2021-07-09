<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPC_Comercio.DetalleProducto" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post">
        <img src="srcImg" class="card-img-top" ID="imgseleccionado" runat="server" />

        <p>Nombre: </p><asp:Label ID="lblNombre" runat="server"> </asp:Label>
        <p>Marca: </p><asp:Label ID="lblMarca" runat="server"></asp:Label>
        <p>Categoria: </p><asp:Label ID="lblCategoria" runat="server"> </asp:Label>
        <p>Stock Minimo: </p><asp:Label ID="lblStockMinimo" runat="server"> </asp:Label>
        <p>Stock Actual: </p><asp:Label ID="lblPorcGanancia" runat="server"></asp:Label>
        <input type="submit" value="Eliminar" class="btn btn-primary" name="eliminar"/>
        <input type="submit" value="Editar" class="btn btn-primary" name="editar"/>
    </form>


    <%--<form method="post">
        <div class="form-group">
            <label >Nombre del producto</label>
            <input type="text" name="nombre" class="form-control">
            
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
            
            <asp:DropDownList ID="Marcas" runat="server"></asp:DropDownList>


        </div>
        
        <div class="form-group">
            <label >Categoria</label>
            <asp:DropDownList ID="Categorias" runat="server"></asp:DropDownList>
        </div>
        
        <div>
            <label>&nbsp;</label>
            <input type="submit" value="Agregar Producto" class="btn btn-primary" />
            
        </div> 


        </form>--%>


</asp:Content>

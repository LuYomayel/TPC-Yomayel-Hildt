<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Comercio.AgregarProducto" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
        <div class="form-group">
            <label >Nombre del producto</label>
            
            <asp:TextBox class="form-control" id="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Descripcion</label>
            
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Url Imagen</label>
            
            <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Precio   <span class="font-italic text-muted">Separe los decimales con ,</span></label>
            
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <label >Porcentaje de ganancia</label>
            
            <asp:TextBox ID="txtPorc" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Stock Minimo</label>
            
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label >Stock Actual</label>
            
            <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group" runat="server">
            <label >Marca</label>
            <asp:DropDownList ID="ddMarcas" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label >Categoria</label>
            <asp:DropDownList ID="ddCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div>
            
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
        </div> 

        <div>
            <asp:Label ID="lblError" runat="server" ></asp:Label>

        </div>
        

        

</asp:Content>

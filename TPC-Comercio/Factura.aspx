<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="TPC_Comercio.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="container">
    <div id="app" class="col-11">

    <h2>Factura</h2>

    <div class="row my-3">
      <div class="col-10">
        <h1>MiComercio</h1>
        <p>Direccion:           Av. San Martin 123, San Miguel</p>
        <p>Cuit:                27-4610605-65</p>
        <p>Inicio de actividad: 7/12/2020</p>
      </div>
      <div class="col-2">
        
      </div>
    </div>
  
    <hr />
  
    <div class="row fact-info mt-3">
      <div class="col-3">
        <h5>Facturar a</h5>
        <p>
          <asp:Label ID="lblCuit" runat="server" ></asp:Label>
        </p>
      </div>
      <div class="col-3">
        <h5>Enviar a</h5>
        <p>
          <asp:Label ID="lblDireccion" runat="server" ></asp:Label>
        </p>
      </div>
      <div class="col-3">
        <h5>N° de factura</h5>
        <h5>Fecha</h5>
        <h5>Fecha de vencimiento</h5>
      </div>
      <div class="col-3">
        <h5><asp:Label ID="lblNroFactura" runat="server" ></asp:Label></h5>
        <p><asp:Label ID="lblFechaVenta" runat="server" ></asp:Label></p>
        <p><asp:Label ID="lblFechaVencimiento" runat="server" ></asp:Label></p>
      </div>
    </div>
    <div class="row my-5">
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" CssClass="table table-borderless factura">
            <Columns>
                
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto"/>
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario"/>
                <asp:BoundField DataField="PrecioParcial" HeaderText="Precio Parcial"/>
            </Columns>
        </asp:GridView>
    </div>
    <div class="text-right row">
        <div class="col-3">
            
        </div>
        <div class="col-3">

        </div>
        <div class="col-3">
            <h1>Total Factura</h1>
        </div>
        <div class="col-3">
            <h1>$<asp:Label ID="lblTotal" runat="server" CssClass="h1"></asp:Label></h1>
        </div>
        
        
    </div>
           
    <div class="cond row">
      <div class="col-3 ">
        <h4>Condiciones y formas de pago</h4>
        <p>El pago se debe realizar en un plazo de 15 dias.</p>
        <p>
          Banco Banreserva
          <br />
          IBAN: DO XX 0075 XXXX XX XX XXXX XXXX
          <br />
          Código SWIFT: BPDODOSXXXX
        </p>
      </div>
        <div class="col-8 mt-2">
            <p class="text-right">Vendedor: </p>
            
        </div>
        <div class="col-1  mt-2">
            <asp:Label ID="lblVendedor" runat="server"  ></asp:Label>
        </div>
    </div>
</div>
        </div>
</asp:Content>

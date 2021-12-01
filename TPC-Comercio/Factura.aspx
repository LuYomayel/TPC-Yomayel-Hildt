<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="TPC_Comercio.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
      
        <hr>
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">
                    Nro. Factura:
                </div>
            </div>
            <div class="col-xs-2">
                <div id="numerofactura"><asp:Label ID="lblNroFactura" runat="server" ></asp:Label></div>
            </div>
            
        </div>   
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">Fecha Emision: </div>
            </div>
            <div class="col-xs-2">
                <div id="fechaemision"><asp:Label ID="lblFechaHoy" runat="server" ></asp:Label></div>
            </div>
            <div class="col-xs-2">
                <div class="titulo">Cuit Cliente:   </div>
            </div>
            <div class="col-xs-5">
                <div id="rucCliente"> <asp:Label ID="lblCuit" runat="server" ></asp:Label></div>
            </div>
        </div>  
       
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">Telefono:      </div>
            </div>
            <div class="col-xs-2">
                <div id="telefono"><asp:Label ID="lblTelefono" runat="server" ></asp:Label></div>
            </div>            
            <div class="col-xs-2">
                <div class="titulo">Direccion:     </div>
            </div>
            <div class="col-xs-5">
                <div id="direccion"><asp:Label ID="lblDireccion" runat="server" ></asp:Label></div>
            </div>
        </div>          
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">Vendedor:      </div>
            </div>
            <div class="col-xs-2">
                <div id="vendedor"><asp:Label ID="lblVendedor" runat="server" ></asp:Label></div>
            </div>   
        </div>
        <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mt-5">
            <Columns>
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto"/>
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario"/>
                <asp:BoundField DataField="PrecioParcial" HeaderText="Precio Parcial"/>
            </Columns>
        </asp:GridView>
        
        
           
     
        
        <div class="row sinespacio">
             <div class="col-xs-3">
                <div><img src="img/blanco.png"></div>
            </div>
            <div class="col-xs-3">
                <div id="blanco4"></div>
            </div>
            <div class="col-xs-3">
                <div>Valor a Pagar:      </div>
            </div>
            <div class="col-xs-3">
                <div class="izq borde" id="apagar"><asp:Label ID="lblTotal" runat="server" ></asp:Label></div>
            </div>          
        </div>
        <div class="row limpiar"></div>
        
        
    </div>
</asp:Content>

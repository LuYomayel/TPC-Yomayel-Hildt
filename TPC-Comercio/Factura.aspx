<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="TPC_Comercio.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
      <div class="row">
          <div class="col-xs-4"><img src="images/logo.png"></div>
          <div class="col-xs-4"><img src="images/direccion.png"></div>
          <div class="col-xs-4"><img src="images/factura.png"></div>
      </div>
        <hr>
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">
                    Nro. Factura: <asp:Label ID="lblNroFactura" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="col-xs-2">
                <div id="numerofactura"></div>
            </div>
            <div class="col-xs-2">
                <div class="titulo">Autorizacion:       </div>
            </div>
            <div class="col-xs-5">
                <div id="numeroauto"></div>
            </div>
        </div>   
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">Fecha Emision: </div>
            </div>
            <div class="col-xs-2">
                <div id="fechaemision"></div>
            </div>
            <div class="col-xs-2">
                <div class="titulo">RUC Cliente:   </div>
            </div>
            <div class="col-xs-5">
                <div id="rucCliente"></div>
            </div>
        </div>  
       
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">Telefono:      </div>
            </div>
            <div class="col-xs-2">
                <div id="telefono"></div>
            </div>            
            <div class="col-xs-2">
                <div class="titulo">Direccion:     </div>
            </div>
            <div class="col-xs-5">
                <div id="direccion"></div>
            </div>
        </div>          
        <div class="row">
            <div class="col-xs-2">
                <div class="titulo">Nombres/Razon: </div>
            </div>
            <div class="col-xs-6">
                <div id="razon"></div>
            </div>
        </div>    
        
        <table class="table table-bordered">
        <thead>
          <tr>
              <th><h4 class="titulo">&nbsp;&nbsp;&nbsp;Codigo&nbsp;&nbsp;&nbsp;</h4></th>
        <th><h4 class="titulo">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Descripcion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4></th>
        <th><h4 class="titulo">&nbsp;&nbsp;&nbsp;Cant.&nbsp;&nbsp;&nbsp;</h4></th>
        <th><h4 class="titulo">&nbsp;&nbsp;&nbsp;&nbsp;P.Unit.&nbsp;&nbsp;&nbsp;&nbsp;</h4></th>
        <th><h4 class="titulo">&nbsp;&nbsp;&nbsp;&nbsp;Dscto.&nbsp;&nbsp;&nbsp;&nbsp;</h4></th>
        <th><h4 class="titulo">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subtotal&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4></th>
          </tr>
        </thead>
        <tbody>
          <tr>
              <td class="codigo"></td>
              <td class="descripcion"></td>
              <td class="cantidad izq"></td>
              <td class="precio izq"></td>
              <td class="descuento izq"></td>
              <td class="subtotal izq"></td>
          </tr>
        </tbody>
      </table>
        <div class="row sinespacio">
             <div class="col-xs-3">
                <div><img src="img/blanco.png"></div>
            </div>
            <div class="col-xs-3">
                <div id="blanco1"></div>
            </div>
            <div class="col-xs-3">
                <div>Total Sin Impto.:   </div>
            </div>
            <div class="col-xs-3">
                <div class="izq borde" id="totalSinImpto"></div>
            </div>          
        </div>
        <div class="row sinespacio">
             <div class="col-xs-3">
                <div><img src="img/blanco.png"></div>
            </div>
            <div class="col-xs-3">
                <div id="blanco2"></div>
            </div>
            <div class="col-xs-3">
                <div>Impuesto 12%:       </div>
            </div>
            <div class="col-xs-3">
                <div class="izq borde" id="valorImpto12"></div>
            </div>          
        </div>    
<!--        <div class="row sinespacio">
             <div class="col-xs-3">
                <div><img src="images/blanco.png"></div>
            </div>
            <div class="col-xs-3">
                <div id="blanco3"></div>
            </div>
            <div class="col-xs-3">
                <div>Impuesto 0%:        </div>
            </div>
            <div class="col-xs-3">
                <div class="izq borde" id="valorImpto0"></div>
            </div>          
        </div>  -->
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
                <div class="izq borde" id="apagar"></div>
            </div>          
        </div>
        <div class="row limpiar"></div>
        
        <div class="row">
            <div class="col-xs-8 titulopie">
                Debo y pagare incondicionalmente a la orden de _____ la cantidad de _________ en esra ciudad de Quito
                En  caso de  mora me  comprometo a  pagar el interes del _____ anual  desde su  vencimiento  hasta la 
                cancelacion  de  la  deuda. En  el evento de juicio me someto a los jueces de la ciudad de Quito y al 
                procedimiento  ejecutivo  o  verbal  sumario a eleccion de _____ sin protesto eximese de presentacion 
                para el pago y de aviso por falta del mismo. 
            </div>
        </div>
        <div class="row">
            <div class="col-xs-5 titulopie">
                QUITO, ______ DE ____________ DEL ______</div>
            <div class="col-xs-1"><img src="img/blanco.png"></div>
            <div class="col-xs-2">
                <img src="img/cliente.png">
            </div>
        </div>
    </div>
</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class DetalleNegocio
    {
        public List<Detalle> listarComprasID( int id)
        {
            List<Detalle> lista = new List<Detalle>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select D.Id Id, d.IdProducto IdProducto, p.Nombre NombreP, d.Cantidad Cantidad, d.IdTransaccion IdTransaccion, d.PrecioUnitario PrecioUnitario, " +
                                     "(d.Cantidad * d.PrecioUnitario) PrecioParcial from Detalle D " +
                                     "join Productos p on p.Id = d.IdProducto " +
                                     "where IdTransaccion =" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Detalle aux = new Detalle();

                    aux.Id = (int)datos.Lector["IdTransaccion"];

                    aux.Producto = new Producto();
                    aux.Producto.Id = (int)datos.Lector["IdProducto"];
                    aux.Producto.Nombre = (string)datos.Lector["NombreP"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Transaccion = new Transaccion();
                    aux.Transaccion.Id = (int)datos.Lector["IdTransaccion"];
                    aux.PrecioParcial = (decimal)datos.Lector["PrecioParcial"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class TransaccionNegocio
    {
        public List<Transaccion> listarCompras()
        {
            List<Transaccion> lista = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("select t.id IdTransaccion, coalesce(t.monto,0) Monto, t.IdProveedor IdProveedor, p.RazonSocial RazonSocial from Transacciones t " +
                                    "join Proveedores p on p.Cuit = t.idProveedor " +
                                    "where t.Tipo = 'C' ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transaccion aux = new Transaccion();

                    aux.Id = (int)datos.Lector["IdTransaccion"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    aux.Proveedor = new Proveedor();
                    aux.Proveedor.Cuit = (string)datos.Lector["IdProveedor"];
                    aux.Proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
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

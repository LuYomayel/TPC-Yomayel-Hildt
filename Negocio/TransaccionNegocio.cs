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
                                    "where t.Tipo = 'C' and t.Estado = 1");
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
        public List<Transaccion> listarTransacciones()
        {
            List<Transaccion> lista = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, coalesce(cast(monto as money),0) Monto from Transacciones where Estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transaccion aux = new Transaccion();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Transaccion> listarTodasT()
        {
            List<Transaccion> lista = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, coalesce(cast(monto as money),0) Monto from Transacciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transaccion aux = new Transaccion();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Transaccion> listarVentas(Usuario usuario)
        {
            List<Transaccion> lista = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select t.id IdTransaccion, coalesce(t.monto,0) Monto, t.IdCliente IdCliente, c.Nombre Nombre, c.Apellido Apellido, u.Usuario Vendedor from Transacciones t " +
                                    "join Clientes c on c.Cuit=t.IdCliente join Usuarios u on u.Id = t.IdUsuario " +
                                    "where t.Tipo = 'V' and t.Estado = 1 and t.idUsuario=" + usuario.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transaccion aux = new Transaccion();

                    aux.Id = (int)datos.Lector["IdTransaccion"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Cuit = (string)datos.Lector["IdCliente"];
                    aux.Cliente.NombreCompleto = (string)datos.Lector["Apellido"] + ", " + (string)datos.Lector["Nombre"];
                    aux.Vendedor = new Usuario();
                    aux.Vendedor.User = (string)datos.Lector["Vendedor"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Transaccion> listarTodasV()
        {
            List<Transaccion> lista = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select t.id IdTransaccion, coalesce(t.monto,0) Monto, t.IdCliente IdCliente, c.Nombre Nombre, c.Apellido Apellido, u.Usuario Vendedor from Transacciones t join Clientes c on c.Cuit= t.IdCliente join Usuarios u on u.Id = t.IdUsuario where t.Tipo = 'V' and t.Estado = 1 ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transaccion aux = new Transaccion();

                    aux.Id = (int)datos.Lector["IdTransaccion"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Cuit = (string)datos.Lector["IdCliente"];
                    aux.Cliente.NombreCompleto = (string)datos.Lector["Apellido"] + ", " + (string)datos.Lector["Nombre"];
                    aux.Vendedor = new Usuario();
                    aux.Vendedor.User = (string)datos.Lector["Vendedor"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregarCompra(Transaccion transaccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                string valores = "values(" + transaccion.Id + ",'" + transaccion.Tipo + "', '" + transaccion.Proveedor.Cuit +"' )";
                datos.setearConsulta("SET IDENTITY_INSERT [Transacciones] ON Insert into Transacciones (Id, Tipo, IdProveedor) " + valores);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarVenta(Transaccion transaccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                string valores = "values(" + transaccion.Id + ",'" + transaccion.Tipo + "', CAST('" + transaccion.Fecha + "' AS DATE), '" + transaccion.Cliente.Cuit + "', " + transaccion.Vendedor.Id + " )";
                datos.setearConsulta("set dateformat dmy SET IDENTITY_INSERT [Transacciones] ON Insert into Transacciones (Id, Tipo, Fecha, IdCliente, IdUsuario) " + valores);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void update(Transaccion transaccion, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                
                datos.setearConsulta("update Transacciones set Monto = replace('"+ transaccion.Monto +"', ',', '.') where id =" + id);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Transaccion GetCompra(int id)
        {
            Transaccion transaccion = new Transaccion();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(" select * from Transacciones where id= " + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    transaccion.Id = (int)datos.Lector["IdTransaccion"];
                    transaccion.Monto = (decimal)datos.Lector["Monto"];
                    transaccion.Proveedor = new Proveedor();
                    transaccion.Proveedor.Cuit = (string)datos.Lector["IdProveedor"];
                    transaccion.Proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
                }

                return transaccion;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public Transaccion GetVenta(int id)
        {
            Transaccion transaccion = new Transaccion();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("set dateformat dmy select t.Id Id,t.IdCliente IdCliente, t.Monto Monto, u.Usuario Vendedor, coalesce(t.Fecha,'15/12/2021') Fecha  from Transacciones t " +

                                    "join Usuarios u on u.Id = t.idUsuario where t.Id =" + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    transaccion.Id = (int)datos.Lector["Id"];
                    transaccion.Monto = (decimal)datos.Lector["Monto"];
                    transaccion.Fecha = (DateTime)datos.Lector["Fecha"];
                    transaccion.Cliente = new Cliente();
                    transaccion.Cliente.Cuit = (string)datos.Lector["IdCliente"];
                    transaccion.Vendedor = new Usuario();
                    transaccion.Vendedor.User = (string)datos.Lector["Vendedor"];
                }
                


                return transaccion;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void eliminar(int  id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Transacciones set estado = 0 where id=" + id );

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

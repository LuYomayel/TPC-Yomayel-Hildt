using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select p.id, p.nombre, p.descripcion, p.urlimagen,p.PorcGanancia,p.StockMinimo, coalesce(p.StockActual, 0) StockActual, m.Nombre Marca,m.id idMarca, c.id idCategoria, c.Nombre Categoria, coalesce(p.UltPrecio,0) UltPrecio from Productos p join Categorias c on c.id = p.idCategoria join Marcas m on m.id = p.IdMarca where p.estado = 1 ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.StockMinimo = (int)datos.Lector["StockMinimo"];
                    aux.StockActual = (int)datos.Lector["StockActual"];
                    aux.UltPrecio = (decimal)datos.Lector["UltPrecio"];
                    aux.PorcGanancia = (double)datos.Lector["PorcGanancia"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["idMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["idCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.UrlImagen + "', " + nuevo.PorcGanancia + ", " + nuevo.Marca + ", " + nuevo.Categoria + ", "+ nuevo.StockMinimo +")";
                datos.setearConsulta("insert into Productos (Nombre, Descripcion, UrlImagen, PorcGanancia, IdMarca, IdCategoria, StockMinimo) " + valores);

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

        public void actualizar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Productos set nombre = '" + producto.Nombre + "', Descripcion = '" + producto.Descripcion + "', UrlImagen = '" + producto.UrlImagen + "', PorcGanancia = '" + producto.PorcGanancia + "', IdMarca = '" + producto.Marca.Id + "', IdCategoria = '" + producto.Categoria.Id + "', StockMinimo = '" + producto.StockMinimo + "' where id = " + producto.Id + ";";
                datos.setearConsulta(consulta);

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
        public void stock_precio(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Productos set StockActual = " + producto.StockActual + ", UltPrecio = replace('" + producto.UltPrecio + "', ',', '.') where id=" + producto.Id;
                datos.setearConsulta(consulta);

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
        public void stock(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Productos set StockActual = " + producto.StockActual + " where id=" + producto.Id;
                datos.setearConsulta(consulta);

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
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update productos set estado = 0 where id=" + id.ToString());

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

        public Producto GetProducto(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, nombre, descripcion, urlimagen, coalesce(ultprecio, 0) UltPrecio, coalesce(stockActual, 0) stockActual, porcGanancia from Productos where estado = 1 and id= " + id );
                datos.ejecutarLectura();

                Producto producto = new Producto();

                while (datos.Lector.Read())
                {
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.StockActual = (int)datos.Lector["stockActual"];
                    producto.PorcGanancia = (double)datos.Lector["porcGanancia"];
                    producto.UrlImagen = (string)datos.Lector["UrlImagen"];
                    producto.UltPrecio = (decimal)datos.Lector["UltPrecio"];
                }

                if(producto.Id != 0)
                {
                    return producto;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

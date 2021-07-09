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
                datos.setearConsulta("select id, nombre, descripcion, urlimagen from Productos where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];

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
                string consulta = "update clientes set nombre = '" + producto.Nombre + "', Descripcion = '" + producto.Descripcion + "', UrlImagen = '" + producto.UrlImagen + "', PorcGanancia = '" + producto.PorcGanancia + "', IdMarca = '" + producto.Marca + "', IdCategoria = '" + producto.Categoria + "', StockMinimo = '" + producto.StockMinimo + "' where id = " + producto.Id.ToString() + ";";
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
                datos.setearConsulta("select id, nombre, descripcion, urlimagen from Productos where estado = 1 and id= " + id );
                datos.ejecutarLectura();

                Producto producto = new Producto();

                while (datos.Lector.Read())
                {
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.UrlImagen = (string)datos.Lector["UrlImagen"];
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

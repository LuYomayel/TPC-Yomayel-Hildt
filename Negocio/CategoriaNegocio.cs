using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Dominio.Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, nombre from Categorias where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Dominio.Categoria((int)datos.Lector["Id"], (string)datos.Lector["Nombre"]));
                }

                return lista;
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

        public void agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( '" + categoria.Nombre + "')";
                datos.setearConsulta("insert into categorias(nombre) " + valores);

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

        public void actualizar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update categorias set nombre = '" + categoria.Nombre + "' where id = " + categoria.Id + ";";
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


                datos.setearConsulta("update categorias set estado = 0 where id=" + id);

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

        public Categoria GetCategoria(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, nombre from categorias where estado = 1 and id= " + id);
                datos.ejecutarLectura();

                Categoria categoria = new Categoria();

                while (datos.Lector.Read())
                {
                    categoria.Id = (int)datos.Lector["id"];
                    categoria.Nombre = (string)datos.Lector["nombre"];
                }

                if (categoria.Id != 0)
                {
                    return categoria;
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

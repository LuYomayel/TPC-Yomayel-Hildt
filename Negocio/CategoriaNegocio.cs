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
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, nombre from Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Categoria((int)datos.Lector["Id"], (string)datos.Lector["Nombre"]));
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
                string consulta = "update categorias set nombre = '" + categoria.Nombre + "' where id = " + categoria.Id.ToString() + ";";
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
    }
}

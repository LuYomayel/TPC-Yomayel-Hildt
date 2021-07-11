using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, nombre from Marcas where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Marca((int)datos.Lector["Id"], (string)datos.Lector["Nombre"]));
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

        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( '" + marca.Nombre + "')";
                datos.setearConsulta("insert into Marcas(Nombre) " + valores);

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

        public void actualizar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update marcas set nombre = '" + marca.Nombre + "' where id = " + marca.Id + ";";
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
                datos.setearConsulta("update marcas set estado = 0 where id=" + id);

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

        public Marca GetMarca(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, nombre from Marcas where estado = 1 and id= " + id);
                datos.ejecutarLectura();

                Marca marca = new Marca();

                while (datos.Lector.Read())
                {
                    marca.Id = (int)datos.Lector["id"];

                    marca.Nombre = (string)datos.Lector["nombre"];
                }

                if (marca.Id != 0)
                {
                    return marca;
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

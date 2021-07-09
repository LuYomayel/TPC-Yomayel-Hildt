using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, descripcion, razonsocial from Proveedores where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (int)datos.Lector["Id"];

                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.RazonSocial = (string)datos.Lector["RazonSocial"];
                    

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( '" + nuevo.Descripcion + "', '" + nuevo.RazonSocial + "')";
                datos.setearConsulta("insert into proveedores (Descripcion, RazonSocial) " + valores);

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

        public void actualizar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update proveedores set descripcion = '" + proveedor.Descripcion + "', razonsocial = '" + proveedor.RazonSocial + "' where id = " + proveedor.Id.ToString() + ";";
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
                datos.setearConsulta("update proveedores set estado = 0 where id=" + id.ToString() + ";");

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

        public Proveedor GetProveedor(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, descripcion, razonsocial from proveedores where estado = 1 and id= " + id);
                datos.ejecutarLectura();

                Proveedor proveedor = new Proveedor();

                while (datos.Lector.Read())
                {
                    proveedor.Id = (int)datos.Lector["Id"];

                    proveedor.Descripcion = (string)datos.Lector["Descripcion"];
                    proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
                }

                if (proveedor.Id != 0)
                {
                    return proveedor;
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

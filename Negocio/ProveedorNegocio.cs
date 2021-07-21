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
                datos.setearConsulta("select cuit, descripcion, razonsocial, email from Proveedores where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Cuit = (string)datos.Lector["Cuit"];
                    aux.Email = (string)datos.Lector["Email"];
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
                string valores = "values( '" + nuevo.Cuit + "' , '" + nuevo.Descripcion + "', '" + nuevo.RazonSocial + "', '"+ nuevo.Email+"')";
                datos.setearConsulta("insert into proveedores (Cuit,Descripcion, RazonSocial,Email) " + valores);

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
                string consulta = "update proveedores set descripcion = '" + proveedor.Descripcion + "', razonsocial = '" + proveedor.RazonSocial + "', email= '" + proveedor.Email + "' where cuit = '" + proveedor.Cuit + "';";
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

        public void eliminar(string cuit)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update proveedores set estado = 0 where cuit='" + cuit + "';");

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

        public Proveedor GetProveedor(string cuit)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select cuit, descripcion, razonsocial, email from proveedores where estado = 1 and cuit= '" + cuit +"'");
                datos.ejecutarLectura();

                Proveedor proveedor = new Proveedor();

                while (datos.Lector.Read())
                {
                    proveedor.Cuit = (string)datos.Lector["Cuit"];
                    proveedor.Email = (string)datos.Lector["Email"];
                    proveedor.Descripcion = (string)datos.Lector["Descripcion"];
                    proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
                }

                if (proveedor.Cuit != null || proveedor.Email != "")
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

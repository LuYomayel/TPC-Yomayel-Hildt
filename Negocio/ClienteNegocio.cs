using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, nombre, apellido, fechanac, direccion, telefono from Clientes where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNac = (DateTime)datos.Lector["FechaNac"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Telefono = (int)datos.Lector["Telefono"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                string valores = "values( '" + nuevo.Nombre + "', '" + nuevo.Apellido + "',CAST('" + nuevo.FechaNac + "' AS DATE), " + nuevo.Telefono + ", '" + nuevo.Direccion + "')";
                datos.setearConsulta("insert into Clientes (Nombre, Apellido, FechaNac, Telefono, Direccion) " + valores);

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

        public void actualizar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update clientes set nombre = '" + cliente.Nombre + "', apellido = '" + cliente.Apellido + "', FechaNac = CAST('" + cliente.FechaNac + "' AS DATE), Telefono = '" + cliente.Telefono + "', Direccion = '" + cliente.Direccion + "' where id = " + cliente.Id.ToString() + ";";
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
                datos.setearConsulta("update clientes set estado = 0 where id=" + id.ToString());

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

        public Cliente getCliente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = new Cliente();

            try
            {
                datos.setearConsulta("select id, nombre, apellido, fechanac, direccion, telefono from Clientes where estado = 1 and id= " + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.FechaNac = (DateTime)datos.Lector["FechaNac"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Telefono = (int)datos.Lector["Telefono"];
                }

                if(cliente.Id != 0)
                {
                    return cliente;
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

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
                datos.setearConsulta("select cuit, nombre, apellido, fechanac, direccion, telefono, email from Clientes where estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();

                    aux.Cuit = (string)datos.Lector["Cuit"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNac = (DateTime)datos.Lector["FechaNac"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Telefono = (int)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["email"];

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
                
                string valores = "values( '" + nuevo.Cuit + "', '" + nuevo.Nombre + "', '" + nuevo.Apellido + "',CAST('" + nuevo.FechaNac + "' AS DATE), " + nuevo.Telefono + ", '" + nuevo.Direccion + "', '" + nuevo.Email + " )";
                datos.setearConsulta("set dateformat dmy insert into Clientes (Cuit, Nombre, Apellido, FechaNac, Telefono, Direccion, Email) " + valores);

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
                string consulta = "set dateformat dmy update clientes set  nombre = '" + cliente.Nombre + "', apellido = '" + cliente.Apellido + "', FechaNac = CAST('" + cliente.FechaNac + "' AS DATE), Telefono = '" + cliente.Telefono + "', Direccion = '" + cliente.Direccion + "' where cuit = '" + cliente.Cuit + "';";
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
                datos.setearConsulta("update clientes set estado = 0 where cuit='" + cuit + "'");

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

        public Cliente getCliente(string cuit)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = new Cliente();

            try
            {
                datos.setearConsulta("select cuit, nombre, apellido, fechanac, direccion, telefono, email from Clientes where estado = 1 and cuit= '" + cuit +"'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cliente.Cuit = (string)datos.Lector["Cuit"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.FechaNac = (DateTime)datos.Lector["FechaNac"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Telefono = (int)datos.Lector["Telefono"];
                    cliente.Email = (string)datos.Lector["Email"];
                }

                if(cliente.Cuit != "" || cliente.Cuit != null)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    class CompraNegocio
    {
        public List<Compra> listarCompras()
        {
            List<Compra> listaCompras = new List<Compra>();
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

            return listaCompras;
        } 
    }
}

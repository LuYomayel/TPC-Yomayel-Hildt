using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Comision
    {
        public int CantVentas { get; set; }
        public double Porcentaje { get; set; }
    }
    public class ComisionNegocio
    {
        public void cargarComisiones(Comision comision)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Comisiones(CantVentas, Porcentaje) values(" +comision.CantVentas+","+comision.Porcentaje+")") ;

                datos.ejectutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public void eliminarComisiones()
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from Comisiones");

                datos.ejectutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Comision> listarComisiones()
        {
            List<Comision> listaComisiones = new List<Comision>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select * from Comisiones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comision aux = new Comision();
                    aux.CantVentas = (int)datos.Lector["CantVentas"];
                    aux.Porcentaje = (double)datos.Lector["Porcentaje"];

                    listaComisiones.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaComisiones;
        }
    }
}

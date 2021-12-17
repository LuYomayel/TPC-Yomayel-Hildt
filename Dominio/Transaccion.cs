using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Dominio
{
    public class Transaccion
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<Detalle> listaDetalles { get; set; }
        public Usuario Vendedor { get; set; }

        public double Comision { get; set; }
        public DateTime Fecha { get; set; }

        public Transaccion()
        {
            Cliente cliente = new Cliente();
            Proveedor proveedor = new Proveedor();
            Usuario usuario = new Usuario();
        }
    }
}

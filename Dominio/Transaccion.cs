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
        public char Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}

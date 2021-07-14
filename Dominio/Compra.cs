using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public Proveedor Proveedor { get; set; }
        public List<Producto> ListaProductos { get; set; }
    }
}

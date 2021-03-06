using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal UltPrecio { get; set; }
        public double PorcGanancia { get; set; }
        public string UrlImagen { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public int StockMinimo { get; set; }
        public int StockActual { get; set; }
    }
}

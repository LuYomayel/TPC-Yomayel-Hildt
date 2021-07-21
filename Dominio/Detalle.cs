﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Detalle
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public Transaccion Transaccion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioParcial { get; set; }
    }
}

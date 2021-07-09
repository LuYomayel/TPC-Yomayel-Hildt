using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Marca(string nombre)
        {
            Nombre = nombre;
        }

        public Marca(){}

        public Marca(int id)
        {
            Id = id;
        }
        public Marca(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Estatus
    {
        public Estatus()
        {
        }

        public Estatus(int id, string nombre)
        {
            this.id = id;
            Nombre = nombre;
        }

        public int id { get; set; }
        public string Nombre { get; set; }
    }
}

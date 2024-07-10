using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    public class EstatusAlumnos
    {
        public EstatusAlumnos()
        {
        }

        public EstatusAlumnos(int id, string clave, string nombre)
        {
            this.id = id;
            this.clave = clave;
            this.nombre = nombre;
        }

        public int id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Alumno
    {
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, decimal calificacion, int idEstado, int idEstatus)
        {
            this.id = id;
            Nombre = nombre;
            Calificacion = calificacion;
            this.idEstado = idEstado;
            this.idEstatus = idEstatus;
        }

        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Calificacion { get; set; }
        public int idEstado { get; set; }
        public int idEstatus { get; set; }
    }
}

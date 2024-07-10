using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Alumno
    {
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimeiento, string curp, string correo, string telefono, decimal sueldo, int estado, int estatus)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.fechaNacimiento = fechaNacimiento;
            this.curp = curp;
            this.correo = correo;
            this.telefono = telefono;
            this.sueldo = sueldo;
            this.estado = estado;
            this.estatus = estatus;
        }

        public int id { get; set; }
        public string nombre { get; set; }

        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string curp { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public decimal? sueldo { get; set; }
        public int estado { get; set; }
        public int estatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSS
{
    public struct ResultadoAportaciones
    {
        public ResultadoAportaciones(double enfermedadMaternidad, double invalidezVida, double retiro, double cesantia, double infonavit)
        {
            this.enfermedadMaternidad = enfermedadMaternidad;
            this.invalidezVida = invalidezVida;
            this.retiro = retiro;
            this.cesantia = cesantia;
            this.infonavit = infonavit;
        }

        public double enfermedadMaternidad { get; set; }
        public double invalidezVida { get; set; }
        public double retiro { get; set; }
        public double cesantia { get; set; }
        public double infonavit { get; set; }
    }
}

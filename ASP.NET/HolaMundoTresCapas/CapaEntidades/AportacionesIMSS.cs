using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class AportacionesIMSS
    {
        public AportacionesIMSS()
        {
        }

        public AportacionesIMSS(decimal enfermedadMaternidad, decimal invalidezVida, decimal retiro, decimal cesantía, decimal infonavit)
        {
            this.enfermedadMaternidad = enfermedadMaternidad;
            this.invalidezVida = invalidezVida;
            this.retiro = retiro;
            this.cesantía = cesantía;
            this.infonavit = infonavit;
        }

        public decimal enfermedadMaternidad { get; set; }
        public decimal invalidezVida { get; set; }
        public decimal retiro { get; set; }
        public decimal cesantía { get; set; }
        public decimal infonavit { get; set; }
    }
}

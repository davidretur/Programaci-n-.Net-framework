using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSS
{
    public struct OperacionImss
    {
        public OperacionImss(double operandoSBC, double operandoUMA, TipoImms tOperacion, TipoPersonaImms tPersona)
        {
            this.operandoSBC = operandoSBC;
            this.operandoUMA = operandoUMA;
            this.tOperacion = tOperacion;
            this.tPersona = tPersona;
        }

        public double operandoSBC { get; set; }
        public double operandoUMA { get; set; }

        public TipoImms tOperacion { get; set; }

        public TipoPersonaImms tPersona { get; set; }
    }
}

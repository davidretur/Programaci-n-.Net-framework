using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    public struct PolizaResultado
    {
        public PolizaResultado(DateTime fechaTerminotipo, decimal primatipodecimal)
        {
            this.fechaTerminotipo = fechaTerminotipo;
            this.primatipodecimal = primatipodecimal;
        }

        public DateTime fechaTerminotipo { get; set; }
        public decimal primatipodecimal { get; set; }
    }
}

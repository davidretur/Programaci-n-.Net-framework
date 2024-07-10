using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OperadoresAritmeticos
{
    public struct Resultado
    {
        public Resultado(decimal suma, decimal sesta, decimal multiplicacion, decimal division, decimal modulo)
        {
            this.suma = suma;
            this.resta = sesta;
            this.multiplicacion = multiplicacion;
            this.division = division;
            this.modulo = modulo;
        }

        public decimal suma { get; set; }
        public decimal resta { get; set; }
        public decimal multiplicacion { get; set; }
        public decimal division { get; set; }
        public decimal modulo { get; set; }
    }
}

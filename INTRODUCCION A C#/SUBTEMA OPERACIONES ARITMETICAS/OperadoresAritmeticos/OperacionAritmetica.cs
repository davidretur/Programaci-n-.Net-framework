using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperadoresAritmeticos
{
    //modificador de acceso publico
    public struct OperacionAritmetica
    {
// hacer referencia y asicnar valores
        public OperacionAritmetica(decimal operandoA, decimal operandoB, tipoOperacion tOperacion)
        {
            //asicnar parametros de entrada
            this.operandoA = operandoA;
            this.operandoB = operandoB;
            this.tOperacion = tOperacion;
        }

        public decimal operandoA { get; set; }
        public decimal operandoB { get; set; }
        public  tipoOperacion tOperacion { get; set; }
    }
}

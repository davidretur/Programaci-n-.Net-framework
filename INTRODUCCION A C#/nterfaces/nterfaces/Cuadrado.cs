using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nterfaces
{
    internal class Cuadrado : IFigura
    {
        private double lado;
        public Cuadrado(double lado)
        {
            this.lado = lado;
        }
        public double Area()
        {
            return lado * lado;
        }

        public double Perimetro()
        {
            return 4 * lado;
        }
    }
}

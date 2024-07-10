using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nterfaces
{
    internal class Triangulo : IFigura
    {
        private double bas;
        private double lado;
        private double altura;
        public Triangulo(double bas, double lado, double altura)
        {
            this.bas = bas;
            this.lado = lado;
            this.altura = altura;
        }

        public double Area()
        {
            return (bas * altura) / 2;
        }

        public double Perimetro()
        {
            return 2 * lado + bas;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFigura[] figura = new IFigura[2];
            figura[0] = new Cuadrado(6);
            figura[1] = new Triangulo(12, 6,4);

            foreach (IFigura item in figura)
            {
                Console.WriteLine("Area de la figura: " + item.Area());
                Console.WriteLine("Perimetros de la figura: " + item.Perimetro());
            }
            Console.ReadKey();
        }
    }
}

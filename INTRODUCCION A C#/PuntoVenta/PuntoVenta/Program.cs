using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //las Intefce siempre inician con I
            //igual que la erencia pero se llama implementacion 
            //class : implemntacion , implementacion2
            //debende cumplir con todas las intefzaces deben de ser concistente e iguales.
            Ventas.Vender();
            Console.ReadKey();
        }
    }
}

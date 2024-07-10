using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            string primerApellido;
            string segundoApellido;
            int edad;
            Console.WriteLine("Cual es nombre?");
            nombre = Console.ReadLine().Trim();
            Console.WriteLine("Cual es Primer Apellido?");
            primerApellido = Console.ReadLine().Trim();           
            Console.WriteLine("Cual es Segundo Apellido?");
            segundoApellido = Console.ReadLine().Trim();
            Console.WriteLine("Cual es Edad?");
            edad = int.Parse(Console.ReadLine());

            string retornoHolaMundoConcatenacion = Cadenas.HolaMundoConcatenacion(nombre,primerApellido ,segundoApellido, edad);
            //cw para + tab 
            Console.WriteLine(retornoHolaMundoConcatenacion);
            string retornoHolaMundoCompuesto = Cadenas.HolaMundoCompuesto(nombre, primerApellido, segundoApellido, edad);
            //cw para + tab 
            Console.WriteLine(retornoHolaMundoCompuesto);

            string retornoConcatenacionMayusculas = Cadenas.ConcatenacionMayusculas(nombre, primerApellido, segundoApellido, edad);
            //cw para + tab 
            Console.WriteLine(retornoConcatenacionMayusculas);
            string retornoAlmacenado = Cadenas.Almacenado();
            //cw para + tab 
            Console.WriteLine(retornoAlmacenado);



            // se va detener hasta que tipes un caracter o cierres la ventana
            Console.ReadKey();
        }
    }
}

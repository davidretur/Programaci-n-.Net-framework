using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    internal class Cadenas
    {
        public static string HolaMundoConcatenacion(string nombre, string primerApellido, 
            string segundoApellido,int edad)
        {
            return "Hola " + nombre + " "+ primerApellido + " "+ segundoApellido;
        }
        public static string HolaMundoCompuesto(string nombre, string primerApellido,
            string segundoApellido, int edad)
        {
            string cadenea = string.Format("{0} {1} {2} es el instructor y tiene {3} años de edad."
               , nombre, primerApellido, segundoApellido, edad);
            return cadenea;
        }
        public static string ConcatenacionMayusculas(string nombre, string primerApellido,
            string segundoApellido, int edad)
        {
            string cadena = string.Format($"Gusto en conocerte {nombre.ToUpper()} {primerApellido.ToUpper()} {segundoApellido.ToUpper()} !!!.");
            return cadena;
            
        }
        public static string Almacenado()
        {

            string ruta = @"C:\Documentos\Diplomado.Net\JorgeValdiviaRosas.docx";
            return ruta;
        }

    }
}

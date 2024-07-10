using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    public class Arreglos
    {
        public static string Cadenas(string nombreCompleto)
        {
            string resultado = "";
            string separator = " ";
            string apellido;
            string apeenvia = "";
            string[] separado = nombreCompleto.Split(new char[] { ' ' });
            apellido = String.Join(separator, separado[1]);
            foreach (string palabra in separado)
            {
                resultado += "\n" + palabra;
            }
            foreach (char palabra in apellido)
            {
                apeenvia += "\n" + palabra;
            }
            return "Hola " + resultado + apeenvia;
        }

        public static string Enteros(int num1, int num2, int num3, int num4, int num5)
        {
            int[] arregloNumeros = { num1, num2, num3, num4, num5 };

            string resultado = "El numero mayor es " + arregloNumeros.Max();

            return resultado;
        }
        public static string ConvierteATipoOracion(string oracion)
        {

            string[] arregloPalbras = oracion.Split(' ');
            string cadenaNueva = string.Empty;
                foreach (string palabraTemporal in arregloPalbras)
                {
                    cadenaNueva += palabraTemporal.Substring(0, 1).ToUpper() +
                    palabraTemporal.Substring(1).ToLower() + " ";
                }

            return cadenaNueva.Substring(0, cadenaNueva.Length - 1);
        }

    }
}










/*https://www.forosdelweb.com/f78/como-mayusculas-las-primeras-letras-cada-palabra-c-403861/*/
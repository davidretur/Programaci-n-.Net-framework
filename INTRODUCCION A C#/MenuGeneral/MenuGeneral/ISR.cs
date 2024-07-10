using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
     internal class ISR
    {
        public decimal sueldo = 0;
        public static string CargarTablaISR(string nombreArchivo, decimal sueldo)
        {
            decimal[,] tablaPlz = new decimal[21, 6];
            string linea = "";
            StreamReader archivo = new StreamReader(@"C:\Users\Tichs\Documents\Manejo de archivos\" +nombreArchivo);
            int i = 0;
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] taballeer = linea.Split(',');
                tablaPlz[i, 0] = Convert.ToDecimal(taballeer[1]);
                tablaPlz[i, 1] = Convert.ToDecimal(taballeer[2]);
                tablaPlz[i, 2] = Convert.ToDecimal(taballeer[3]);
                tablaPlz[i, 3] = Convert.ToDecimal(taballeer[4]);
                tablaPlz[i, 4] = Convert.ToDecimal(taballeer[5]);
                
                i++;
            }
            archivo.Close();

            CalcularISR(tablaPlz, sueldo);
            return $"";
        }
        internal static string CalcularISR(decimal[,] tablaPlz, decimal sueldo)
        {
            string res = "";
            decimal sueldoQuincenal = sueldo / 2;
            decimal liminferior = 0;
            decimal limsuperior = 0;
            decimal cuotaFija = 0;
            decimal excedenteLimInf = 0;
            for (int j = 0; j < tablaPlz.GetLength(0); j++)
            {
                // posicion cero es la edad minima
                // edad maxima 
                if (sueldoQuincenal >= tablaPlz[j, 0] && sueldoQuincenal <= tablaPlz[j, 1])
                {
                    liminferior = tablaPlz[j, 0];
                    limsuperior = tablaPlz[j, 1];
                    cuotaFija = tablaPlz[j, 2];
                    excedenteLimInf = tablaPlz[j, 3];
                }
            }

            decimal salQuinMLiminfer = sueldoQuincenal - liminferior;
            decimal porcentajeSalQuinMLiminfer = salQuinMLiminfer * excedenteLimInf / 100;
            decimal sumaCuotafijaMasporcentajeSalQuin = porcentajeSalQuinMLiminfer + cuotaFija;
            
            Console.WriteLine($"El Impuesto a pagar es {sumaCuotafijaMasporcentajeSalQuin.ToString("C2")}");

            return $"{liminferior} \n{limsuperior}\n{cuotaFija}";
        }

        public static void Presentación()
        {
            string res="";
            Console.WriteLine("Proporciona nombre de archivo que contiene los ISR");
            string nombreArchivo = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Proporciona tu sueldo mensual");
            decimal sueldo = Convert.ToDecimal(Console.ReadLine());
            CargarTablaISR(nombreArchivo,sueldo);
        }
    }
}


/*
 * manejo de arreglos
 * 
 * string [] palabra; este es un arreglo
 * string texto = "Hola como estas" ; esto es mi cadena
 * palabra = texto.split(""); llenamos el arreglo identicando por espacio con el split y 
 * en cada espacio almacena una posicion
 * array [pos1="hola",pos2="como",pos3="estas"] = split(" ") ;
 * recorerr el split 
 * foreach(string palabra in palabras){
 * cw("planbras")
 * }
 * 
 * este join hace la union del las plabars y el texto
 * string texto = join("", palabras);
 * char [] apellido;
 * 
 * acceder a datos del un char 
 * foreach(char letras in apellido){
 * cw('letra')
 * }
 * 
 * acceder con for
 * for(i = 0 i<apellido.leng i++){
 * sw()
 * }
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    public class Poliza
    {
        public static string Calcular(DateTime fechainicioVigencia, string tipodeperiodo, int duraciónPóliza,
           decimal sumaAsegurada, DateTime fechadeNacimiento, string géneroAsegurado)
        {

            decimal resultado = 0;
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year - fechadeNacimiento.Year;
            decimal genero;
            genero = géneroAsegurado.Equals("H") ? 1 : genero = 0;
            decimal factor = 0;
            int diasDuracion = 0;
            DateTime fechaDuracion = fechainicioVigencia;
            decimal prima = 0;
            // fecha inicio + mas los meses o años que se ingresan que va durar la poliza
            // sacar dias duarcion de la poliza apartir de fecha los meses o dias o años que se ingresan

            // calcular dias apartir de la fecha
            // efcha final y fecha final diferencia en dias y lo guardo en un toimespan

            if (tipodeperiodo == "años")
            {
                fechaDuracion = fechaDuracion.AddYears(duraciónPóliza);
                TimeSpan ts =  fechaDuracion - fechainicioVigencia;
                diasDuracion = ts.Days;
            }
            else if (tipodeperiodo.Equals("meses"))
            {
                fechaDuracion = fechaDuracion.AddMonths(duraciónPóliza);
                TimeSpan ts = fechaDuracion - fechainicioVigencia;
                diasDuracion = ts.Days;
            }
            else if (tipodeperiodo.Equals("dias"))
            {
                fechaDuracion = fechaDuracion.AddDays(duraciónPóliza);
                TimeSpan ts = fechaDuracion - fechainicioVigencia;
                diasDuracion = ts.Days;
            }

            //buscar edad y genero y se obtiene el factor
            // buscar como 
            decimal[,] tablaPlz = new decimal[,]
                {
                {0,20,0,0.5m},
                {21,31,0,0.1m},
                {31,40,0,0.4m},
                {41,50,0,0.5m},
                {51,60,0,0.65m},
                {61,70,0,0.85m},
                {0,20,1,0.05m},
                {21,31,1,0.1m},
                {31,40,1,0.4m},
                {41,50,1,0.55m},
                {51,60,1,0.5m},
                {61,70,1,0.9m}
                                };

            for (int i = 0; i < tablaPlz.GetLength(0); i++)
            {
                // posicion cero es la edad minima
                // edad maxima 
                if (edad >= tablaPlz[i,0] && edad <= tablaPlz[i,1] && genero == tablaPlz[i,2])
                {
                    factor = tablaPlz[i, 3];
                }
            }
            prima = sumaAsegurada * factor * diasDuracion / 360;


            return $"El fin de poliza es {fechaDuracion.ToString("dd MMMM , yyyy")}\nLa prima a pagar es {prima.ToString("N1")}";
        }

        public static void Presentacion()
        {
            OperacionPoliza operacionPoliza = new OperacionPoliza();
            Console.WriteLine("Proporciona la fecha de inicio de Vigencia:");
            operacionPoliza.fechainicioVigencia = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("El tipo de periodo por el que se desea la póliza (años, meses, días),");
            operacionPoliza.tipodeperiodo = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Proporciona para cuantos mes tiempo requieres la póliza (ejemplo 3 meses):");
            operacionPoliza.tiempoRequieres = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Proporciona la suma asegurada:");
            operacionPoliza.sumaAsegurada = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Proporciona la fecha de Nacimiento del asegurado:");
            operacionPoliza.fechaNacimientoAsegurado = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Proporciona el género del asegurado M -> Mujer o H -> Hombre:");
            operacionPoliza.géneroAsegurado = Convert.ToString(Console.ReadLine());
            string resultado = Calcular(operacionPoliza.fechainicioVigencia, operacionPoliza.tipodeperiodo, operacionPoliza.tiempoRequieres,
                operacionPoliza.sumaAsegurada, operacionPoliza.fechaNacimientoAsegurado, operacionPoliza.géneroAsegurado);
            Console.WriteLine(resultado);
        }
    }
}

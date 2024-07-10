using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSS
{
    public class CalculadoraImss
    {
        public static string CalcularImmsTotal(double operandoSBC, double operandoUMA, double tipoPersona)
        {
            string resultado = "";
            double enfermedadMaternidad = 0;
            double invalidezVida = 0;
            double retiro = 0;
            double cesantia=0;
            double infonavit = 0;
            if (tipoPersona == 1)
            {
                enfermedadMaternidad = operandoUMA - 3 * operandoSBC * 1.1 / 100;
                invalidezVida = operandoSBC * 1.75 / 100;
                retiro = operandoSBC * 2 / 100;
                cesantia = operandoSBC * 3.150 / 100;
                infonavit = operandoSBC * 5 / 100;
            }
            else if (tipoPersona == 2)
            {
                enfermedadMaternidad = operandoUMA - 3 * operandoSBC * 0.4 / 100;
                invalidezVida = operandoSBC * 0.625 / 100;
                retiro = operandoSBC * 0 / 100;
                cesantia = operandoSBC * 1.125 / 100;
                infonavit = operandoSBC * 0 / 100;
            }

            return $"El calculo de Enfermedades y Maternidad es: {enfermedadMaternidad.ToString("C")}\n" +
                $"El calculo de Invalidez y Vida es: {invalidezVida.ToString("C")}\n" +
                $"El calculo de Retiro es: {retiro.ToString("C")}\n" +
                $"El calculo de Cesantia es: {cesantia.ToString("C")}\n" +
                $"El calculo de Credito Infonavit es: {infonavit.ToString("C")}";
        }



        public static void Presentacion()
        {
            OperacionImss operacionImss = new OperacionImss();
            Console.WriteLine("Operacion a Realizar\n1.- Calculos IMSS \n6 - Terminar");
            Console.WriteLine("Seleciona opéracion a realizar");
            int operacionR = Convert.ToInt16(Console.ReadLine());


            if (operacionR <= 1)
            {
                Console.WriteLine("Proporcione Salario Base de Cotización (SBC)");
                operacionImss.operandoSBC = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Proporcione Unidad de Medida de Actualización (UMA)");
                operacionImss.operandoUMA = Convert.ToDouble(Console.ReadLine());
                TipoPersonaImms tipoPersonaImms = new TipoPersonaImms();
                Console.WriteLine("Selecciona si eres patron o trabajador \n1.-  Patrón \n2.- Trabajador");
                double operacionP = Convert.ToDouble(Console.ReadLine());
                operacionImss.tPersona = (TipoPersonaImms)operacionP;
                if (operacionP == 1)
                {
                    string resultado = CalcularImmsTotal(operacionImss.operandoSBC, operacionImss.operandoUMA, operacionP);
                    Console.WriteLine($"" + resultado);
                }
                else
                {
                    string resultado = CalcularImmsTotal(operacionImss.operandoSBC, operacionImss.operandoUMA, operacionP);
                    Console.WriteLine($"" + resultado);
                }

            }
            else if(operacionR == 6)
            {
                Environment.Exit(0);
            }

        }
    }
}

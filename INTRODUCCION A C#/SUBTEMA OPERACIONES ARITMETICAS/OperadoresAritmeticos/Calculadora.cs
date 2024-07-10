using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OperadoresAritmeticos
{
    internal class Calculadora
    {
        public static decimal Sumar(decimal operadorA, decimal OperadorB)
        {
            return operadorA + OperadorB;
        }
        public static decimal Restar(decimal operadorA, decimal OperadorB)
        {
            return operadorA - OperadorB;
        }
        public static decimal Multiplicar(decimal operadorA, decimal OperadorB)
        {
            return operadorA * OperadorB;
        }
        public static decimal Dividir(decimal operadorA, decimal OperadorB)
        {
            return operadorA / OperadorB;
        }
        public static decimal Modulo(decimal operadorA, decimal OperadorB)
        {
            return operadorA % OperadorB;
        }
        public static decimal Operacion(OperacionAritmetica operacionAritmetica)
        {
            decimal resultado = 0;
            if (operacionAritmetica.tOperacion == tipoOperacion.sumar)
               resultado = Sumar(operacionAritmetica.operandoA,operacionAritmetica.operandoB);
            else if(operacionAritmetica.tOperacion == tipoOperacion.restar)
               resultado = Restar(operacionAritmetica.operandoA, operacionAritmetica.operandoB);
            else if(operacionAritmetica.tOperacion == tipoOperacion.multiplicar)
               resultado = Multiplicar(operacionAritmetica.operandoA, operacionAritmetica.operandoB);
            else if(operacionAritmetica.tOperacion == tipoOperacion.dividir)
               resultado = Dividir(operacionAritmetica.operandoA, operacionAritmetica.operandoB);
            else if(operacionAritmetica.tOperacion == tipoOperacion.módulo)
               resultado = Modulo(operacionAritmetica.operandoA, operacionAritmetica.operandoB);

            return resultado;
        } 

        internal static Resultado Simultaneas(decimal numA , decimal numB, )
        {
            Resultado objresultado = new Resultado();
            objresultado.suma = Sumar(numA, numB);
            objresultado.resta = Restar(numA, numB);
            objresultado.multiplicacion = Multiplicar(numA, numB);
            objresultado.division = Dividir(numA, numB);
            objresultado.modulo = Modulo(numA, numB);
            return objresultado;
        }

        public static void Presentacion()
        {
            OperacionAritmetica operacionAritmetica = new OperacionAritmetica();
            Console.WriteLine("Operacion a Realizar\n1.- Sumar \n2.- Restar \n3.- Multiplicar \n4.- Dividir \n 5.- Módulo \n6 - Todas");
            Console.WriteLine("Seleciona opéracion a realizar");
            int operacionR=Convert.ToInt16(Console.ReadLine());
            operacionAritmetica.tOperacion = (tipoOperacion)operacionR;
            Console.WriteLine("Proporcione primer Operador");
            operacionAritmetica.operandoA = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Proporcione segundo Operador");
            operacionAritmetica.operandoB = Convert.ToDecimal(Console.ReadLine());
            if (operacionR < 6)
            {
                decimal resultado = Operacion(operacionAritmetica);
                Console.WriteLine($"{operacionAritmetica.tOperacion.ToString()} es:"+ resultado);
            }
            else if (operacionR == 6)
            {
               Resultado resultado= Simultaneas(operacionAritmetica.operandoA, operacionAritmetica.operandoB);
                Console.WriteLine($"La suma es: {resultado.suma}");
                Console.WriteLine($"La Resta es: {resultado.resta}");
                Console.WriteLine($"La Multiplicacion es: {resultado.multiplicacion}");
                Console.WriteLine($"La Division es: {resultado.division}");
                Console.WriteLine($"La Modulo es: {resultado.modulo}");
            }

        }
    }
}

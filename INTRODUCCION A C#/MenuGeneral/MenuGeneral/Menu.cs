using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Menu
    {


        public static string Calcular(OperacionMenuGeneral operacionMenuGeneral)
        {
            string resultado = "";
            if (operacionMenuGeneral.tOperacion == MenuGeneralEnum.arreglos)
                resultado = Arreglos.Cadenas(operacionMenuGeneral.nombreCompleto);
            else if(operacionMenuGeneral.tOperacion == MenuGeneralEnum.declaracionVariables)
                resultado = Arreglos.Enteros(operacionMenuGeneral.num1, operacionMenuGeneral.num2, operacionMenuGeneral.num3,
                    operacionMenuGeneral.num4, operacionMenuGeneral.num5);
            else if(operacionMenuGeneral.tOperacion == MenuGeneralEnum.convierteATipoOracion)
                resultado = Arreglos.ConvierteATipoOracion(operacionMenuGeneral.oracion);
            return resultado;
        }
        public static void Presentacion()
        {
            OperacionMenuGeneral operacionMenuGeneral = new OperacionMenuGeneral();
            Console.WriteLine("Operacion a Realizar\n1.- Arreglos \n2.- Numero mayor \n3.-Convierte A Tipo Oracion\n4.- Calcular Poliza \n5.- Mostrar ArchivoCSV \n6.- ExcribirTXT \n7.- Calcular ISR \nF.- Terminar");
            Console.WriteLine("Seleciona opéracion a realizar");
            string operacionR = Convert.ToString(Console.ReadLine());
            int opcion = 0;
            opcion = operacionR.Equals("F") ? 15 : opcion = Int32.Parse(operacionR);
            operacionMenuGeneral.tOperacion = (MenuGeneralEnum)opcion;
            while (opcion >= 1)
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Usted seleccionó la opción 1");
                        Console.WriteLine("Proporciona tu nombre completo");
                        operacionMenuGeneral.nombreCompleto = Convert.ToString(Console.ReadLine());
                        string resultado = Calcular(operacionMenuGeneral);
                        Console.WriteLine(resultado);
                        Presentacion();
       
                        break;
                    case 2:
                        Console.WriteLine("Usted seleccionó la opción 2");
                        Console.WriteLine("Proporciona el primer numero");
                        operacionMenuGeneral.num1 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Proporciona el segundo numero");
                        operacionMenuGeneral.num2 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Proporciona el tercer numero");
                        operacionMenuGeneral.num3 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Proporciona el cuarto numero");
                        operacionMenuGeneral.num4 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Proporciona el quinto numero");
                        operacionMenuGeneral.num5 = Convert.ToInt16(Console.ReadLine());
                        string resultadoEntero = Calcular(operacionMenuGeneral);
                        Console.WriteLine(resultadoEntero);
                        Presentacion();
                        break;
                    case 3:
                        Console.WriteLine("Usted seleccionó la opción 3");
                        Console.WriteLine("Proporciona Una oracion");
                        operacionMenuGeneral.oracion = Convert.ToString(Console.ReadLine());
                        string resultadoOracion = Calcular(operacionMenuGeneral);
                        Console.WriteLine(resultadoOracion);
                        Presentacion();
                        break;
                    case 4:
                        Console.WriteLine("Usted seleccionó la opción 4");
                        Poliza.Presentacion();
                        Presentacion();
                        break;
                    case 5:
                        Console.WriteLine("Usted seleccionó la opción 5");
                        Console.WriteLine("Proporciona la ruta y nombre de archivo");
                        string nombreRuta = Convert.ToString(Console.ReadLine());
                        string resultadoArchivo = Archivotxt.MostrarTxt(nombreRuta);
                        Console.WriteLine(resultadoArchivo);
                        Presentacion();
                        break;
                    case 6:
                        Console.WriteLine("Usted seleccionó la opción 6");
                        Console.WriteLine("si- > Es un archivo nuevo o no -> Para usuar archivo existente");
                        string archivoCrear = Convert.ToString(Console.ReadLine());
                        bool crearArchivoNuevo = true;
                        if (archivoCrear == "si"){ crearArchivoNuevo = true; }
                        else if(archivoCrear == "no") {crearArchivoNuevo = false;}
                        Console.WriteLine("Proporciona el nombre del archivo");
                        string nombreArchivo = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Indique en que código se quiere escribir (UTF7,UTF8,Unicod, UTF32,ASCII)");
                        string formatoEscritura = Convert.ToString(Console.ReadLine());
                        string resultadoEscribirArchi = Archivotxt.ExcribirTXT(crearArchivoNuevo, nombreArchivo, formatoEscritura);
                        Console.WriteLine(resultadoEscribirArchi);
                        Presentacion();
                        break;
                    case 7:
                        Console.WriteLine("Usted seleccionó la opción 7");
                        ISR.Presentación();
                        Presentacion();
                        break;
                    case 15:
                        Environment.Exit(0);
                        break;
                }

            }

        }
    }
}

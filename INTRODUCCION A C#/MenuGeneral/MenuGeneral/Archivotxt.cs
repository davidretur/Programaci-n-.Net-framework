using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    public class Archivotxt
    {
        public static string MostrarCSV(string nombreRuta)
        {
            string linea;
            StreamReader archivo = new StreamReader(@"C:\Users\Tichs\Documents\Manejo de archivos\"+nombreRuta);
            while ((linea = archivo.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }
            archivo.Close();
            return linea;
        }
        public static string MostrarTxt(string nombreRuta)
        {

            string resultado = "";
            resultado = MostrarCSV(nombreRuta);

            return resultado;
        }

        public static string ExcribirTXT(bool crearArchivoNuev, string nombreArchivo, string formatoEscritura)
        {
            string res = "";
            bool lcrearArchivoNuev = crearArchivoNuev;
            string lformatoEscritura = formatoEscritura;
            string lnombreArchivo = nombreArchivo;
            string rutaDeArchivo = @"C:\Users\Tichs\Documents\Manejo de archivos\"+nombreArchivo+".txt";
            Encoding codigo = Encoding.UTF8;
            switch (formatoEscritura)
            {
                case "UTF7":
                    codigo = Encoding.UTF7;
                    break;
                case "utf8":
                    codigo = Encoding.UTF8;
                    break;
                case "Unicod":
                    codigo = Encoding.Unicode;
                    break;
                case "UTF32":
                    codigo = Encoding.UTF32;
                    break;
                case "ASCII":
                    codigo = Encoding.ASCII;
                    break;
            }

                Console.WriteLine("Proporciona tu nombre");
                string nombreAlu = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Proporciona tu primer apellido");
                string primerapellidoAlu = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Proporciona tu segundo apellido");
                string segundoapellidoAlu = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Proporciona tu edad");
                int edad = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Proporciona tu Estado de Nacimiento");
                string estado = Convert.ToString(Console.ReadLine());
            if (lcrearArchivoNuev == false)
            {
                StreamWriter archivo;
                archivo = new StreamWriter(rutaDeArchivo, true, codigo);
                archivo.WriteLine($"{nombreAlu},{primerapellidoAlu},{segundoapellidoAlu},{edad},{estado}");
                archivo.Close();
            }
            else
            {
                bool nlcrearArchivoNuev = false;
                lcrearArchivoNuev = nlcrearArchivoNuev;
                StreamWriter archivo;
                archivo = new StreamWriter(rutaDeArchivo, false, codigo);
                archivo.WriteLine($"{nombreAlu},{primerapellidoAlu},{segundoapellidoAlu},{edad},{estado}");
                archivo.Close();
            }

                Console.WriteLine("Seguir agrenado ingresa -> 1 regresar a menu 0 principal");
                int seguir = Convert.ToInt16(Console.ReadLine());
                if(seguir > 0)
            {
                Console.Clear();
                ExcribirTXT(lcrearArchivoNuev, lnombreArchivo, lformatoEscritura);
            }
            Console.Clear();
            return res;
        }

    }
}

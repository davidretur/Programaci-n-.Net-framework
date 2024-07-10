using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LINQ
{
    internal class OperacionesLINQ
    {
        public static List<Alumno> _alumnoLista = new List<Alumno>();
        public static List<Estado> _estadosLista = new List<Estado>();
            public static List<Estatus> _estatusLista = new List<Estatus>(); 
            public static List<ItemISR> _ItemISRLista = new List<ItemISR>();
        internal static void CargarLists()
        {
            string ralumnosJson = @"C:\Users\Tichs\Documents\json\Alumnos.json";
            using (StreamReader jsonStream = File.OpenText(ralumnosJson))
            {
                var json = jsonStream.ReadToEnd();

                 _alumnoLista = JsonConvert.DeserializeObject <List<Alumno >>(json);
            }
            string restadosJson = @"C:\Users\Tichs\Documents\json\Estados.json";
            using (StreamReader jsonStream = File.OpenText(restadosJson))
            {
                var json = jsonStream.ReadToEnd();

                _estadosLista = JsonConvert.DeserializeObject<List<Estado>>(json);
            }
            string restatusJson = @"C:\Users\Tichs\Documents\json\Estatus.json";
            using (StreamReader jsonStream = File.OpenText(restatusJson))
            {
                var json = jsonStream.ReadToEnd();

                _estatusLista = JsonConvert.DeserializeObject<List<Estatus>>(json);
            }
          /*  string rTablaIsr = @"C:\Users\Tichs\Documents\json\TablaIsr.csv";



            decimal[,] tablaPlz = new decimal[21, 6];
            string linea = "";
            StreamReader archivo = new StreamReader(rTablaIsr);
            int i = 0;
            while ((linea = archivo.ReadToEnd()) != null)
            {
                string[] taballeer = linea.Split(',');
                tablaPlz[i, 0] = Convert.ToDecimal(taballeer[1]);
                tablaPlz[i, 1] = Convert.ToDecimal(taballeer[2]);
                tablaPlz[i, 2] = Convert.ToDecimal(taballeer[3]);
                tablaPlz[i, 3] = Convert.ToDecimal(taballeer[4]);
                tablaPlz[i, 4] = Convert.ToDecimal(taballeer[5]);

                i++;
            }
          */
           

            // Lista para almacenar los objetos ItemISR
            
            string rTablaIsr = @"C:\Users\Tichs\Documents\json\TablaIsr.csv";
            try
            {
                string[] lineas = File.ReadAllLines(rTablaIsr);

                
                _ItemISRLista = (from linea in lineas.Skip(0) 
                            let campos = linea.Split(',')
                            select new ItemISR
                            {
                                id = int.Parse(campos[0]),
                                LimInf = decimal.Parse(campos[1]),
                                LimSup = decimal.Parse(campos[2]),
                                CuotaFija = decimal.Parse(campos[3]),
                                PorExced = decimal.Parse(campos[4]),
                                Subsidio = decimal.Parse(campos[5])
                            }).ToList();

              /*  // Ejemplo: imprimir los objetos ItemISR cargados
                foreach (var item in _ItemISRLista)
                {
                    Console.WriteLine($"ID: {item.id}, LimiteInferior: {item.LimInf}, LimiteSuperior: {item.LimSup}, CuotaFija: {item.CuotaFija}, ExcedenteLimiteInferior: {item.PorExced}, Subsidio: {item.Subsidio}");
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo CSV: {ex.Message}");
            }

            Consultas();
        }

        internal static void Consultas()
        {


            // Consulta LINQ para obtener el estado con id = 5
            Estado estadoId5 = _estadosLista.Find(e => e.id == 5);
            // Verificamos si se encontró el estado
            if (estadoId5 != null)
            {
                Console.WriteLine("Estado encontrado: " + estadoId5.nombre);
            }
            else
            {
                Console.WriteLine("Estado con id = 5 no encontrado");
            }

            var resultado = _alumnoLista
                            .Where(alumno => alumno.idEstado == 29 || alumno.idEstado == 13)
                            .OrderBy(alumno => alumno.Nombre)
                            .ToList();


            Console.WriteLine("Alumnos con idEstado 29 o 13, ordenados por nombre:");
            foreach (var alumno in resultado)
            {
                Console.WriteLine($"ID: {alumno.id}, Nombre: {alumno.Nombre}, Estado: {alumno.idEstado}");
            }


            var resultado2 = _alumnoLista
                            .Where(alumno => alumno.idEstado == 29 && alumno.idEstado == 13 && alumno.idEstatus == 4 || alumno.idEstatus == 5)
                            .OrderBy(alumno => alumno.Nombre)
                            .ToList();

            Console.WriteLine("Alumnos que son IdEstado 19 y 20 y además de que estén en el estatus 4 o 5:");
            foreach (var alumno in resultado2)
            {
                Console.WriteLine($"ID: {alumno.id}, Nombre: {alumno.Nombre}, Estado: {alumno.idEstado}");
            }
            /// consulta
            var resultado3 = _alumnoLista
                            .Where(alumno => alumno.Calificacion >= 6)
                            .OrderBy(alumno => alumno.Calificacion)
                            .ToList();

            Console.WriteLine("Alumnos que tienen calificación aprobatoria, \n considerando esta como 6 o mayor, " +
                "ordenado por calificación del mayor al menor");
            foreach (var alumno in resultado3)
            {
                Console.WriteLine($"ID: {alumno.id}, Nombre: {alumno.Nombre}, Estado: {alumno.idEstado}");
            }
            ////termina
       
            decimal promedioCalificaciones = _alumnoLista.Average(alumno => alumno.Calificacion);

         
            Console.WriteLine($"La calificación promedio de los alumnos es: {promedioCalificaciones}");


            bool ningunDiez = _alumnoLista.All(alumno => alumno.Calificacion != 10);

         
            bool todosEntreSeisYSiete = _alumnoLista.All(alumno => alumno.Calificacion >= 6 && alumno.Calificacion <= 7);

            if (ningunDiez)
            {
                _alumnoLista.ForEach(alumno => alumno.Calificacion += 1);
            }

            if (todosEntreSeisYSiete)
            {
                _alumnoLista.ForEach(alumno => alumno.Calificacion += 2);
            }

            Console.WriteLine("Calificaciones actualizadas:");
            foreach (var alumno in _alumnoLista)
            {
                Console.WriteLine($"ID: {alumno.id}, Nombre: {alumno.Nombre}, Calificación: {alumno.Calificacion}");
            }

            // consulta
            var resultado4 = _alumnoLista
                            .Where(alumno => alumno.Calificacion >= 6)
                            .OrderBy(alumno => alumno.Calificacion)
                            .ToList();

            Console.WriteLine("Alumnos que tienen calificación aprobatoria, \n considerando esta como 6 o mayor, " +
                "ordenado por calificación del mayor al menor");
            foreach (var alumno in resultado4)
            {
                Console.WriteLine($"ID: {alumno.id}, Nombre: {alumno.Nombre}, Estado: {alumno.idEstado}");
            }
            //termina
            //consulta
            var resultado5 = from alumno in _alumnoLista
                             join estado in _estadosLista on alumno.idEstado equals estado.id
                            where alumno.idEstado == 13
                            select new
                            {
                                idAlumno = alumno.id,
                                nombreAlumno = alumno.Nombre,
                                nombreEstado = estado.nombre
                            };

            Console.WriteLine("Alumnos en estado 13:");
            foreach (var alumno in resultado5)
            {
                Console.WriteLine($"ID Alumno: {alumno.idAlumno}, Nombre: {alumno.nombreAlumno}, Estado: {alumno.nombreEstado}");
            }
            //termina
            //consulta
            var resultado6 = from alumno in _alumnoLista
                             join estatus in _estatusLista on alumno.idEstatus equals estatus.id
                             where alumno.idEstatus == 2 orderby alumno.Nombre
                             select new
                             {
                                 idAlumno = alumno.id,
                                 nombreAlumno = alumno.Nombre,
                                 nombreEstatus = estatus.Nombre
                             };

            Console.WriteLine("Alumnos en estatus 2:");
            foreach (var alumno in resultado6)
            {
                Console.WriteLine($"ID Alumno: {alumno.idAlumno}, Nombre: {alumno.nombreAlumno}, Estatus: {alumno.nombreEstatus}");
            }
            //termina
            //consulta
            var resultado7 = from alumno in _alumnoLista
                             join estatus in _estatusLista on alumno.idEstatus equals estatus.id
                             join estado in _estadosLista on alumno.idEstado equals estado.id
                             where alumno.idEstatus > 2 orderby estatus.Nombre
                             orderby alumno.Nombre
                             select new
                             {
                                 idAlumno = alumno.id,
                                 nombreAlumno = alumno.Nombre,
                                 nombreEstado = estado.nombre,
                                 nombreEstatus = estatus.Nombre
                             };

            Console.WriteLine("Alumnos en estatus mayor a 2:");
            foreach (var alumno in resultado7)
            {
                Console.WriteLine($"ID Alumno: {alumno.idAlumno}, Nombre: {alumno.nombreAlumno},  Estado: {alumno.nombreEstado}, Estatus: {alumno.nombreEstatus}");
            }
            //termina
            // Calcular el impuesto
            decimal sueldoMensual = 50000 / 2;
            decimal isrCalculado = 0;

            // Encontrar el rango en la tabla ISR que corresponde al sueldo mensual
            var rangoISR = _ItemISRLista.Find(r => sueldoMensual > r.LimInf && sueldoMensual <= r.LimSup);

            if (rangoISR != null)
            {
                // Calcular ISR utilizando la fórmula
                isrCalculado = rangoISR.CuotaFija + (rangoISR.PorExced / 100) * (sueldoMensual - rangoISR.LimInf);
            }

            Console.WriteLine($"El ISR calculado para un sueldo de {sueldoMensual} pesos mensuales es: {isrCalculado}");


        }
    }
}

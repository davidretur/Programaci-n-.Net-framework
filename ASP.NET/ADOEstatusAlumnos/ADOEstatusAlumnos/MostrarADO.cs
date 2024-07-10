using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    public class MostrarADO
    {
        public static void Presentacion()
        {
            CrudADO crudADO = new CrudADO();    
            do
            {
                int opcion = 0;
                Console.WriteLine("Operacion a Realizar\n1.- Consultar Todos\n2.- Consultar Solo Uno\n3.- Agregar\n4.- Actualizar\n5.- Eliminar");
                opcion = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {

                    case 1:
                        List<EstatusAlumnos> _estatusAlumnoLista = crudADO.ConsultarTodos();
                        foreach (var lEstatusAlumno in _estatusAlumnoLista)
                        {
                            Console.WriteLine($"id : {lEstatusAlumno.id}  - Clave :{lEstatusAlumno.clave} - nombre: {lEstatusAlumno.nombre}");
                        }
                        break;
                    case 2:
                      //consultar solo uno
                        Console.WriteLine("Ingresa id estado a consultar");
                        int idEstatus = Convert.ToInt16(Console.ReadLine());
                        EstatusAlumnos estadoUno = crudADO.ConsultarSoloUno(idEstatus);
                
                            Console.WriteLine($"id : {estadoUno.id}  - Clave :{estadoUno.clave} - nombre: {estadoUno.nombre}");
                        
                        break;
                     case 3:
                         //console agregar
                         EstatusAlumnos AgregareStatus = new EstatusAlumnos();
                         Console.WriteLine("Ingresa el nombre clave estatus Alumno a agregar");
                         AgregareStatus.clave = Convert.ToString(Console.ReadLine());
                         Console.WriteLine("Ingresa el nombre estatus Alumno a agregar");
                         AgregareStatus.nombre = Convert.ToString(Console.ReadLine());
                        int idInsertado = crudADO.Agregar(AgregareStatus);
                        Console.WriteLine($"Se agregó el estatus de alumno con id: {idInsertado}");
                        break;
                     case 4:
                         // actualizar estado
                         EstatusAlumnos Actualizarestatus = new EstatusAlumnos();
                         Console.WriteLine("Ingresa id estatus Alumno a Actualizar");
                         Actualizarestatus.id = Convert.ToInt16(Console.ReadLine());
                         Console.WriteLine("Ingresa el nombre clave estatus Alumno a agregar");
                         Actualizarestatus.clave = Convert.ToString(Console.ReadLine());
                         Console.WriteLine("Ingresa el nombre estatus Alumno a Actualizar");
                         Actualizarestatus.nombre = Convert.ToString(Console.ReadLine());
                        crudADO.Actualizar(Actualizarestatus);
                         break;
                       case 5:
                         //eliminar estado
                        
                         Console.WriteLine("Ingresa id estatus Alumno a eliminar");
                         int idEstatusEliminar = Convert.ToInt16(Console.ReadLine());
                        crudADO.Eliminar(idEstatusEliminar);
                         break;
                    default:
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }



    }
}

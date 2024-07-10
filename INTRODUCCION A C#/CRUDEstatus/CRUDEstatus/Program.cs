using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUD cRUD = new CRUD();
            do
            {
                int opcion = 0;
                Console.WriteLine("Operacion a Realizar\n1.- Consultar Todos\n2.- Consultar Solo Uno\n3.- Agregar\n4.- Actualizar\n5.- Eliminar");
                opcion = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {

                    case 1:
                        List<EstatusAlumno> _estatusAlumnoLista = cRUD.ConsultarTodos();
                        foreach (var lEstatusAlumno in _estatusAlumnoLista)
                        {
                            Console.WriteLine($"id : {lEstatusAlumno.idEstatus}  - Clave :{lEstatusAlumno.clave} - nombre: {lEstatusAlumno.nombreEstatus}");
                        }
                        break;
                    case 2:
                        //consultar solo uno
                        Console.WriteLine("Ingresa id estado a consultar");
                        int idEstatus = Convert.ToInt16(Console.ReadLine());
                        EstatusAlumno estadoUno = cRUD.ConsultarSoloUno(idEstatus);
                        Console.WriteLine($"id :{estadoUno.idEstatus} - Clave :{estadoUno.clave} - nombre : {estadoUno.nombreEstatus}");
                        break;
                    case 3:
                        //console agregar
                        EstatusAlumno AgregareStatus = new EstatusAlumno();
                        Console.WriteLine("Ingresa id estatus Alumno a agregar");
                        AgregareStatus.idEstatus = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre clave estatus Alumno a agregar");
                        AgregareStatus.clave = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre estatus Alumno a agregar");
                        AgregareStatus.nombreEstatus = Convert.ToString(Console.ReadLine());
                        cRUD.Agregar(AgregareStatus);
                        break;
                    case 4:
                        // actualizar estado
                        EstatusAlumno Actualizarestatus = new EstatusAlumno();
                        Console.WriteLine("Ingresa id estatus Alumno a Actualizar");
                        Actualizarestatus.idEstatus = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre clave estatus Alumno a agregar");
                        Actualizarestatus.clave = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre estatus Alumno a Actualizar");
                        Actualizarestatus.nombreEstatus = Convert.ToString(Console.ReadLine());
                        cRUD.Actualizar(Actualizarestatus);
                        break;
                    case 5:
                        //eliminar estado
                        EstatusAlumno eliminarEstatus = new EstatusAlumno();
                        Console.WriteLine("Ingresa id estatus Alumno a eliminar");
                        eliminarEstatus.idEstatus = Convert.ToInt16(Console.ReadLine());
                        cRUD.Eliminar(eliminarEstatus);
                        break;
                    default:
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}

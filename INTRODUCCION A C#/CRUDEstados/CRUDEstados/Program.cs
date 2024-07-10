using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUD cRUD = new CRUD();            
            do
            {
                int opcion = 0;
                Console.WriteLine("Operacion a Realizar\n1.- Consultar Todos \n2.-Consultar Solo Uno \n3.-Agregar \n4.- Actualizar \n5.- Eliminar  \n6.- Terminar");
                 opcion = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    
                    case 1:
                        Dictionary<int, Estado> dicEstados = cRUD.ConsultarTodos();
                        foreach (KeyValuePair<int, Estado> estado in dicEstados)
                        {
                            Console.WriteLine($"id : {estado.Key} nombre: {estado.Value.nombre}");
                        }
                        break;
                        case 2:
                        //consultar solo uno
                        Console.WriteLine("Ingresa id estado a consultar");
                        int id = Convert.ToInt16(Console.ReadLine());
                        Estado estadoUno = cRUD.ConsultarSoloUno(id);
                        Console.WriteLine($"id :{estadoUno.idEstado} nombre : {estadoUno.nombre}");
                        break;
                    case 3:
                        //console agregar
                        Estado Agregarestado = new Estado();
                        Console.WriteLine("Ingresa id estado a agregar");
                        Agregarestado.idEstado = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Ingresa el  nombre del estado");
                        Agregarestado.nombre = Convert.ToString(Console.ReadLine());
                        cRUD.Agregar(Agregarestado);
                        break;
                    case 4:
                        // actualizar estado
                        Estado Actualizarestado = new Estado();
                        Console.WriteLine("Ingresa id estado a Actualizar");
                        Actualizarestado.idEstado = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Ingresa el  nombre del estado");
                        Actualizarestado.nombre = Convert.ToString(Console.ReadLine());
                        cRUD.Actualizar(Actualizarestado);
                        break;
                    case 5:
                        //eliminar estado
                        Console.WriteLine("Ingresa id estado a eliminar");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        cRUD.Eliminar(idEliminar);
                        break;
                    case 6:
                        //eliminar estado
                        Console.ReadKey();
                        break;
                    default:
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}

//https://www.luisllamas.es/csharp-que-son-listas/
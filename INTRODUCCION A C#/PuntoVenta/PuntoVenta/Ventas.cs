using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuntoVenta
{
    public class Ventas
    {

        public static List<Articulo> _articulosLista = new List<Articulo>();
        internal static void CargarLists()
        {
            string rarticulosJson = @"C:\Users\Tichs\Documents\PROYECTOS JUN TICH\TichJunio2024\TEMA INTRODUCCION A C#\PuntoVenta\PuntoVenta\Data\Articulos.json";

            using (StreamReader jsonStream = File.OpenText(rarticulosJson))
            {
                var json = jsonStream.ReadToEnd();
                _articulosLista = JsonConvert.DeserializeObject<List<Articulo>>(json);
            }
        }

        public static List<ItemBase> _productosVentaNormal = new List<ItemBase>();

        // Método para agregar un nuevo artículo a la lista

        // Método para calcular el total de la venta
        public static decimal CalcularTotal()
        {
            decimal totalVenta = 0.0m;
            foreach (var producto in _productosVentaNormal)
            {
                totalVenta += producto.SubTotal();
            }
            return totalVenta;
        }

        // Método para mostrar el resumen de la venta
        public static void MostrarResumen()
        {
            Console.WriteLine("\nResumen de la venta:");
            foreach (var producto in _productosVentaNormal)
            {
                producto.ImprimirDetalle();
                Console.WriteLine($"Subtotal: ${producto.SubTotal():0.00}");
            }
            Console.WriteLine($"Total de la venta: ${CalcularTotal():0.00}");
        }


        public static void Vender()
        {
            Articulo articulo = new Articulo();
            while (true)
            {
                Console.WriteLine("\n(V) Iniciar nueva venta o (TV) Terminar venta: ");
                string opcion = Console.ReadLine().ToUpper();

                if (opcion == "V")
                {
                    // mostrar lista de productos
                    CargarLists();

                    while (true)
                    {
                        Console.WriteLine("Ingrese el id del producto O T terminar y cobrar");
                        string idProducto = Console.ReadLine();
                        if (idProducto.ToUpper() == "T")
                        {
                            break;
                        }
                        int idproductoVenta = Convert.ToInt16(idProducto);
                        Articulo Tventa = _articulosLista.Find(at => at.id == idproductoVenta);
                        int tOperacion = Tventa.tipo;
                        articulo.tOperacion = (TipoVenta)Tventa.tipo;
                        if (tOperacion == 1)
                        {
                            Console.WriteLine("Ingrese la cantidad de productos ");
                            int cantidad = Convert.ToInt16(Console.ReadLine());
                            Item item = new Item(Tventa,cantidad);
                            _productosVentaNormal.Add(item);

                        }
                        else if (tOperacion == 2)
                        {
                            Console.WriteLine("Ingrese la cantidad de productos ");
                            int cantidad = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Ingrese (%) a descontar");
                            int porcentajeDescontar = Convert.ToInt16(Console.ReadLine());
              
                            ItemDescuento itemDescuento = new ItemDescuento(Tventa,porcentajeDescontar,cantidad);
                            _productosVentaNormal.Add(itemDescuento);
                        }else if(tOperacion == 3)
                        {
                            Console.WriteLine("Ingrese el teléfono: ");
                            string telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese la compañía: ");
                            string compania = Console.ReadLine();
                            Console.WriteLine("Ingrese la comision: ");
                            decimal comision = Convert.ToDecimal(Console.ReadLine());
                            itemTa itemTa = new itemTa(Tventa,telefono,compania,comision,1);
                            _productosVentaNormal.Add(itemTa);
                        }


                        // Crear un nuevo artículo dependiendo del nombre del producto
                        ItemBase nuevoProducto;
                        if (idProducto.ToLower().Contains("descuento"))
                        {
                            decimal descuento;
                            while (true)
                            {
                                Console.Write("Ingrese el descuento (%): ");
                                if (decimal.TryParse(Console.ReadLine(), out descuento))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error: Ingrese un descuento válido.");
                                }
                            }
                        }
                        else if (idProducto.ToLower().Contains("tiempo aire"))
                        {
                            Console.Write("Ingrese el teléfono: ");
                            string telefono = Console.ReadLine();
                            Console.Write("Ingrese la compañía: ");
                            string compania = Console.ReadLine();
                            decimal comision;
                            while (true)
                            {
                                Console.Write("Ingrese la comisión: ");
                                if (decimal.TryParse(Console.ReadLine(), out comision))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error: Ingrese una comisión válida.");
                                }
                            }
                        }
                        else
                        {
                        }

                        // Agregar el artículo a la lista de productos
                        // AgregarProducto(nuevoProducto);
                    }
                }
                else if (opcion == "TV")
                {
                    Console.WriteLine("Tienda Tich");
                    foreach (var item in _productosVentaNormal)
                    {
                        item.ImprimirDetalle();
                        
                    }
         
                    decimal total = _productosVentaNormal.Sum(x => x.CalcularTotal());
                    decimal descuento = _productosVentaNormal.Sum(x => x.CalcularTotal());
                    Console.WriteLine("El total: "+ total.ToString("C"));
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese 'V' para iniciar o 'T' para terminar.");
                }
            }
        }

    }
}

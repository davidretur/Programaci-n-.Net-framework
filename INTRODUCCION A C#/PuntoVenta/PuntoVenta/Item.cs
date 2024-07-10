using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuntoVenta
{
    public class Item : ItemBase
    {
        public Item()
        {
        }
        public Item(Articulo articulo, decimal cantidad) : base(articulo, cantidad)
        {
        }

        public override void ImprimirDetalle()
        {
            Console.WriteLine($" Id: {id}, Nombre: {nombre}, Precio: ${precio}, Cantidad: {cantidad}, Subtotal: {SubTotal()}\n Total : {CalcularTotal()}");
        }
    }
}

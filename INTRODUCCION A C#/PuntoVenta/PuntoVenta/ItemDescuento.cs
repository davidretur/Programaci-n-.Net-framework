using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class ItemDescuento : ItemBase
    {
        public static decimal _descuento = 0;
        public ItemDescuento()
        {
        }

        public ItemDescuento(Articulo articulo ,decimal descuento, decimal cantidad):base(articulo,cantidad)
        {
            this.descuento = descuento;
        }

        public decimal descuento { get; set; }
        public decimal importeDescuento { get 
            {
                return SubTotal() * descuento / 100;
            } }

        public override decimal CalcularTotal()
        {
            return base.SubTotal()-importeDescuento;
        }
        public override void ImprimirDetalle()
        {
             Console.WriteLine($"- Id: {id}, Nombre: {nombre}, Precio: ${precio}, Cantidad: {cantidad}, Subtotal: {SubTotal()}\n, Descuento: {importeDescuento} {descuento}% \n Total : {CalcularTotal()}");
        }

        // Implementación del método abstracto para imprimir detalles específicos de artículos con descuento
 
    }
}
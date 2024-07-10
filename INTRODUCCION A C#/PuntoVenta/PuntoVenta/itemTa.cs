using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class itemTa: ItemBase
    {
        public itemTa()
        {
        }

        public itemTa(Articulo articulo, string telefono, string compania, decimal comision, decimal cantidad) : base(articulo, cantidad)
        {
            this.telefono = telefono;
            this.compania = compania;
            this.comision = comision;
        }

        public string telefono { get; set; }
        public string compania { get; set; }
        public decimal comision { get; set; }

        public override decimal CalcularTotal()
        {
            return base.SubTotal() + comision;
        }

        // Implementación del método abstracto para imprimir detalles específicos de artículos de tiempo aire
        public override void ImprimirDetalle()
        {
             Console.WriteLine($"Tiempo aire - Id: {id}, Teléfono: {telefono}, Compañía: {compania}, Precio: ${precio}, Comisión: ${comision}, Subtotal: {SubTotal()}\n Total : {CalcularTotal()}");
        }
    }
}

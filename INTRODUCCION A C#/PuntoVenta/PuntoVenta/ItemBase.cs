using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public abstract class ItemBase
    {
        public ItemBase()
        {
        }

        protected ItemBase(Articulo articulo, decimal cantidad)
        {
            this.id = articulo.id;
            this.nombre = articulo.nombre;
            this.precio = articulo.precio;
            this.cantidad = cantidad;
        }

        public int id { get; set; }

        public string nombre { get; set; }
        // definidas ára noo ahacer operaciones
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }

        /// </summary>
        /// //accion sobre esta propiedad


        public virtual decimal SubTotal()
        {
            decimal subtotal = precio * cantidad;
            return subtotal;
        }
        public virtual decimal CalcularTotal()
        {
            decimal total = precio * cantidad;
            return total;
        }
        public abstract void ImprimirDetalle();


    }
}

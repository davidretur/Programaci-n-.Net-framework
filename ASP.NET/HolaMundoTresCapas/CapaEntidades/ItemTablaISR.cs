using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ItemTablaISR
    {
        public ItemTablaISR()
        {
        }

        public ItemTablaISR(decimal limiteInferior, decimal limiteSuperior, decimal cuotaFija, decimal excedente, decimal subsidio, decimal isr)
        {
            this.limiteInferior = limiteInferior;
            this.limiteSuperior = limiteSuperior;
            this.cuotaFija = cuotaFija;
            this.excedente = excedente;
            this.subsidio = subsidio;
            this.isr = isr;
        }

        public decimal limiteInferior { get; set; }
        public decimal limiteSuperior { get; set; }
        public decimal cuotaFija { get; set; }
        public decimal excedente { get; set; }
        public decimal subsidio { get; set; }
        public decimal isr { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    public struct OperacionPoliza
    {
        public OperacionPoliza(DateTime fechainicioVigencia, string tipodeperiodo, int tiempoRequieres, decimal sumaAsegurada, DateTime fechaNacimientoAsegurado, string géneroAsegurado)
        {
            this.fechainicioVigencia = fechainicioVigencia;
            this.tipodeperiodo = tipodeperiodo;
            this.tiempoRequieres = tiempoRequieres;
            this.sumaAsegurada = sumaAsegurada;
            this.fechaNacimientoAsegurado = fechaNacimientoAsegurado;
            this.géneroAsegurado = géneroAsegurado;
        }

        public DateTime fechainicioVigencia { get; set; }
        public string tipodeperiodo { get; set; }
        public int tiempoRequieres { get; set; }
        public decimal sumaAsegurada { get; set; }
        public DateTime fechaNacimientoAsegurado { get; set; }
        public string géneroAsegurado { get; set; }

    }
}

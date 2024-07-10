using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    public struct OperacionMenuGeneral
    {
        public OperacionMenuGeneral(string nombreCompleto, int num1, int num2, int num3, int num4, int num5, string oracion, MenuGeneralEnum tOperacion)
        {
            this.nombreCompleto = nombreCompleto;
            this.num1 = num1;
            this.num2 = num2;
            this.num3 = num3;
            this.num4 = num4;
            this.num5 = num5;
            this.oracion = oracion;
            this.tOperacion = tOperacion;
        }

        public string nombreCompleto { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int num5 { get; set; }

        public string oracion { get; set; }

        public MenuGeneralEnum tOperacion { get; set; }
    }
}

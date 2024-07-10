using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel.DataAnnotations
{
    public class RangeDate: ValidationAttribute
    {
        public RangeDate(string fechaMaxima, string fechaMinima)
        {
            this.fechaMaxima = DateTime.Parse(fechaMaxima);
            this.fechaMinima = DateTime.Parse(fechaMinima);
        }

        public DateTime fechaMaxima { get; set; }
        public DateTime fechaMinima { get; set; }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessage, name, fechaMinima.ToString("yyyy-MM-dd"), fechaMaxima.ToString("yyyy-MM-dd"));
        }
        public override bool IsValid(object value)
        {
            DateTime fechaIngresada=DateTime.Parse(value.ToString());

            return fechaIngresada >= fechaMaxima && fechaIngresada<= fechaMaxima? true : false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel.DataAnnotations
{
    public class FechaNacimientoValidaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fechaNacimiento = (DateTime)value;
                DateTime fechaMinima = new DateTime(1990, 1, 1);
                DateTime fechaMaxima = new DateTime(2000, 12, 31);
                if (fechaNacimiento < fechaMinima || fechaNacimiento > fechaMaxima)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

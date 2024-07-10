using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CapaEntidades
{
    [MetadataType(typeof(DataAnotacionAlumnos))]
    public partial class Alumnos
    {
    }

    public class DataAnotacionAlumnos
    {
        public int id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El campo Nombre solo debe contener letras y espacios")]
        public string nombre { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El campo Primer Apellido solo debe contener letras y espacios")]
        public string primerApellido { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El campo SegundoApellido solo debe contener letras y espacios")]
        public string segundoApellido { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "{0} Ingresa un correo valido")]
        public string correo { get; set; }
        [Required]
        [StringLength(maximumLength: 10)]
        [Phone(ErrorMessage ="{0}Ingresa un telefono valido")]
        public string telefono { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [FechaNacimientoValidaAttribute(ErrorMessage = "La fecha de nacimiento debe estar entre el {1} y el {2}.")]
        public System.DateTime fechaNacimiento { get; set; }
        [RegularExpression(@"^[A-Z]{4}[0-9]{6}[HM][A-Z]{5}[0-9]{2}$", ErrorMessage = "El {0} no tiene el formato")]
        public string curp { get; set; }
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "No es una moneda")]
        [Range(10000, 40000, ErrorMessage = "El sueldo debe estar entre 10,000 y 40,000 pesos")]
        public Nullable<decimal> sueldo { get; set; }
        public int idEstadoOrigen { get; set; }
        public short idEstatus { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFAlumnos
{
    [DataContract]
    public class ItemTablaIsr
    {
        [DataMember]
        public decimal limiteInferior { get; set; }
        [DataMember]
        public decimal limiteSuperior { get; set; }
        [DataMember]
        public decimal cuotaFija { get; set; }
        [DataMember]
        public decimal excedente { get; set; }
        [DataMember]
        public decimal subsidio { get; set; }
        [DataMember]
        public decimal isr { get; set; }
    }
}
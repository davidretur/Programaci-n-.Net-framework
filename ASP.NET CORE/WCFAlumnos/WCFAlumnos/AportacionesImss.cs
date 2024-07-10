using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFAlumnos
{
    [DataContract]
    public class AportacionesImss
    {
        [DataMember]
        public decimal enfermedadMaternidad { get; set; }
        [DataMember]
        public decimal invalidezVida { get; set; }
        [DataMember]
        public decimal retiro { get; set; }
        [DataMember]
        public decimal cesantía { get; set; }
        [DataMember]
        public decimal infonavit { get; set; }

    }
}
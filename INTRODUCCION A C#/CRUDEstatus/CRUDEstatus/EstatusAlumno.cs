using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    public class EstatusAlumno
    {
        public EstatusAlumno()
        {
        }

        public EstatusAlumno(int idEstatus, string clave, string nombreEstatus)
        {
            this.idEstatus = idEstatus;
            this.clave = clave;
            this.nombreEstatus = nombreEstatus;
        }

        public int idEstatus { get; set; }
        public string clave { get; set; }
        public string nombreEstatus { get; set; }
    }
}

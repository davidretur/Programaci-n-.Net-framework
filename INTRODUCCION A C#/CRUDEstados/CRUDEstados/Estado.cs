using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    //puede ser clase o estruc
    public class Estado
    {
        public Estado()
        {
        }

        public Estado(int idEstado, string nombre)
        {
            this.idEstado = idEstado;
            this.nombre = nombre;
        }

        public int idEstado { get; set; }
        public string nombre { get; set; }
    }
}

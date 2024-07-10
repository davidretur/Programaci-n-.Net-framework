using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaWindowsForn.Contex
{
    internal class CrudADO
    {
        List<Estado> _listaEstado = new List<Estado>
        {
            new Estado{idEstado=1,nombre="aguas calientes"},
            new Estado{idEstado=2,nombre="baja california norte"},
            new Estado{idEstado=3,nombre="baja california norte"}
        };
        public List<Estado> ConsultarEstados()
        {
            return _listaEstado;
        }

        public Estado Consultar(int id)
        {
            return _listaEstado.Find(x => x.idEstado == id);
        }
    }
}

using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal interface IDEstado
    {
        List<Estado> ConsultarTodos();
        Estado ConsultarSoloUno(int idEstado);
        bool Agregar(Estado dEstado);
        bool Actualizar(Estado dEstado);

        bool Eliminar(int idAlumno);
    }
}

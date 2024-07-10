using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal interface IDEstatusAlumno
    {
        List<EstatusAlumno> ConsultarTodos();
        EstatusAlumno ConsultarSoloUno(int idEstatus);
        bool Agregar(EstatusAlumno aEstatusAlumno);
        bool Actualizar(EstatusAlumno aEstatusAlumno);

        bool Eliminar(int idEstatus);
    }
}


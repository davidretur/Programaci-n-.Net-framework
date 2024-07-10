using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    interface ICRUDEstatus
    {
        List<EstatusAlumnos> ConsultarTodos();
        EstatusAlumnos ConsultarSoloUno(int idEstatus);
        int Agregar(EstatusAlumnos aEstatusAlumno);
        void Actualizar(EstatusAlumnos aEstatusAlumno);

        void Eliminar(int idEstatus);

    }
}

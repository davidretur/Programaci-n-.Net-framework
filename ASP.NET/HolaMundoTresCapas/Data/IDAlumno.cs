using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data
{
    public interface IDAlumno
    {

    List<Alumno> ConsultarTodos();
    Alumno ConsultarUno(int idAlumno);
    bool Agregar(Alumno alumno);
    bool Actualizar(Alumno alumno);

    bool Eliminar(int idAlumno);

    List<ItemTablaISR> ConsultarTablaISR();
    }

}

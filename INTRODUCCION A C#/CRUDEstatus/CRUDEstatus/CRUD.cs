using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class CRUD
    {

         List<EstatusAlumno> _estatusAlumnoList = new List<EstatusAlumno> ();
        internal List<EstatusAlumno> ConsultarTodos()
        {
            return _estatusAlumnoList;
        }
        internal EstatusAlumno ConsultarSoloUno(int idEstatus)
        {
            EstatusAlumno unoEstatus = _estatusAlumnoList.Find(x=> x.idEstatus == idEstatus);
           /* foreach (var elementoLista in _estatusAlumnoList.Where(x => x.idEstatus == idEstatus))
            {
                unoEstatus = elementoLista;
            }*/

            return unoEstatus;

        }
        internal void Agregar(EstatusAlumno aEstatusAlumno)
        {
            _estatusAlumnoList.Add(aEstatusAlumno);
        }

        internal void Actualizar(EstatusAlumno uEstatusAlumno)
        {
            /*foreach (var elementoLista in _estatusAlumnoList.Where(x => x.idEstatus == uEstatusAlumno.idEstatus))
            {
                elementoLista.nombreEstatus = uEstatusAlumno.nombreEstatus;
                elementoLista.clave = uEstatusAlumno.clave;
            }*/
            EstatusAlumno unoEstatus = _estatusAlumnoList.Find(x => x.idEstatus == uEstatusAlumno.idEstatus);
            unoEstatus.clave = uEstatusAlumno.clave;
            unoEstatus.nombreEstatus  = uEstatusAlumno.nombreEstatus;
        }
        internal void Eliminar(EstatusAlumno uEstatusAlumno)
        {
            /* foreach (var lEstatusAlumno in _estatusAlumnoList.Reverse<EstatusAlumno>())
             {
                 if (lEstatusAlumno.idEstatus == uEstatusAlumno.idEstatus)
                 {  
                     _estatusAlumnoList.Remove(lEstatusAlumno);
                 }
             }
            */
            EstatusAlumno unoEstatus = _estatusAlumnoList.Find(x => x.idEstatus == uEstatusAlumno.idEstatus);
            _estatusAlumnoList.Remove(unoEstatus);
        }
    }
}

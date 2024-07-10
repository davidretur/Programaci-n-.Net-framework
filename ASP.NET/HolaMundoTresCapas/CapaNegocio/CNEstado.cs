using CapaEntidades;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public class CNEstado
    {
        DEstado dEstado = new DEstado();
        public List<Estado> ConsultarTodos()
        {
            try
            {
                return dEstado.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     public Estado ConsultarSoloUno(int idEstado)
        {
            try
            {
                return dEstado.ConsultarSoloUno(idEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*     public bool Agregar(Alumno alumnoAgregar)
          {
              try
              {
                  if (alumnoAgregar.nombre == "")
                      throw new OperationCanceledException("Ingresa un nombre");

                  return _aDOCRUDAlumno.Agregar(alumnoAgregar);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
          public bool Editar(Alumno alumnoEditar)
          {
              try
              {

                  var encontrado = _aDOCRUDAlumno.ConsultarSoloUno(alumnoEditar.id);


                  if (encontrado.id == 0)
                      throw new OperationCanceledException("No existe el alumno");

                  return _aDOCRUDAlumno.Actualizar(alumnoEditar);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
          public bool Eliminar(int idAlumno)
          {
              try
              {
                  var encontrado = _aDOCRUDAlumno.ConsultarSoloUno(idAlumno);
                  if (encontrado.id == 0)
                      throw new OperationCanceledException("No existe el Alumno");

                  return _aDOCRUDAlumno.Eliminar(idAlumno);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
        */
    }
}

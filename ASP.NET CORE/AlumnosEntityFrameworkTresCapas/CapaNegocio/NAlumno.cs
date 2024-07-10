using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CapaNegocio.ServiceReferenceWsfAlumnos;

namespace CapaNegocio
{
    public class NAlumno
    {
        private InstitutoTichEntities _DBContext = new InstitutoTichEntities();
        public List<Alumnos> ConsultarTodos()
        {
            try
            {
                _DBContext.Configuration.LazyLoadingEnabled = true;
                List<Alumnos> lstAlumnos = _DBContext.Alumnos.ToList();
                return lstAlumnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Alumnos ConsultarSoloUno(int idAlumno)
        {
            try
            {

                Alumnos alumno = _DBContext.Alumnos.Find(idAlumno);
                return alumno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Alumnos alumnoAgregar)
        {
            try
            {
                Alumnos alumnos1 = new Alumnos();
                _DBContext.Alumnos.Add(alumnoAgregar);
                _DBContext.SaveChanges();
          //      alumnos1 = _DBContext.Alumnos.Find(alumnos1.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Editar(Alumnos alumnoEditar)
        {
            try
            {
                _DBContext.Entry(alumnoEditar).State = EntityState.Modified;
                _DBContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(Alumnos alumnos)
        {
            try
            {
                _DBContext.Alumnos.Remove(alumnos);
                _DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AportacionesImss CalcularIMSS(int id)
        {

           WCFAlumnosClient cliente = new WCFAlumnosClient();            
            AportacionesImss aportacionesImss = cliente.CalcularImss(id);
                return aportacionesImss;   
        }

        public ItemTablaIsr CalcularISR(int id)
        {
            WCFAlumnosClient cliente = new WCFAlumnosClient();
            ItemTablaIsr isr = cliente.CalcularIsr(id);
                return isr;   
        }
    }
}

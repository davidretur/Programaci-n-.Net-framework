using CapaEntidades;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNEstatusAlumno
    {
        DEstatusAlumno dEstatusAlumno = new DEstatusAlumno();
        public List<EstatusAlumno> ConsultarTodos()
        {
            try
            {
                return dEstatusAlumno.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstatusAlumno ConsultarSoloUno(int idEstatus)
        {
            try
            {
                return dEstatusAlumno.ConsultarSoloUno(idEstatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

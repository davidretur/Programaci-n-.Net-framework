using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NEstatus
    {
        private InstitutoTichEntities _DBContext = new InstitutoTichEntities();
        public List<EstatusAlumnos> ConsultarTodos()
        {
            try
            {
                _DBContext.Configuration.LazyLoadingEnabled = true;
                List<EstatusAlumnos> lstEstatus = _DBContext.EstatusAlumnos.ToList();
                return lstEstatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

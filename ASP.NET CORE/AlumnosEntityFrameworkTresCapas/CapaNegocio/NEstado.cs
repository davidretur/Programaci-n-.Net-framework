using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NEstado
    {
        private InstitutoTichEntities _DBContext = new InstitutoTichEntities();
        public List<Estados> ConsultarTodos()
        {
            try
            {
                _DBContext.Configuration.LazyLoadingEnabled = true;
                List<Estados> lstEstados = _DBContext.Estados.ToList();
                return lstEstados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    internal class CRUD
    {
        private static Dictionary<int, Estado> _diccionarioEstados = new Dictionary<int, Estado>(); 
        internal Dictionary<int, Estado> ConsultarTodos()
        {
            return _diccionarioEstados;
        }
        internal Estado ConsultarSoloUno(int idEstado)
        {
            return _diccionarioEstados[idEstado];
        }
        internal void  Agregar(Estado oEstado)
        {
           _diccionarioEstados.Add(oEstado.idEstado, oEstado);
        }
        internal void Actualizar(Estado oEstado)
        {
            _diccionarioEstados[oEstado.idEstado] = oEstado;
        }
        internal void Eliminar(int idEstado)
        {
            Console.Write(idEstado);
            _diccionarioEstados.Remove(idEstado);
        }

        //metodo presentacion() como internal y invocar desde el menu
    }
}

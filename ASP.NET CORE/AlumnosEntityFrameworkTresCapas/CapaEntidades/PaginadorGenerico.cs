using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    /*https://rafaelacosta.net/Blog/2018/5/26/c%c3%b3mo-desarrollar-un-sistema-de-paginaci%c3%b3n-en-aspnet-mvc?AspxAutoDetectCookieSupport=1*/
    public class PaginadorGenerico<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<T> Resultado { get; set; }
    }
}

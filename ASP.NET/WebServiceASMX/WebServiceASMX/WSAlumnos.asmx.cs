using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaEntidades;
using CapaNegocio;
using Data;

namespace WebServiceASMX
{
    /// <summary>
    /// Descripción breve de WSAlumnos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSAlumnos : System.Web.Services.WebService
    {
        CNAlumno cNAlumno = new CNAlumno();
        [WebMethod]
        public AportacionesIMSS CalcularIMSS(int id) => cNAlumno.CalcularIMSS(id);
        [WebMethod]
        public ItemTablaISR CalcularISR(int id) => cNAlumno.CalcularISR(id);
    }
}

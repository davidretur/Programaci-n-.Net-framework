using ADOEstatusAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOEstatusAlumnoWebForms.forms
{
    public partial class Details : System.Web.UI.Page
    {
        CrudADO _crudADO = new CrudADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EstatusAlumnos> lisesEstatusAlumnos = _crudADO.ConsultarTodos();
            int id = Convert.ToInt16( Request.QueryString["id"]);

            EstatusAlumnos estatus = lisesEstatusAlumnos.Find(x => x.id == id);
            lbliddef.Text = estatus.id.ToString();
            lblclavedef.Text = estatus.clave.ToString();    
            lblnombredef.Text = estatus.nombre.ToString();
           // Response.Redirect($"Index.aspx");

        }
        
    }
}
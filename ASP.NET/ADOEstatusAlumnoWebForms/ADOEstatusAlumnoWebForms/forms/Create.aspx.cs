using ADOEstatusAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOEstatusAlumnoWebForms.forms
{
    public partial class Create : System.Web.UI.Page
    {
        CrudADO crudADO = new CrudADO();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ButtonGuardar_Click1(object sender, EventArgs e)
        {
            EstatusAlumnos agregareStatus = new EstatusAlumnos();  
            agregareStatus.clave = TextBoxClave.Text;
            agregareStatus.nombre = TextBoxNombre.Text;
            int idInsertado = crudADO.Agregar(agregareStatus);
            LabelResultado.Text = $"Se agregó el estatus Alumno";
            TextBoxClave.Text = "";
            TextBoxNombre.Text = "";
        }
    }
}
using ADOEstatusAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOEstatusAlumnoWebForms.forms
{
    public partial class Edit : System.Web.UI.Page
    {
        CrudADO crudADO = new CrudADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxId.Enabled = false;
                List<EstatusAlumnos> lisesEstatusAlumnos = crudADO.ConsultarTodos();
                int id = Convert.ToInt16(Request.QueryString["id"]);
                EstatusAlumnos estatus = lisesEstatusAlumnos.Find(x => x.id == id);
                TextBoxId.Text = estatus.id.ToString();
                TextBoxClave.Text = estatus.clave.ToString();
                TextBoxNombre.Text = estatus.nombre.ToString();
            }
        }

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
            EstatusAlumnos Actualizarestatus = new EstatusAlumnos();
            Actualizarestatus.id = Convert.ToInt16(TextBoxId.Text);
            Actualizarestatus.clave = TextBoxClave.Text;
            Actualizarestatus.nombre = TextBoxNombre.Text;
            crudADO.Actualizar(Actualizarestatus);

          Response.Redirect($"Index.aspx");
        }
    }
}
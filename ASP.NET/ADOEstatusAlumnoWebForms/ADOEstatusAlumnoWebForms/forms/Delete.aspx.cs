using ADOEstatusAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOEstatusAlumnoWebForms.forms
{
    public partial class Delete : System.Web.UI.Page
    {
        CrudADO crudADO = new CrudADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                TextBoxId.Enabled = false;
                List<EstatusAlumnos> lisesEstatusAlumnos = crudADO.ConsultarTodos();
                int id = Convert.ToInt16( Request.QueryString["id"]);
                EstatusAlumnos estatus = lisesEstatusAlumnos.Find(x => x.id == id);
                TextBoxId.Text = estatus.id.ToString();
            }
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt16(TextBoxId.Text);
            crudADO.Eliminar(idEliminar);
            Response.Redirect($"Index.aspx");
        }
    }
}
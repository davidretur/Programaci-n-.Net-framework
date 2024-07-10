using ADOEstatusAlumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOEstatusAlumnoWebForms.forms
{
    public partial class Index : System.Web.UI.Page
    {
        CrudADO _crudADO = new CrudADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<EstatusAlumnos> lisesEstatusAlumnos = _crudADO.ConsultarTodos();
                ddlEstatusAlumnos.DataSource = lisesEstatusAlumnos;
                ddlEstatusAlumnos.DataTextField = "nombre";
                ddlEstatusAlumnos.DataValueField = "id";
                ddlEstatusAlumnos.DataBind();
                dgvEstatusAlumnos.DataSource = lisesEstatusAlumnos;
                dgvEstatusAlumnos.DataBind();
            }
        }

        protected void ButtonDetalles_Click(object sender, EventArgs e)
        {
            string id = ddlEstatusAlumnos.SelectedValue;
            Response.Redirect($"Details.aspx?id={id}");
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx");
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            string id = ddlEstatusAlumnos.SelectedValue;
            Response.Redirect($"Edit.aspx?id={id}");
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            string id = ddlEstatusAlumnos.SelectedValue;
            Response.Redirect($"Delete.aspx?id={id}");
        }
    }
}
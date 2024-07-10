using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaNegocio;

namespace Presentacion.form
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CNAlumno _cNAlumno = new CNAlumno();
        CNEstado _cNEstado = new CNEstado();
        CNEstatusAlumno _nEstatusAlumno = new CNEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarAlumnos();
            }
        }

        protected void GVAlumno_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            GVAlumno.PageIndex = e.NewPageIndex;
            MostrarAlumnos();
        }
        private void MostrarAlumnos()
        {
            List<Alumno> listAlumnos = _cNAlumno.ConsultarTodos();
            List<Estado> listEstado = _cNEstado.ConsultarTodos();
            List<EstatusAlumno> listEstatus = _nEstatusAlumno.ConsultarTodos();

            List<Alumno> listAlumnoEstado = null;

            //consulta
           var listaNombreES = (from alumno in listAlumnos
                             join estado in listEstado on alumno.estado equals estado.id
                             join estatus in listEstatus on alumno.estatus equals estatus.id
                             select new
                             {
                                 id = alumno.id,
                                 nombre = alumno.nombre,
                                 primerApellido = alumno.primerApellido,
                                 segundoApellido = alumno.segundoApellido,
                                 fechaNacimiento = alumno.fechaNacimiento,
                                 correo = alumno.correo,
                                 telefono = alumno.telefono,
                                 curp = alumno.curp,
                                 sueldo = alumno.sueldo,
                                 estado = estado.nombre,
                                 estatus = estatus.nombre
                             }).ToList();

            GVAlumno.DataSource = listaNombreES;
            GVAlumno.DataBind();


        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx?idEmpleado=0");
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idPersona = btn.CommandArgument;

            Response.Redirect($"/Personas/Details.aspx?id={idPersona}");
        }
        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idAlumno = btn.CommandArgument;

            Response.Redirect($"/Alumnos/Edit.aspx?id={idAlumno}");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
           LinkButton btn = (LinkButton)sender;
            string idAlumno = btn.CommandArgument;
            Response.Redirect($"/Alumnos/Delete.aspx?id={idAlumno}");
        }
    }
}
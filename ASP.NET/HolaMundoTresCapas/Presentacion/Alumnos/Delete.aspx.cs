using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Delete : System.Web.UI.Page
    {
        CNAlumno _cNAlumno = new CNAlumno();
        int idEliminar=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int idAlumno = Convert.ToInt16(Request.QueryString["id"]);
            idEliminar = idAlumno;
            if (!IsPostBack)
            {
                Alumno alumno = _cNAlumno.ConsultarSoloUno(idAlumno);
                DateTime fechaNa = alumno.fechaNacimiento;
                string fechaNacimiento = fechaNa.ToString("yyyy-MM-dd");
                lblid.Text = Convert.ToString(alumno.id);
                lblnombre.Text = alumno.nombre;
                lblprimerApellido.Text = alumno.primerApellido;
                lblsegundoApellido.Text = alumno.segundoApellido;
                lblFechaNacimiento.Text = fechaNacimiento;
                lblcurp.Text = alumno.curp;
                lblcorreo.Text = alumno.correo;
                lbltelefono.Text = alumno.telefono;
                lblsueldo.Text = Convert.ToString(alumno.sueldo);
                lblEstado.Text = Convert.ToString(alumno.estado);
                lblEstatus.Text = Convert.ToString(alumno.estatus);
            }
         }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idEliminar > 0)
            {
                bool siElimino = _cNAlumno.Eliminar(idEliminar);
                Response.Redirect($"Index.aspx");
            }


        }
    }
}
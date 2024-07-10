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
    public partial class Edit : System.Web.UI.Page
    {
        CNAlumno _cNAlumno = new CNAlumno();
        CNEstado _cNEstado = new CNEstado();
        CNEstatusAlumno _nEstatusAlumno = new CNEstatusAlumno();
        bool _valid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextId.Visible = false;
                int idAlumno = Convert.ToInt16(Request.QueryString["id"]);
                Alumno alumnos = _cNAlumno.ConsultarSoloUno(idAlumno);
                CargarEstados();
                CargarEstatus();
                DateTime fechaNa = alumnos.fechaNacimiento;
                string fechaNacimiento = fechaNa.ToString("yyyy-MM-dd");
                decimal sueldo = Convert.ToDecimal(alumnos.sueldo);
                TextId.Text = Convert.ToString(alumnos.id);
                textnombre.Text = alumnos.nombre;
                textnombre.Text = alumnos.nombre;
                textprimerApellido.Text = alumnos.primerApellido;
                textsegundoApellido.Text = alumnos.segundoApellido;
                textfechaNacimiento.Text = fechaNacimiento;
                textcurp.Text = alumnos.curp;
                textCorreo.Text = alumnos.correo;
                textTelefono.Text = alumnos.telefono;
                textSueldo.Text = sueldo.ToString("0.##");
                ddlEstado.Text = Convert.ToString(alumnos.estado);
                ddlEstatus.Text = Convert.ToString(alumnos.estatus);
            }
        }

        protected void cvFechaNacimiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
           /* var fechanacimiento = textfechaNacimiento.Text;
            var curpVsFecha = args.Value.Substring(4, 6);
            var fechaFormCurp = fechanacimiento.Substring(2, 2) + fechanacimiento.Substring(5, 2) + fechanacimiento.Substring(8, 2);
            args.IsValid = curpVsFecha == fechaFormCurp;*/

            string curp = textcurp.Text.ToUpper();
            DateTime fechaNacimiento;

            if (DateTime.TryParse(textfechaNacimiento.Text, out fechaNacimiento))
            {
                string fechaCurp = curp.Substring(4, 6);
                int añoCurp = int.Parse(fechaCurp.Substring(0, 2)) + 1900;
                int mesCurp = int.Parse(fechaCurp.Substring(2, 2));
                int díaCurp = int.Parse(fechaCurp.Substring(4, 2));

                DateTime fechaCurpCompleta = new DateTime(añoCurp, mesCurp, díaCurp);
                _valid = (fechaNacimiento.Date == fechaCurpCompleta.Date);
                args.IsValid = (fechaNacimiento.Date == fechaCurpCompleta.Date);
                cvFechaNacimiento.ErrorMessage = "";
            }
            else
            {
                _valid = false;
                args.IsValid = false;
            }
        }
        private void CargarEstados(string idEstado = "")
        {
            List<Estado> listaEstado = _cNEstado.ConsultarTodos();

            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "id";
            ddlEstado.DataSource = listaEstado;
            ddlEstado.DataBind();

            if (idEstado != "")
                ddlEstado.SelectedValue = idEstado;
        }
        private void CargarEstatus(string idEstatus = "")
        {
            List<EstatusAlumno> listaEstatus = _nEstatusAlumno.ConsultarTodos();
            ddlEstatus.DataTextField = "nombre";
            ddlEstatus.DataValueField = "id";
            ddlEstatus.DataSource = listaEstatus;
            ddlEstatus.DataBind();

            if (idEstatus != "")
                ddlEstado.SelectedValue = idEstatus;

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Alumno eAlumno = new Alumno();

                eAlumno.id = Convert.ToInt16(TextId.Text);
                eAlumno.nombre = textnombre.Text;
                eAlumno.primerApellido = textprimerApellido.Text;
                eAlumno.segundoApellido = textsegundoApellido.Text;
                eAlumno.correo = textCorreo.Text;
                eAlumno.telefono = textTelefono.Text;
                eAlumno.fechaNacimiento = DateTime.ParseExact(textfechaNacimiento.Text, "yyyy-MM-dd", null);
                eAlumno.curp = textcurp.Text;
                eAlumno.sueldo = Convert.ToDecimal(textSueldo.Text);
                eAlumno.estado = Convert.ToInt32(ddlEstado.Text);
                eAlumno.estatus = Convert.ToInt32(ddlEstatus.Text);

                bool idInsertado = _cNAlumno.Editar(eAlumno);
                Response.Redirect($"Index.aspx");
            }
            else
            {
                cvFechaNacimiento.ErrorMessage = "La fecha de nacimiento tiene que coincidir con la fecha en el CURP";
            }
        }
     }
}
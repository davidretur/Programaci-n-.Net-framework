
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
    public partial class Create : System.Web.UI.Page
    {
        CNAlumno _cNAlumno = new CNAlumno();
        CNEstado _cNEstado = new CNEstado();
        CNEstatusAlumno _nEstatusAlumno = new CNEstatusAlumno();
        bool _valid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstados();
                CargarEstatus();

            }
        }
        protected void cvFechaNacimiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_valid == true)
            {
 
                Alumno alumno = new Alumno()
                {
                    nombre = textnombre.Text.ToString(),
                    primerApellido = textprimerApellido.Text.ToString(),
                    segundoApellido = textsegundoApellido.Text.ToString(),
                    correo = textCorreo.Text.ToString(),
                    telefono = textTelefono.Text.ToString(),
                    fechaNacimiento = DateTime.ParseExact(textfechaNacimiento.Text, "yyyy-MM-dd", null),
                    curp = textcurp.Text.ToString(),
                    sueldo = Convert.ToDecimal(textSueldo.Text),
                    estado = Convert.ToInt32(ddlEstado.Text),
                    estatus = Convert.ToInt32(ddlEstatus.Text),
                };
                
                bool idInsertado = _cNAlumno.Agregar(alumno);
                Response.Redirect($"Index.aspx");
            }
            else
            {
                cvFechaNacimiento.ErrorMessage = "La fecha de nacimiento tiene que coincidir con la fecha en el CURP";
            }
               
        }
    }
}
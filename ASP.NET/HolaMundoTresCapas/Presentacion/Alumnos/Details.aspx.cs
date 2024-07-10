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
    public partial class Details : System.Web.UI.Page
    {
        CNAlumno _cNAlumno = new CNAlumno();
        CNEstado _cNEstado = new CNEstado();
        CNEstatusAlumno _nEstatusAlumno = new CNEstatusAlumno();
        private int _idAlumnoS;
        protected void Page_Load(object sender, EventArgs e)
        {
            int idAlumno = Convert.ToInt16(Request.QueryString["id"]);
            _idAlumnoS = idAlumno;
            if (!IsPostBack)
            {
                Alumno alumnos = _cNAlumno.ConsultarSoloUno(idAlumno);
               
                DateTime fechaNa = alumnos.fechaNacimiento;
                string fechaNacimiento = fechaNa.ToString("yyyy-MM-dd");
                lblid.Text = Convert.ToString(alumnos.id);
                lblnombre.Text = alumnos.nombre;
                lblprimerApellido.Text = alumnos.primerApellido;
                lblsegundoApellido.Text = alumnos.segundoApellido;
                lblFechaNacimiento.Text = fechaNacimiento;
                lblcurp.Text = alumnos.curp;
                lblcorreo.Text = alumnos.correo;
                lbltelefono.Text = alumnos.telefono;
                lblsueldo.Text = Convert.ToString(alumnos.sueldo);
                CargarEstado(alumnos.estado);
                CargarEstatu(alumnos.estatus);
            }
        }

        private void CargarEstado(int idEstado)
        {
            Estado Estado = _cNEstado.ConsultarSoloUno(idEstado);

            lblEstado.Text = Estado.nombre.ToString();

        }
        private void CargarEstatu(int idEstatus)
        {
            EstatusAlumno listaEstatus = _nEstatusAlumno.ConsultarSoloUno(idEstatus);
            lblEstatus.Text = listaEstatus.nombre.ToString();   

        }
        protected void ConsultarISR_Click(object sender, EventArgs e)
        {
            ItemTablaISR itemTablaISR = _cNAlumno.CalcularISR(_idAlumnoS);
            lbllímiteinferior.Text = itemTablaISR.limiteInferior.ToString("C");
            lbllímitesuperior.Text = itemTablaISR.limiteSuperior.ToString("C");
            lblcuotaFija.Text = itemTablaISR.cuotaFija.ToString("C");
            lblexcedente.Text = itemTablaISR.excedente.ToString("C");
            lblsubsidio.Text = itemTablaISR.subsidio.ToString("C");
            lblisr.Text = itemTablaISR.isr.ToString("C");

            string script = @"<script type='text/javascript'>
                        $(function () {
                            $('#ModalISR').modal('show');
                        });
                    </script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Muestra mosal", script,false);
        }
        protected void ConsultarIMMS_Click(object sender, EventArgs e)
        {
            AportacionesIMSS aportacionesIMSS = _cNAlumno.CalcularIMSS(_idAlumnoS);
            lblEnfermedadMaternidad.Text = aportacionesIMSS.enfermedadMaternidad.ToString("C");
            lblInvalidezVida.Text = aportacionesIMSS.invalidezVida.ToString("C");
            lblRetiro.Text = aportacionesIMSS.retiro.ToString("C");
            lblCesantía.Text = aportacionesIMSS.cesantía.ToString("C");
            lblInfonavit.Text = aportacionesIMSS.infonavit.ToString("C");
        }

    }
}
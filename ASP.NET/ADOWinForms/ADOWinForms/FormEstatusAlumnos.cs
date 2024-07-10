using ADOEstatusAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinForms
{

    public partial class FormEstatusAlumnos : Form
    {
        CrudADO _crudADO = new CrudADO();
        bool estaAgregando = false;
        bool estaActualizando = false;
        bool estaEliminando = false;
        public FormEstatusAlumnos()
        {
            InitializeComponent();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            List<EstatusAlumnos> listaEstatusAlumnos = _crudADO.ConsultarTodos();
            comboNombreEstado.DataSource = listaEstatusAlumnos;
            comboNombreEstado.DisplayMember = "Nombre";
            comboNombreEstado.ValueMember = "id";

            dGVEstatusAlumnos.DataSource = listaEstatusAlumnos;
        }




        private void checkBoxGuardar_CheckedChanged(object sender, EventArgs e)
        {
            comboNombreEstado.Enabled = false;
            estaAgregando = true;
            panelDetalles.Visible = checkBoxGuardar.Checked ? true : false;
            panelDetalles.Enabled = true;
            checkBoxGuardar.Enabled = false;
            checkBoxActualizar.Enabled = false;
            checkBoxEliminar.Enabled = false;
            txtClave.Text = "";
            txtNombre.Text = "";
            labelResultado.Text = $"";
            BtnGuardar.Text = "Guardar";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelDetalles.Visible = false;
            panelDetalles.Enabled = false; // Deshabilita el panel
            checkBoxGuardar.Checked = false;
            checkBoxActualizar.Checked = false;
            checkBoxEliminar.Checked = false;
            checkBoxGuardar.Enabled = true;
            checkBoxActualizar.Enabled = true;
            checkBoxEliminar.Enabled = true;
            txtClave.Enabled = true;
            txtNombre.Enabled = true;
            estaAgregando = false;
            estaActualizando = false;
            estaEliminando = false;
            comboNombreEstado.Enabled = true;

        }
        private void actualizarTabla()
        {
            List<EstatusAlumnos> listaEstatusAlumnos = _crudADO.ConsultarTodos();
            comboNombreEstado.DataSource = listaEstatusAlumnos;
            comboNombreEstado.DisplayMember = "nombre";
            comboNombreEstado.ValueMember = "id";
            dGVEstatusAlumnos.DataSource = listaEstatusAlumnos;
            txtClave.Enabled = true;
            txtNombre.Enabled = true;
            checkBoxGuardar.Enabled = true;
            checkBoxActualizar.Enabled = true;
            checkBoxEliminar.Enabled = true;
            comboNombreEstado.Enabled = true;
        }
        private void buttonActualizar_Click(object sender, EventArgs e)
        {

        }

        private void checkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            estaEliminando = true;
            panelDetalles.Visible = checkBoxEliminar.Checked ? true : false;
            panelDetalles.Enabled = true;
            checkBoxGuardar.Enabled = true;
            checkBoxActualizar.Enabled = true;
            checkBoxEliminar.Enabled = true;
            comboNombreEstado.Enabled = false;
            int id = Convert.ToInt32(comboNombreEstado.SelectedValue);
            EstatusAlumnos estadoAlumno = _crudADO.ConsultarSoloUno(id);
            txtId.Text = estadoAlumno.id.ToString();
            txtClave.Text = estadoAlumno.clave.ToString();
            txtNombre.Text = estadoAlumno.nombre.ToString();
            txtClave.Enabled = false;
            txtNombre.Enabled = false;
            BtnGuardar.Text = "Eliminar";
        }

        private void comboNombreEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxEliminar.Checked = false;
            panelDetalles.Enabled = true;

        }

        private void checkActualizar_CheckedChanged(object sender, EventArgs e)
        {
            estaActualizando = true;
            panelDetalles.Visible = checkBoxActualizar.Checked ? true : false;
            panelDetalles.Enabled = true;
            checkBoxGuardar.Enabled = false;
            checkBoxActualizar.Enabled = false;
            checkBoxEliminar.Enabled = false;
            comboNombreEstado.Enabled = false;
            int id = Convert.ToInt32(comboNombreEstado.SelectedValue);
            EstatusAlumnos estadoAlumno = _crudADO.ConsultarSoloUno(id);
            txtId.Text = estadoAlumno.id.ToString();
            txtClave.Text = estadoAlumno.clave.ToString();
            txtNombre.Text = estadoAlumno.nombre.ToString();
            BtnGuardar.Text = "Actualizar";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (estaAgregando == true)
            {
                EstatusAlumnos AgregareStatus = new EstatusAlumnos();
                AgregareStatus.clave = txtClave.Text;
                AgregareStatus.nombre = txtNombre.Text;
                int idInsertado = _crudADO.Agregar(AgregareStatus);
                labelResultado.Text = $"Se agregó id: {idInsertado}";
                if (idInsertado > 0)
                {
                    txtClave.Text = "";
                    txtNombre.Text = "";
                    panelDetalles.Enabled = false; // Deshabilita el panel
                    checkBoxGuardar.Checked = false;
                    actualizarTabla();
                }
                estaAgregando = !estaAgregando;
            }
             if (estaActualizando == true)
            {
                BtnGuardar.Text = "Actualizar";
                EstatusAlumnos actualizarStatus = new EstatusAlumnos();
                actualizarStatus.clave = txtClave.Text;
                actualizarStatus.nombre = txtNombre.Text;
                actualizarStatus.id = Convert.ToInt16(txtId.Text);
                _crudADO.Actualizar(actualizarStatus);
                txtClave.Text = "";
                txtNombre.Text = "";
                panelDetalles.Enabled = false; // Deshabilita el panel
                checkBoxActualizar.Checked = false;
                estaActualizando = !estaActualizando;
                actualizarTabla();
            }
            if (estaEliminando == true)
            {
                CrudADO crudADO = new CrudADO();
                int idEliminar = Convert.ToInt16(txtId.Text);
                crudADO.Eliminar(idEliminar);
                panelDetalles.Enabled = false; // Deshabilita el panel
                estaEliminando = !estaEliminando;
                actualizarTabla();
            }

        }
    }
}

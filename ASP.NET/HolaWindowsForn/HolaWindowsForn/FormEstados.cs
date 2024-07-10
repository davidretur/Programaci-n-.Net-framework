using HolaWindowsForn.Contex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolaWindowsForn
{
    public partial class FormEstados : Form
    {
        CrudADO _crudADO = new CrudADO();
        public FormEstados()
        {
            InitializeComponent();
        }

        private void btn_Cnsultar_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormEstados_Load(object sender, EventArgs e)
        {
            //todos los elementos se agregan aqui
            
            List<Estado> lisestados = _crudADO.ConsultarEstados();
            comboEstados.DataSource = lisestados;
            comboEstados.DisplayMember = "Name";
            comboEstados.ValueMember = "idEstado";

            dgvEstados.DataSource = lisestados;

        }

        private void btn_Cnsultar_MouseClick(object sender, MouseEventArgs e)
        {
            int id = Convert.ToInt32(comboEstados.SelectedValue);
            Estado estado = _crudADO.Consultar(id);

            txtId.Text = estado.idEstado.ToString();
            txtNombre.Text = estado.nombre;
        }

        private void cbDetalles_CheckedChanged(object sender, EventArgs e)
        {
           panelDetalles.Visible = cbDetalles.Checked ? true : false;
        }
    }
}

namespace ADOWinForms
{
    partial class FormEstatusAlumnos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboNombreEstado = new System.Windows.Forms.ComboBox();
            this.dGVEstatusAlumnos = new System.Windows.Forms.DataGridView();
            this.panelDetalles = new System.Windows.Forms.Panel();
            this.labelResultado = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.checkBoxGuardar = new System.Windows.Forms.CheckBox();
            this.checkBoxActualizar = new System.Windows.Forms.CheckBox();
            this.checkBoxEliminar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEstatusAlumnos)).BeginInit();
            this.panelDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboNombreEstado
            // 
            this.comboNombreEstado.FormattingEnabled = true;
            this.comboNombreEstado.Location = new System.Drawing.Point(44, 26);
            this.comboNombreEstado.Name = "comboNombreEstado";
            this.comboNombreEstado.Size = new System.Drawing.Size(163, 21);
            this.comboNombreEstado.TabIndex = 0;
            this.comboNombreEstado.SelectedIndexChanged += new System.EventHandler(this.comboNombreEstado_SelectedIndexChanged);
            // 
            // dGVEstatusAlumnos
            // 
            this.dGVEstatusAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVEstatusAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEstatusAlumnos.Location = new System.Drawing.Point(44, 68);
            this.dGVEstatusAlumnos.Name = "dGVEstatusAlumnos";
            this.dGVEstatusAlumnos.Size = new System.Drawing.Size(663, 150);
            this.dGVEstatusAlumnos.TabIndex = 2;
            // 
            // panelDetalles
            // 
            this.panelDetalles.Controls.Add(this.labelResultado);
            this.panelDetalles.Controls.Add(this.btnCancelar);
            this.panelDetalles.Controls.Add(this.BtnGuardar);
            this.panelDetalles.Controls.Add(this.txtNombre);
            this.panelDetalles.Controls.Add(this.lblNombre);
            this.panelDetalles.Controls.Add(this.txtClave);
            this.panelDetalles.Controls.Add(this.lblClave);
            this.panelDetalles.Controls.Add(this.txtId);
            this.panelDetalles.Controls.Add(this.lblId);
            this.panelDetalles.Location = new System.Drawing.Point(44, 249);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.Size = new System.Drawing.Size(663, 150);
            this.panelDetalles.TabIndex = 3;
            this.panelDetalles.Visible = false;
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(292, 42);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(55, 13);
            this.labelResultado.TabIndex = 10;
            this.labelResultado.Text = "Resultado";
            this.labelResultado.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(200, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(77, 110);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 8;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(77, 74);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(27, 77);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(77, 39);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(100, 20);
            this.txtClave.TabIndex = 5;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(27, 42);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 4;
            this.lblClave.Text = "Clave";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(77, 10);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 3;
            this.txtId.Visible = false;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(27, 17);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(15, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "id";
            this.lblId.Visible = false;
            this.lblId.Click += new System.EventHandler(this.lblId_Click);
            // 
            // checkBoxGuardar
            // 
            this.checkBoxGuardar.AutoSize = true;
            this.checkBoxGuardar.Location = new System.Drawing.Point(386, 28);
            this.checkBoxGuardar.Name = "checkBoxGuardar";
            this.checkBoxGuardar.Size = new System.Drawing.Size(63, 17);
            this.checkBoxGuardar.TabIndex = 4;
            this.checkBoxGuardar.Text = "Agregar";
            this.checkBoxGuardar.UseVisualStyleBackColor = true;
            this.checkBoxGuardar.CheckedChanged += new System.EventHandler(this.checkBoxGuardar_CheckedChanged);
            // 
            // checkBoxActualizar
            // 
            this.checkBoxActualizar.AutoSize = true;
            this.checkBoxActualizar.Location = new System.Drawing.Point(471, 28);
            this.checkBoxActualizar.Name = "checkBoxActualizar";
            this.checkBoxActualizar.Size = new System.Drawing.Size(72, 17);
            this.checkBoxActualizar.TabIndex = 4;
            this.checkBoxActualizar.Text = "Actualizar";
            this.checkBoxActualizar.UseVisualStyleBackColor = true;
            this.checkBoxActualizar.CheckedChanged += new System.EventHandler(this.checkActualizar_CheckedChanged);
            // 
            // checkBoxEliminar
            // 
            this.checkBoxEliminar.AutoSize = true;
            this.checkBoxEliminar.Location = new System.Drawing.Point(588, 28);
            this.checkBoxEliminar.Name = "checkBoxEliminar";
            this.checkBoxEliminar.Size = new System.Drawing.Size(62, 17);
            this.checkBoxEliminar.TabIndex = 4;
            this.checkBoxEliminar.Text = "Eliminar";
            this.checkBoxEliminar.UseVisualStyleBackColor = true;
            this.checkBoxEliminar.CheckedChanged += new System.EventHandler(this.checkEliminar_CheckedChanged);
            // 
            // FormEstatusAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxEliminar);
            this.Controls.Add(this.checkBoxActualizar);
            this.Controls.Add(this.checkBoxGuardar);
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.dGVEstatusAlumnos);
            this.Controls.Add(this.comboNombreEstado);
            this.Name = "FormEstatusAlumnos";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVEstatusAlumnos)).EndInit();
            this.panelDetalles.ResumeLayout(false);
            this.panelDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboNombreEstado;
        private System.Windows.Forms.DataGridView dGVEstatusAlumnos;
        private System.Windows.Forms.Panel panelDetalles;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.CheckBox checkBoxGuardar;
        private System.Windows.Forms.CheckBox checkBoxActualizar;
        private System.Windows.Forms.CheckBox checkBoxEliminar;
        private System.Windows.Forms.Label labelResultado;
    }
}


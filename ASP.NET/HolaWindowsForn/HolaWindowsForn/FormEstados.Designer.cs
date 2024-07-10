namespace HolaWindowsForn
{
    partial class FormEstados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboEstados = new System.Windows.Forms.ComboBox();
            this.dgvEstados = new System.Windows.Forms.DataGridView();
            this.btn_Cnsultar = new System.Windows.Forms.Button();
            this.panelDetalles = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.cbDetalles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstados)).BeginInit();
            this.panelDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estados";
            // 
            // comboEstados
            // 
            this.comboEstados.FormattingEnabled = true;
            this.comboEstados.Location = new System.Drawing.Point(112, 32);
            this.comboEstados.Name = "comboEstados";
            this.comboEstados.Size = new System.Drawing.Size(255, 21);
            this.comboEstados.TabIndex = 1;
            // 
            // dgvEstados
            // 
            this.dgvEstados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstados.Location = new System.Drawing.Point(39, 89);
            this.dgvEstados.Name = "dgvEstados";
            this.dgvEstados.Size = new System.Drawing.Size(668, 141);
            this.dgvEstados.TabIndex = 2;
            // 
            // btn_Cnsultar
            // 
            this.btn_Cnsultar.Location = new System.Drawing.Point(337, 236);
            this.btn_Cnsultar.Name = "btn_Cnsultar";
            this.btn_Cnsultar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cnsultar.TabIndex = 3;
            this.btn_Cnsultar.Text = "Consultar";
            this.btn_Cnsultar.UseVisualStyleBackColor = true;
            this.btn_Cnsultar.Click += new System.EventHandler(this.btn_Cnsultar_Click);
            this.btn_Cnsultar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_Cnsultar_MouseClick);
            // 
            // panelDetalles
            // 
            this.panelDetalles.Controls.Add(this.txtNombre);
            this.panelDetalles.Controls.Add(this.txtId);
            this.panelDetalles.Controls.Add(this.lblNombre);
            this.panelDetalles.Controls.Add(this.lblId);
            this.panelDetalles.Location = new System.Drawing.Point(39, 277);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.Size = new System.Drawing.Size(668, 100);
            this.panelDetalles.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(64, 39);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(35, 10);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 1;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(14, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Click += new System.EventHandler(this.lblId_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(14, 13);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(15, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "id";
            this.lblId.Click += new System.EventHandler(this.lblId_Click);
            // 
            // cbDetalles
            // 
            this.cbDetalles.AutoSize = true;
            this.cbDetalles.Location = new System.Drawing.Point(563, 38);
            this.cbDetalles.Name = "cbDetalles";
            this.cbDetalles.Size = new System.Drawing.Size(61, 17);
            this.cbDetalles.TabIndex = 5;
            this.cbDetalles.Text = "Mostrar";
            this.cbDetalles.UseVisualStyleBackColor = true;
            this.cbDetalles.CheckedChanged += new System.EventHandler(this.cbDetalles_CheckedChanged);
            // 
            // FormEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbDetalles);
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.btn_Cnsultar);
            this.Controls.Add(this.dgvEstados);
            this.Controls.Add(this.comboEstados);
            this.Controls.Add(this.label1);
            this.Name = "FormEstados";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormEstados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstados)).EndInit();
            this.panelDetalles.ResumeLayout(false);
            this.panelDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboEstados;
        private System.Windows.Forms.DataGridView dgvEstados;
        private System.Windows.Forms.Button btn_Cnsultar;
        private System.Windows.Forms.Panel panelDetalles;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.CheckBox cbDetalles;
    }
}
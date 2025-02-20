namespace Cronos360.CP
{
    partial class frmCargaHoras
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
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvProyectos = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cmbProyectos = new System.Windows.Forms.ComboBox();
            this.lblProyectos = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dptFecha2 = new System.Windows.Forms.DateTimePicker();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblFinicio = new System.Windows.Forms.Label();
            this.lblFfin = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dtpFechaCarga = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCarga = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.fLPanelBtn = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.fLPanelBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // numHoras
            // 
            this.numHoras.Location = new System.Drawing.Point(200, 48);
            this.numHoras.Name = "numHoras";
            this.numHoras.Size = new System.Drawing.Size(76, 20);
            this.numHoras.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(682, 48);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // dgvProyectos
            // 
            this.dgvProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProyectos.Location = new System.Drawing.Point(0, 162);
            this.dgvProyectos.Name = "dgvProyectos";
            this.dgvProyectos.Size = new System.Drawing.Size(1284, 627);
            this.dgvProyectos.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(237, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 45);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cmbProyectos
            // 
            this.cmbProyectos.FormattingEnabled = true;
            this.cmbProyectos.Location = new System.Drawing.Point(200, 98);
            this.cmbProyectos.Name = "cmbProyectos";
            this.cmbProyectos.Size = new System.Drawing.Size(216, 21);
            this.cmbProyectos.TabIndex = 8;
            this.cmbProyectos.SelectedIndexChanged += new System.EventHandler(this.cmbProyectos_SelectedIndexChanged);
            // 
            // lblProyectos
            // 
            this.lblProyectos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyectos.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProyectos.Location = new System.Drawing.Point(41, 94);
            this.lblProyectos.Name = "lblProyectos";
            this.lblProyectos.Size = new System.Drawing.Size(153, 25);
            this.lblProyectos.TabIndex = 10;
            this.lblProyectos.Text = "Seleccione un proyecto:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(111, 45);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // dptFecha2
            // 
            this.dptFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptFecha2.Location = new System.Drawing.Point(682, 110);
            this.dptFecha2.Name = "dptFecha2";
            this.dptFecha2.Size = new System.Drawing.Size(110, 20);
            this.dptFecha2.TabIndex = 12;
            // 
            // lblHoras
            // 
            this.lblHoras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHoras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHoras.Location = new System.Drawing.Point(41, 45);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(124, 23);
            this.lblHoras.TabIndex = 13;
            this.lblHoras.Text = "Ingrese las horas:";
            // 
            // lblFinicio
            // 
            this.lblFinicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinicio.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFinicio.Location = new System.Drawing.Point(682, 9);
            this.lblFinicio.Name = "lblFinicio";
            this.lblFinicio.Size = new System.Drawing.Size(128, 23);
            this.lblFinicio.TabIndex = 14;
            this.lblFinicio.Text = "Inicio del Proyecto:";
            // 
            // lblFfin
            // 
            this.lblFfin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFfin.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFfin.Location = new System.Drawing.Point(682, 84);
            this.lblFfin.Name = "lblFfin";
            this.lblFfin.Size = new System.Drawing.Size(128, 23);
            this.lblFfin.TabIndex = 15;
            this.lblFfin.Text = "Fin del Proyecto:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(120, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(111, 45);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(453, 98);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 17;
            this.txtDescripcion.Visible = false;
            // 
            // dtpFechaCarga
            // 
            this.dtpFechaCarga.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCarga.Location = new System.Drawing.Point(506, 47);
            this.dtpFechaCarga.Name = "dtpFechaCarga";
            this.dtpFechaCarga.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaCarga.TabIndex = 18;
            // 
            // lblFechaCarga
            // 
            this.lblFechaCarga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCarga.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFechaCarga.Location = new System.Drawing.Point(396, 45);
            this.lblFechaCarga.Name = "lblFechaCarga";
            this.lblFechaCarga.Size = new System.Drawing.Size(104, 23);
            this.lblFechaCarga.TabIndex = 19;
            this.lblFechaCarga.Text = "Fecha de carga:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(559, 98);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 20;
            this.txtEstado.Visible = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelMenu.Controls.Add(this.fLPanelBtn);
            this.panelMenu.Controls.Add(this.txtEstado);
            this.panelMenu.Controls.Add(this.numHoras);
            this.panelMenu.Controls.Add(this.lblFechaCarga);
            this.panelMenu.Controls.Add(this.dtpFecha);
            this.panelMenu.Controls.Add(this.dtpFechaCarga);
            this.panelMenu.Controls.Add(this.cmbProyectos);
            this.panelMenu.Controls.Add(this.txtDescripcion);
            this.panelMenu.Controls.Add(this.lblProyectos);
            this.panelMenu.Controls.Add(this.dptFecha2);
            this.panelMenu.Controls.Add(this.lblFfin);
            this.panelMenu.Controls.Add(this.lblHoras);
            this.panelMenu.Controls.Add(this.lblFinicio);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1284, 156);
            this.panelMenu.TabIndex = 21;
            // 
            // fLPanelBtn
            // 
            this.fLPanelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fLPanelBtn.Controls.Add(this.btnAgregar);
            this.fLPanelBtn.Controls.Add(this.btnGuardar);
            this.fLPanelBtn.Controls.Add(this.btnSalir);
            this.fLPanelBtn.Location = new System.Drawing.Point(864, 26);
            this.fLPanelBtn.Name = "fLPanelBtn";
            this.fLPanelBtn.Size = new System.Drawing.Size(355, 92);
            this.fLPanelBtn.TabIndex = 21;
            // 
            // frmCargaHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1284, 787);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.dgvProyectos);
            this.Name = "frmCargaHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCargaHoras";
            this.Load += new System.EventHandler(this.frmCargaHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.fLPanelBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numHoras;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvProyectos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cmbProyectos;
        private System.Windows.Forms.Label lblProyectos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker dptFecha2;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Label lblFinicio;
        private System.Windows.Forms.Label lblFfin;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DateTimePicker dtpFechaCarga;
        private System.Windows.Forms.Label lblFechaCarga;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.FlowLayoutPanel fLPanelBtn;
    }
}
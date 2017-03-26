namespace LosNaranjitos
{
    partial class FrmCajaMantenimiento
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
            this.lblCajaModificar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cbbCajasId = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtCajaModificar = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.Consecutivo = new System.Windows.Forms.Label();
            this.lblConsecutivo = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.tbMantenimiento = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbBusqueda = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCajas = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbLista = new System.Windows.Forms.TabPage();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            this.tbMantenimiento.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tbLista.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCajaModificar
            // 
            this.lblCajaModificar.AutoSize = true;
            this.lblCajaModificar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCajaModificar.Location = new System.Drawing.Point(19, 0);
            this.lblCajaModificar.Name = "lblCajaModificar";
            this.lblCajaModificar.Size = new System.Drawing.Size(238, 33);
            this.lblCajaModificar.TabIndex = 21;
            this.lblCajaModificar.Text = "Seleccione la Caja a Modificar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 33);
            this.label2.TabIndex = 23;
            this.label2.Text = "Justificacion:";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActivo.Location = new System.Drawing.Point(19, 144);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(238, 20);
            this.chkActivo.TabIndex = 25;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cbbCajasId
            // 
            this.cbbCajasId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbCajasId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCajasId.FormattingEnabled = true;
            this.cbbCajasId.Items.AddRange(new object[] {
            "Consecutivo",
            "Descripcion"});
            this.cbbCajasId.Location = new System.Drawing.Point(19, 36);
            this.cbbCajasId.Name = "cbbCajasId";
            this.cbbCajasId.Size = new System.Drawing.Size(238, 21);
            this.cbbCajasId.Sorted = true;
            this.cbbCajasId.TabIndex = 27;
            this.cbbCajasId.SelectedIndexChanged += new System.EventHandler(this.cbbCajasId_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel5.Controls.Add(this.btnActualizar, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.lblCajaModificar, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.chkActivo, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.txtCajaModificar, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.cbbCajasId, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.17117F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.11712F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(278, 203);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActualizar.Location = new System.Drawing.Point(19, 170);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(238, 30);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar Carga";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtCajaModificar
            // 
            this.txtCajaModificar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCajaModificar.Location = new System.Drawing.Point(19, 102);
            this.txtCajaModificar.MaxLength = 30;
            this.txtCajaModificar.Multiline = true;
            this.txtCajaModificar.Name = "txtCajaModificar";
            this.txtCajaModificar.Size = new System.Drawing.Size(238, 36);
            this.txtCajaModificar.TabIndex = 26;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(542, 391);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 34);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregar.Location = new System.Drawing.Point(19, 168);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(238, 32);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Nueva Carga";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Consecutivo
            // 
            this.Consecutivo.AutoSize = true;
            this.Consecutivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Consecutivo.Location = new System.Drawing.Point(19, 0);
            this.Consecutivo.Name = "Consecutivo";
            this.Consecutivo.Size = new System.Drawing.Size(238, 33);
            this.Consecutivo.TabIndex = 21;
            this.Consecutivo.Text = "Consecutivo";
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConsecutivo.ForeColor = System.Drawing.Color.Black;
            this.lblConsecutivo.Location = new System.Drawing.Point(19, 33);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(238, 33);
            this.lblConsecutivo.TabIndex = 24;
            this.lblConsecutivo.Text = "CAJ-";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel4.Controls.Add(this.btnAgregar, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.Consecutivo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblConsecutivo, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(278, 203);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox2.Location = new System.Drawing.Point(293, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 222);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Desactivar/ Activar Caja";
            // 
            // grbBuscar
            // 
            this.grbBuscar.Controls.Add(this.tableLayoutPanel4);
            this.grbBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.ForeColor = System.Drawing.Color.OrangeRed;
            this.grbBuscar.Location = new System.Drawing.Point(3, 3);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(284, 222);
            this.grbBuscar.TabIndex = 0;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "Crear Nueva Caja";
            // 
            // tbMantenimiento
            // 
            this.tbMantenimiento.Controls.Add(this.tableLayoutPanel3);
            this.tbMantenimiento.Location = new System.Drawing.Point(4, 22);
            this.tbMantenimiento.Name = "tbMantenimiento";
            this.tbMantenimiento.Padding = new System.Windows.Forms.Padding(3);
            this.tbMantenimiento.Size = new System.Drawing.Size(586, 276);
            this.tbMantenimiento.TabIndex = 1;
            this.tbMantenimiento.Text = "Mantenimiento Cargas";
            this.tbMantenimiento.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.grbBuscar, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.67742F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.32258F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(580, 270);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbbBusqueda
            // 
            this.cbbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBusqueda.FormattingEnabled = true;
            this.cbbBusqueda.Items.AddRange(new object[] {
            "Consecutivo",
            "Descripcion"});
            this.cbbBusqueda.Location = new System.Drawing.Point(3, 3);
            this.cbbBusqueda.Name = "cbbBusqueda";
            this.cbbBusqueda.Size = new System.Drawing.Size(189, 21);
            this.cbbBusqueda.Sorted = true;
            this.cbbBusqueda.TabIndex = 19;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(198, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(139, 20);
            this.txtBuscar.TabIndex = 17;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(343, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvCajas
            // 
            this.dgvCajas.AllowUserToAddRows = false;
            this.dgvCajas.AllowUserToDeleteRows = false;
            this.dgvCajas.AllowUserToOrderColumns = true;
            this.dgvCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajas.Location = new System.Drawing.Point(3, 43);
            this.dgvCajas.MultiSelect = false;
            this.dgvCajas.Name = "dgvCajas";
            this.dgvCajas.ReadOnly = true;
            this.dgvCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajas.Size = new System.Drawing.Size(574, 224);
            this.dgvCajas.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbbBusqueda);
            this.flowLayoutPanel1.Controls.Add(this.txtBuscar);
            this.flowLayoutPanel1.Controls.Add(this.btnBuscar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(574, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvCajas, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(580, 270);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tbLista
            // 
            this.tbLista.Controls.Add(this.tableLayoutPanel2);
            this.tbLista.Location = new System.Drawing.Point(4, 22);
            this.tbLista.Name = "tbLista";
            this.tbLista.Padding = new System.Windows.Forms.Padding(3);
            this.tbLista.Size = new System.Drawing.Size(586, 276);
            this.tbLista.TabIndex = 0;
            this.tbLista.Text = "Listado";
            this.tbLista.UseVisualStyleBackColor = true;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbLista);
            this.tbMain.Controls.Add(this.tbMantenimiento);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(23, 83);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(594, 302);
            this.tbMain.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LimeGreen;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbMain, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 428);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(23, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 74);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cajas";
            // 
            // FrmCajaMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 428);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCajaMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cajas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCajaMantenimiento_Load);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grbBuscar.ResumeLayout(false);
            this.tbMantenimiento.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tbLista.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCajaModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cbbCajasId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtCajaModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label Consecutivo;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.TabPage tbMantenimiento;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbbBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvCajas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tbLista;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
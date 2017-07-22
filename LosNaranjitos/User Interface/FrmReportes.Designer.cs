namespace LosNaranjitos.User_Interface
{
    partial class FrmReportes
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
            this.btnEjecutarConParametros = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkEmailParametros = new System.Windows.Forms.CheckBox();
            this.cmbItemsParametros = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtVentasCombo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtVentaProducto = new System.Windows.Forms.RadioButton();
            this.rbtComprasPorFecha = new System.Windows.Forms.RadioButton();
            this.rbtVentasporFecha = new System.Windows.Forms.RadioButton();
            this.tbRptConParametros = new System.Windows.Forms.TabPage();
            this.cbTipoReporte = new System.Windows.Forms.ComboBox();
            this.grbReportes1 = new System.Windows.Forms.GroupBox();
            this.chkMail = new System.Windows.Forms.CheckBox();
            this.btnEjecutarReporteSinParametros = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbRptSinParametros = new System.Windows.Forms.TabPage();
            this.tbcReporteria = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lable = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbRptConParametros.SuspendLayout();
            this.grbReportes1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tbRptSinParametros.SuspendLayout();
            this.tbcReporteria.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEjecutarConParametros
            // 
            this.btnEjecutarConParametros.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEjecutarConParametros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutarConParametros.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutarConParametros.ForeColor = System.Drawing.Color.White;
            this.btnEjecutarConParametros.Location = new System.Drawing.Point(111, 211);
            this.btnEjecutarConParametros.Name = "btnEjecutarConParametros";
            this.btnEjecutarConParametros.Size = new System.Drawing.Size(132, 28);
            this.btnEjecutarConParametros.TabIndex = 351;
            this.btnEjecutarConParametros.Text = "Ejecutar Reporte";
            this.btnEjecutarConParametros.UseVisualStyleBackColor = false;
            this.btnEjecutarConParametros.Click += new System.EventHandler(this.btnEjecutarConParametros_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Britannic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 271);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reportes Con Parametros";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(510, 251);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkEmailParametros);
            this.groupBox4.Controls.Add(this.cmbItemsParametros);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnEjecutarConParametros);
            this.groupBox4.Controls.Add(this.dt2);
            this.groupBox4.Controls.Add(this.dt1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(258, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(249, 245);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parametro";
            // 
            // chkEmailParametros
            // 
            this.chkEmailParametros.AutoSize = true;
            this.chkEmailParametros.Location = new System.Drawing.Point(38, 180);
            this.chkEmailParametros.Name = "chkEmailParametros";
            this.chkEmailParametros.Size = new System.Drawing.Size(119, 18);
            this.chkEmailParametros.TabIndex = 353;
            this.chkEmailParametros.Text = "Enviar por Correo";
            this.chkEmailParametros.UseVisualStyleBackColor = true;
            // 
            // cmbItemsParametros
            // 
            this.cmbItemsParametros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemsParametros.Enabled = false;
            this.cmbItemsParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemsParametros.ForeColor = System.Drawing.Color.OrangeRed;
            this.cmbItemsParametros.FormattingEnabled = true;
            this.cmbItemsParametros.Location = new System.Drawing.Point(27, 149);
            this.cmbItemsParametros.Name = "cmbItemsParametros";
            this.cmbItemsParametros.Size = new System.Drawing.Size(186, 21);
            this.cmbItemsParametros.Sorted = true;
            this.cmbItemsParametros.TabIndex = 352;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Desde";
            // 
            // dt2
            // 
            this.dt2.Enabled = false;
            this.dt2.Location = new System.Drawing.Point(24, 103);
            this.dt2.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(200, 21);
            this.dt2.TabIndex = 14;
            // 
            // dt1
            // 
            this.dt1.Enabled = false;
            this.dt1.Location = new System.Drawing.Point(24, 44);
            this.dt1.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(200, 21);
            this.dt1.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.rbtVentasCombo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rbtVentaProducto);
            this.groupBox3.Controls.Add(this.rbtComprasPorFecha);
            this.groupBox3.Controls.Add(this.rbtVentasporFecha);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 245);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Reporte";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(40, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 28);
            this.label6.TabIndex = 7;
            this.label6.Text = "Seleccione el Combo \r\nen el Panel derecho.";
            // 
            // rbtVentasCombo
            // 
            this.rbtVentasCombo.AutoSize = true;
            this.rbtVentasCombo.Enabled = false;
            this.rbtVentasCombo.Location = new System.Drawing.Point(24, 176);
            this.rbtVentasCombo.Name = "rbtVentasCombo";
            this.rbtVentasCombo.Size = new System.Drawing.Size(133, 18);
            this.rbtVentasCombo.TabIndex = 6;
            this.rbtVentasCombo.Text = "Productos de Combo";
            this.rbtVentasCombo.UseVisualStyleBackColor = true;
            this.rbtVentasCombo.CheckedChanged += new System.EventHandler(this.rbtVentasCombo_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(40, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "Seleccione el Producto \r\nen el Panel derecho.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(40, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Seleccione fechas del reporte  \r\nen el panel derecho.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seleccione fechas del reporte  \r\nen el panel derecho.";
            // 
            // rbtVentaProducto
            // 
            this.rbtVentaProducto.AutoSize = true;
            this.rbtVentaProducto.Enabled = false;
            this.rbtVentaProducto.Location = new System.Drawing.Point(22, 123);
            this.rbtVentaProducto.Name = "rbtVentaProducto";
            this.rbtVentaProducto.Size = new System.Drawing.Size(144, 18);
            this.rbtVentaProducto.TabIndex = 2;
            this.rbtVentaProducto.Text = "Insumos por Producto";
            this.rbtVentaProducto.UseVisualStyleBackColor = true;
            this.rbtVentaProducto.CheckedChanged += new System.EventHandler(this.rbtVentaProducto_CheckedChanged);
            // 
            // rbtComprasPorFecha
            // 
            this.rbtComprasPorFecha.AutoSize = true;
            this.rbtComprasPorFecha.Location = new System.Drawing.Point(22, 70);
            this.rbtComprasPorFecha.Name = "rbtComprasPorFecha";
            this.rbtComprasPorFecha.Size = new System.Drawing.Size(129, 18);
            this.rbtComprasPorFecha.TabIndex = 1;
            this.rbtComprasPorFecha.Text = "Compras por Fecha";
            this.rbtComprasPorFecha.UseVisualStyleBackColor = true;
            this.rbtComprasPorFecha.CheckedChanged += new System.EventHandler(this.rbtComprasPorFecha_CheckedChanged);
            // 
            // rbtVentasporFecha
            // 
            this.rbtVentasporFecha.AutoSize = true;
            this.rbtVentasporFecha.Location = new System.Drawing.Point(22, 18);
            this.rbtVentasporFecha.Name = "rbtVentasporFecha";
            this.rbtVentasporFecha.Size = new System.Drawing.Size(117, 18);
            this.rbtVentasporFecha.TabIndex = 0;
            this.rbtVentasporFecha.Text = "Ventas por Fecha";
            this.rbtVentasporFecha.UseVisualStyleBackColor = true;
            this.rbtVentasporFecha.CheckedChanged += new System.EventHandler(this.rbtVentasporFecha_CheckedChanged);
            // 
            // tbRptConParametros
            // 
            this.tbRptConParametros.Controls.Add(this.groupBox2);
            this.tbRptConParametros.Location = new System.Drawing.Point(4, 23);
            this.tbRptConParametros.Name = "tbRptConParametros";
            this.tbRptConParametros.Padding = new System.Windows.Forms.Padding(3);
            this.tbRptConParametros.Size = new System.Drawing.Size(522, 277);
            this.tbRptConParametros.TabIndex = 1;
            this.tbRptConParametros.Text = "Reportes Con Parametros";
            this.tbRptConParametros.UseVisualStyleBackColor = true;
            // 
            // cbTipoReporte
            // 
            this.cbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoReporte.ForeColor = System.Drawing.Color.OrangeRed;
            this.cbTipoReporte.FormattingEnabled = true;
            this.cbTipoReporte.Items.AddRange(new object[] {
            "Clientes",
            "Combos",
            "Compras",
            "Errores",
            "Insumo Por Producto",
            "Insumos",
            "Producto Por Combo",
            "Productos",
            "Proveedores",
            "Usuarios",
            "Ventas"});
            this.cbTipoReporte.Location = new System.Drawing.Point(67, 28);
            this.cbTipoReporte.Name = "cbTipoReporte";
            this.cbTipoReporte.Size = new System.Drawing.Size(186, 21);
            this.cbTipoReporte.Sorted = true;
            this.cbTipoReporte.TabIndex = 15;
            // 
            // grbReportes1
            // 
            this.grbReportes1.Controls.Add(this.chkMail);
            this.grbReportes1.Controls.Add(this.cbTipoReporte);
            this.grbReportes1.Controls.Add(this.btnEjecutarReporteSinParametros);
            this.grbReportes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbReportes1.Location = new System.Drawing.Point(3, 3);
            this.grbReportes1.Name = "grbReportes1";
            this.grbReportes1.Size = new System.Drawing.Size(510, 74);
            this.grbReportes1.TabIndex = 0;
            this.grbReportes1.TabStop = false;
            this.grbReportes1.Text = "Seleccione el Reporte a Ejecutar";
            // 
            // chkMail
            // 
            this.chkMail.AutoSize = true;
            this.chkMail.Location = new System.Drawing.Point(67, 56);
            this.chkMail.Name = "chkMail";
            this.chkMail.Size = new System.Drawing.Size(119, 18);
            this.chkMail.TabIndex = 16;
            this.chkMail.Text = "Enviar por Correo";
            this.chkMail.UseVisualStyleBackColor = true;
            // 
            // btnEjecutarReporteSinParametros
            // 
            this.btnEjecutarReporteSinParametros.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEjecutarReporteSinParametros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutarReporteSinParametros.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutarReporteSinParametros.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEjecutarReporteSinParametros.Location = new System.Drawing.Point(310, 20);
            this.btnEjecutarReporteSinParametros.Name = "btnEjecutarReporteSinParametros";
            this.btnEjecutarReporteSinParametros.Size = new System.Drawing.Size(152, 39);
            this.btnEjecutarReporteSinParametros.TabIndex = 14;
            this.btnEjecutarReporteSinParametros.Text = "Ejecutar";
            this.btnEjecutarReporteSinParametros.UseVisualStyleBackColor = false;
            this.btnEjecutarReporteSinParametros.Click += new System.EventHandler(this.btnEjecutarReporteSinParametros_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grbReportes1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(516, 271);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tbRptSinParametros
            // 
            this.tbRptSinParametros.Controls.Add(this.tableLayoutPanel2);
            this.tbRptSinParametros.Location = new System.Drawing.Point(4, 23);
            this.tbRptSinParametros.Name = "tbRptSinParametros";
            this.tbRptSinParametros.Padding = new System.Windows.Forms.Padding(3);
            this.tbRptSinParametros.Size = new System.Drawing.Size(522, 277);
            this.tbRptSinParametros.TabIndex = 0;
            this.tbRptSinParametros.Text = "Reportes Sin Parametros";
            this.tbRptSinParametros.UseVisualStyleBackColor = true;
            // 
            // tbcReporteria
            // 
            this.tbcReporteria.Controls.Add(this.tbRptSinParametros);
            this.tbcReporteria.Controls.Add(this.tbRptConParametros);
            this.tbcReporteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcReporteria.Font = new System.Drawing.Font("Britannic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcReporteria.Location = new System.Drawing.Point(23, 72);
            this.tbcReporteria.Name = "tbcReporteria";
            this.tbcReporteria.SelectedIndex = 0;
            this.tbcReporteria.Size = new System.Drawing.Size(530, 304);
            this.tbcReporteria.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(23, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reportes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LosNaranjitos.Properties.Resources.taco;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(463, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 27);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LimeGreen;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbcReporteria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 414);
            this.tableLayoutPanel1.TabIndex = 358;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSalir);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(353, 382);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 29);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(122, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable.Location = new System.Drawing.Point(0, 0);
            this.lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(0, 13);
            this.lable.TabIndex = 359;
            this.lable.Visible = false;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 414);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbRptConParametros.ResumeLayout(false);
            this.grbReportes1.ResumeLayout(false);
            this.grbReportes1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tbRptSinParametros.ResumeLayout(false);
            this.tbcReporteria.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEjecutarConParametros;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tbRptConParametros;
        private System.Windows.Forms.ComboBox cbTipoReporte;
        private System.Windows.Forms.GroupBox grbReportes1;
        private System.Windows.Forms.Button btnEjecutarReporteSinParametros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tbRptSinParametros;
        private System.Windows.Forms.TabControl tbcReporteria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.CheckBox chkMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtVentaProducto;
        private System.Windows.Forms.RadioButton rbtComprasPorFecha;
        private System.Windows.Forms.RadioButton rbtVentasporFecha;
        private System.Windows.Forms.CheckBox chkEmailParametros;
        private System.Windows.Forms.ComboBox cmbItemsParametros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtVentasCombo;
        private System.Windows.Forms.Label label5;
    }
}
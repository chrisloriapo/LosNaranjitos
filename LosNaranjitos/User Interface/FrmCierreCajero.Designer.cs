namespace LosNaranjitos
{
    partial class FrmCierreCajero
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrangeDB1DataSet = new LosNaranjitos.OrangeDB1DataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rptVReporteLocal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbTipoCierre = new System.Windows.Forms.ComboBox();
            this.cbbItemTipodeCierre = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.CierreTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.CierreTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CierreBindingSource
            // 
            this.CierreBindingSource.DataMember = "Cierre";
            this.CierreBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // OrangeDB1DataSet
            // 
            this.OrangeDB1DataSet.DataSetName = "OrangeDB1DataSet";
            this.OrangeDB1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rptVReporteLocal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 479);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rptVReporteLocal
            // 
            this.rptVReporteLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CierreBindingSource;
            this.rptVReporteLocal.LocalReport.DataSources.Add(reportDataSource1);
            this.rptVReporteLocal.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcReporteCierre.rdlc";
            this.rptVReporteLocal.Location = new System.Drawing.Point(3, 122);
            this.rptVReporteLocal.Name = "rptVReporteLocal";
            this.rptVReporteLocal.ServerReport.BearerToken = null;
            this.rptVReporteLocal.Size = new System.Drawing.Size(909, 354);
            this.rptVReporteLocal.TabIndex = 5;
            this.rptVReporteLocal.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 113);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el tipo de cierre";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.43743F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.69214F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.75969F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(903, 92);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbTipoCierre);
            this.groupBox2.Controls.Add(this.cbbItemTipodeCierre);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 86);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Cierre";
            // 
            // cbbTipoCierre
            // 
            this.cbbTipoCierre.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbTipoCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoCierre.FormattingEnabled = true;
            this.cbbTipoCierre.Items.AddRange(new object[] {
            "Cierre de Caja",
            "Cierre Diario"});
            this.cbbTipoCierre.Location = new System.Drawing.Point(3, 18);
            this.cbbTipoCierre.Name = "cbbTipoCierre";
            this.cbbTipoCierre.Size = new System.Drawing.Size(308, 23);
            this.cbbTipoCierre.TabIndex = 0;
            this.cbbTipoCierre.SelectedIndexChanged += new System.EventHandler(this.cbbTipoCierre_SelectedIndexChanged);
            // 
            // cbbItemTipodeCierre
            // 
            this.cbbItemTipodeCierre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbbItemTipodeCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbItemTipodeCierre.FormattingEnabled = true;
            this.cbbItemTipodeCierre.Items.AddRange(new object[] {
            "Cierre de Caja",
            "Cierre Diario"});
            this.cbbItemTipodeCierre.Location = new System.Drawing.Point(3, 60);
            this.cbbItemTipodeCierre.Name = "cbbItemTipodeCierre";
            this.cbbItemTipodeCierre.Size = new System.Drawing.Size(308, 23);
            this.cbbItemTipodeCierre.TabIndex = 1;
            this.cbbItemTipodeCierre.Visible = false;
            this.cbbItemTipodeCierre.SelectedIndexChanged += new System.EventHandler(this.cbbItemTipodeCierre_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnCancelar, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnEjecutar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNuevo, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(323, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(226, 86);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(3, 59);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(220, 24);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEjecutar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutar.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.ForeColor = System.Drawing.Color.White;
            this.btnEjecutar.Location = new System.Drawing.Point(3, 3);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(220, 22);
            this.btnEjecutar.TabIndex = 13;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.DarkOrange;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(3, 31);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(220, 22);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo Cierre";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // CierreTableAdapter
            // 
            this.CierreTableAdapter.ClearBeforeFill = true;
            // 
            // FrmCierreCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(915, 479);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCierreCajero";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soda Los Naranjitos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCierreCajero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbTipoCierre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbbItemTipodeCierre;
        private Microsoft.Reporting.WinForms.ReportViewer rptVReporteLocal;
        private System.Windows.Forms.BindingSource CierreBindingSource;
        private OrangeDB1DataSet OrangeDB1DataSet;
        private OrangeDB1DataSetTableAdapters.CierreTableAdapter CierreTableAdapter;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
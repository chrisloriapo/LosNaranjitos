namespace LosNaranjitos
{
    partial class FrmReporteProductos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrangeDB1DataSet = new LosNaranjitos.OrangeDB1DataSet();
            this.ProductoTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.ProductoTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbProductos = new System.Windows.Forms.TabPage();
            this.tbInsumos = new System.Windows.Forms.TabPage();
            this.rptVReporteLocal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbBitacora = new System.Windows.Forms.TabPage();
            this.tbErrores = new System.Windows.Forms.TabPage();
            this.tbCombos = new System.Windows.Forms.TabPage();
            this.tbCierres = new System.Windows.Forms.TabPage();
            this.rptCombos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptInsumos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbProveedores = new System.Windows.Forms.TabPage();
            this.tbUsuarios = new System.Windows.Forms.TabPage();
            this.rptBitacora = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptErrores = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptCierres = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptProveedores = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptUsuarios = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ComboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ComboTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.ComboTableAdapter();
            this.InsumosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InsumosTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.InsumosTableAdapter();
            this.BitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BitacoraTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.BitacoraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbProductos.SuspendLayout();
            this.tbInsumos.SuspendLayout();
            this.tbBitacora.SuspendLayout();
            this.tbErrores.SuspendLayout();
            this.tbCombos.SuspendLayout();
            this.tbCierres.SuspendLayout();
            this.tbProveedores.SuspendLayout();
            this.tbUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsumosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductoBindingSource
            // 
            this.ProductoBindingSource.DataMember = "Producto";
            this.ProductoBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // OrangeDB1DataSet
            // 
            this.OrangeDB1DataSet.DataSetName = "OrangeDB1DataSet";
            this.OrangeDB1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProductoTableAdapter
            // 
            this.ProductoTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.542857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.74286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.714286F));
            this.tableLayoutPanel1.Controls.Add(this.tbcMain, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.89063F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.10938F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbProductos);
            this.tbcMain.Controls.Add(this.tbCombos);
            this.tbcMain.Controls.Add(this.tbInsumos);
            this.tbcMain.Controls.Add(this.tbBitacora);
            this.tbcMain.Controls.Add(this.tbErrores);
            this.tbcMain.Controls.Add(this.tbCierres);
            this.tbcMain.Controls.Add(this.tbProveedores);
            this.tbcMain.Controls.Add(this.tbUsuarios);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(34, 59);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(788, 325);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tbProductos
            // 
            this.tbProductos.Controls.Add(this.rptVReporteLocal);
            this.tbProductos.Location = new System.Drawing.Point(4, 22);
            this.tbProductos.Name = "tbProductos";
            this.tbProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tbProductos.Size = new System.Drawing.Size(780, 299);
            this.tbProductos.TabIndex = 0;
            this.tbProductos.Text = "Productos";
            this.tbProductos.UseVisualStyleBackColor = true;
            // 
            // tbInsumos
            // 
            this.tbInsumos.Controls.Add(this.rptInsumos);
            this.tbInsumos.Location = new System.Drawing.Point(4, 22);
            this.tbInsumos.Name = "tbInsumos";
            this.tbInsumos.Padding = new System.Windows.Forms.Padding(3);
            this.tbInsumos.Size = new System.Drawing.Size(780, 299);
            this.tbInsumos.TabIndex = 1;
            this.tbInsumos.Text = "Insumos";
            this.tbInsumos.UseVisualStyleBackColor = true;
            // 
            // rptVReporteLocal
            // 
            this.rptVReporteLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ProductoBindingSource;
            this.rptVReporteLocal.LocalReport.DataSources.Add(reportDataSource1);
            this.rptVReporteLocal.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptVReporteLocal.Location = new System.Drawing.Point(3, 3);
            this.rptVReporteLocal.Name = "rptVReporteLocal";
            this.rptVReporteLocal.ServerReport.BearerToken = null;
            this.rptVReporteLocal.Size = new System.Drawing.Size(774, 293);
            this.rptVReporteLocal.TabIndex = 1;
            // 
            // tbBitacora
            // 
            this.tbBitacora.Controls.Add(this.rptBitacora);
            this.tbBitacora.Location = new System.Drawing.Point(4, 22);
            this.tbBitacora.Name = "tbBitacora";
            this.tbBitacora.Size = new System.Drawing.Size(780, 299);
            this.tbBitacora.TabIndex = 2;
            this.tbBitacora.Text = "Bitacora";
            this.tbBitacora.UseVisualStyleBackColor = true;
            // 
            // tbErrores
            // 
            this.tbErrores.Controls.Add(this.rptErrores);
            this.tbErrores.Location = new System.Drawing.Point(4, 22);
            this.tbErrores.Name = "tbErrores";
            this.tbErrores.Size = new System.Drawing.Size(780, 299);
            this.tbErrores.TabIndex = 3;
            this.tbErrores.Text = "Errores";
            this.tbErrores.UseVisualStyleBackColor = true;
            // 
            // tbCombos
            // 
            this.tbCombos.Controls.Add(this.rptCombos);
            this.tbCombos.Location = new System.Drawing.Point(4, 22);
            this.tbCombos.Name = "tbCombos";
            this.tbCombos.Size = new System.Drawing.Size(780, 299);
            this.tbCombos.TabIndex = 4;
            this.tbCombos.Text = "Combos";
            this.tbCombos.UseVisualStyleBackColor = true;
            // 
            // tbCierres
            // 
            this.tbCierres.Controls.Add(this.rptCierres);
            this.tbCierres.Location = new System.Drawing.Point(4, 22);
            this.tbCierres.Name = "tbCierres";
            this.tbCierres.Size = new System.Drawing.Size(780, 299);
            this.tbCierres.TabIndex = 5;
            this.tbCierres.Text = "Cierres";
            this.tbCierres.UseVisualStyleBackColor = true;
            // 
            // rptCombos
            // 
            this.rptCombos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.ComboBindingSource;
            this.rptCombos.LocalReport.DataSources.Add(reportDataSource2);
            this.rptCombos.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcCombos.rdlc";
            this.rptCombos.Location = new System.Drawing.Point(0, 0);
            this.rptCombos.Name = "rptCombos";
            this.rptCombos.ServerReport.BearerToken = null;
            this.rptCombos.Size = new System.Drawing.Size(780, 299);
            this.rptCombos.TabIndex = 2;
            // 
            // rptInsumos
            // 
            this.rptInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.InsumosBindingSource;
            this.rptInsumos.LocalReport.DataSources.Add(reportDataSource3);
            this.rptInsumos.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcReporteInsumos.rdlc";
            this.rptInsumos.Location = new System.Drawing.Point(3, 3);
            this.rptInsumos.Name = "rptInsumos";
            this.rptInsumos.ServerReport.BearerToken = null;
            this.rptInsumos.Size = new System.Drawing.Size(774, 293);
            this.rptInsumos.TabIndex = 2;
            // 
            // tbProveedores
            // 
            this.tbProveedores.Controls.Add(this.rptProveedores);
            this.tbProveedores.Location = new System.Drawing.Point(4, 22);
            this.tbProveedores.Name = "tbProveedores";
            this.tbProveedores.Size = new System.Drawing.Size(780, 299);
            this.tbProveedores.TabIndex = 6;
            this.tbProveedores.Text = "Proveedores";
            this.tbProveedores.UseVisualStyleBackColor = true;
            // 
            // tbUsuarios
            // 
            this.tbUsuarios.Controls.Add(this.rptUsuarios);
            this.tbUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tbUsuarios.Name = "tbUsuarios";
            this.tbUsuarios.Size = new System.Drawing.Size(780, 299);
            this.tbUsuarios.TabIndex = 7;
            this.tbUsuarios.Text = "Usuarios";
            this.tbUsuarios.UseVisualStyleBackColor = true;
            // 
            // rptBitacora
            // 
            this.rptBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.BitacoraBindingSource;
            this.rptBitacora.LocalReport.DataSources.Add(reportDataSource4);
            this.rptBitacora.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcReporteBitacora.rdlc";
            this.rptBitacora.Location = new System.Drawing.Point(0, 0);
            this.rptBitacora.Name = "rptBitacora";
            this.rptBitacora.ServerReport.BearerToken = null;
            this.rptBitacora.Size = new System.Drawing.Size(780, 299);
            this.rptBitacora.TabIndex = 3;
            // 
            // rptErrores
            // 
            this.rptErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "DataSet1";
            reportDataSource5.Value = this.ProductoBindingSource;
            this.rptErrores.LocalReport.DataSources.Add(reportDataSource5);
            this.rptErrores.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptErrores.Location = new System.Drawing.Point(0, 0);
            this.rptErrores.Name = "rptErrores";
            this.rptErrores.ServerReport.BearerToken = null;
            this.rptErrores.Size = new System.Drawing.Size(780, 299);
            this.rptErrores.TabIndex = 3;
            // 
            // rptCierres
            // 
            this.rptCierres.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.ProductoBindingSource;
            this.rptCierres.LocalReport.DataSources.Add(reportDataSource6);
            this.rptCierres.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptCierres.Location = new System.Drawing.Point(0, 0);
            this.rptCierres.Name = "rptCierres";
            this.rptCierres.ServerReport.BearerToken = null;
            this.rptCierres.Size = new System.Drawing.Size(780, 299);
            this.rptCierres.TabIndex = 3;
            // 
            // rptProveedores
            // 
            this.rptProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.ProductoBindingSource;
            this.rptProveedores.LocalReport.DataSources.Add(reportDataSource7);
            this.rptProveedores.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptProveedores.Location = new System.Drawing.Point(0, 0);
            this.rptProveedores.Name = "rptProveedores";
            this.rptProveedores.ServerReport.BearerToken = null;
            this.rptProveedores.Size = new System.Drawing.Size(780, 299);
            this.rptProveedores.TabIndex = 3;
            // 
            // rptUsuarios
            // 
            this.rptUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.ProductoBindingSource;
            this.rptUsuarios.LocalReport.DataSources.Add(reportDataSource8);
            this.rptUsuarios.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptUsuarios.Location = new System.Drawing.Point(0, 0);
            this.rptUsuarios.Name = "rptUsuarios";
            this.rptUsuarios.ServerReport.BearerToken = null;
            this.rptUsuarios.Size = new System.Drawing.Size(780, 299);
            this.rptUsuarios.TabIndex = 3;
            // 
            // ComboBindingSource
            // 
            this.ComboBindingSource.DataMember = "Combo";
            this.ComboBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // ComboTableAdapter
            // 
            this.ComboTableAdapter.ClearBeforeFill = true;
            // 
            // InsumosBindingSource
            // 
            this.InsumosBindingSource.DataMember = "Insumos";
            this.InsumosBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // InsumosTableAdapter
            // 
            this.InsumosTableAdapter.ClearBeforeFill = true;
            // 
            // BitacoraBindingSource
            // 
            this.BitacoraBindingSource.DataMember = "Bitacora";
            this.BitacoraBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // BitacoraTableAdapter
            // 
            this.BitacoraTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReporteProductos";
            this.Text = "FrmReporteProductos";
            this.Load += new System.EventHandler(this.FrmReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tbProductos.ResumeLayout(false);
            this.tbInsumos.ResumeLayout(false);
            this.tbBitacora.ResumeLayout(false);
            this.tbErrores.ResumeLayout(false);
            this.tbCombos.ResumeLayout(false);
            this.tbCierres.ResumeLayout(false);
            this.tbProveedores.ResumeLayout(false);
            this.tbUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsumosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ProductoBindingSource;
        private OrangeDB1DataSet OrangeDB1DataSet;
        private OrangeDB1DataSetTableAdapters.ProductoTableAdapter ProductoTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbProductos;
        private Microsoft.Reporting.WinForms.ReportViewer rptVReporteLocal;
        private System.Windows.Forms.TabPage tbCombos;
        private Microsoft.Reporting.WinForms.ReportViewer rptCombos;
        private System.Windows.Forms.TabPage tbInsumos;
        private Microsoft.Reporting.WinForms.ReportViewer rptInsumos;
        private System.Windows.Forms.TabPage tbBitacora;
        private Microsoft.Reporting.WinForms.ReportViewer rptBitacora;
        private System.Windows.Forms.TabPage tbErrores;
        private Microsoft.Reporting.WinForms.ReportViewer rptErrores;
        private System.Windows.Forms.TabPage tbCierres;
        private Microsoft.Reporting.WinForms.ReportViewer rptCierres;
        private System.Windows.Forms.TabPage tbProveedores;
        private Microsoft.Reporting.WinForms.ReportViewer rptProveedores;
        private System.Windows.Forms.TabPage tbUsuarios;
        private Microsoft.Reporting.WinForms.ReportViewer rptUsuarios;
        private System.Windows.Forms.BindingSource ComboBindingSource;
        private OrangeDB1DataSetTableAdapters.ComboTableAdapter ComboTableAdapter;
        private System.Windows.Forms.BindingSource InsumosBindingSource;
        private OrangeDB1DataSetTableAdapters.InsumosTableAdapter InsumosTableAdapter;
        private System.Windows.Forms.BindingSource BitacoraBindingSource;
        private OrangeDB1DataSetTableAdapters.BitacoraTableAdapter BitacoraTableAdapter;
    }
}
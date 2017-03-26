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
            this.ProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrangeDB1DataSet = new LosNaranjitos.OrangeDB1DataSet();
            this.rptVReporteLocal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProductoTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.ProductoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).BeginInit();
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
            // rptVReporteLocal
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ProductoBindingSource;
            this.rptVReporteLocal.LocalReport.DataSources.Add(reportDataSource1);
            this.rptVReporteLocal.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptVReporteLocal.Location = new System.Drawing.Point(48, 87);
            this.rptVReporteLocal.Name = "rptVReporteLocal";
            this.rptVReporteLocal.ServerReport.BearerToken = null;
            this.rptVReporteLocal.Size = new System.Drawing.Size(723, 333);
            this.rptVReporteLocal.TabIndex = 0;
            // 
            // ProductoTableAdapter
            // 
            this.ProductoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 512);
            this.Controls.Add(this.rptVReporteLocal);
            this.Name = "FrmReporteProductos";
            this.Text = "FrmReporteProductos";
            this.Load += new System.EventHandler(this.FrmReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptVReporteLocal;
        private System.Windows.Forms.BindingSource ProductoBindingSource;
        private OrangeDB1DataSet OrangeDB1DataSet;
        private OrangeDB1DataSetTableAdapters.ProductoTableAdapter ProductoTableAdapter;
    }
}
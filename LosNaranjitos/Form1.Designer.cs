namespace LosNaranjitos
{
    partial class Form1
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
            this.rpvBitacora = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrangeDB1DataSet = new LosNaranjitos.OrangeDB1DataSet();
            this.DTReporteBitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DTReporteBitacoraTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.DTReporteBitacoraTableAdapter();
            this.BitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BitacoraTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.BitacoraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTReporteBitacoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvBitacora
            // 
            this.rpvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BitacoraBindingSource;
            this.rpvBitacora.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBitacora.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcReporteBitacora.rdlc";
            this.rpvBitacora.Location = new System.Drawing.Point(0, 0);
            this.rpvBitacora.Name = "rpvBitacora";
            this.rpvBitacora.ServerReport.BearerToken = null;
            this.rpvBitacora.Size = new System.Drawing.Size(673, 390);
            this.rpvBitacora.TabIndex = 0;
            // 
            // OrangeDB1DataSet
            // 
            this.OrangeDB1DataSet.DataSetName = "OrangeDB1DataSet";
            this.OrangeDB1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DTReporteBitacoraBindingSource
            // 
            this.DTReporteBitacoraBindingSource.DataMember = "DTReporteBitacora";
            this.DTReporteBitacoraBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // DTReporteBitacoraTableAdapter
            // 
            this.DTReporteBitacoraTableAdapter.ClearBeforeFill = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 390);
            this.Controls.Add(this.rpvBitacora);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTReporteBitacoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBitacora;
        private System.Windows.Forms.BindingSource DTReporteBitacoraBindingSource;
        private OrangeDB1DataSet OrangeDB1DataSet;
        private OrangeDB1DataSetTableAdapters.DTReporteBitacoraTableAdapter DTReporteBitacoraTableAdapter;
        private System.Windows.Forms.BindingSource BitacoraBindingSource;
        private OrangeDB1DataSetTableAdapters.BitacoraTableAdapter BitacoraTableAdapter;
    }
}
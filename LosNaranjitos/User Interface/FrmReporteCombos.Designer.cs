namespace LosNaranjitos
{
    partial class FrmReporteCombos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptVReporteLocal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptVReporteLocal
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.rptVReporteLocal.LocalReport.DataSources.Add(reportDataSource1);
            this.rptVReporteLocal.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcProductos.rdlc";
            this.rptVReporteLocal.Location = new System.Drawing.Point(92, 87);
            this.rptVReporteLocal.Name = "rptVReporteLocal";
            this.rptVReporteLocal.ServerReport.BearerToken = null;
            this.rptVReporteLocal.Size = new System.Drawing.Size(723, 333);
            this.rptVReporteLocal.TabIndex = 1;
            // 
            // FrmReporteCombos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 506);
            this.Controls.Add(this.rptVReporteLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReporteCombos";
            this.Text = "FrmReporteCombos";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptVReporteLocal;
    }
}
namespace LosNaranjitos.Reporteria
{
    partial class FrmReporteDeVentas
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
            this.PedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrangeDB1DataSet = new LosNaranjitos.OrangeDB1DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pedidoTableAdapter1 = new LosNaranjitos.OrangeDB1DataSetTableAdapters.PedidoTableAdapter();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.dtpkHastaReporte = new System.Windows.Forms.DateTimePicker();
            this.dtpkDesdeReporte = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PedidoBindingSource
            // 
            this.PedidoBindingSource.DataMember = "Pedido";
            this.PedidoBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // OrangeDB1DataSet
            // 
            this.OrangeDB1DataSet.DataSetName = "OrangeDB1DataSet";
            this.OrangeDB1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcVentasDetalle.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(56, 138);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(644, 432);
            this.reportViewer1.TabIndex = 23;
            // 
            // pedidoTableAdapter1
            // 
            this.pedidoTableAdapter1.ClearBeforeFill = true;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(453, 14);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 26;
            this.btnEjecutar.Text = "button1";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // dtpkHastaReporte
            // 
            this.dtpkHastaReporte.Location = new System.Drawing.Point(358, 59);
            this.dtpkHastaReporte.MinDate = new System.DateTime(2017, 3, 29, 0, 0, 0, 0);
            this.dtpkHastaReporte.Name = "dtpkHastaReporte";
            this.dtpkHastaReporte.Size = new System.Drawing.Size(251, 20);
            this.dtpkHastaReporte.TabIndex = 25;
            // 
            // dtpkDesdeReporte
            // 
            this.dtpkDesdeReporte.Location = new System.Drawing.Point(106, 59);
            this.dtpkDesdeReporte.MinDate = new System.DateTime(2017, 3, 29, 0, 0, 0, 0);
            this.dtpkDesdeReporte.Name = "dtpkDesdeReporte";
            this.dtpkDesdeReporte.Size = new System.Drawing.Size(246, 20);
            this.dtpkDesdeReporte.TabIndex = 24;
            // 
            // FrmReporteDeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 457);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.dtpkHastaReporte);
            this.Controls.Add(this.dtpkDesdeReporte);
            this.Name = "FrmReporteDeVentas";
            this.Text = "FrmReporteDeVentas";
            this.Load += new System.EventHandler(this.FrmReporteDeVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PedidoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PedidoBindingSource;
        private OrangeDB1DataSet OrangeDB1DataSet;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private OrangeDB1DataSetTableAdapters.PedidoTableAdapter pedidoTableAdapter1;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.DateTimePicker dtpkHastaReporte;
        private System.Windows.Forms.DateTimePicker dtpkDesdeReporte;
    }
}
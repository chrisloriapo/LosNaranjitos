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
            this.CierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrangeDB1DataSet = new LosNaranjitos.OrangeDB1DataSet();
            this.BitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBitacora = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DTReporteBitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DTReporteBitacoraTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.DTReporteBitacoraTableAdapter();
            this.BitacoraTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.BitacoraTableAdapter();
            this.CierreTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.CierreTableAdapter();
            this.InsumosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InsumosTableAdapter = new LosNaranjitos.OrangeDB1DataSetTableAdapters.InsumosTableAdapter();
            this.chkLechuga = new System.Windows.Forms.CheckBox();
            this.txtObservacionesPP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTReporteBitacoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsumosBindingSource)).BeginInit();
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
            // BitacoraBindingSource
            // 
            this.BitacoraBindingSource.DataMember = "Bitacora";
            this.BitacoraBindingSource.DataSource = this.OrangeDB1DataSet;
            // 
            // rpvBitacora
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CierreBindingSource;
            this.rpvBitacora.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBitacora.LocalReport.ReportEmbeddedResource = "LosNaranjitos.Reporteria.rdlcReporteCierre.rdlc";
            this.rpvBitacora.Location = new System.Drawing.Point(0, 0);
            this.rpvBitacora.Name = "rpvBitacora";
            this.rpvBitacora.ServerReport.BearerToken = null;
            this.rpvBitacora.Size = new System.Drawing.Size(464, 211);
            this.rpvBitacora.TabIndex = 0;
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
            // BitacoraTableAdapter
            // 
            this.BitacoraTableAdapter.ClearBeforeFill = true;
            // 
            // CierreTableAdapter
            // 
            this.CierreTableAdapter.ClearBeforeFill = true;
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
            // chkLechuga
            // 
            this.chkLechuga.AutoSize = true;
            this.chkLechuga.Checked = true;
            this.chkLechuga.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLechuga.Location = new System.Drawing.Point(550, 351);
            this.chkLechuga.Name = "chkLechuga";
            this.chkLechuga.Size = new System.Drawing.Size(50, 17);
            this.chkLechuga.TabIndex = 5;
            this.chkLechuga.Text = "Lech";
            this.chkLechuga.UseVisualStyleBackColor = true;
            this.chkLechuga.CheckedChanged += new System.EventHandler(this.chkLechuga_CheckedChanged);
            // 
            // txtObservacionesPP
            // 
            this.txtObservacionesPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacionesPP.Font = new System.Drawing.Font("Exo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionesPP.Location = new System.Drawing.Point(48, 230);
            this.txtObservacionesPP.Multiline = true;
            this.txtObservacionesPP.Name = "txtObservacionesPP";
            this.txtObservacionesPP.Size = new System.Drawing.Size(300, 138);
            this.txtObservacionesPP.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "PDF Printing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(423, 285);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 390);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkLechuga);
            this.Controls.Add(this.txtObservacionesPP);
            this.Controls.Add(this.rpvBitacora);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeDB1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTReporteBitacoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsumosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBitacora;
        private System.Windows.Forms.BindingSource DTReporteBitacoraBindingSource;
        private OrangeDB1DataSet OrangeDB1DataSet;
        private OrangeDB1DataSetTableAdapters.DTReporteBitacoraTableAdapter DTReporteBitacoraTableAdapter;
        private System.Windows.Forms.BindingSource BitacoraBindingSource;
        private OrangeDB1DataSetTableAdapters.BitacoraTableAdapter BitacoraTableAdapter;
        private System.Windows.Forms.BindingSource CierreBindingSource;
        private OrangeDB1DataSetTableAdapters.CierreTableAdapter CierreTableAdapter;
        private System.Windows.Forms.BindingSource InsumosBindingSource;
        private OrangeDB1DataSetTableAdapters.InsumosTableAdapter InsumosTableAdapter;
        private System.Windows.Forms.CheckBox chkLechuga;
        private System.Windows.Forms.TextBox txtObservacionesPP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
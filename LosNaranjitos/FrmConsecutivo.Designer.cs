namespace LosNaranjitos
{
    partial class FrmConsecutivo
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
            this.dgvConsecutivo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsecutivo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsecutivo
            // 
            this.dgvConsecutivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsecutivo.Location = new System.Drawing.Point(29, 68);
            this.dgvConsecutivo.Name = "dgvConsecutivo";
            this.dgvConsecutivo.Size = new System.Drawing.Size(509, 301);
            this.dgvConsecutivo.TabIndex = 0;
            // 
            // FrmConsecutivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 412);
            this.Controls.Add(this.dgvConsecutivo);
            this.Name = "FrmConsecutivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsecutivo";
            this.Load += new System.EventHandler(this.Carga);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsecutivo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsecutivo;
    }
}
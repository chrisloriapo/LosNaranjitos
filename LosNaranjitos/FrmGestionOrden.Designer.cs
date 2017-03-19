namespace LosNaranjitos
{
    partial class FrmGestionOrden
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkOrden = new System.Windows.Forms.CheckBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.cbbOrden = new System.Windows.Forms.ComboBox();
            this.cbbCliente = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.btnEntregarPagar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbIdcliente = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.chkCancelado = new System.Windows.Forms.CheckBox();
            this.chkEntregado = new System.Windows.Forms.CheckBox();
            this.lblOrden = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvOrdenesVista = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesVista)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOrdenesVista, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.65347F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.34653F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 404);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Orden";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(637, 215);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 101);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Busqueda";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.73856F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.26144F));
            this.tableLayoutPanel3.Controls.Add(this.cbbCliente, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkOrden, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkCliente, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbbOrden, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(306, 82);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // chkOrden
            // 
            this.chkOrden.AutoSize = true;
            this.chkOrden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOrden.Location = new System.Drawing.Point(3, 3);
            this.chkOrden.Name = "chkOrden";
            this.chkOrden.Size = new System.Drawing.Size(84, 35);
            this.chkOrden.TabIndex = 0;
            this.chkOrden.Text = "Orden";
            this.chkOrden.UseVisualStyleBackColor = true;
            this.chkOrden.CheckedChanged += new System.EventHandler(this.chkOrden_CheckedChanged);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCliente.Location = new System.Drawing.Point(3, 44);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(84, 35);
            this.chkCliente.TabIndex = 1;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // cbbOrden
            // 
            this.cbbOrden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbOrden.FormattingEnabled = true;
            this.cbbOrden.Location = new System.Drawing.Point(93, 3);
            this.cbbOrden.Name = "cbbOrden";
            this.cbbOrden.Size = new System.Drawing.Size(210, 21);
            this.cbbOrden.TabIndex = 2;
            this.cbbOrden.SelectedIndexChanged += new System.EventHandler(this.cbbOrden_SelectedIndexChanged);
            // 
            // cbbCliente
            // 
            this.cbbCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbCliente.FormattingEnabled = true;
            this.cbbCliente.Location = new System.Drawing.Point(93, 44);
            this.cbbCliente.Name = "cbbCliente";
            this.cbbCliente.Size = new System.Drawing.Size(210, 21);
            this.cbbCliente.TabIndex = 3;
            this.cbbCliente.SelectedIndexChanged += new System.EventHandler(this.cbbCliente_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnModificar, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnPagar, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnEntregarPagar, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnEntregar, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(321, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(313, 101);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btnEntregar
            // 
            this.btnEntregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEntregar.Location = new System.Drawing.Point(3, 3);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(150, 44);
            this.btnEntregar.TabIndex = 0;
            this.btnEntregar.Text = "Entregar Orden";
            this.btnEntregar.UseVisualStyleBackColor = true;
            // 
            // btnEntregarPagar
            // 
            this.btnEntregarPagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEntregarPagar.Location = new System.Drawing.Point(159, 3);
            this.btnEntregarPagar.Name = "btnEntregarPagar";
            this.btnEntregarPagar.Size = new System.Drawing.Size(151, 44);
            this.btnEntregarPagar.TabIndex = 1;
            this.btnEntregarPagar.Text = "Entregar y Pagar";
            this.btnEntregarPagar.UseVisualStyleBackColor = true;
            // 
            // btnPagar
            // 
            this.btnPagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPagar.Location = new System.Drawing.Point(3, 53);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(150, 45);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Pagar Orden";
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModificar.Location = new System.Drawing.Point(159, 53);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(151, 45);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar Orden";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 102);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(321, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 102);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Orden";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.lblApellidos, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblNombre, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lbIdcliente, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(306, 83);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.lblTotal, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblOrden, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.chkEntregado, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.chkCancelado, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(307, 83);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // lbIdcliente
            // 
            this.lbIdcliente.AutoSize = true;
            this.lbIdcliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIdcliente.Location = new System.Drawing.Point(3, 0);
            this.lbIdcliente.Name = "lbIdcliente";
            this.lbIdcliente.Size = new System.Drawing.Size(300, 27);
            this.lbIdcliente.TabIndex = 0;
            this.lbIdcliente.Text = "ID: ";
            this.lbIdcliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.Location = new System.Drawing.Point(3, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(300, 27);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre: ";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApellidos.Location = new System.Drawing.Point(3, 54);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(300, 29);
            this.lblApellidos.TabIndex = 2;
            this.lblApellidos.Text = "Apellidos:";
            this.lblApellidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkCancelado
            // 
            this.chkCancelado.AutoSize = true;
            this.chkCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCancelado.Enabled = false;
            this.chkCancelado.Location = new System.Drawing.Point(156, 44);
            this.chkCancelado.Name = "chkCancelado";
            this.chkCancelado.Size = new System.Drawing.Size(148, 36);
            this.chkCancelado.TabIndex = 0;
            this.chkCancelado.Text = "Cancelado";
            this.chkCancelado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCancelado.UseVisualStyleBackColor = true;
            // 
            // chkEntregado
            // 
            this.chkEntregado.AutoSize = true;
            this.chkEntregado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEntregado.Enabled = false;
            this.chkEntregado.Location = new System.Drawing.Point(3, 44);
            this.chkEntregado.Name = "chkEntregado";
            this.chkEntregado.Size = new System.Drawing.Size(147, 36);
            this.chkEntregado.TabIndex = 1;
            this.chkEntregado.Text = "Entregado";
            this.chkEntregado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEntregado.UseVisualStyleBackColor = true;
            // 
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrden.Location = new System.Drawing.Point(3, 0);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(147, 41);
            this.lblOrden.TabIndex = 2;
            this.lblOrden.Text = "#Orden: ";
            this.lblOrden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Location = new System.Drawing.Point(156, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 41);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total: ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvOrdenesVista
            // 
            this.dgvOrdenesVista.AllowUserToAddRows = false;
            this.dgvOrdenesVista.AllowUserToDeleteRows = false;
            this.dgvOrdenesVista.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvOrdenesVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesVista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenesVista.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvOrdenesVista.Location = new System.Drawing.Point(3, 243);
            this.dgvOrdenesVista.Name = "dgvOrdenesVista";
            this.dgvOrdenesVista.ReadOnly = true;
            this.dgvOrdenesVista.Size = new System.Drawing.Size(643, 158);
            this.dgvOrdenesVista.TabIndex = 1;
            // 
            // FrmGestionOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 404);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGestionOrden";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion de Ordenes";
            this.Load += new System.EventHandler(this.FrmGestionOrden_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesVista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbbCliente;
        private System.Windows.Forms.CheckBox chkOrden;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.ComboBox cbbOrden;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.CheckBox chkEntregado;
        private System.Windows.Forms.CheckBox chkCancelado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnEntregarPagar;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lbIdcliente;
        private System.Windows.Forms.DataGridView dgvOrdenesVista;
    }
}
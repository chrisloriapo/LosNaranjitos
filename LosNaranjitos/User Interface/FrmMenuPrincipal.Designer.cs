namespace LosNaranjitos
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lnkUsuario = new System.Windows.Forms.LinkLabel();
            this.pcbUsuario = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menumain = new System.Windows.Forms.MenuStrip();
            this.tsmSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiPasswordChange = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosDeImpresiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiInsumosG = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOperacionesInsumos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiUnidadesMedida = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosALaVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combosPromocionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMiCargas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiProovedores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.cajasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiCierreCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiBitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consecutivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVentanas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmerTiempo = new System.Windows.Forms.Timer(this.components);
            this.parametrosGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.grbMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsuario)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.menumain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // grbMain
            // 
            this.grbMain.BackColor = System.Drawing.Color.DarkOrange;
            this.grbMain.Controls.Add(this.tableLayoutPanel1);
            this.grbMain.Controls.Add(this.label1);
            resources.ApplyResources(this.grbMain, "grbMain");
            this.grbMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbMain.Name = "grbMain";
            this.grbMain.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.lnkUsuario, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pcbUsuario, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // lnkUsuario
            // 
            resources.ApplyResources(this.lnkUsuario, "lnkUsuario");
            this.lnkUsuario.Name = "lnkUsuario";
            this.lnkUsuario.TabStop = true;
            // 
            // pcbUsuario
            // 
            resources.ApplyResources(this.pcbUsuario, "pcbUsuario");
            this.pcbUsuario.Image = global::LosNaranjitos.Properties.Resources.cocinero;
            this.pcbUsuario.Name = "pcbUsuario";
            this.pcbUsuario.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.lblTime, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblDate, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Name = "lblTime";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // menumain
            // 
            this.menumain.BackColor = System.Drawing.Color.DarkOrange;
            resources.ApplyResources(this.menumain, "menumain");
            this.menumain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menumain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSistema,
            this.tsmAdministracion,
            this.tsmVentas,
            this.tsmSeguridad,
            this.tsmVentanas,
            this.tsmAyuda,
            this.reportesToolStripMenuItem});
            this.menumain.Name = "menumain";
            // 
            // tsmSistema
            // 
            this.tsmSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiCerrarSesion,
            this.tsiPasswordChange,
            this.parametrosGeneralesToolStripMenuItem,
            this.parametrosDeImpresiónToolStripMenuItem,
            this.tsiAbout,
            this.tsiSalir});
            resources.ApplyResources(this.tsmSistema, "tsmSistema");
            this.tsmSistema.ForeColor = System.Drawing.Color.White;
            this.tsmSistema.Name = "tsmSistema";
            // 
            // tsiCerrarSesion
            // 
            this.tsiCerrarSesion.Name = "tsiCerrarSesion";
            resources.ApplyResources(this.tsiCerrarSesion, "tsiCerrarSesion");
            this.tsiCerrarSesion.Click += new System.EventHandler(this.tstICerrarSesion_Click);
            // 
            // tsiPasswordChange
            // 
            this.tsiPasswordChange.Name = "tsiPasswordChange";
            resources.ApplyResources(this.tsiPasswordChange, "tsiPasswordChange");
            this.tsiPasswordChange.Click += new System.EventHandler(this.tsiPasswordChange_Click);
            // 
            // parametrosDeImpresiónToolStripMenuItem
            // 
            this.parametrosDeImpresiónToolStripMenuItem.Name = "parametrosDeImpresiónToolStripMenuItem";
            resources.ApplyResources(this.parametrosDeImpresiónToolStripMenuItem, "parametrosDeImpresiónToolStripMenuItem");
            this.parametrosDeImpresiónToolStripMenuItem.Click += new System.EventHandler(this.parametrosDeImpresiónToolStripMenuItem_Click);
            // 
            // tsiAbout
            // 
            this.tsiAbout.Name = "tsiAbout";
            resources.ApplyResources(this.tsiAbout, "tsiAbout");
            this.tsiAbout.Click += new System.EventHandler(this.tstabout_Click);
            // 
            // tsiSalir
            // 
            this.tsiSalir.Name = "tsiSalir";
            resources.ApplyResources(this.tsiSalir, "tsiSalir");
            this.tsiSalir.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tsmAdministracion
            // 
            this.tsmAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiInsumosG,
            this.productosToolStripMenuItem,
            this.tsiProovedores,
            this.tsiCompras,
            this.tsiClientes,
            this.cajasToolStripMenuItem});
            resources.ApplyResources(this.tsmAdministracion, "tsmAdministracion");
            this.tsmAdministracion.ForeColor = System.Drawing.Color.White;
            this.tsmAdministracion.Name = "tsmAdministracion";
            // 
            // tsiInsumosG
            // 
            this.tsiInsumosG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiOperacionesInsumos,
            this.tsiUnidadesMedida});
            this.tsiInsumosG.Name = "tsiInsumosG";
            resources.ApplyResources(this.tsiInsumosG, "tsiInsumosG");
            // 
            // tsiOperacionesInsumos
            // 
            this.tsiOperacionesInsumos.Name = "tsiOperacionesInsumos";
            resources.ApplyResources(this.tsiOperacionesInsumos, "tsiOperacionesInsumos");
            this.tsiOperacionesInsumos.Click += new System.EventHandler(this.insumosToolStripMenuItem1_Click);
            // 
            // tsiUnidadesMedida
            // 
            this.tsiUnidadesMedida.Name = "tsiUnidadesMedida";
            resources.ApplyResources(this.tsiUnidadesMedida, "tsiUnidadesMedida");
            this.tsiUnidadesMedida.Click += new System.EventHandler(this.unidadesDeMedidasToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosALaVentaToolStripMenuItem,
            this.combosPromocionesToolStripMenuItem,
            this.tsMiCargas});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            resources.ApplyResources(this.productosToolStripMenuItem, "productosToolStripMenuItem");
            // 
            // productosALaVentaToolStripMenuItem
            // 
            this.productosALaVentaToolStripMenuItem.Name = "productosALaVentaToolStripMenuItem";
            resources.ApplyResources(this.productosALaVentaToolStripMenuItem, "productosALaVentaToolStripMenuItem");
            this.productosALaVentaToolStripMenuItem.Click += new System.EventHandler(this.productosALaVentaToolStripMenuItem_Click);
            // 
            // combosPromocionesToolStripMenuItem
            // 
            this.combosPromocionesToolStripMenuItem.Name = "combosPromocionesToolStripMenuItem";
            resources.ApplyResources(this.combosPromocionesToolStripMenuItem, "combosPromocionesToolStripMenuItem");
            this.combosPromocionesToolStripMenuItem.Click += new System.EventHandler(this.combosPromocionesToolStripMenuItem_Click);
            // 
            // tsMiCargas
            // 
            this.tsMiCargas.Name = "tsMiCargas";
            resources.ApplyResources(this.tsMiCargas, "tsMiCargas");
            this.tsMiCargas.Click += new System.EventHandler(this.tsMiCargas_Click);
            // 
            // tsiProovedores
            // 
            this.tsiProovedores.Name = "tsiProovedores";
            resources.ApplyResources(this.tsiProovedores, "tsiProovedores");
            this.tsiProovedores.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // tsiCompras
            // 
            this.tsiCompras.Name = "tsiCompras";
            resources.ApplyResources(this.tsiCompras, "tsiCompras");
            this.tsiCompras.Click += new System.EventHandler(this.ComprasTst_Click);
            // 
            // tsiClientes
            // 
            this.tsiClientes.Name = "tsiClientes";
            resources.ApplyResources(this.tsiClientes, "tsiClientes");
            this.tsiClientes.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // cajasToolStripMenuItem
            // 
            this.cajasToolStripMenuItem.Name = "cajasToolStripMenuItem";
            resources.ApplyResources(this.cajasToolStripMenuItem, "cajasToolStripMenuItem");
            this.cajasToolStripMenuItem.Click += new System.EventHandler(this.cajasToolStripMenuItem_Click);
            // 
            // tsmVentas
            // 
            this.tsmVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiPedido,
            this.tsiCierreCaja});
            resources.ApplyResources(this.tsmVentas, "tsmVentas");
            this.tsmVentas.ForeColor = System.Drawing.Color.White;
            this.tsmVentas.Name = "tsmVentas";
            // 
            // tsiPedido
            // 
            this.tsiPedido.Name = "tsiPedido";
            resources.ApplyResources(this.tsiPedido, "tsiPedido");
            this.tsiPedido.Click += new System.EventHandler(this.pedidosToolStripMenuItem1_Click);
            // 
            // tsiCierreCaja
            // 
            this.tsiCierreCaja.Name = "tsiCierreCaja";
            resources.ApplyResources(this.tsiCierreCaja, "tsiCierreCaja");
            this.tsiCierreCaja.Click += new System.EventHandler(this.tsiCierreCaja_Click);
            // 
            // tsmSeguridad
            // 
            this.tsmSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiUsuarios,
            this.tsiBitacora});
            resources.ApplyResources(this.tsmSeguridad, "tsmSeguridad");
            this.tsmSeguridad.ForeColor = System.Drawing.Color.White;
            this.tsmSeguridad.Name = "tsmSeguridad";
            // 
            // tsiUsuarios
            // 
            this.tsiUsuarios.Name = "tsiUsuarios";
            resources.ApplyResources(this.tsiUsuarios, "tsiUsuarios");
            this.tsiUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // tsiBitacora
            // 
            this.tsiBitacora.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraDeCambiosToolStripMenuItem,
            this.consecutivosToolStripMenuItem});
            this.tsiBitacora.Name = "tsiBitacora";
            resources.ApplyResources(this.tsiBitacora, "tsiBitacora");
            // 
            // bitacoraDeCambiosToolStripMenuItem
            // 
            this.bitacoraDeCambiosToolStripMenuItem.Name = "bitacoraDeCambiosToolStripMenuItem";
            resources.ApplyResources(this.bitacoraDeCambiosToolStripMenuItem, "bitacoraDeCambiosToolStripMenuItem");
            this.bitacoraDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.bitacoraDeCambiosToolStripMenuItem_Click);
            // 
            // consecutivosToolStripMenuItem
            // 
            this.consecutivosToolStripMenuItem.Name = "consecutivosToolStripMenuItem";
            resources.ApplyResources(this.consecutivosToolStripMenuItem, "consecutivosToolStripMenuItem");
            this.consecutivosToolStripMenuItem.Click += new System.EventHandler(this.consecutivosToolStripMenuItem_Click_1);
            // 
            // tsmVentanas
            // 
            resources.ApplyResources(this.tsmVentanas, "tsmVentanas");
            this.tsmVentanas.ForeColor = System.Drawing.Color.White;
            this.tsmVentanas.Name = "tsmVentanas";
            // 
            // tsmAyuda
            // 
            resources.ApplyResources(this.tsmAyuda, "tsmAyuda");
            this.tsmAyuda.ForeColor = System.Drawing.Color.White;
            this.tsmAyuda.Name = "tsmAyuda";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            resources.ApplyResources(this.reportesToolStripMenuItem, "reportesToolStripMenuItem");
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // tmerTiempo
            // 
            this.tmerTiempo.Tick += new System.EventHandler(this.tmerTiempo_Tick);
            // 
            // parametrosGeneralesToolStripMenuItem
            // 
            this.parametrosGeneralesToolStripMenuItem.Name = "parametrosGeneralesToolStripMenuItem";
            resources.ApplyResources(this.parametrosGeneralesToolStripMenuItem, "parametrosGeneralesToolStripMenuItem");
            this.parametrosGeneralesToolStripMenuItem.Click += new System.EventHandler(this.parametrosGeneralesToolStripMenuItem_Click);
            // 
            // FrmMenuPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grbMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menumain);
            this.IsMdiContainer = true;
            this.Name = "FrmMenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grbMain.ResumeLayout(false);
            this.grbMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsuario)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menumain.ResumeLayout(false);
            this.menumain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox grbMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menumain;
        private System.Windows.Forms.ToolStripMenuItem tsmSistema;
        private System.Windows.Forms.ToolStripMenuItem tsiCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsiSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmAdministracion;
        private System.Windows.Forms.ToolStripMenuItem tsiInsumosG;
        private System.Windows.Forms.ToolStripMenuItem tsiOperacionesInsumos;
        private System.Windows.Forms.ToolStripMenuItem tsiUnidadesMedida;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiProovedores;
        private System.Windows.Forms.ToolStripMenuItem tsiCompras;
        private System.Windows.Forms.ToolStripMenuItem tsiClientes;
        private System.Windows.Forms.ToolStripMenuItem tsmVentas;
        private System.Windows.Forms.ToolStripMenuItem tsiPedido;
        private System.Windows.Forms.ToolStripMenuItem tsmSeguridad;
        private System.Windows.Forms.ToolStripMenuItem tsiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsiBitacora;
        private System.Windows.Forms.ToolStripMenuItem bitacoraDeCambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consecutivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmVentanas;
        private System.Windows.Forms.ToolStripMenuItem tsmAyuda;
        private System.Windows.Forms.Timer tmerTiempo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pcbUsuario;
        private System.Windows.Forms.LinkLabel lnkUsuario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripMenuItem tsiAbout;
        private System.Windows.Forms.ToolStripMenuItem productosALaVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combosPromocionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMiCargas;
        private System.Windows.Forms.ToolStripMenuItem tsiCierreCaja;
        private System.Windows.Forms.ToolStripMenuItem cajasToolStripMenuItem;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ToolStripMenuItem tsiPasswordChange;
        private System.Windows.Forms.ToolStripMenuItem parametrosDeImpresiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosGeneralesToolStripMenuItem;
    }
}




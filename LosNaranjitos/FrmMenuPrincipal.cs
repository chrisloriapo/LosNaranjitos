using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosNaranjitos
{
    public partial class FrmMenuPrincipal : Form
    {
        private int childFormNumber = 0;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        public static GroupBox GR = new GroupBox();

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUsuarios a = new FrmUsuarios();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Usuarios ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProveedor a = new FrmProveedor();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Proveedores ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pedidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpCaja.ListarCajas().Where(x => x.Estado == true && x.OperadorActual == FrmLogin.UsuarioGlobal.Username).Count() > 0)
                {
                    grbMain.Visible = false;
                    FrmPedido a = new FrmPedido();
                    a.MdiParent = this;
                    a.ControlBox = false;
                    a.MinimizeBox = false;
                    a.MaximizeBox = false;
                    a.Show();
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Pedidos ");
                }
                else
                {
                    grbMain.Visible = false;
                    FrmAperturaCaja a = new FrmAperturaCaja();
                    a.MdiParent = this;
                    a.ControlBox = false;
                    a.MinimizeBox = false;
                    a.MaximizeBox = false;
                    a.Show();
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Pedidos ");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)

        {
            var mensaje = MessageBox.Show("¿Desea salir del sistema?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (mensaje == DialogResult.Yes)
            {
                this.Dispose();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Aplicación ");
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tstICerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLogin ReLog = new FrmLogin();
                ReLog.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Sesion");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCliente a = new FrmCliente();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Clientes ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insumosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmInsumos a = new FrmInsumos();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Insumos/Inventario ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void unidadesDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMedidas a = new FrmMedidas();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Unidades de Medidas ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bitacoraDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBitacora a = new FrmBitacora();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Bitacora ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consecutivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    FrmConsecutivo a = new FrmConsecutivo();
            //    a.MdiParent = this;
            //    a.ControlBox = false;
            //    a.MinimizeBox = false;
            //    a.MaximizeBox = false;
            //    a.Dock = DockStyle.Fill;
            //    a.Show();
            //    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Consecutivos ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            tmerTiempo.Start();
            lnkUsuario.Text = FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1;
            GR = grbMain;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.White;
                }
            }
        }

        private void consecutivosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    FrmErrores a = new FrmErrores();
            //    a.MdiParent = this;
            //    a.ControlBox = false;
            //    a.MinimizeBox = false;
            //    a.MaximizeBox = false;
            //    a.Dock = DockStyle.Fill;
            //    a.Show();
            //    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Consecutivos ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tmerTiempo_Tick(object sender, EventArgs e)
        {
            lblDate.Text = "Fecha: " + DateTime.Today.ToShortDateString();
            lblTime.Text = "Hora: " + DateTime.Now.ToShortTimeString();
        }

        private void tstabout_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAbout a = new FrmAbout();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill; a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Se mostro el formulario de Acerca De ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productosALaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProductosVenta a = new FrmProductosVenta();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill; 
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Productos ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void combosPromocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCombo a = new FrmCombo();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Combos/Promociones ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ComprasTst_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCompras a = new FrmCompras();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill; 
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Compras ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsMiCargas_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargas a = new FrmCargas();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cargas-Impuestos ");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsiCierreCaja_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCierreCajero a = new FrmCierreCajero();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();


                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cierres ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCajaMantenimiento a = new FrmCajaMantenimiento();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cierres ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporteVentas a = new FrmReporteVentas();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cierres ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeCierresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporteCierres a = new FrmReporteCierres();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cierres ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporteInsumos a = new FrmReporteInsumos();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cierres ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporteProductos a = new FrmReporteProductos();
                a.MdiParent = this;
                a.ControlBox = false;
                a.MinimizeBox = false;
                a.MaximizeBox = false;
                a.Dock = DockStyle.Fill;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Registro de Cierres ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios a = new FrmUsuarios();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
                        a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Usuarios ");

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductosVenta a = new FrmProductosVenta();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Productos ");

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor a = new FrmProveedor();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Proveedores ");

        }

        private void lnkUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void pedidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPedido a = new FrmPedido();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Pedidos ");

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
            foreach (Form frm in Application.OpenForms)
            {
                frm.Close();
            }
            FrmLogin ReLog = new FrmLogin();
            ReLog.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Sesion");

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente a = new FrmCliente();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Clientes ");

        }

        private void insumosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmInsumos a = new FrmInsumos();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Insumos/Inventario ");

        }

        private void unidadesDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedidas a = new FrmMedidas();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Unidades de Medidas ");

        }


        private void promocionesCombosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCombo a = new FrmCombo();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Combos/Promociones ");

        }




        private void bitacoraDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora a = new FrmBitacora();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Bitacora ");

        }

        private void consecutivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsecutivo a = new FrmConsecutivo();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Consecutivos ");

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            tmerTiempo.Start();
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
            FrmErrores a = new FrmErrores();
            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Consecutivos ");

        }

        private void tmerTiempo_Tick(object sender, EventArgs e)
        {
            lblDate.Text = "Fecha: " + DateTime.Today.ToShortDateString();
            lblTime.Text = "Hora: " + DateTime.Now.ToShortTimeString();
        }
    }
}

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
    public partial class FrmMenuCaja : Form
    {
        public FrmMenuCaja()
        {
            InitializeComponent();
        }

        private void btnAperturaCaja_Click(object sender, EventArgs e)
        {

            FrmPedido a = new FrmPedido();
            a.WindowState = FormWindowState.Maximized;
            a.Show();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Caja desde menu de Caja ");
        }

        private void btnSalir_Click(object sender, EventArgs e)
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
                return;
            }
        }
    }
}

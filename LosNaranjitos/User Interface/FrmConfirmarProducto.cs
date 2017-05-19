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
    public partial class FrmConfirmarProducto : Form
    {
        public FrmConfirmarProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmConfirmarProducto_Load(object sender, EventArgs e)
        {
            txtResumen.Text = FrmProductosVenta.Summary;
        }

        private void FrmConfirmarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mensaje = MessageBox.Show("¿Desea Descartar el Producto?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (mensaje == DialogResult.Yes)
            {
                this.Dispose();
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name != "FrmMenuPrincipal")
                    {
                        frm.Close();
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

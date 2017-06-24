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
    public partial class FrmCambioCaja : Form
    {
        public FrmCambioCaja()
        {
            InitializeComponent();
        }

        public static string CambioShow;

        private void FrmCambioCaja_Load(object sender, EventArgs e)
        {

            lblCambio.Text = "₡" + CambioShow;
        }
    }
}

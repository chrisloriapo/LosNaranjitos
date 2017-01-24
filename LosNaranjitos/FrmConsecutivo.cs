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
    public partial class FrmConsecutivo : Form
    {
        BL.Interfaces.IConsecutivo OperacionesConsec = new BL.Clases.Consecutivo();
        public FrmConsecutivo()
        {
            InitializeComponent();
        }

        private void Carga(object sender, EventArgs e)
        {
            dgvConsecutivo.DataSource = OperacionesConsec.ListarConsecutivos();
        }
    }
}

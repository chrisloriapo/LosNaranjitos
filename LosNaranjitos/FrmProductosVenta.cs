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
    public partial class FrmProductosVenta : Form
    {
        public FrmProductosVenta()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductosVenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'orangeDB1DataSet.VProveedor_Insumo' Puede moverla o quitarla según sea necesario.
            this.vProveedor_InsumoTableAdapter.Fill(this.orangeDB1DataSet.VProveedor_Insumo);

        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DATOS.ProductoInsumo> Receta = Utilitarios.OpProductoInsumo.ListarProductoInsumo();
            List<DATOS.Insumos> Insumos = Utilitarios.OpInsumos.ListarInsumos();

            var result = Utilitarios.OpInsumos.ListarInsumos().Join(
                Receta,
            a => a.IdInsumo,
            b => b.IdInsumo,
            (a, b) => new { b.Consecutivo, b.IdInsumo, a.Nombre, b.CantidadRequerida });

            dgvListado.DataSource = result.ToList();
            dgvListado.RowHeadersVisible = false;
            dgvListado.ColumnHeadersVisible = false;
            dgvListado.GridColor = Color.White;
            dgvListado.BackgroundColor = Color.White;

            foreach (var item in result)
            {
                ListViewItem Itemx = new ListViewItem(item.Consecutivo);
                Itemx.SubItems.Add(item.IdInsumo);
                Itemx.SubItems.Add(item.Nombre);
                Itemx.SubItems.Add(item.CantidadRequerida.ToString());

            }
            this.reportViewer1.RefreshReport();
        }
    }
}

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
    public partial class FrmEdicionFacturaCompra : Form
    {
        public FrmEdicionFacturaCompra()
        {
            InitializeComponent();
        }
        public static DATOS.FacturaCompra FacturaEditar = new DATOS.FacturaCompra();


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.Cambio = false;
            this.Dispose();
        }

        private void cbbFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FacturaEditar = Utilitarios.OpFacturaCompra.BuscarFactura(cbbFactura.SelectedValue.ToString());
                lblObservaciones.Text = "Observaciones : " + FacturaEditar.Observaciones;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Facturas de Compra al Intentar Seleccionar la Factura a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FacturaEditar = Utilitarios.OpFacturaCompra.BuscarFactura(cbbFactura.SelectedValue.ToString());
            FrmCompras.EditFacturaCompra = FacturaEditar;
            Utilitarios.Cambio = true;
          
            FrmCompras a = new FrmCompras();
            a.MdiParent = FrmLogin.MN;
            a.Dock = DockStyle.Fill;
            a.Show();
            this.Dispose();
        }

        private void FrmEdicionFacturaCompra_Load(object sender, EventArgs e)
        {
            try
            {
                cbbFactura.DataSource = Utilitarios.OpFacturaCompra.ListarFacturas().Select(p => p.IdFactura).ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Facturas de Compra al Intentar Seleccionar la Factura a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

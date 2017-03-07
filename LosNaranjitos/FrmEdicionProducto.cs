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
    public partial class FrmEdicionProducto : Form
    {
        public static DATOS.Producto ProductoEditar = new DATOS.Producto();

        public FrmEdicionProducto()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbProducto.DataSource = Utilitarios.OpProducto.ListarProductos().Select(p => p.Nombre).ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Intentar Seleccionar el Producto a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductoEditar = Utilitarios.OpProducto.ListarProductos().FirstOrDefault(x => x.Nombre == cbbProducto.SelectedValue.ToString());
                lblNombre.Text = "Codigo: " + ProductoEditar.Codigo;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Intentar Seleccionar el Producto a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.Cambio = false;
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ProductoEditar = Utilitarios.OpProducto.ListarProductos().FirstOrDefault(x => x.Nombre == cbbProducto.SelectedValue.ToString());
            FrmProductosVenta.EditProducto = ProductoEditar;
            Utilitarios.Cambio = true;

            this.Dispose();
            FrmProductosVenta a = new FrmProductosVenta();
            a.MdiParent = FrmLogin.MN;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }
    }
}

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
        BL.Interfaces.IProducto OpProducto = new BL.Clases.Producto();
        BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        DATOS.Error ER = new DATOS.Error();
        public static DATOS.Producto ProductoEditar = new DATOS.Producto();

        public FrmEdicionProducto()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbProducto.DataSource = OpProducto.ListarProductos().Select(p => p.Nombre).ToList();
            }
            catch (Exception ex)
            {

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductoEditar = OpProducto.ListarProductos().FirstOrDefault(x => x.Nombre == cbbProducto.SelectedValue.ToString());
                lblNombre.Text = "Codigo: " + ProductoEditar.Codigo;
            }
            catch (Exception ex)
            {
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
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
            ProductoEditar = OpProducto.ListarProductos().FirstOrDefault(x => x.Nombre == cbbProducto.SelectedValue.ToString());
            FrmProductosVenta.EditProducto = ProductoEditar;
            Utilitarios.Cambio = true;

            this.Dispose();
            FrmProductosVenta a = new FrmProductosVenta();
            a.MdiParent = FrmLogin.MN;
            a.Show();
        }
    }
}

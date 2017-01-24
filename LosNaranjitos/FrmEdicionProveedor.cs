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
    public partial class FrmEdicionProveedor : Form
    {
        BL.Interfaces.IProveedor OpProveedor = new BL.Clases.Proveedor();
        BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        DATOS.Error ER = new DATOS.Error();
        public static DATOS.Proveedor ProveedorEditar = new DATOS.Proveedor();

        public FrmEdicionProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.Cambio = false;
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ProveedorEditar = OpProveedor.ListarProveedores().FirstOrDefault(x => x.Nombre == cbbProveedores.SelectedValue.ToString());
            FrmProveedor.EditProveedor = ProveedorEditar;
            Utilitarios.Cambio = true;
            this.Dispose();
            FrmProveedor a = new FrmProveedor();
            a.Show();
        }

        private void FrmEdicionProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                cbbProveedores.DataSource = OpProveedor.ListarProveedores().Select(p => p.Nombre).ToList();
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

        private void cbbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProveedorEditar = OpProveedor.ListarProveedores().FirstOrDefault(x => x.Nombre == cbbProveedores.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + ProveedorEditar.Nombre;
                lblIdPersonal.Text = "Id Proveedor: " + ProveedorEditar.IdProveedor;
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
    }
}

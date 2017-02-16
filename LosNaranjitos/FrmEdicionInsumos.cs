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
    public partial class FrmEdicionInsumos : Form
    {
        public static DATOS.Insumos InsumosEditar = new DATOS.Insumos();

        public FrmEdicionInsumos()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbInsumos.DataSource = Utilitarios.OpInsumos.ListarInsumos().Select(p => p.IdInsumo).ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Seleccionar el Insumo a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                InsumosEditar = Utilitarios.OpInsumos.ListarInsumos().FirstOrDefault(x => x.IdInsumo == cbbInsumos.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + InsumosEditar.Nombre;
                lblIdPersonal.Text = "Id : " + InsumosEditar.IdInsumo   ;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Seleccionar el Insumo a editar");
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
            InsumosEditar = Utilitarios.OpInsumos.ListarInsumos().FirstOrDefault(x => x.IdInsumo == cbbInsumos.SelectedValue.ToString());
            FrmInsumos.EditInsumo = InsumosEditar;
            Utilitarios.Cambio = true;
            this.Dispose();
            FrmInsumos a = new FrmInsumos();
            a.MdiParent = FrmLogin.MN;
            a.WindowState = FormWindowState.Maximized;
            a.Show();

        }
    }
}

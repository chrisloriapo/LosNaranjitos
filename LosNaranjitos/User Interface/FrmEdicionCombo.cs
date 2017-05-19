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
    public partial class FrmEdicionCombo : Form
    {
        public FrmEdicionCombo()
        {
            InitializeComponent();
        }
        public static DATOS.Combo ComboEditar = new DATOS.Combo();

        private void FrmEdicionCombo_Load(object sender, EventArgs e)
        {
            try
            {
                cbbCombos.DataSource = Utilitarios.OpCombo.ListarCombo().Select(p => p.Nombre).ToList();
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Intentar Seleccionar el Combo a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbCombos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboEditar = Utilitarios.OpCombo.ListarCombo().FirstOrDefault(x => x.Nombre == cbbCombos.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + ComboEditar.Nombre;
                lblDescricpion.Text = "Descripcion: " + ComboEditar.Descripcion;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Intentar Seleccionar el Combo a editar");
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
            ComboEditar = Utilitarios.OpCombo.ListarCombo().FirstOrDefault(x => x.Nombre == cbbCombos.SelectedValue.ToString());
            FrmCombo.EditCombo = ComboEditar;
            Utilitarios.Cambio = true;
         
            FrmCombo a = new FrmCombo();
            a.WindowState = FormWindowState.Maximized;
            a.MdiParent = FrmLogin.MN;
            a.Show();
            this.Dispose();
        }
    }
}

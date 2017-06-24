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
    public partial class FrmEdicionMedida : Form
    {

        public static DATOS.Medida MedidaEditar = new DATOS.Medida();

        public FrmEdicionMedida()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbMedida.DataSource = Utilitarios.OpMedidas.ListarMedidas().Select(p => p.IdMedida).ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Medidas al Intentar Seleccionar la Medida a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MedidaEditar = Utilitarios.OpMedidas.ListarMedidas().FirstOrDefault(x => x.IdMedida == cbbMedida.SelectedValue.ToString());
                lblNombre.Text = "Medida: " + MedidaEditar.Descripcion;
                lblIdPersonal.Text = "Unidad de Medida: " + MedidaEditar.IdMedida;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Medidas al Intentar Seleccionar la Medida a editar");
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
            MedidaEditar = Utilitarios.OpMedidas.ListarMedidas().FirstOrDefault(x => x.IdMedida == cbbMedida.SelectedValue.ToString());
            FrmMedidas.EditMedida = MedidaEditar;
            Utilitarios.Cambio = true;

     
            FrmMedidas a = new FrmMedidas();
            a.MdiParent = FrmLogin.MN;
            a.Show();
            this.Dispose();
        }
    }
}

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
    public partial class FrmEdicionCargas : Form
    {
        public FrmEdicionCargas()
        {
            InitializeComponent();
        }
        public static DATOS.Cargas CargasEditar = new DATOS.Cargas();

        private void FrmEdicionCargas_Load(object sender, EventArgs e)
        {
            try
            {
                cbbCargas.DataSource = Utilitarios.OpCargas.ListarCargas().Select(p => p.Consecutivo).ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Intentar Seleccionar el Cliente a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbCargas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargasEditar = Utilitarios.OpCargas.ListarCargas().FirstOrDefault(x => x.Consecutivo == cbbCargas.SelectedValue.ToString());
                lblNombre.Text = "Descripción: " + CargasEditar.Descripcion ;
                lblIdPersonal.Text = "Porcentaje de Carga: " + CargasEditar.Porcentaje;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Intentar Seleccionar el Cliente a editar");
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
            CargasEditar = Utilitarios.OpCargas.ListarCargas().FirstOrDefault(x => x.Consecutivo == cbbCargas.SelectedValue.ToString());
            FrmCargas.EditarCarga = CargasEditar;
            Utilitarios.Cambio = true;

            this.Dispose();
            FrmUsuarios a = new FrmUsuarios();

            a.Show();
        }
    }
}

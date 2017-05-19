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
    public partial class FrmEdicionCliente : Form
    {
        public static DATOS.Cliente ClienteEditar = new DATOS.Cliente();

        public FrmEdicionCliente()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbCliente.DataSource = Utilitarios.OpClientes.ListarClientes().Select(p => p.IdPersonal).ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Intentar Seleccionar el Cliente a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClienteEditar = Utilitarios.OpClientes.ListarClientes().FirstOrDefault(x => x.IdPersonal == cbbCliente.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + ClienteEditar.Nombre + " " + ClienteEditar.Apellido1 + " " + ClienteEditar.Apellido2;
                lblIdPersonal.Text = "Id Personal: " + ClienteEditar.IdPersonal;
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
            ClienteEditar = Utilitarios.OpClientes.ListarClientes().FirstOrDefault(x => x.IdPersonal == cbbCliente.SelectedValue.ToString());
            FrmCliente.EditCLiente = ClienteEditar;
            Utilitarios.Cambio = true;

            this.Dispose();
            FrmUsuarios a = new FrmUsuarios();

            a.Show();
        }
    }
}

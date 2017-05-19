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
    public partial class FrmEdicionUsuario : Form
    {
        public static DATOS.Usuario UsuarioEditar = new DATOS.Usuario();

        public FrmEdicionUsuario()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbUsuarios.DataSource = Utilitarios.OpUsuarios.ListarUsuarios().Select(p => p.Username).ToList();
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Seleccionar el usuario a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UsuarioEditar = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault(x => x.Username == cbbUsuarios.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + UsuarioEditar.Nombre + " " + UsuarioEditar.Apellido1 + " " + UsuarioEditar.Apellido2;
                lblIdPersonal.Text = "Id Personal: " + UsuarioEditar.IdPersonal;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Seleccionar el usuario a editar");
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
            UsuarioEditar = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault(x => x.Username == cbbUsuarios.SelectedValue.ToString());
            FrmUsuarios.EditUser = UsuarioEditar;
            Utilitarios.Cambio = true;

            FrmUsuarios a = new FrmUsuarios();
            a.MdiParent = FrmLogin.MN;
            a.WindowState= FormWindowState.Maximized;
            a.Show();
            this.Dispose();
        }
    }
}

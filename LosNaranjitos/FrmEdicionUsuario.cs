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
        BL.Interfaces.IUsuario OpUsuarios = new BL.Clases.Usuario();
        BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        DATOS.Error ER = new DATOS.Error();
        public static DATOS.Usuario UsuarioEditar = new DATOS.Usuario();

        public FrmEdicionUsuario()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbUsuarios.DataSource = OpUsuarios.ListarUsuarios().Select(p => p.IdUsuario).ToList();
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
                UsuarioEditar = OpUsuarios.ListarUsuarios().FirstOrDefault(x => x.IdUsuario == cbbUsuarios.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + UsuarioEditar.Nombre + " " + UsuarioEditar.Apellido1 + " " + UsuarioEditar.Apellido2;
                lblIdPersonal.Text = "Id Personal: " + UsuarioEditar.IdPersonal;
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
            UsuarioEditar = OpUsuarios.ListarUsuarios().FirstOrDefault(x => x.IdUsuario == cbbUsuarios.SelectedValue.ToString());
            FrmUsuarios.EditUser = UsuarioEditar;
            Utilitarios.Cambio = true;

            this.Dispose();
            FrmUsuarios a = new FrmUsuarios();
            a.MdiParent = FrmLogin.MN;
            a.WindowState= FormWindowState.Maximized;
            a.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosNaranjitos.User_Interface
{
    public partial class FrmPasswordChange : Form
    {
        public FrmPasswordChange()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            try
            {
                FrmLogin ReLog = new FrmLogin();
                ReLog.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Sesion");
                FrmLogin.MN.Dispose();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtConfirmacion.Text) || string.IsNullOrWhiteSpace(txtConfirmacion.Text) || string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("Debes Digitar una contraseña Nueva ", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (PanGood.BackColor == Color.Green && (txtConfirmacion.Text == txtContraseña.Text) && (FrmLogin.UsuarioGlobal.Contrasena == txtContrasenaAntigua.Text))
                {
                    if (FrmLogin.UsuarioGlobal.Contrasena==txtContraseña.Text)
                    {
                        MessageBox.Show("Debes Digitar una contraseña Nueva, no puede ser igual a la anterior ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FrmLogin.UsuarioGlobal.Contrasena = txtContraseña.Text;
                    FrmLogin.UsuarioGlobal.CambioContrasena = false;
                    FrmLogin.UsuarioGlobal.UltimoContrasena = DateTime.Now;
                    Utilitarios.OpUsuarios.ActualizarUsuario(FrmLogin.UsuarioGlobal);

                    MessageBox.Show("Contraseña Actualizada ", "Contraseña Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(Utilitarios.Decriptar( FrmLogin.UsuarioGlobal.Username,Utilitarios.Llave), "Contraseña del usuario: " + FrmLogin.UsuarioGlobal.Username + " Cambiada");
                    FrmLogin.MN.Dispose();
                    FrmLogin ReLog = new FrmLogin();
                    ReLog.Show();
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Sesion");
                    this.Dispose();
                }
                else
                {

                    MessageBox.Show("Tu contraseña actual es incorrecta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Tools.PasswordPolicy.IsValid(txtContraseña.Text);
                if (Tools.PasswordPolicy.Score == 3)
                {
                    PanAverage.BackColor = Color.Orange;
                    PanWeek.BackColor = Color.Orange;
                    PanGood.BackColor = Color.Red;
                    btnCambiar.Enabled = false;

                }
                else if (Tools.PasswordPolicy.Score < 3)
                {
                    PanAverage.BackColor = Color.Red;
                    PanWeek.BackColor = Color.Red;
                    PanGood.BackColor = Color.Red;
                    btnCambiar.Enabled = false;

                }
                else
                {
                    PanAverage.BackColor = Color.Green;
                    PanWeek.BackColor = Color.Green;
                    PanGood.BackColor = Color.Green;
                    btnCambiar.Enabled = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPasswordChange_Load(object sender, EventArgs e)
        {
            
            btnCambiar.Enabled = false;
        }
    }
}

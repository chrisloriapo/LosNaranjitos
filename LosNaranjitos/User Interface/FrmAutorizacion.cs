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
    public partial class FrmAutorizacion : Form
    {
        public FrmAutorizacion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(txtComentario.Text) || String.IsNullOrEmpty(txtComentario.Text))
                {
                    MessageBox.Show("Debes ingresar un comentario de Aprobacion", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtComentario.Focus();
                    return;
                }
                if (!Utilitarios.OpUsuarios.ExisteUsuario(txtUsuario.Text.ToLower()))
                {
                    MessageBox.Show("Usuario No existe", "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    txtUsuario.Focus();
                    return;
                }
                else
                {
                    Utilitarios.Autorizante = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(txtUsuario.Text.ToLower());
                    if (Utilitarios.Autorizante.Rol==1 || Utilitarios.Autorizante.Rol == 2)
                    {
                        if (Utilitarios.Autorizante.Contrasena == txtPassword.Text)
                        {
                            Utilitarios.CambioEnCajas = true;
                            Utilitarios.ComentarioAutorizacion = txtComentario.Text;
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta", "No Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtPassword.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario No Posee la autoridad suficiente para aprobar el cambio", "No Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Clear();
                        txtPassword.Clear();
                        txtUsuario.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error al Popular Datos", FrmLogin.UsuarioGlobal.Username, "Error durante Autorizacion del Sistema ");
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void FrmAutorizacion_Load(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsuario.Clear();
            txtComentario.Clear();
            Utilitarios.Autorizante = new DATOS.Usuario();
            Utilitarios.ComentarioAutorizacion = "";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.CambioEnCajas = false;
            this.Dispose();
        }
    }
}

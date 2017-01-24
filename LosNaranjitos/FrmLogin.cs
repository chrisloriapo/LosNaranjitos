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
    public partial class FrmLogin : Form
    {
        BL.Interfaces.IUsuario UsuarioOperaciones = new BL.Clases.Usuario();
        public static DATOS.Usuario UsuarioGlobal = new DATOS.Usuario();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal MN = new FrmMenuPrincipal();
            bool Ingreso =ValidarUser();
            if (Ingreso)
            {
                MN.Show();
                this.Hide();
            }
        }

        public bool ValidarUser()
        {

            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    bool ExisteUser = UsuarioOperaciones.ExisteUsuario(Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave));
                    UsuarioGlobal = UsuarioOperaciones.BuscarUsuarioXUsername(Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave));
                    if ((Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave) == UsuarioGlobal.IdUsuario) &&
                   (Utilitarios.Encriptar(txtPassword.Text, Utilitarios.Llave) == UsuarioGlobal.Contrasena))
                    {

                        return true;
                    }
                    else if ((Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave) == UsuarioGlobal.IdUsuario) &&
                        (Utilitarios.Encriptar(txtPassword.Text, Utilitarios.Llave) != UsuarioGlobal.Contrasena))
                    {
                        MessageBox.Show("Credenciales Incorrectos\n Trate de nuevo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                        return false;
                    }
                    else
                    {
                        return false; 
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                    {
                        MessageBox.Show("Usuario No Existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnIngresar_Click(sender, e);
            }
        }
    }
}

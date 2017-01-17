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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //FrmMenuPrincipal MN = new FrmMenuPrincipal();
            //MN.Show();
            try
            {
                FrmMenuPrincipal MN = new FrmMenuPrincipal();
               
                bool ExisteUser = UsuarioOperaciones.ExisteUsuario(Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave));
                if (ExisteUser)
                {
                    UsuarioGlobal = UsuarioOperaciones.BuscarUsuarioXUsername(Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave));

                    if ((Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave) == UsuarioGlobal.IdUsuario) &&
                    (Utilitarios.Encriptar(txtPassword.Text, Utilitarios.Llave) == UsuarioGlobal.Contrasena))
                    {


                        MessageBox.Show("ACCESO RESTRINGIDO\n Todo movimiento o transacción durante su sesión será monitoreado",
                                        "PRECAUCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MN.Show();
                        this.Hide();
                    }
                    else if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPassword.Text) ||
                        String.IsNullOrWhiteSpace(txtUsuario.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();

                    }
                    else if ((Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave) == UsuarioGlobal.IdUsuario) &&
                        (Utilitarios.Encriptar(txtPassword.Text, Utilitarios.Llave) != UsuarioGlobal.Contrasena))
                    {
                        MessageBox.Show("Credenciales Incorrectos\n Trate de nuevo", "ERROR",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                    }

                }

                else
                {
                    MessageBox.Show("Usuario No Existe", "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }



            }
            catch (Exception ex)
            {
                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    MessageBox.Show("Usuario No Existe", "ERROR",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
                else
                {

                    MessageBox.Show(ex.Message, "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}

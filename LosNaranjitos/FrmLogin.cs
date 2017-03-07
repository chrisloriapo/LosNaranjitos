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
        public DATOS.Error ER = new DATOS.Error();
        public DATOS.Bitacora BIT = new DATOS.Bitacora();
        public static DATOS.Usuario UsuarioGlobal = new DATOS.Usuario();
        public static FrmMenuPrincipal MN = new FrmMenuPrincipal();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //try
            //{
                FrmMenuCaja MC = new FrmMenuCaja();

                bool Ingreso = ValidarUser();
                if (Ingreso)
                {
                    if (UsuarioGlobal.Rol == "ROL-3")
                    {
                        MC.Show();
                        this.Hide();
                    }
                    else
                    {
                        MN = new FrmMenuPrincipal();
                        MN.Show();
                        this.Hide();
                    }
                    Utilitarios.GeneralBitacora(UsuarioGlobal.Username, "Ingreso al Sistema");

                }
         //  }
//            catch (Exception ex)
//            {
//                if (ex.Message == "No se puede obtener acceso al objeto desechado.Nombre del objeto: 'FrmMenuPrincipal'.")
//                {
//FrmMenuPrincipal MNN =new FrmMenuPrincipal()
//                }

                   //     }


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
                    bool ExisteUser = Utilitarios.OpUsuarios.ExisteUsuario(Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave));
                    UsuarioGlobal = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave));
                    if ((Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave) == UsuarioGlobal.Username) &&
                   (Utilitarios.Encriptar(txtPassword.Text, Utilitarios.Llave) == UsuarioGlobal.Contrasena))
                    {
                        return true;
                    }
                    else if ((Utilitarios.Encriptar(txtUsuario.Text, Utilitarios.Llave) == UsuarioGlobal.Username) &&
                        (Utilitarios.Encriptar(txtPassword.Text, Utilitarios.Llave) != UsuarioGlobal.Contrasena))
                    {
                        Utilitarios.GeneralError("Intento de ingreso fallido del supuesto usuario" + txtUsuario.Text, "Ingreso Denegado", Utilitarios.Encriptar( txtUsuario.Text,Utilitarios.Llave), "Intento de ingreso fallido del supuesto usuario" + txtUsuario.Text);
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

                        Utilitarios.GeneralError("Intento de ingreso fallido del supuesto usuario " + txtUsuario.Text, "Ingreso Denegado",Utilitarios.Encriptar( txtUsuario.Text,Utilitarios.Llave), "Intento de ingreso fallido del supuesto usuario" + txtUsuario.Text);

                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                        return false;
                    }
                    else
                    {
                        Utilitarios.GeneralError(ex.Message, "Error Desconocido",Utilitarios.Encriptar( "No User logged",Utilitarios.Llave), "Error durante la validaciòn del usuario ");
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                Utilitarios.GeneralBitacora(Utilitarios.Encriptar("No User logged", Utilitarios.Llave), "Cierre de Aplicación ");
                Application.Exit();

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error al Popular Datos", Utilitarios.Encriptar("No User logged", Utilitarios.Llave), "Error durante la Salida del Sistema ");
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

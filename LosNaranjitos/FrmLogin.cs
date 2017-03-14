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
                    if (Utilitarios.OpUsuarios.ListarUsuarios().Count == 0)
                    {
                        DATOS.Usuario Userprivate = new DATOS.Usuario
                        {
                            Consecutivo = "USR-1",
                            Username = "admin",
                            Nombre = "Administrador",
                            Apellido1 = "SuperUsuario",
                            Apellido2 = " ",
                            Contrasena = "admin1",
                            Activo = true,
                            IdPersonal = "admin1",
                            Telefono = "0",
                            Correo = "nomail",
                            Rol = "ROL-1",
                            Direccion = "NoWhere",
                        };
                        Utilitarios.OpUsuarios.AgregarUsuario(Userprivate);
                        DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Usuario");
                        Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "No existen Usuarios previamente creados, ingreso de usuario default  admin");
                        MessageBox.Show("Es primer vez que el sistema se utiliza, debes utilizar los siguientes credenciales para ingresar: usuario: admin \n contraseña: admin1",
    "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    bool ExisteUser = Utilitarios.OpUsuarios.ExisteUsuario(txtUsuario.Text.ToLower());
                    UsuarioGlobal = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(txtUsuario.Text);
                    if (((txtUsuario.Text == UsuarioGlobal.Username) &&
                   (txtPassword.Text == UsuarioGlobal.Contrasena)))
                    {
                        return true;
                    }
                    else if ((txtUsuario.Text == UsuarioGlobal.Username) &&
                       (txtPassword.Text != UsuarioGlobal.Contrasena))
                    {
                        Utilitarios.GeneralError("Intento de ingreso fallido del supuesto usuario " + txtUsuario.Text, "Ingreso Denegado", txtUsuario.Text, " Intento de ingreso fallido del supuesto usuario " + txtUsuario.Text);
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

                        Utilitarios.GeneralError("Intento de ingreso fallido del supuesto usuario " + txtUsuario.Text, "Ingreso Denegado", txtUsuario.Text, " Intento de ingreso fallido del supuesto usuario " + txtUsuario.Text);

                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                        return false;
                    }
                    else
                    {
                        Utilitarios.GeneralError(ex.Message, "Error Desconocido", "No User logged", "Error durante la validaciòn del usuario ");
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
                Utilitarios.GeneralBitacora("No User logged", "Cierre de Aplicación ");
                Application.Exit();

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error al Popular Datos", "No User logged", "Error durante la Salida del Sistema ");
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

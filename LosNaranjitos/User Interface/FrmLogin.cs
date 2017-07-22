using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LosNaranjitos
{
    public partial class FrmLogin : Form
    {
        public DATOS.Error ER = new DATOS.Error();
        public DATOS.Bitacora BIT = new DATOS.Bitacora();
        public static DATOS.Usuario UsuarioGlobal = new DATOS.Usuario();
        public static FrmMenuPrincipal MN = new FrmMenuPrincipal();
        public static FrmMenuCaja MC = new FrmMenuCaja();
        public static int ConfigFlag = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            bool Ingreso = ValidarUser();
            if (Ingreso)
            {
                if (UsuarioGlobal.Rol == 3)
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

                    UsuarioGlobal = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(txtUsuario.Text.ToLower());
                    if (((txtUsuario.Text == UsuarioGlobal.Username) &&
                   (txtPassword.Text == UsuarioGlobal.Contrasena)) && UsuarioGlobal.Activo)
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
                    else if (!UsuarioGlobal.Activo)
                    {
                        Utilitarios.GeneralError("Intento de ingreso de usuario desactivado: " + txtUsuario.Text, "Ingreso Denegado", txtUsuario.Text, " Intento de ingreso fallido del usuario desactivado " + txtUsuario.Text);
                        MessageBox.Show("Usuario desactivado", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            try
            {
                DS._Conexion.CrearConexion().OpenDbConnection();
                Utilitarios.OpParametros.ListarRegistros();
            }
            catch (SqlException)
            {
                var mensaje = MessageBox.Show("Error al Conectarse a la Base de datos, \n ¿Desea Ingresar a la Configuración por Primer Vez?", "Advertencia",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    ConfigFlag = 1;
                    DS.FrmConfiguracion ConfigIn = new DS.FrmConfiguracion();
                    ConfigIn.Show();
                    ConfigIn.TopMost = true;
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    Application.Exit(); ;
                }
            }

            timer1.Start();
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

        private void lblPasswordReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    if (Utilitarios.OpUsuarios.ExisteUsuario(txtUsuario.Text.ToLower()))
                    {
                        var mensaje = MessageBox.Show("¿Desea Solicitar la contraseña del usuario " + txtUsuario.Text.ToLower() + "?\n Si acepta la próxima vez deberá cambiar su contraseña ", "Advertencia",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (mensaje == DialogResult.Yes)
                        {
                            DATOS.Usuario TempUser = new DATOS.Usuario();
                            TempUser = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(txtUsuario.Text.ToLower());
                            TempUser.CambioContrasena = true;
                            List<string> Destinatario = new List<string>();
                            Destinatario.Add(TempUser.Correo);
                            Utilitarios.EnviarEmail(Destinatario, "***CONFIDENCIAL**** - Credenciales de Acceso - Soda Los Naranjitos", "Su Contraseña de acceso es:" + TempUser.Contrasena);
                            Utilitarios.GeneralBitacora(txtUsuario.Text.ToLower(), "Solicitud de Contraseña del usuario " + txtUsuario.Text.ToLower());
                            MessageBox.Show("Se ha enviado la contraseña al correo correspondiente al usuario " + txtUsuario.Text.ToLower(), "Advertencia",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsuario.Clear();
                            txtPassword.Clear();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {

                        Utilitarios.GeneralError("Intento de ingreso fallido del cambio de contraseña " + txtUsuario.Text, "Ingreso Denegado", txtUsuario.Text, " Intento de ingreso fallido del supuesto usuario " + txtUsuario.Text);

                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error al Popular Datos", "No User logged", "Error durante la Salida del Sistema ");
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }
    }
}

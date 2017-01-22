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
    public partial class FrmUsuarios : Form
    {
        BL.Interfaces.IUsuario Usrs = new BL.Clases.Usuario();

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) ||
               string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
               string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
               string.IsNullOrEmpty(txtIdUsuario.Text) || string.IsNullOrWhiteSpace(txtIdUsuario.Text) ||
               string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Usrs.ExisteUsuario((Utilitarios.Encriptar(txtIdUsuario.Text, Utilitarios.Llave))))
                {
                    MessageBox.Show("Usuario Ya existe \n No se puede ingresar usuarios duplicados",
                        "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //if (txtContrasena.Text != txtConfirmarC.Text)
                    //{
                    //    MessageBox.Show("Confirme su contraseña Correctamente",
                    //    "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                        try
                        {

                        DATOS.Usuario Userprivate = new DATOS.Usuario
                        {
                            IdUsuario = Utilitarios.Encriptar(txtIdUsuario.Text, Utilitarios.Llave),
                            Nombre = Utilitarios.Encriptar(txtNombre.Text, Utilitarios.Llave),
                            Apellido1 = Utilitarios.Encriptar(txtApellido.Text, Utilitarios.Llave),
                            Contrasena = Utilitarios.Encriptar(txtContraseña.Text, Utilitarios.Llave),
                            Activo = true,
                            IdPersonal = Utilitarios.Encriptar(txtIdPersonal.Text, Utilitarios.Llave),
                            Telefono = Utilitarios.Encriptar(txtTelefono.Text, Utilitarios.Llave),
                            Correo = Utilitarios.Encriptar(txtEmail.Text, Utilitarios.Llave),
                            Rol = 1

                        };

                            Usrs.AgregarUsuario(Userprivate);
                            MessageBox.Show("Los datos del Usuario se ingresaron correctamente",
                           "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

            }
        }
    }
}

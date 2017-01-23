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
        BL.Interfaces.IRolUsuario OperacionesRoles = new BL.Clases.RolUsuario();
        BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        DATOS.Error ER = new DATOS.Error();

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.Text!=txtContraseña.Text)
            {
                MessageBox.Show("Error", "Contraseñas No Coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AgregarUsuario();
            }
            
           
        }
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                cbbRol.DataSource = OperacionesRoles.ListarRoles().Select(p => p.Descripcion).ToList();
                List<DATOS.Usuario> ListaUsuarios = new List<DATOS.Usuario>();
                ListaUsuarios = Usrs.ListarUsuarios();
                dgvListado.DataSource = ListaUsuarios.Select(a => new { a.IdUsuario, a.IdPersonal, a.Nombre, a.Apellido1, a.Apellido2, a.Correo, a.Direccion, a.Telefono, a.Rol }).ToList();
            }
            catch (Exception ex)
            {
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error","Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        public void AgregarUsuario()
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
                    try
                    {

                        DATOS.Usuario Userprivate = new DATOS.Usuario
                        {
                            IdUsuario = Utilitarios.Encriptar(txtIdUsuario.Text, Utilitarios.Llave),
                            Nombre = Utilitarios.Encriptar(txtNombre.Text, Utilitarios.Llave),
                            Apellido1 = Utilitarios.Encriptar(txtApellido.Text, Utilitarios.Llave),
                            Apellido2 = Utilitarios.Encriptar(txtApellido2.Text, Utilitarios.Llave),
                            Contrasena = Utilitarios.Encriptar(txtContraseña.Text, Utilitarios.Llave),
                            Activo = true,
                            IdPersonal = Utilitarios.Encriptar(txtIdPersonal.Text, Utilitarios.Llave),
                            Telefono = Utilitarios.Encriptar(txtTelefono.Text, Utilitarios.Llave),
                            Correo = Utilitarios.Encriptar(txtEmail.Text, Utilitarios.Llave),
                            Rol = Convert.ToInt32(OperacionesRoles.BuscarRolPorDescripcion(cbbRol.SelectedText)),
                            Direccion = txtDireccion.Text,

                        };

                        Usrs.AgregarUsuario(Userprivate);
                        MessageBox.Show("Los datos del Usuario se ingresaron correctamente",
                       "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        clearall();
                    }
                    catch (Exception ex)
                    {

                        ER.Descripcion = ex.Message;
                        ER.Tipo = "Error al Popular Datos";
                        OpErrpr.AgregarError(ER);
                        MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void clearall()
        {
            txtIdPersonal.Clear();
            txtIdUsuario.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtContraseña.Clear();
            txtConfirmarContrasena.Clear();
            txtApellido2.Clear();
            txtApellido.Clear();
        }
    }
}

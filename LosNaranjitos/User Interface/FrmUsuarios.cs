
using LosNaranjitos.DATOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LosNaranjitos
{
    public partial class FrmUsuarios : Form
    {
        public static DATOS.Usuario EditUser = new DATOS.Usuario();
        public static List<DATOS.Usuario> ListaUsuarios = new List<DATOS.Usuario>();


        public FrmUsuarios()
        {
            InitializeComponent();
        }

        public void AgregarUsuario()
        {

            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
              string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
              string.IsNullOrEmpty(txtIdPersonal.Text) || string.IsNullOrWhiteSpace(txtIdPersonal.Text) ||
              string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    if (!Utilitarios.emailValido(txtEmail.Text))
                    {
                        MessageBox.Show("Email No Valido",
                            "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                    RolUsuario RolLocal = Utilitarios.OpRol.BuscarRolPorDescripcion(cbbRol.SelectedValue.ToString());

                    Usuario Userprivate = new Usuario
                    {
                        //    Consecutivo = lblConsecutivo.Text,
                        Username = txtUsername.Text,
                        Nombre = txtNombre.Text,
                        Apellido1 = txtApellido.Text,
                        Apellido2 = txtApellido2.Text,
                        Contrasena = RandomString(6),
                        Activo = true,
                        IdPersonal = txtIdPersonal.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtEmail.Text,
                        Rol = RolLocal.IdRol,
                        Direccion = txtDireccion.Text,
                        CambioContrasena = true,
                        UltimoContrasena = DateTime.Now

                    };

                    Utilitarios.OpUsuarios.AgregarUsuario(Userprivate);


                    List<string> Destinatario = new List<string>();
                    Destinatario.Add(Utilitarios.Decriptar(Userprivate.Correo, Utilitarios.Llave));
                    Utilitarios.EnviarEmail(Destinatario, "***CONFIDENCIAL**** - Credenciales de Acceso - Soda Los Naranjitos", "Su nombre de Usuario es: " + Utilitarios.Decriptar(Userprivate.Username, Utilitarios.Llave) + "Su Contraseña de acceso es:" + Utilitarios.Decriptar(Userprivate.Contrasena, Utilitarios.Llave));

                    MessageBox.Show("Se ha enviado la contraseña al correo correspondiente al usuario " + Utilitarios.Decriptar(Userprivate.Username, Utilitarios.Llave), "Advertencia",
   MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Usuario Nuevo " + Userprivate.Username);
                    MessageBox.Show("Los datos del Usuario se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Agregar un usuario nuevo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Dispose();
                }
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarUsuario();
            tbControl1.SelectedIndex = 0;
            this.FrmUsuarios_Load(sender, e);
            clearall();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try

            {
                if (!Utilitarios.Cambio)
                {

                    Usuario UltimoUsuario = new Usuario();

                    try
                    {
                        UltimoUsuario = Utilitarios.OpUsuarios.ListarUsuarios().OrderByDescending(x => x.Consecutivo).First();
                        lblConsecutivo.Text = (UltimoUsuario.Consecutivo + 1).ToString();

                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos")
                        {
                            UltimoUsuario.Consecutivo = 1;
                        }
                        lblConsecutivo.Text = UltimoUsuario.Consecutivo.ToString();

                    }

                }

                cbbRol.DataSource = Utilitarios.OpRol.ListarRoles().Select(p => p.Descripcion).ToList();
                cbbRol.SelectedIndex = 0;
                cbBuscar.SelectedIndex = 0;
                ListaUsuarios = Utilitarios.OpUsuarios.ListarUsuarios();
                var ListaLocal = ListaUsuarios.Select(a => new
                {
                    a.Username,
                    a.IdPersonal,
                    a.Nombre,
                    a.Apellido1,
                    a.Apellido2,
                    a.Correo,
                    a.Direccion,
                    a.Telefono,
                    a.Rol
                }).ToList();

                dgvListado.DataSource = ListaLocal;
                dgvListado.Columns[0].HeaderText = "Usuario";
                dgvListado.Columns[1].HeaderText = "Cédula";
                dgvListado.Columns[2].HeaderText = "Nombre";
                dgvListado.Columns[3].HeaderText = "1er Apellido";
                dgvListado.Columns[4].HeaderText = "2do Apellido";
                dgvListado.Columns[5].HeaderText = "Correo Electrónico";
                dgvListado.Columns[6].HeaderText = "Dirección";
                dgvListado.Columns[7].HeaderText = "Teléfono";
                dgvListado.Columns[8].HeaderText = "Rol de Usuario";

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.Username));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;

                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tbControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        lblConsecutivo.Text = EditUser.Consecutivo.ToString();
                        txtUsername.Text = EditUser.Username;
                        txtNombre.Text = EditUser.Nombre;
                        txtApellido.Text = EditUser.Apellido1;
                        txtApellido2.Text = EditUser.Apellido2;
                        txtDireccion.Text = EditUser.Direccion;
                        txtEmail.Text = EditUser.Correo;
                        txtTelefono.Text = EditUser.Telefono;
                        txtIdPersonal.Text = EditUser.IdPersonal;

                        txtNombre.ReadOnly = false;
                        txtApellido.ReadOnly = false;
                        txtApellido2.ReadOnly = false;
                        txtDireccion.ReadOnly = false;
                        txtEmail.ReadOnly = false;
                        txtTelefono.ReadOnly = false;
                        txtIdPersonal.ReadOnly = true;

                        btnNuevo.Visible = false;

                        if (EditUser.Activo)
                        {
                            chkEstado.Checked = true;
                        }
                        else
                        {
                            chkEstado.Checked = false;
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error al Popular Datos", FrmLogin.UsuarioGlobal.Username, "Error al Cargar Formulario de Usuarios");

                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Usuario");
            this.Dispose();

        }

        public void clearall()
        {
            txtIdPersonal.Clear();
            txtUsername.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

            txtApellido2.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                FrmEdicionUsuario a = new FrmEdicionUsuario();
                a.Show();
                this.Dispose();
            }
            else
            {
                EditarUsuario();
                Utilitarios.Cambio = false;
            }
        }

        public void EditarUsuario()
        {
            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
              string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
              string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
              string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    RolUsuario RolLocal = Utilitarios.OpRol.BuscarRolPorDescripcion(cbbRol.SelectedValue.ToString());
                    Usuario Userprivate = new Usuario();
                    Userprivate = EditUser;
                    {
                        //   Consecutivo = lblConsecutivo.Text,
                        Userprivate.Username = txtUsername.Text;
                        Userprivate.Nombre = txtNombre.Text;
                        Userprivate.Apellido1 = txtApellido.Text;
                        Userprivate.Apellido2 = txtApellido2.Text;
                        //      Contrasena = txtContraseña.Text,
                        Userprivate.Activo = chkEstado.Checked;
                        Userprivate.IdPersonal = txtIdPersonal.Text;
                        Userprivate.Telefono = txtTelefono.Text;
                        Userprivate.Correo = txtEmail.Text;
                        Userprivate.Rol = RolLocal.IdRol;
                        Userprivate.Direccion = txtDireccion.Text;
                        Userprivate.CambioContrasena = true;
                    };
                    Utilitarios.OpUsuarios.ActualizarUsuario(Userprivate);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Usuario " + Userprivate.Username);

                    List<string> Destinatario = new List<string>();
                    Destinatario.Add(Utilitarios.Decriptar(Userprivate.Correo, Utilitarios.Llave));
                    Utilitarios.EnviarEmail(Destinatario, "***CONFIDENCIAL**** - Credenciales de Acceso - Soda Los Naranjitos", "Su Contraseña de acceso es:" + Utilitarios.Decriptar(Userprivate.Contrasena, Utilitarios.Llave));

                    MessageBox.Show("Los datos del Usuario se Actualizaron correctamente",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Usuarios");

                    this.Dispose();
                    clearall();
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Editar Usuario");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaUsuarios = Utilitarios.OpUsuarios.ListarUsuarios();
                var ListaLocal = ListaUsuarios.Select(a => new
                {
                    a.Consecutivo,
                    a.Username,
                    a.IdPersonal,
                    a.Nombre,
                    a.Apellido1,
                    a.Apellido2,
                    a.Correo,
                    a.Direccion,
                    a.Telefono,
                    a.Rol
                }).ToList();

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "IdPersonal":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.IdPersonal));
                        }
                        break;
                    case "Username":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.Username));
                        }
                        break;
                    case "Nombre":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.Nombre));
                        }
                        break;
                    case "Apellido":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.Apellido1));
                        }
                        break;
                    case "Consecutivo":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.Consecutivo));
                        }
                        break;
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Cambiar Criterio en Combobox de busqueda Principal");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaUsuarios = Utilitarios.OpUsuarios.ListarUsuarios();
                var ListaLocal = ListaUsuarios.Select(a => new
                {
                    a.Consecutivo,
                    a.Username,
                    a.IdPersonal,
                    a.Nombre,
                    a.Apellido1,
                    a.Apellido2,
                    a.Correo,
                    a.Direccion,
                    a.Telefono,
                    a.Rol
                }).ToList();
                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "IdPersonal":

                        ListaLocal = ListaLocal.Where(x => x.IdPersonal == txtBuscar.Text).ToList();

                        break;
                    case "Username":

                        ListaLocal = ListaLocal.Where(x => x.Username == txtBuscar.Text).ToList();
                        break;
                    case "Nombre":

                        ListaLocal = ListaLocal.Where(x => x.Nombre == txtBuscar.Text).ToList();
                        break;
                    case "Apellido":

                        ListaLocal = ListaLocal.Where(x => x.Apellido1 == txtBuscar.Text).ToList();
                        break;
                    case "Consecutivo":

                        ListaLocal = ListaLocal.Where(x => x.Consecutivo.ToString() == txtBuscar.Text).ToList();
                        break;
                }
                dgvListado.DataSource = ListaLocal;
                dgvListado.Columns[0].HeaderText = "Usuario";
                dgvListado.Columns[1].HeaderText = "Cédula";
                dgvListado.Columns[2].HeaderText = "Nombre";
                dgvListado.Columns[3].HeaderText = "1er Apellido";
                dgvListado.Columns[4].HeaderText = "2do Apellido";
                dgvListado.Columns[5].HeaderText = "Correo Electrónico";
                dgvListado.Columns[6].HeaderText = "Dirección";
                dgvListado.Columns[7].HeaderText = "Teléfono";
                dgvListado.Columns[8].HeaderText = "Rol de Usuario";
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Buscar Usuario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Usuario");
            this.Dispose();
        }



        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.Cambio)
            {
                if (e.KeyChar == '\r' || (int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("Debes digitar tu Apellido antes de continuar", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        try
                        {
                            string Usuario; int Consec = 0;

                            Usuario = txtApellido.Text.Replace(" ", "") + txtNombre.Text.Substring(0, 1) + Consec.ToString();
                            Usuario = Usuario.ToLower();
                            do
                            {
                                Consec = Consec + 1; //Consecutivo para IdUsuario
                                Usuario = txtApellido.Text + txtNombre.Text.Substring(0, 1) + Consec.ToString();
                                Usuario = Usuario.ToLower();
                            } while (Utilitarios.OpUsuarios.ExisteUsuario(Utilitarios.Encriptar(Usuario, Utilitarios.Llave)));

                            txtUsername.Text = Usuario;
                        }
                        catch (Exception ex)
                        {

                            Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios texbox de Apellido");
                            MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        txtApellido2.ReadOnly = false;
                        txtApellido2.Focus();
                        txtDireccion.ReadOnly = false;
                        txtEmail.ReadOnly = false;
                        txtTelefono.ReadOnly = false;

                        txtIdPersonal.ReadOnly = false;

                    }
                }
            }
        }

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || (int)e.KeyChar == (int)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debes digitar tu Nombre antes de continuar", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    txtApellido.Focus();
                    txtApellido.ReadOnly = false;
                }
            }
        }

        private void ClearAll()
        {
            txtApellido2.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            txtIdPersonal.Clear();
            EditUser = null;
            Utilitarios.Cambio = false;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Usuario");
            this.Dispose();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utilitarios.emailValido(txtEmail.Text))
            {
                lblValidEmail.Text = "Email Válido";
                lblValidEmail.ForeColor = Color.Green;
            }
            else
            {
                lblValidEmail.Text = "Email NO Válido";
                lblValidEmail.ForeColor = Color.Red;
            }
        }
    }
}


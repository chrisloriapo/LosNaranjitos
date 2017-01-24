
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
        public static DATOS.Usuario EditUser = new DATOS.Usuario();
        public static List<DATOS.Usuario> ListaUsuarios = new List<DATOS.Usuario>();
        public BL.Interfaces.IUsuario Usrs = new BL.Clases.Usuario();
        public BL.Interfaces.IRolUsuario OperacionesRoles = new BL.Clases.RolUsuario();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();

        public FrmUsuarios()
        {
            InitializeComponent();
        }
        public void AgregarUsuario()
        {

            string Usuario; int Consec = 1;


            if (txtConfirmarContrasena.Text != txtContraseña.Text)
            {
                MessageBox.Show("Error", "Contraseñas No Coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) ||
              string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
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
                    Usuario = txtApellido.Text + txtNombre.Text.Substring(0, 1) + Consec.ToString();
                    Usuario = Usuario.ToLower();
                    while (Usrs.ExisteUsuario(Usuario))
                    {
                        Consec++;
                        Usuario = txtApellido.Text + txtNombre.Text.Substring(0, 1) + Consec.ToString();
                        Usuario = Usuario.ToLower();
                    }
                    txtIdUsuario.Text = Usuario;
                    DATOS.RolUsuario RolLocal = OperacionesRoles.BuscarRolPorDescripcion(cbbRol.SelectedValue.ToString());

                    DATOS.Usuario Userprivate = new DATOS.Usuario
                    {
                        IdUsuario = Utilitarios.Encriptar(Usuario, Utilitarios.Llave),
                        Nombre = Utilitarios.Encriptar(txtNombre.Text, Utilitarios.Llave),
                        Apellido1 = Utilitarios.Encriptar(txtApellido.Text, Utilitarios.Llave),
                        Apellido2 = Utilitarios.Encriptar(txtApellido2.Text, Utilitarios.Llave),
                        Contrasena = Utilitarios.Encriptar(txtContraseña.Text, Utilitarios.Llave),
                        Activo = true,
                        IdPersonal = Utilitarios.Encriptar(txtIdPersonal.Text, Utilitarios.Llave),
                        Telefono = Utilitarios.Encriptar(txtTelefono.Text, Utilitarios.Llave),
                        Correo = Utilitarios.Encriptar(txtEmail.Text, Utilitarios.Llave),
                        Rol = RolLocal.IdRol,
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
                    ER.Hora = DateTime.Now;
                    OpErrpr.AgregarError(ER);
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {


            AgregarUsuario();

        }
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                cbbRol.DataSource = OperacionesRoles.ListarRoles().Select(p =>
                p.Descripcion).ToList();
                ListaUsuarios = Usrs.ListarUsuarios();
                var ListaLocal = ListaUsuarios.Select(a => new
                {
                    a.IdUsuario,
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

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.IdUsuario));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;

                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtIdUsuario.Text = EditUser.IdUsuario;
                        txtNombre.Text = EditUser.Nombre;
                        txtApellido.Text = EditUser.Apellido1;
                        txtApellido2.Text = EditUser.Apellido2;
                        txtDireccion.Text = EditUser.Direccion;
                        txtEmail.Text = EditUser.Correo;
                        txtTelefono.Text = EditUser.Telefono;
                        txtIdPersonal.Text = EditUser.IdPersonal;
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
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            txtDireccion.Clear();

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
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

                try
                {
                    DATOS.RolUsuario RolLocal = OperacionesRoles.BuscarRolPorDescripcion(cbbRol.SelectedValue.ToString());

                    DATOS.Usuario Userprivate = new DATOS.Usuario
                    {
                        IdUsuario = Utilitarios.Encriptar(txtIdUsuario.Text, Utilitarios.Llave),
                        Nombre = Utilitarios.Encriptar(txtNombre.Text, Utilitarios.Llave),
                        Apellido1 = Utilitarios.Encriptar(txtApellido.Text, Utilitarios.Llave),
                        Apellido2 = Utilitarios.Encriptar(txtApellido2.Text, Utilitarios.Llave),
                        Contrasena = Utilitarios.Encriptar(txtContraseña.Text, Utilitarios.Llave),
                        Activo = chkEstado.Checked,
                        IdPersonal = Utilitarios.Encriptar(txtIdPersonal.Text, Utilitarios.Llave),
                        Telefono = Utilitarios.Encriptar(txtTelefono.Text, Utilitarios.Llave),
                        Correo = Utilitarios.Encriptar(txtEmail.Text, Utilitarios.Llave),
                        Rol = RolLocal.IdRol,
                        Direccion = txtDireccion.Text,

                    };

                    Usrs.ActualizarUsuario(Userprivate);
                    MessageBox.Show("Los datos del Usuario se Actualizaron correctamente",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    clearall();
                }
                catch (Exception ex)
                {

                    ER.Descripcion = ex.Message;
                    ER.Tipo = "Error al Popular Datos";
                    ER.Hora = DateTime.Now;
                    OpErrpr.AgregarError(ER);
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaUsuarios = Usrs.ListarUsuarios();
                var ListaLocal = ListaUsuarios.Select(a => new
                {
                    a.IdUsuario,
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
                    case "IdUsuario":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.IdUsuario));
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


                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
            }
            catch (Exception ex)
            {

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaUsuarios = Usrs.ListarUsuarios();
                var ListaLocal = ListaUsuarios.Select(a => new
                {
                    a.IdUsuario,
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
                    case "IdUsuario":

                        ListaLocal = ListaLocal.Where(x => x.IdUsuario == txtBuscar.Text).ToList(); break;
                    case "Nombre":

                        ListaLocal = ListaLocal.Where(x => x.Nombre == txtBuscar.Text).ToList();
                        break;
                    case "Apellido":

                        ListaLocal = ListaLocal.Where(x => x.Apellido1 == txtBuscar.Text).ToList();
                        break;

                  
                }
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {
                
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


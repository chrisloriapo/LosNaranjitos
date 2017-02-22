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

namespace LosNaranjitos
{
    public partial class FrmProveedor : Form
    {

        public static DATOS.Proveedor EditProveedor = new DATOS.Proveedor();
        public static List<DATOS.Proveedor> ListaProveedores = new List<DATOS.Proveedor>();

        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.Cambio == false)
                {
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Proveedor UltimoProveedor = Utilitarios.OpProveedor.ListarProveedores().OrderByDescending(x => x.Consecutivo).First();
                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Proveedor").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSProveedor = Consecutivo.ConsecutivoActual + 1;
                    UltimoProveedor.Consecutivo = Prefijo + "-" + CSProveedor;
                    if (Utilitarios.OpUsuarios.ExisteConsecutivo(UltimoProveedor.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimoProveedor.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnNuevo.Enabled = false;
                    }
                    lblConsecutivo.Text = UltimoProveedor.Consecutivo;
                }
                ListaProveedores = Utilitarios.OpProveedor.ListarProveedores();
                var ListaLocal = ListaProveedores.ToList();
                dgvListado.DataSource = ListaLocal;

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.IdProveedor));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;

                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtIdProveedor.Text = EditProveedor.IdProveedor;
                        txtEmpresa.Text = EditProveedor.Nombre;
                        txtTelefono.Text = EditProveedor.Telefono;
                        txtEmail.Text = EditProveedor.Correo;
                        if (EditProveedor.Activo)
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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Cargar el formulario ");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarProveedor();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProveedor.Text))
            {
                FrmEdicionProveedor a = new FrmEdicionProveedor();
                a.Show();
                this.Dispose();
            }
            else
            {
                if (Utilitarios.OpProveedor.ExisteProveedor(txtIdProveedor.Text))
                {
                    EditarProveedor();
                    Utilitarios.Cambio = false;
                }
                else
                {
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Usuario Fallida, Proveedor No existe");
                    MessageBox.Show("Proveedor No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");

        }

        public void AgregarProveedor()
        {
            if (string.IsNullOrEmpty(txtIdProveedor.Text) || string.IsNullOrWhiteSpace(txtIdProveedor.Text) ||
                string.IsNullOrEmpty(txtEmpresa.Text) || string.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    if (Utilitarios.OpProveedor.ExisteProveedor(txtIdProveedor.Text))
                    {
                        MessageBox.Show("Proveedor Duplicado",
                                            "No se puede Ingresar usuario duplicado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso Fallido de Proveedor " + txtIdProveedor.Text + ", Proveedor ya existe");

                        return;
                    }
                    else
                    {
                        DATOS.Proveedor ProvedorPrivate = new DATOS.Proveedor
                        {
                            Consecutivo = lblConsecutivo.Text,
                            IdProveedor = txtIdProveedor.Text,
                            Nombre = txtEmpresa.Text,
                            Activo = chkEstado.Checked,
                            Telefono = txtTelefono.Text,
                            Correo = txtEmail.Text,
                        };
                       Utilitarios.OpProveedor.AgregarProveedor(ProvedorPrivate);

                        DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Proveedor");
                        Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual+1;
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Proveedor Nuevo "+ProvedorPrivate.IdProveedor);

                        MessageBox.Show("Los datos del Proveedor se ingresaron correctamente", "Ingreso de datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");
                    this.Dispose();
                    clearall();
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Intentar Agregar un Proveedor nuevo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EditarProveedor()
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
              string.IsNullOrEmpty(txtEmpresa.Text) || string.IsNullOrWhiteSpace(txtEmpresa.Text) ||
              string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
              string.IsNullOrEmpty(txtIdProveedor.Text) || string.IsNullOrWhiteSpace(txtIdProveedor.Text) ||
              string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DATOS.Proveedor ProvedorPrivate = new DATOS.Proveedor
                    {
                        Consecutivo = lblConsecutivo.Text,
                        IdProveedor = txtIdProveedor.Text,
                        Nombre = Utilitarios.Encriptar(txtEmpresa.Text, Utilitarios.Llave),
                        Activo = chkEstado.Checked,
                        Telefono = txtTelefono.Text,
                        Correo = txtEmail.Text,
                    };

                    Utilitarios. OpProveedor.ActualizarProveedor(ProvedorPrivate);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Proveedor " + ProvedorPrivate.IdProveedor);
                    MessageBox.Show("Los datos del Proveedor se Actualizaron correctamente",
                   "Actualizacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");
                    this.Dispose();
                    clearall();
                }
                catch (Exception ex)
                {

                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Editar Proveedor ");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void clearall()
        {
            txtTelefono.Clear();
            txtEmail.Clear();
            txtIdProveedor.Clear();
            txtEmpresa.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaProveedores = Utilitarios.OpProveedor.ListarProveedores();
                var ListaLocal = ListaProveedores.ToList();
                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Codigo":

                        ListaLocal = ListaLocal.Where(x => x.IdProveedor == txtBuscar.Text).ToList();

                        break;
                    case "Empresa":

                        ListaLocal = ListaLocal.Where(x => x.Nombre == txtBuscar.Text).ToList();
                        break;


                }
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Buscar el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaProveedores = Utilitarios.OpProveedor.ListarProveedores();
                var ListaLocal = ListaProveedores.ToList();

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Codigo":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.IdProveedor));
                        }

                        break;
                    case "Empresa":
                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.Nombre));
                        }
                        break;
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Cargar el Combobox de Busqueda ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
      
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");
            this.Close();
        }
    }
}

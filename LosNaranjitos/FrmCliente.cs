using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LosNaranjitos.DATOS;

namespace LosNaranjitos
{
    public partial class FrmCliente : Form
    {
        public static DATOS.Cliente EditCLiente = new DATOS.Cliente();
        public static List<DATOS.Cliente> ListaClientes = new List<DATOS.Cliente>();

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaClientes = Utilitarios.OpClientes.ListarClientes();
                var ListaLocal = ListaClientes.ToList();
                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Nombre":

                        ListaLocal = ListaLocal.Where(x => x.Nombre == txtBuscar.Text).ToList();

                        break;
                    case "IdPersonal":

                        ListaLocal = ListaLocal.Where(x => x.Apellido1 == txtBuscar.Text).ToList();
                        break;
                    case "Apellido":

                        ListaLocal = ListaLocal.Where(x => x.IdPersonal == txtBuscar.Text).ToList();
                        break;

                }
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Intentar buscar el Cliente");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpClientes.ListarClientes().Count() == 0)
                {
                    btnEditar.Enabled = false;
                }
                if (!Utilitarios.Cambio)
                {
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Cliente UltimoCliente = new Cliente();
                    try
                    {
                        UltimoCliente = Utilitarios.OpClientes.ListarClientes().OrderByDescending(x => x.Consecutivo).First();
                        if (UltimoCliente == null)
                        {
                            UltimoCliente = new Cliente()
                            {
                                Consecutivo = "CLI-1"
                            };
                        }
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimoCliente = new Cliente()
                            {
                                Consecutivo = "CLI-1"
                            };
                        }
                    }
                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Cliente").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSCliente = Consecutivo.ConsecutivoActual + 1;
                    UltimoCliente.Consecutivo = Prefijo + "-" + CSCliente;
                    if (Utilitarios.OpUsuarios.ExisteConsecutivo(UltimoCliente.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimoCliente.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnNuevo.Enabled = false;
                    }
                    lblConsecutivo.Text = UltimoCliente.Consecutivo;
                }


                ListaClientes = Utilitarios.OpClientes.ListarClientes();
                var ListaLocal = ListaClientes.ToList();
                dgvListado.DataSource = ListaLocal;

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.IdPersonal));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
                cbBuscar.SelectedIndex = 0;
                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        lblConsecutivo.Text = EditCLiente.Consecutivo;
                        txtIdCliente.Text = EditCLiente.IdPersonal;
                        txtNombre.Text = EditCLiente.Nombre;
                        txtTelefono.Text = EditCLiente.Telefono;
                        txtEmail.Text = EditCLiente.Correo;

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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Cargar el formulario ");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text) || string.IsNullOrWhiteSpace(txtIdCliente.Text) ||
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
                    if (Utilitarios.OpClientes.ExisteCLIENTE(txtIdCliente.Text))
                    {
                        MessageBox.Show("Cliente Duplicado",
                                            "No se puede Ingresar Cliente duplicado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso Fallido de Cliente " + txtIdCliente.Text + ", Cliente ya existe");
                        return;
                    }
                    else
                    {
                        DATOS.Cliente ClientePrivate = new DATOS.Cliente
                        {
                            Consecutivo = lblConsecutivo.Text,
                            IdPersonal = txtIdCliente.Text,
                            Nombre = txtNombre.Text,
                            Activo = true,
                            Telefono = txtTelefono.Text,
                            Correo = txtEmail.Text,
                            Apellido1 = txtApellido.Text,

                        };

                        Utilitarios.OpClientes.AgregarCliente(ClientePrivate);

                        DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Cliente");
                        Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Cliente Nuevo " + ClientePrivate.IdPersonal);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Clientes");

                        MessageBox.Show("Los datos del Cliente se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Insertar Cliente Nuevo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaClientes = Utilitarios.OpClientes.ListarClientes();
                var ListaLocal = ListaClientes.ToList();

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Nombre":

                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.Nombre));
                        }

                        break;
                    case "IdPersonal":
                        foreach (var pos in ListaLocal)
                        {
                            autosearch.Add(Convert.ToString(pos.IdPersonal));
                        }
                        break;
                    case "Apellido":
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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Clientes al Buscar Cliente  ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Clientes");
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
             string.IsNullOrEmpty(txtIdCliente.Text) || string.IsNullOrWhiteSpace(txtIdCliente.Text) ||
             string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
             string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
             string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (Utilitarios.OpClientes.ExisteCLIENTE(txtIdCliente.Text))
                    {
                        MessageBox.Show("Cliente No encontrado",
                                          "Cliente No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DATOS.Cliente ClientePrivate = new DATOS.Cliente
                    {
                        Consecutivo = lblConsecutivo.Text,
                        IdPersonal = txtIdCliente.Text,
                        Nombre = txtNombre.Text,
                        Activo = true,
                        Telefono = txtTelefono.Text,
                        Correo = txtEmail.Text,
                        Apellido1 = txtApellido.Text,
                    };

                    Utilitarios.OpClientes.ActualizarCLIENTE(ClientePrivate);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Cliente " + ClientePrivate.IdPersonal);
                    MessageBox.Show("Los datos del Cliente se Actualizaron correctamente",
                   "Actualizacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Clientes");
                    this.Dispose();
                }
                catch (Exception ex)
                {

                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Editar Proveedor ");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Clientes");
            this.Dispose();
        }
    }
}


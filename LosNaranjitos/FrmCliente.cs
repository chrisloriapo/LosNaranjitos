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
    public partial class FrmCliente : Form
    {
        public static DATOS.Cliente EditCLiente = new DATOS.Cliente();
        public static List<DATOS.Cliente> ListaClientes = new List<DATOS.Cliente>();
        public BL.Interfaces.ICliente OpCliente = new BL.Clases.Cliente();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IConsecutivo ConsecutivoOperaciones = new BL.Clases.Consecutivo();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();
        public DATOS.Bitacora BIT = new DATOS.Bitacora();

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaClientes = OpCliente.ListarClientes();
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

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                ListaClientes = OpCliente.ListarClientes();
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

                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtIdCliente.Text = EditCLiente.IdPersonal;
                        txtNombre.Text = EditCLiente.Nombre;
                        txtTelefono.Text = EditCLiente.Telefono;
                        txtEmail.Text = EditCLiente.Correo;

                        //if (EditCLiente.Activo)
                        //{
                        //    chkEstado.Checked = true;
                        //}
                        //else
                        //{
                        //    chkEstado.Checked = false;
                        //}
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
                    if (OpCliente.ExisteCLIENTE(txtIdCliente.Text))
                    {
                        MessageBox.Show("Cliente Duplicado",
                                            "No se puede Ingresar Cliente duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DATOS.Cliente ClientePrivate = new DATOS.Cliente
                        {
                            IdPersonal = txtIdCliente.Text,
                            Nombre = txtNombre.Text,
                            Activo = false,
                            Telefono = txtTelefono.Text,
                            Correo = txtEmail.Text,

                        };

                        OpCliente.ActualizarCLIENTE(ClientePrivate);
                        DATOS.Consecutivo UltimoConsecutivo = ConsecutivoOperaciones.ListaPorTipo("Cliente").OrderByDescending(x => x.IdConsecutivo).First();
                        UltimoConsecutivo.PKTabla = ClientePrivate.IdPersonal;
                        ConsecutivoOperaciones.ActualizarConsecutivo(UltimoConsecutivo);
                        BIT.Usuario = FrmLogin.UsuarioGlobal.IdUsuario;
                        BIT.Accion = "Ingreso de Cliente Nuevo " + ClientePrivate.IdPersonal;
                        BIT.Fecha = DateTime.Now;
                        OpBitacora.AgregarBitacora(BIT);
                    }


                    MessageBox.Show("Los datos del Cliente se ingresaron correctamente",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                 
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
                ListaClientes = OpCliente.ListarClientes();
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

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }


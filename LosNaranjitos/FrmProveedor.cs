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
        public BL.Interfaces.IProveedor OpProveedor = new BL.Clases.Proveedor();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();

        public FrmProveedor()
        {
            InitializeComponent();
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
                if (OpProveedor.ExisteProveedor(txtIdProveedor.Text))
                {
                    EditarProveedor();
                    Utilitarios.Cambio = false;
                }
                else
                {
                    MessageBox.Show("Proveedor No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    if (OpProveedor.ExisteProveedor(txtIdProveedor.Text))
                    {
                        MessageBox.Show("Proveedor Duplicado",
                                            "No se puede Ingresar usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DATOS.Proveedor ProvedorPrivate = new DATOS.Proveedor
                        {
                            IdProveedor = txtIdProveedor.Text,
                            Nombre = txtEmpresa.Text,
                            Activo = chkEstado.Checked,
                            Telefono = txtTelefono.Text,
                            Correo = txtEmail.Text,

                        };
                        OpProveedor.AgregarProveedor(ProvedorPrivate);
                    }
                    MessageBox.Show("Los datos del Proveedor se ingresaron correctamente","Ingreso de datos", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void clearall()
        {
            txtTelefono.Clear();
            txtEmail.Clear();
            txtIdProveedor.Clear();
            txtEmpresa.Clear();
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
                        IdProveedor = txtIdProveedor.Text,
                        Nombre = Utilitarios.Encriptar(txtEmpresa.Text, Utilitarios.Llave),
                        Activo = chkEstado.Checked,
                        Telefono = txtTelefono.Text,
                        Correo = txtEmail.Text,

                    };

                    OpProveedor.ActualizarProveedor(ProvedorPrivate);
                    MessageBox.Show("Los datos del Proveedor se Actualizaron correctamente",
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

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                ListaProveedores = OpProveedor.ListarProveedores();
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
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaProveedores = OpProveedor.ListarProveedores();
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

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaProveedores = OpProveedor.ListarProveedores();
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

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

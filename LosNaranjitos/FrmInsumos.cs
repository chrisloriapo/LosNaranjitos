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
    public partial class FrmInsumos : Form
    {
        public static DATOS.Insumos EditInsumo = new DATOS.Insumos();
        public static List<DATOS.Insumos> ListaInsumos = new List<DATOS.Insumos>();

        public FrmInsumos()
        {
            InitializeComponent();
        }

        private void FrmInsumos_Load(object sender, EventArgs e)
        {

            try
            {
                //Verificacion de Consecutivo
                if (Utilitarios.Cambio == false)
                {
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Insumos UltimoInsumo = Utilitarios.OpInsumos.ListarInsumos().OrderByDescending(x => x.Consecutivo).First();
                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Insumo").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSInsumo = Consecutivo.ConsecutivoActual + 1;
                    UltimoInsumo.Consecutivo = Prefijo + "-" + CSInsumo;
                    if (Utilitarios.OpUsuarios.ExisteConsecutivo(UltimoInsumo.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimoInsumo.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnNuevo.Enabled = false;
                    }
                    lblConsecutivo.Text = UltimoInsumo.Consecutivo;
                }
                //Carga de Formulario Usual

                this.vProveedor_InsumoTableAdapter.Fill(this.orangeDB1DataSet.VProveedor_Insumo);
                var ListaLocal = this.orangeDB1DataSet.VProveedor_Insumo.ToList();
                dgvListado.DataSource = ListaLocal;
                cbMedida.DataSource = Utilitarios.OpMedidas.ListarMedidas().Select(x => x.IdMedida).ToList();
                cbProveedor.DataSource = Utilitarios.OpProveedor.ListarProveedores().Select(x => x.Nombre).ToList();
                cbbCodigoStock.DataSource = Utilitarios.OpInsumos.ListarInsumos().Select(x => x.IdInsumo).ToList();

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.Nombre));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
                //--------------------------------------------


                while (Utilitarios.Cambio)
                {
                    DATOS.Proveedor Prov = new DATOS.Proveedor();
                    Prov = Utilitarios.OpProveedor.BuscarProveedor(EditInsumo.Proveedor);

                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtIdInsumo.Text = EditInsumo.IdInsumo;
                        txtNombre.Text = EditInsumo.Nombre;
                        txtPrecioCompra.Text = EditInsumo.PrecioCompra.ToString();
                        txtStock.Text = EditInsumo.CantInventario.ToString();
                        lblConsecutivo.Text = EditInsumo.Consecutivo;
                        cbMedida.SelectedItem = EditInsumo.IdMedida;

                        cbProveedor.SelectedItem = Prov.Nombre;
                        chkActivo.Checked = EditInsumo.Activo;
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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Cargar el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdInsumo.Text) || string.IsNullOrWhiteSpace(txtIdInsumo.Text) ||
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
                    if (Utilitarios.OpInsumos.ExisteInsumo(txtIdInsumo.Text))
                    {
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso fallido de Insumo nuevo, Insumo ya existe " + txtIdInsumo.Text);
                        MessageBox.Show("Insumo Duplicado",
                                            "No se puede Ingresar Insumo duplicado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DATOS.Proveedor Prov = new DATOS.Proveedor();
                        Prov = Utilitarios.OpProveedor.BuscarProveedorPorNombre(cbProveedor.SelectedValue.ToString());
                        DATOS.Insumos InsumoPrivate = new DATOS.Insumos
                        {
                            Consecutivo = lblConsecutivo.Text,
                            IdInsumo = txtIdInsumo.Text,
                            Nombre = txtNombre.Text,
                            Activo = chkActivo.Checked,
                            PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                            CantInventario = float.Parse(txtStock.Text),
                            IdMedida = cbMedida.SelectedValue.ToString(),
                            Proveedor = Prov.IdProveedor,
                        };

                        Utilitarios.OpInsumos.AgregarInsumo(InsumoPrivate);

                        DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Insumo");
                        Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual++;
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Insumos Nuevo " + InsumoPrivate.IdInsumo);

                        MessageBox.Show("Los datos del Insumo se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Insumos");
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Agregar un Insumo nuevo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdInsumo.Text))
            {
                FrmEdicionInsumos a = new FrmEdicionInsumos();
                a.Show();
                this.Dispose();
            }
            else
            {
                if (Utilitarios.OpInsumos.ExisteInsumo(txtIdInsumo.Text))
                {
                    EditarInsumo();
                    Utilitarios.Cambio = false;
                }
                else
                {
                    MessageBox.Show("Insumo No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Insumos");
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = new DataTable();

                foreach (var item in orangeDB1DataSet.VProveedor_Insumo)
                {
                    ListaLocal.ImportRow(item);
                }

                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Codigo":
                        ListaLocal.Clear();
                        foreach (var item in orangeDB1DataSet.VProveedor_Insumo)
                        {
                            if (item.IdInsumo == txtBuscar.Text)
                            {
                                ListaLocal.ImportRow(item);
                            }
                        }
                        break;
                    case "Proveedor":
                        ListaLocal.Clear();
                        foreach (var item in orangeDB1DataSet.VProveedor_Insumo)
                        {
                            if (item.Proveedor == txtBuscar.Text)
                            {
                                ListaLocal.ImportRow(item);
                            }
                        }
                        break;
                }
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Buscar un Insumo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = new DataTable();

                foreach (var item in orangeDB1DataSet.VProveedor_Insumo)
                {
                    ListaLocal.ImportRow(item);
                }
                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                switch (cbBuscar.SelectedText.ToString())
                {
                    case "Codigo":
                        ListaLocal.Clear();
                        foreach (var item in orangeDB1DataSet.VProveedor_Insumo)
                        {
                            if (item.IdInsumo == txtBuscar.Text)
                            {
                                ListaLocal.ImportRow(item);
                            }
                        }
                        break;
                    case "Proveedor":
                        ListaLocal.Clear();
                        foreach (var item in orangeDB1DataSet.VProveedor_Insumo)
                        {
                            if (item.Proveedor == txtBuscar.Text)
                            {
                                ListaLocal.ImportRow(item);
                            }
                        }
                        break;
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar llenar la informacion en combobox de busqueda");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EditarInsumo()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtStock.Text) ||
              string.IsNullOrEmpty(txtStock.Text) ||
              string.IsNullOrEmpty(txtPrecioCompra.Text) || string.IsNullOrWhiteSpace(txtPrecioCompra.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var ProveedorId = Utilitarios.OpProveedor.BuscarProveedorPorNombre(cbProveedor.SelectedValue.ToString());
                    DATOS.Insumos InsumoPrivate = new DATOS.Insumos
                    {
                        Consecutivo = lblConsecutivo.Text,
                        IdInsumo = txtIdInsumo.Text,
                        Nombre = txtNombre.Text,
                        Activo = chkActivo.Checked,
                        PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                        IdMedida = cbMedida.SelectedValue.ToString(),
                        Proveedor = ProveedorId.IdProveedor
                    };

                    Utilitarios.OpInsumos.ActualizarInsumo(InsumoPrivate);

                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Insumo " + InsumoPrivate.IdInsumo);
                    MessageBox.Show("Los datos del Proveedor se Actualizaron correctamente",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");
                    this.Dispose();
                    clearall();
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Editar un isumo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Insumos");
            this.Dispose(); clearall();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var InsumoPrivate = Utilitarios.OpInsumos.BuscarInsumos(cbbCodigoStock.SelectedValue.ToString());
                InsumoPrivate.CantInventario = InsumoPrivate.CantInventario + float.Parse(txtAjuste.Text);
                Utilitarios.OpInsumos.ActualizarInsumo(InsumoPrivate);
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Actualizacion de Cantidad en Stock " + InsumoPrivate.IdInsumo);
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Editar stock de Insumo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbCodigoStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DATOS.Insumos InsumoPrivate = Utilitarios.OpInsumos.BuscarInsumos(cbbCodigoStock.SelectedItem.ToString());
                var ProveedorId = Utilitarios.OpProveedor.BuscarProveedor(InsumoPrivate.Proveedor);
                txtCantidadStock.Text = InsumoPrivate.CantInventario.ToString();
                txtMedidaStock.Text = InsumoPrivate.IdMedida;
                txtNombreStock.Text = InsumoPrivate.Nombre;
                txtProveedorStock.Text = ProveedorId.Nombre;
                txtPrecioCompraStock.Text = "‎₡ " + InsumoPrivate.PrecioCompra.ToString();
                if (InsumoPrivate.Activo)
                {
                    chkActivoInventario.Checked = true;
                }
                else
                {
                    chkActivoInventario.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Cargar los datos stock de Insumo en el combobox de Inventario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            try
            {
                var InsumoPrivate = Utilitarios.OpInsumos.BuscarInsumos(cbbCodigoStock.SelectedValue.ToString());
                InsumoPrivate.CantInventario = float.Parse(txtAjuste.Text);
                Utilitarios.OpInsumos.ActualizarInsumo(InsumoPrivate);
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Editar stock de Insumo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearall()
        {
            txtIdInsumo.Clear();
            txtNombre.Clear();
            txtStock.Clear();
            txtPrecioCompra.Clear();
        }
    }
}


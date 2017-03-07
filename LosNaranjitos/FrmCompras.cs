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
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }
        public static DATOS.FacturaCompra EditFacturaCompra = new DATOS.FacturaCompra();
        public static List<DATOS.FacturaCompra> ListaFacturas = new List<DATOS.FacturaCompra>();

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.Cambio == false)
                {
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.FacturaCompra UltimaFactura = Utilitarios.OpFacturaCompra.ListarFacturas().OrderByDescending(x => x.Consecutivo).First();
                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Factura-Compras").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSFactura = Consecutivo.ConsecutivoActual + 1;
                    UltimaFactura.Consecutivo = Prefijo + "-" + CSFactura;
                    if (Utilitarios.OpFacturaCompra.ExisteConsecutivo(UltimaFactura.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimaFactura.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnNuevo.Enabled = false;
                    }
                    lblConsecutivo.Text = UltimaFactura.Consecutivo;
                }
                ListaFacturas = Utilitarios.OpFacturaCompra.ListarFacturas();
                var ListaLocal = ListaFacturas.ToList();
                dgvListado.DataSource = ListaLocal;

                dtpFechaFactura.Value = DateTime.Today;
                cbbProveedor.DataSource = Utilitarios.OpProveedor.ListarProveedores().Select(X => X.Nombre);
                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                cbBuscar.SelectedIndex = 0;
                cbbProveedor.SelectedIndex = 0;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.IdFactura));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;

                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtIdFactura.Text = EditFacturaCompra.IdFactura;
                        txtObservaciones.Text = EditFacturaCompra.Observaciones;
                        lblConsecutivo.Text = EditFacturaCompra.Consecutivo;
                        DATOS.Proveedor ProvLocal = Utilitarios.OpProveedor.BuscarProveedor(EditFacturaCompra.IdProveedor);
                        cbbProveedor.SelectedItem = ProvLocal.Nombre;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Compras al Cargar el formulario ");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdFactura.Text) || string.IsNullOrWhiteSpace(txtIdFactura.Text) ||
               string.IsNullOrEmpty(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMonto.Text) ||
               string.IsNullOrEmpty(txtObservaciones.Text) || string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    if (Utilitarios.OpFacturaCompra.ExisteFactura(txtIdFactura.Text))
                    {
                        MessageBox.Show("Factura Duplicado",
                                            "No se puede Ingresar una Factura duplicado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso Fallido de Factura de Compra " + txtIdFactura.Text + ", Factura ya existe");

                        return;
                    }
                    else
                    {
                        DATOS.Proveedor ProvLocal = Utilitarios.OpProveedor.BuscarProveedorPorNombre(cbbProveedor.SelectedItem.ToString());
                        DATOS.FacturaCompra FacturaCompraPrivate = new DATOS.FacturaCompra
                        {
                            Consecutivo = lblConsecutivo.Text,
                            IdProveedor = ProvLocal.IdProveedor,
                            Monto = Convert.ToDecimal(txtMonto.Text),
                            Fecha = dtpFechaFactura.Value,
                            Observaciones = txtObservaciones.Text,
                            IdFactura = txtIdFactura.Text,
                            Operador = FrmLogin.UsuarioGlobal.Username
                        };
                        Utilitarios.OpFacturaCompra.AgregarFacturaCompra(FacturaCompraPrivate);

                        DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Factura-Compras");
                        Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Factura-Compras Nuevo " + EditFacturaCompra.IdFactura);

                        MessageBox.Show("Los datos de la Factura se ingresaron correctamente", "Ingreso de datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tabControl1.SelectedIndex = 0;
                    ClearAll();
                    dgvListado.Refresh();
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Facturas de Compras al Intentar Agregar una Factura nuevo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearAll()
        {
            txtBuscar.Clear();
            txtIdFactura.Clear();
            txtMonto.Clear();
            txtObservaciones.Clear();
            cbBuscar.SelectedIndex = 0;
            cbbProveedor.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Compras");
            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Compras");
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdFactura.Text))
            {
                FrmEdicionFacturaCompra a = new FrmEdicionFacturaCompra();
                a.Show();
                this.Dispose();
            }
            else
            {
                if (Utilitarios.OpFacturaCompra.ExisteFactura(txtIdFactura.Text))
                {
                    EditarFactura();
                    Utilitarios.Cambio = false;
                }
                else
                {
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Factura Fallida, Factura No existe");
                    MessageBox.Show("Factura No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EditarFactura()
        {
            if (string.IsNullOrEmpty(txtIdFactura.Text) || string.IsNullOrWhiteSpace(txtIdFactura.Text) ||
               string.IsNullOrEmpty(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMonto.Text) ||
               string.IsNullOrEmpty(txtObservaciones.Text) || string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DATOS.Proveedor ProvLocal = Utilitarios.OpProveedor.BuscarProveedorPorNombre(cbbProveedor.SelectedItem.ToString());
                    DATOS.FacturaCompra FacturaCompraPrivate = new DATOS.FacturaCompra
                    {
                        Consecutivo = lblConsecutivo.Text,
                        IdProveedor = ProvLocal.IdProveedor,
                        Monto = Convert.ToDecimal(txtMonto.Text),
                        Fecha = dtpFechaFactura.Value,
                        Observaciones = txtObservaciones.Text,
                        IdFactura = txtIdFactura.Text,
                        Operador = FrmLogin.UsuarioGlobal.Username
                    };

                    Utilitarios.OpFacturaCompra.ActualizarFacturaCompra(FacturaCompraPrivate);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Factura " + FacturaCompraPrivate.IdFactura);
                    MessageBox.Show("Los datos de la Factura se Actualizaron correctamente",
                   "Actualizacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    tabControl1.SelectedIndex = 0;
                    dgvListado.Refresh();
                }
                catch (Exception ex)
                {

                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Editar Proveedor ");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

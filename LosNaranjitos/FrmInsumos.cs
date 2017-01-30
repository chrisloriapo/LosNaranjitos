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
    public partial class FrmInsumos : Form
    {
        public static DATOS.Insumos EditInsumo = new DATOS.Insumos();
        public static List<DATOS.Insumos> ListaInsumos = new List<DATOS.Insumos>();
        public BL.Interfaces.IInsumos OpInsumos = new BL.Clases.Insumos();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IProveedor OpProveedor = new BL.Clases.Proveedor();
        public BL.Interfaces.IMedida OpMedidas = new BL.Clases.Medida();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();


        public FrmInsumos()
        {
            InitializeComponent();
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmInsumos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'orangeDB1DataSet.VProveedor_Insumo' Puede moverla o quitarla según sea necesario.
            this.vProveedor_InsumoTableAdapter.Fill(this.orangeDB1DataSet.VProveedor_Insumo);
            ListaInsumos = OpInsumos.ListarInsumos();
            var ListaLocal = ListaInsumos.ToList();
            dgvListado.DataSource = ListaLocal;

            var autosearch = new AutoCompleteStringCollection();
            txtBuscar.AutoCompleteCustomSource = autosearch;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var pos in ListaLocal)
            {
                autosearch.Add(Convert.ToString(pos.Nombre));
            }
            txtBuscar.AutoCompleteCustomSource = autosearch;
            while (Utilitarios.Cambio)
            {
                DATOS.Proveedor Prov = new DATOS.Proveedor();
                Prov = OpProveedor.BuscarProveedor(EditInsumo.Proveedor);

                tabControl1.SelectedIndex = 1;
                if (Utilitarios.Cambio)
                {
                    txtIdInsumo.Text = EditInsumo.IdInsumo;
                    txtNombre.Text = EditInsumo.Nombre;
                    txtPrecioCompra.Text = EditInsumo.PrecioCompra.ToString();
                    txtStock.Text = EditInsumo.CantInventario.ToString();
                    txtPorcion.Text = EditInsumo.Porcion.ToString();

                    cbMedida.SelectedValue = EditInsumo.IdMedida;

                    cbProveedor.SelectedValue = Prov.Nombre;
                    chkActivo.Checked = EditInsumo.Activo;

                }
                else
                {
                    return;
                }
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
                    if (OpInsumos.ExisteInsumo(txtIdInsumo.Text))
                    {
                        MessageBox.Show("Insumo Duplicado",
                                            "No se puede Ingresar Insumo duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DATOS.Proveedor Prov = new DATOS.Proveedor();
                        Prov = OpProveedor.BuscarProveedorPorNombre(cbProveedor.SelectedValue.ToString());

                        DATOS.Insumos InsumoPrivate = new DATOS.Insumos
                        {
                            IdInsumo = txtIdInsumo.Text,
                            Nombre = txtNombre.Text,
                            Activo = chkActivo.Checked,
                            PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                            CantInventario = float.Parse(txtStock.Text),
                            IdMedida = cbMedida.SelectedValue.ToString(),
                            Proveedor = Prov.IdProveedor,

                        };

                        OpInsumos.ActualizarInsumo(InsumoPrivate);
                    }

                    MessageBox.Show("Los datos del Proveedor se ingresaron correctamente",
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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}

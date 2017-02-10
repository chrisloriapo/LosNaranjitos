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
    public partial class FrmProductosVenta : Form
    {

        public BL.Interfaces.IInsumos OpInsumos = new BL.Clases.Insumos();
        public BL.Interfaces.IProductoInsumo OpInsumoProducto = new BL.Clases.ProductoInsumo();
        public BL.Interfaces.IProducto OpProductos = new BL.Clases.Producto();
        public BL.Interfaces.IConsecutivo ConsecutivoOperaciones = new BL.Clases.Consecutivo();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();
        public DATOS.Bitacora BIT = new DATOS.Bitacora();
        public static DATOS.Producto EditProducto = new DATOS.Producto();
        public static DATOS.Producto NuevoProducto = new DATOS.Producto();
        public static DATOS.ProductoInsumo RecetaNueva = new DATOS.ProductoInsumo();
        public static DATOS.ProductoInsumo RecetaEditada = new DATOS.ProductoInsumo();
        public static List<DATOS.Producto> ListaProductos = new List<DATOS.Producto>();

        public static string Summary;

        public FrmProductosVenta()
        {
            InitializeComponent();
        }

        private void FrmProductosVenta_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = OpProductos.ListarProductos();
                lstAllInsumos.DataSource = OpInsumos.ListarInsumos().Select(x => x.Nombre).ToList();

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Summary.DefaultIfEmpty();
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Digita al menos el nombre del Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    lstInsumosSelected.Items.Add(lstAllInsumos.SelectedItems);
                    Summary = "El Producto " + txtNombre.Text + " contiene los siguientes insumos \n";
                    foreach (var insumo in lstInsumosSelected.SelectedItems)
                    {
                        Summary = Summary + "\t " + insumo + "\n";
                    }
                }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lstAllInsumos.Items.Clear();
                lstAllInsumos.DataSource = OpInsumos.ListarInsumos().Select(x => x.Nombre);

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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                FrmEdicionProducto a = new FrmEdicionProducto();
                a.Show();
                this.Dispose();
            }
            else
            {
                if (OpProductos.ExisteProducto(txtIdProducto.Text))
                {
                    EditarProducto();
                    Utilitarios.Cambio = false;
                }
                else
                {
                    MessageBox.Show("Producto No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EditarProducto()
        { }

        private void btnQuitar_Click_1(object sender, EventArgs e)
        {

            if (lstInsumosSelected.SelectedItems.Count >= 1)
            {
                foreach (var item in lstInsumosSelected.SelectedItems)
                {
                    lstInsumosSelected.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Selecciona al menos un Insumo", "Selecciona al menos un Insumo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void AgregarInsumosaLista(object sender, EventArgs e)
        {
            if (lstAllInsumos.SelectedItems.Count >= 1)
            {
                foreach (var item in lstAllInsumos.SelectedItems)
                {
                    lstInsumosSelected.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Selecciona al menos un Insumo", "Selecciona al menos un Insumo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNuevoInsumo_Click(object sender, EventArgs e)
        {
            FrmInsumos a = new FrmInsumos();
            a.MdiParent = FrmLogin.MN;
            a.Show();

        }

        private void EditarProducto(object sender, EventArgs e)
        {

        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            tbOperacionesProductos.SelectedTab = tbReceta;
        }

        private void btnContinuar2_Click(object sender, EventArgs e)
        {
            tbOperacionesProductos.SelectedTab = tbCostos;

        }

        private void btnContinuar3_Click(object sender, EventArgs e)
        {
            tbOperacionesProductos.SelectedTab = tbResumen;

        }

        private void btnRegresar3_Click(object sender, EventArgs e)
        {
            tbOperacionesProductos.SelectedTab = tbReceta;

        }
    }
}

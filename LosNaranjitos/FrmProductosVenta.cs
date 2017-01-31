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
        public static DATOS.Producto EditProducto = new DATOS.Producto();
        public static List<DATOS.Producto> ListaProductos = new List<DATOS.Producto>();
        public BL.Interfaces.IInsumos OpInsumos = new BL.Clases.Insumos();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IProductoInsumo OpInsumoProducto = new BL.Clases.ProductoInsumo();
        public BL.Interfaces.IProducto OpProductos = new BL.Clases.Producto();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();

        public static string Summary; 

        public FrmProductosVenta()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductosVenta_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = OpProductos.ListarProductos();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInsumos FI = new FrmInsumos();
            FI.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Summary.DefaultIfEmpty();
                if (string.IsNullOrEmpty(txtNombre.Text)|| string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Digita al menos el nombre del Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    lstInsumosSelected.Items.Add(lstAllInsumos.SelectedItems);
                    Summary = "El Producto " + txtNombre.Text + " contiene los siguientes insumos \n";
                    foreach (var insumo in lstInsumosSelected.SelectedItems)
                    {
                        Summary = Summary + "\t "+insumo+"\n";
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Digita al menos el nombre del Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Summary.DefaultIfEmpty();
                    lstInsumosSelected.Items.Remove(lstInsumosSelected.SelectedItems);
                    Summary = "El Producto " + txtNombre.Text + " contiene los siguientes insumos \n";
                    foreach (var insumo in lstInsumosSelected.Items)
                    {
                        Summary = Summary + "\t " + insumo+ "\n";
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
        {
            //if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
            //  string.IsNullOrEmpty(txtEmpresa.Text) || string.IsNullOrWhiteSpace(txtEmpresa.Text) ||
            //  string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
            //  string.IsNullOrEmpty(txtIdProveedor.Text) || string.IsNullOrWhiteSpace(txtIdProveedor.Text) ||
            //  string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            //{
            //    MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
            //        "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{

            //    try
            //    {
            //        DATOS.Proveedor ProvedorPrivate = new DATOS.Proveedor
            //        {
            //            IdProveedor = txtIdProveedor.Text,
            //            Nombre = Utilitarios.Encriptar(txtEmpresa.Text, Utilitarios.Llave),
            //            Activo = chkEstado.Checked,
            //            Telefono = txtTelefono.Text,
            //            Correo = txtEmail.Text,

            //        };

            //        OpProveedor.ActualizarProveedor(ProvedorPrivate);
            //        MessageBox.Show("Los datos del Proveedor se Actualizaron correctamente",
            //       "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Dispose();
            //        clearall();
            //    }
            //    catch (Exception ex)
            //    {

            //        ER.Descripcion = ex.Message;
            //        ER.Tipo = "Error al Popular Datos";
            //        ER.Hora = DateTime.Now;
            //        OpErrpr.AgregarError(ER);
            //        MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
        }
    }
}

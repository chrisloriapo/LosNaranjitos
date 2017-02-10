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
        
            try
            {
                this.vProveedor_InsumoTableAdapter.Fill(this.orangeDB1DataSet.VProveedor_Insumo);
                var ListaLocal = this.orangeDB1DataSet.VProveedor_Insumo.ToList();
                dgvListado.DataSource = ListaLocal;
                cbMedida.DataSource = OpMedidas.ListarMedidas().Select(x => x.IdMedida).ToList();
                cbProveedor.DataSource = OpProveedor.ListarProveedores().Select(x => x.Nombre).ToList();
                cbbCodigo.DataSource = OpInsumos.ListarInsumos().Select(x => x.IdInsumo).ToList();

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
            catch (Exception ex)
            {
                
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
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
            if (string.IsNullOrEmpty(txtIdInsumo.Text))
            {
                FrmEdicionInsumos a = new FrmEdicionInsumos();
                a.Show();
                this.Dispose();
            }
            else
            {
                if (OpInsumos.ExisteInsumo(txtIdInsumo.Text))
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

        public void clearall()
        {
            txtIdInsumo.Clear();
            txtNombre.Clear();
            txtStock.Clear();
            txtPrecioCompra.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
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
                    var ProveedorId = OpProveedor.BuscarProveedorPorNombre(cbProveedor.SelectedValue.ToString());
                    DATOS.Insumos InsumoPrivate = new DATOS.Insumos
                    {
                        IdInsumo = txtIdInsumo.Text,
                        Nombre = txtNombre.Text,
                        Activo = chkActivo.Checked,
                        PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                        IdMedida = cbMedida.SelectedValue.ToString(),
                        Proveedor = ProveedorId.IdProveedor

                    };

                    OpInsumos.ActualizarInsumo(InsumoPrivate);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose(); clearall();
        }

        private void cbbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var InsumoPrivate = OpInsumos.BuscarInsumos(cbbCodigo.SelectedValue.ToString());
                InsumoPrivate.CantInventario = InsumoPrivate.CantInventario + float.Parse(txtAjuste.Text);
                OpInsumos.ActualizarInsumo(InsumoPrivate);
            }
            catch (Exception ex)
            {
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Actualizar Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var InsumoPrivate = OpInsumos.BuscarInsumos(cbbCodigo.SelectedValue.ToString());
                InsumoPrivate.CantInventario =  float.Parse(txtAjuste.Text);
                OpInsumos.ActualizarInsumo(InsumoPrivate);
            }
            catch (Exception ex)
            {
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Actualizar Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


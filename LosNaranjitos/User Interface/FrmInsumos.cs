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
        public static bool CBBool = false;
        public FrmInsumos()
        {
            InitializeComponent();
        }

        private void FrmInsumos_Load(object sender, EventArgs e)
        {

            try
            {

                if (Utilitarios.OpProveedor.ListarProveedores().Count() == 0)
                {
                    MessageBox.Show("No existe ningun Proveedor Registrado, debes registrar proveedores para ingresar Insumos nuevos, pureba Ingresando un nuevo registro en el modulo de Proveedores", "No hay datos a modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utilitarios.GeneralError("No existe ningun Proveedor Registrado, debes registrar proveedores para ingresar Insumos nuevos, pureba Ingresando un nuevo registro en el modulo de Proveedores", "No hay datos disponibles", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Cargar el formulario ");
                    this.BeginInvoke(new MethodInvoker(Close));

                }
                if (Utilitarios.OpInsumos.ListarInsumos().Count() == 0)
                {
                    tbcInsumos.TabPages.Remove(tbStock);
                    btnEditar.Enabled = false;
                }
                else
                {
                    cbbCodigoStock.DataSource = Utilitarios.OpInsumos.ListarInsumos().Select(x => x.IdInsumo).ToList();
                    cbbCodigoStock.SelectedIndex = 0;
                }

                for (int i = 0; i < 101; i++)
                {
                    cbbPorcentajeRendimiento.Items.Add(i);
                }
                cbbPorcentajeRendimiento.SelectedIndex = 0;
                CBBool = true;
                //Verificacion de Consecutivo
                if (!Utilitarios.Cambio)
                {
                    //DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    //List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Insumos UltimoInsumo = new Insumos();
                    try
                    {
                        UltimoInsumo = Utilitarios.OpInsumos.ListarInsumos().OrderByDescending(x => x.Consecutivo).FirstOrDefault();
                        if (UltimoInsumo == null)
                        {
                            UltimoInsumo = new Insumos()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimoInsumo.Consecutivo.ToString();

                        }
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimoInsumo = new Insumos()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimoInsumo.Consecutivo.ToString();

                        }
                    }
                    //string Prefijo = Consecutivos.Where(x => x.Tipo == "Insumo").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSInsumo = Consecutivo.ConsecutivoActual + 1;
                    //UltimoInsumo.Consecutivo = Prefijo + "-" + CSInsumo;
                    //if (Utilitarios.OpUsuarios.ExisteConsecutivo(UltimoInsumo.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimoInsumo.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnNuevo.Enabled = false;
                    //}
                }
                //Carga de Formulario Usual

                txtIdInsumo.ReadOnly = false;
                cbBuscar.SelectedIndex = 0;
                var ListaLocal = Utilitarios.OpInsumos.ListarInsumos();
                dgvListado.DataSource = ListaLocal;
                cbMedida.DataSource = Utilitarios.OpMedidas.ListarMedidas().Select(x => x.IdMedida).ToList();
                cbProveedor.DataSource = Utilitarios.OpProveedor.ListarProveedores().Select(x => x.NombreProveedor).ToList();


                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.Nombre));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
                cbBuscar.SelectedIndex = 0;
                //--------------------------------------------


                while (Utilitarios.Cambio)
                {
                    DATOS.Proveedor Prov = new DATOS.Proveedor();
                    Prov = Utilitarios.OpProveedor.BuscarProveedor(EditInsumo.Proveedor);
                    txtIdInsumo.ReadOnly = true;
                    tbcInsumos.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtIdInsumo.Text = EditInsumo.IdInsumo;
                        txtNombre.Text = EditInsumo.Nombre;
                        txtPrecioCompra.Text = EditInsumo.PrecioCompra.ToString();
                        txtStock.Text = EditInsumo.CantInventario.ToString();
                        lblConsecutivo.Text = EditInsumo.Consecutivo.ToString();
                        cbMedida.SelectedItem = EditInsumo.IdMedida;

                        cbProveedor.SelectedItem = Prov.NombreProveedor;
                        chkActivo.Checked = EditInsumo.Activo;
                        lblPrecioMermado.Text = EditInsumo.PrecioMermado.ToString();
                        txtRendimientoUM.Text = EditInsumo.RendimientoUM.ToString();
                        cbbPorcentajeRendimiento.Text = (EditInsumo.RendimientoPorcion * 100).ToString();

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
                          //  Consecutivo = lblConsecutivo.Text,
                            IdInsumo = txtIdInsumo.Text,
                            Nombre = txtNombre.Text,
                            Activo = chkActivo.Checked,
                            PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                            CantInventario = float.Parse(txtStock.Text),
                            IdMedida = cbMedida.SelectedValue.ToString(),
                            Proveedor = Prov.IdProveedor,
                            PrecioMermado = Convert.ToDecimal(lblPrecioMermado.Text),
                            RendimientoPorcion = float.Parse(cbbPorcentajeRendimiento.Text) / 100,
                            RendimientoUM = float.Parse(txtRendimientoUM.Text)
                        };

                        Utilitarios.OpInsumos.AgregarInsumo(InsumoPrivate);

                        //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Insumo");
                        //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Insumos Nuevo " + InsumoPrivate.IdInsumo);

                        MessageBox.Show("Los datos del Insumo se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Insumos");
                        clearall();
                        dgvListado.DataSource = Utilitarios.OpInsumos.ListarInsumos();
                        tbcInsumos.SelectedIndex = 0;
                        this.FrmInsumos_Load(sender, e);
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
            clearall();
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = Utilitarios.OpInsumos.ListarInsumos();


                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Codigo":
                        ListaLocal = ListaLocal.Where(x => x.IdInsumo == txtBuscar.Text).ToList();
                        break;
                    case "Proveedor":
                        ListaLocal = ListaLocal.Where(x => x.Proveedor == txtBuscar.Text).ToList();
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
                var ListaLocal = Utilitarios.OpInsumos.ListarInsumos();


                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                switch (cbBuscar.SelectedItem.ToString())
                {
                    case "Codigo":
                        txtBuscar.Visible = true;
                        btnBuscar.Visible = true;
                        var  ListaLocalx = ListaLocal.Select(x => x.IdInsumo).ToList();
                        foreach (var pos in ListaLocalx)
                        {
                            autosearch.Add(pos);
                        }
                        break;
                    case "Proveedor":
                        txtBuscar.Visible = true;
                        btnBuscar.Visible = true;
                        ListaLocalx = ListaLocal.Select(x => x.Proveedor).ToList();
                        foreach (var pos in ListaLocalx)
                        {
                            autosearch.Add(pos);
                        }
                        break;
                    case "Lista Completa":

                        dgvListado.DataSource = ListaLocal.ToList();
                        txtBuscar.Visible = false;
                        btnBuscar.Visible = false;
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
                        //Consecutivo = lblConsecutivo.Text,
                        IdInsumo = txtIdInsumo.Text,
                        Nombre = txtNombre.Text,
                        Activo = chkActivo.Checked,
                        PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                        IdMedida = cbMedida.SelectedValue.ToString(),
                        Proveedor = ProveedorId.IdProveedor,
                        PrecioMermado = Convert.ToDecimal(lblPrecioMermado.Text),
                        RendimientoPorcion = float.Parse(cbbPorcentajeRendimiento.Text) / 100,
                        RendimientoUM = float.Parse(txtRendimientoUM.Text)
                    };

                    Utilitarios.OpInsumos.ActualizarInsumo(InsumoPrivate);

                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Insumo " + InsumoPrivate.IdInsumo);
                    MessageBox.Show("Los datos del Proveedor se Actualizaron correctamente",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");
                    clearall();
                    dgvListado.DataSource = Utilitarios.OpInsumos.ListarInsumos();
                    tbcInsumos.SelectedIndex = 0;
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
            clearall();
            this.Dispose();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var InsumoPrivate = Utilitarios.OpInsumos.BuscarInsumos(cbbCodigoStock.SelectedValue.ToString());
                InsumoPrivate.CantInventario = InsumoPrivate.CantInventario + float.Parse(txtAjuste.Text);
                Utilitarios.OpInsumos.ActualizarInsumo(InsumoPrivate);
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Actualizacion de Cantidad en Stock " + InsumoPrivate.IdInsumo);
                MessageBox.Show("Actualizacion de Cantidad en Stock", "Actualización Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvListado.DataSource = Utilitarios.OpInsumos.ListarInsumos();
                clearall();

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
                txtProveedorStock.Text = ProveedorId.NombreProveedor;
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
                MessageBox.Show("Actualizacion de Cantidad en Stock", "Actualización COmpleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvListado.DataSource = Utilitarios.OpInsumos.ListarInsumos();
                clearall();
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
            txtBuscar.Clear();
            txtAjuste.Clear();
            txtRendimientoUM.Clear();
            CBBool = false;

        }

        private void cbbPorcentajeRendimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (CBBool)
                {
                    if ((string.IsNullOrEmpty(txtPrecioCompra.Text) || string.IsNullOrWhiteSpace(txtPrecioCompra.Text))&&EditInsumo==null)
                    {
                        MessageBox.Show("Debes digitar el Precio del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPrecioCompra.Focus();
                        //cbbPorcentajeRendimiento.Text = "";
                        return;
                    }
                    if ((string.IsNullOrEmpty(txtRendimientoUM.Text) || string.IsNullOrWhiteSpace(txtRendimientoUM.Text))&& EditInsumo == null)
                    {
                        MessageBox.Show("Debes digitar el Rendimiento del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRendimientoUM.Focus();
                        //cbbPorcentajeRendimiento.Text = "";
                        return;
                    }
                    else
                    {
                        float precio = ((float.Parse(txtPrecioCompra.Text) / float.Parse(txtRendimientoUM.Text)) * (1 - ((float.Parse(cbbPorcentajeRendimiento.SelectedItem.ToString()) / 100))) + (float.Parse(txtPrecioCompra.Text) / float.Parse(txtRendimientoUM.Text)));
                        lblPrecioMermado.Text = precio.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Calcular Precio de Mermado stock de Insumo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtPrecioCompra.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRendimientoUM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtRendimientoUM.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtStock.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


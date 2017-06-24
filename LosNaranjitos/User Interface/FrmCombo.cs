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
    public partial class FrmCombo : Form
    {


        public FrmCombo()
        {
            InitializeComponent();
        }
        public static DATOS.Combo EditCombo = new DATOS.Combo();
        public static DATOS.Combo NuevoCombo = new DATOS.Combo();
        public static DATOS.ComboProducto IngredienteNuevo = new DATOS.ComboProducto();
        public static DATOS.ComboProducto IngredienteEditado = new DATOS.ComboProducto();
        public static List<DATOS.ComboProducto> Receta = new List<DATOS.ComboProducto>();
        public static List<DATOS.Combo> ListaCombos = new List<DATOS.Combo>();
        public static List<DATOS.Producto> ListaProductos = new List<DATOS.Producto>();

        private void FrmCombo_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpProducto.ListarProductos().Count == 0)
                {
                    MessageBox.Show("No existe ningun Producto Registrado, debes registrar Productos para ingresar Combos o promociones nuevos, pureba Ingresando un nuevo registro en el modulo de Productos", "No hay datos a Utilizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utilitarios.GeneralError("No existe ningun Producto Registrado, debes registrar Productos para ingresar Combos o promociones nuevos, pureba Ingresando un nuevo registro en el modulo de Productos", "No hay datos disponibles", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Cargar el formulario ");
                    this.BeginInvoke(new MethodInvoker(Close));

                }
                if (Utilitarios.OpCombo.ListarCombo().Count == 0)
                {
                    btnEditarProducto.Enabled = false;
                }
                dgvListado.DataSource = Utilitarios.OpCombo.ListarCombo();
                lstAllProducts.DataSource = Utilitarios.OpProducto.ListarProductos().Select(x => x.Nombre).ToList();
                tbOperacionesProductos.TabPages.Remove(tbProductos);
                tbOperacionesProductos.TabPages.Remove(tbCostos);
                tbOperacionesProductos.TabPages.Remove(tbResumen);

                if (!Utilitarios.Cambio)
                {
                    //Validacion Consecutivos Producto
                    txtIdCombo.ReadOnly = false;
                    //DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    //List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Combo UltimoCombo = new Combo();
                    try
                    {
                        UltimoCombo = Utilitarios.OpCombo.ListarCombo().OrderByDescending(x => x.Consecutivo).First();
                        if (UltimoCombo == null)
                        {
                            UltimoCombo = new Combo()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimoCombo.Consecutivo.ToString();

                        }
                        else
                        {
                            lblConsecutivo.Text = UltimoCombo.Consecutivo.ToString();
                        }
                    }
                    catch (Exception x)
                    {

                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimoCombo = new Combo()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimoCombo.Consecutivo.ToString();
                        }
                    }
                    //string Prefijo = Consecutivos.Where(x => x.Tipo == "Combo").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSCombo = Consecutivo.ConsecutivoActual + 1;
                    //UltimoCombo.Consecutivo = Prefijo + "-" + CSCombo;
                    //if (Utilitarios.OpCombo.ExisteConsecutivo(UltimoCombo.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimoCombo.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnAgregar.Enabled = false;
                    //}

                    //Validacion Consecutivos Productos

                    DATOS.ComboProducto UltimoComboProducto = new ComboProducto();
                    try
                    {
                        UltimoComboProducto = Utilitarios.OpComboProducto.ListarComboProductos().OrderByDescending(x => x.Consecutivo).First();
                        if (UltimoComboProducto == null)
                        {
                            UltimoComboProducto = new ComboProducto()
                            {
                                Consecutivo = 1
                            };
                        }
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimoComboProducto = new ComboProducto()
                            {
                                Consecutivo = 1
                            };
                        }
                    }
                    //Prefijo = Consecutivos.Where(x => x.Tipo == "Combo-Producto").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSComboProducto = Consecutivo.ConsecutivoActual + 1;
                    //UltimoComboProducto.Consecutivo = Prefijo + "-" + CSComboProducto;
                    //if (Utilitarios.OpProductoInsumo.ExisteConsecutivo(UltimoComboProducto.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimoComboProducto.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnAgregar.Enabled = false;
                    //}
                }
                while (Utilitarios.Cambio)
                {
                    txtIdCombo.ReadOnly = true;
                    btnEditarProducto.Visible = false;
                    tbcProductos.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        tbOperacionesProductos.TabPages.Add(tbProductos);
                        tbOperacionesProductos.TabPages.Add(tbCostos);
                        txtIdCombo.Text = EditCombo.Codigo;
                        lblConsecutivo.Text = EditCombo.Consecutivo.ToString();
                        txtNombre.Text = EditCombo.Nombre;

                        txtDescricpion.Text = EditCombo.Descripcion;
                        chkActivo.Visible = true;

                        if (EditCombo.Activo)
                        {
                            chkActivo.Checked = true;
                        }
                        else
                        {
                            chkActivo.Checked = false;
                        }

                        txtPrecioTotal.Text = EditCombo.Precio.ToString();
                        Receta = Utilitarios.OpComboProducto.ListarComboProductos().Where(x => x.CodCombo == EditCombo.Codigo).ToList();
                        foreach (var item in Receta)
                        {
                            DATOS.Producto Product = Utilitarios.OpProducto.BuscarProducto(item.CodProducto);
                            ListaProductos.Add(new Producto()
                            {
                                Consecutivo = Product.Consecutivo,
                                Activo = Product.Activo,
                                Nombre = Product.Nombre,
                                Categoria = Product.Categoria,
                                Codigo = Product.Codigo,
                                Descripcion = Product.Descripcion,
                                Precio = Product.Precio

                            });

                            for (int i = 0; i < item.CantidadProducto; i++)
                            {
                                lstProductosSelected.Items.Add(Product.Nombre);
                            }
                        }
                        Receta.Clear();
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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Cargar Formulario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Combos");
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Combos");
            Utilitarios.Cambio = false;
            this.Dispose();
        }

        private void btnDescartarPromo_Click(object sender, EventArgs e)
        {

            var mensaje = MessageBox.Show("Esta a punto de Descartar el Combo " + NuevoCombo.Nombre + " ¿Desea continuar?", "Advertencia",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (mensaje == DialogResult.Yes)
            {
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Combos");
                Utilitarios.Cambio = false;
                this.Dispose();
            }
            else
            {
                return;
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCombo.Text))
            {
                FrmEdicionCombo a = new FrmEdicionCombo();
                a.Show();
                btnConfirmarCombo.Text = "Aceptar y someter cambios";
                this.Dispose();
            }
            else
            {
                if (Utilitarios.OpProducto.ExisteProducto(txtIdCombo.Text))
                {
                    EditCombo = Utilitarios.OpCombo.BuscarCombo(txtIdCombo.Text);
                    Utilitarios.Cambio = true;
                    this.FrmCombo_Load(sender, e);
                    btnEditarProducto.Visible = false;
                    btnConfirmarCombo.Text = "Aceptar y someter cambios";
                }
                else
                {
                    MessageBox.Show("Combo No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditarCombo()
        {


        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {

            try
            {
                if (Utilitarios.OpCombo.ExisteCombo(txtIdCombo.Text))
                {
                    MessageBox.Show("Ya Existe Un Codigo de Combo/Promoción Relacionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtIdCombo.Text) || string.IsNullOrWhiteSpace(txtIdCombo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    NuevoCombo.Activo = true;
                    NuevoCombo.Codigo = txtIdCombo.Text;
                    //       NuevoCombo.Consecutivo = lblConsecutivo.Text;
                    NuevoCombo.Descripcion = txtDescricpion.Text;
                    NuevoCombo.Nombre = txtNombre.Text;


                    tbOperacionesProductos.SelectedTab = tbProductos;
                    if (!tbOperacionesProductos.Contains(tbProductos))
                    {
                        tbOperacionesProductos.TabPages.Add(tbProductos);
                    }
                    Receta.Clear();
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Presionar Click en la continuacion de los Datos del Combos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinuar2_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtIdCombo.Text) || string.IsNullOrWhiteSpace(txtIdCombo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (lstProductosSelected.Items.Count > 0)
                    {
                        Receta.Clear();
                        ListaProductos.Clear();
                    //    DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Combo-Producto");


                        foreach (var item in lstProductosSelected.Items)
                        {
                            ListaProductos.Add(Utilitarios.OpProducto.ListarProductos().Where(c => c.Nombre == item.ToString()).FirstOrDefault());
                        }
                        ListaProductos = ListaProductos.OrderBy(x => x.Codigo).ToList();
                        var ListaInsumos2 = ListaProductos.OrderBy(x => x.Codigo).ToList();
                        foreach (var item in ListaInsumos2)
                        {
                            if (ListaProductos.Contains(item))
                            {

                            //    Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                                //  IngredienteNuevo.Consecutivo = "CDP-" + Consecutivo.ConsecutivoActual;
                                IngredienteNuevo.CodCombo = NuevoCombo.Codigo;
                                IngredienteNuevo.CodProducto = ListaProductos.FirstOrDefault().Codigo;
                                IngredienteNuevo.CantidadProducto = float.Parse(ListaProductos.Where(c => c.Codigo == IngredienteNuevo.CodProducto).Count().ToString());

                                NuevoCombo.Precio = NuevoCombo.Precio + (item.Precio * (Convert.ToDecimal(IngredienteNuevo.CantidadProducto)));

                                ListaProductos.RemoveAll(x => x.Codigo == IngredienteNuevo.CodProducto);

                                Receta.Add(new ComboProducto()
                                {
                                    CodProducto = IngredienteNuevo.CodProducto,
                                    Consecutivo = IngredienteNuevo.Consecutivo,
                                    CantidadProducto = IngredienteNuevo.CantidadProducto,
                                    CodCombo = IngredienteNuevo.CodCombo,
                                    IdMedida = "u"

                                });
                            }
                        }

                        txtPrecioBase.Text = NuevoCombo.Precio.ToString();
                        txtPrecioSugerido.Text = NuevoCombo.Precio.ToString();
                        if (!tbOperacionesProductos.Contains(tbCostos))
                        {
                            tbOperacionesProductos.TabPages.Add(tbCostos);
                        }
                        tbOperacionesProductos.SelectedTab = tbCostos;

                    }
                    else
                    {
                        MessageBox.Show("Debes Seleccionar Los Productos que requiere la oferta " + txtNombre.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Presionar Click en la continuacion de los Productos del Combo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinuar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdCombo.Text) || string.IsNullOrWhiteSpace(txtIdCombo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDatosG.Focus();
                    return;
                }
                if (lstProductosSelected.Items.Count == 0)
                {
                    MessageBox.Show("Debes Seleccionar Los Productos que requiere el Combo " + txtNombre.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbProductos.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecioTotal.Text) || string.IsNullOrWhiteSpace(txtPrecioTotal.Text))
                {
                    MessageBox.Show("Debes Especificar el precio del Combo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioTotal.Focus();
                    return;
                }
                NuevoCombo.Precio = Convert.ToDecimal(txtPrecioTotal.Text);
                tbOperacionesProductos.TabPages.Add(tbResumen);
                lblComboResumen.Text = NuevoCombo.Nombre;
                lblCodigo.Text = NuevoCombo.Codigo;
                lblConsecutivoResumen.Text = NuevoCombo.Consecutivo.ToString();
                lblDescripcionResumen.Text = NuevoCombo.Descripcion;
                lblPrecioVenta.Text = "₡ " + NuevoCombo.Precio.ToString();

                var result = Receta.Join(
                    Utilitarios.OpProducto.ListarProductos(),
                a => a.CodProducto,
                b => b.Codigo,
                (a, b) => new { a.Consecutivo, b.Codigo, b.Nombre, a.CantidadProducto });

                dgvResumen.DataSource = result.ToList();
                dgvResumen.RowHeadersVisible = false;
                dgvResumen.ColumnHeadersVisible = false;
                dgvResumen.GridColor = Color.White;
                dgvResumen.BackgroundColor = Color.White;
                tbOperacionesProductos.SelectedTab = tbResumen;

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Presionar Click en la continuacion de los Costos del Combo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnConfirmarCombo_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnConfirmarCombo.Text == "Aceptar y someter cambios")
                {
                    var mensajex = MessageBox.Show("Esta a Punto de Modificar el producto " + EditCombo.Nombre + " ¿Desea continuar?", "Advertencia",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (mensajex == DialogResult.Yes)
                    {
                        EditCombo.Activo = chkActivo.Checked;
                        Utilitarios.OpCombo.ActualizarCombo(EditCombo);

                        foreach (var item in Utilitarios.OpComboProducto.ListarComboProductos().Where(x => x.CodCombo == EditCombo.Codigo))
                        {
                            Utilitarios.OpComboProducto.EliminarProductodeCombo(item);
                        }

                        foreach (var Ingrediente in Receta)
                        {

                            Ingrediente.CodCombo = EditCombo.Codigo;
                            Utilitarios.OpComboProducto.AgregarComboProducto(Ingrediente);
                            //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto-Insumo");
                            //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                            //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Producto a Combo ya existente " + Ingrediente.Consecutivo);

                        }
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Producto Nuevo " + NuevoCombo.Nombre);

                        MessageBox.Show("Los datos del Producto se Modificaron correctamente",
    "Modificacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                    this.FrmCombo_Load(sender, e);
                }
                else
                {
                    var mensaje = MessageBox.Show("Esta a Punto de Ingresar la Oferta " + NuevoCombo.Nombre + " ¿Desea continuar?", "Advertencia",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (mensaje == DialogResult.Yes)
                    {
                        NuevoCombo.Activo = true;
                        Utilitarios.OpCombo.AgregarCombo(NuevoCombo);
                        //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Combo");
                        //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        foreach (var Ingrediente in Receta)
                        {
                            Utilitarios.OpComboProducto.AgregarComboProducto(Ingrediente);
                            //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Combo-Producto");
                            //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                            //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Producto a Combo nuevo " + Ingrediente.Consecutivo);
                        }
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Oferta Nueva " + NuevoCombo.Nombre);

                        MessageBox.Show("Los datos del Combo Nuevo se ingresaron correctamente",
    "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Confirmar Ingreso de Oferta Nuevo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegresar3_Click(object sender, EventArgs e)
        {
            tbOperacionesProductos.SelectedTab = tbProductos;
            tbOperacionesProductos.TabPages.Remove(tbCostos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAllProducts.SelectedItems.Count >= 1)
                {
                    foreach (var item in lstAllProducts.SelectedItems)
                    {
                        lstProductosSelected.Items.Add(item);
                    }
                    lstAllProducts.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Selecciona al menos un Producto", "Selecciona al menos un Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Agregar Productos del Combo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            try
            {
                if (lstProductosSelected.SelectedItems.Count >= 1)
                {
                    for (int i = 0; i < lstProductosSelected.SelectedItems.Count; i++)
                    {
                        lstProductosSelected.Items.Remove(lstProductosSelected.SelectedItems[i].ToString());
                        i--;
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona al menos un Producto a Retirar", "Selecciona al menos un Producto ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combo al Quitar Productos del Combo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lstAllProducts.Refresh();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Refrescar Lista de Insumos en Modulo de Produtos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProductosVenta a = new FrmProductosVenta();
                a.MdiParent = FrmLogin.MN;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Productos desde Modulo de Combos ");
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Tratar de Ingresar al modulo de Productos del Combo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaCombos = Utilitarios.OpCombo.ListarCombo();
                var ListaLocal = ListaProductos.ToList();
                ListaLocal = ListaLocal.Where(x => x.Nombre == txtBuscar.Text).ToList();
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Combos al Intentar Buscar un Combo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtPrecioTotal.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

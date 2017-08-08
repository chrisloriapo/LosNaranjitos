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
    public partial class FrmProductosVenta : Form
    {


        public static DATOS.Producto EditProducto = new DATOS.Producto();
        public static DATOS.Producto NuevoProducto = new DATOS.Producto();
        public static DATOS.ProductoInsumo IngredienteNuevo = new DATOS.ProductoInsumo();
        public static DATOS.ProductoInsumo IngredienteEditado = new DATOS.ProductoInsumo();
        public static List<DATOS.ProductoInsumo> Receta = new List<DATOS.ProductoInsumo>();
        public static List<DATOS.Producto> ListaProductos = new List<DATOS.Producto>();
        public static List<DATOS.Insumos> ListaInsumos = new List<DATOS.Insumos>();

        public static string Summary;

        public FrmProductosVenta()
        {
            InitializeComponent();
        }

        private void FrmProductosVenta_Load(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                tbcProductos.SelectedIndex = 0;

                if (Utilitarios.OpInsumos.ListarInsumos().Count == 0)
                {
                    MessageBox.Show("No existe ningun Insumo Registrado, debes registrar Insumos para ingresar productos nuevos, pureba Ingresando un nuevo registro en el modulo de Insumos", "No hay datos a modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utilitarios.GeneralError("No existe ningun Insumo Registrado, debes registrar Insumos para ingresar productos nuevos, pureba Ingresando un nuevo registro en el modulo de Insumos", "No hay datos disponibles", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Cargar el formulario ");
                    this.BeginInvoke(new MethodInvoker(Close));

                }
                if (Utilitarios.OpProducto.ListarProductos().Count == 0)
                {
                    btnEditarProducto.Enabled = false;
                }


                var ListaProductos = Utilitarios.OpProducto.ListarProductos().Join(Utilitarios.OpCategorias.ListarCategorias(),
                               a => a.Categoria,
                               b => b.IdTipo,
                               (a, b) => new
                               {
                                   a.Codigo,
                                   a.Nombre,
                                   a.Descripcion,
                                   b.DescripcionCategoria,
                                   a.Precio,
                                   a.Activo,
                               }).OrderBy(x => x.Nombre).ToList();

                dgvListado.DataSource = ListaProductos;



                dgvListado.Columns[0].HeaderText = "Código";

                dgvListado.Columns[1].HeaderText = "Nombre";
                dgvListado.Columns[2].HeaderText = "Descripción";
                dgvListado.Columns[3].HeaderText = "Categoría";
                dgvListado.Columns[4].HeaderText = "Precio Venta";
                dgvListado.Columns[5].HeaderText = "Activo";

                dgvListado.Columns[4].DefaultCellStyle.Format = "c";
                

                lstAllInsumos.DataSource = Utilitarios.OpInsumos.ListarInsumos().OrderBy(x=>x.Nombre).Select(x => x.Nombre).ToList();
                tbOperacionesProductos.TabPages.Remove(tbReceta);
                tbOperacionesProductos.TabPages.Remove(tbCostos);
                tbOperacionesProductos.TabPages.Remove(tbResumen);
                cbCategoriaProducto.DataSource = Utilitarios.OpCategorias.ListarCategorias().Select(x => x.DescripcionCategoria).ToList();
                cbCategoriaProducto.SelectedIndex = 0;

                var ListaLocal = Utilitarios.OpCargas.ListarCargas().Where(x => x.Activo = true).Select(a => new
                {
                    a.Descripcion,
                    a.Porcentaje,

                }).ToList();

                dgvCargas.DataSource = ListaLocal.ToList();

                if (!Utilitarios.Cambio)
                {
                    //Validacion Consecutivos Producto
                    //Consecutivo Consecutivo = new Consecutivo();
                    //List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    txtIdProducto.ReadOnly = false;

                    Producto UltimoProducto = new Producto();
                    try
                    {
                        UltimoProducto = Utilitarios.OpProducto.ListarProductos().OrderByDescending(x => x.Consecutivo).First();
                        lblConsecutivo.Text = (UltimoProducto.Consecutivo + 1).ToString();
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos")
                        {
                            UltimoProducto.Consecutivo = 1;
                            lblConsecutivo.Text = UltimoProducto.Consecutivo.ToString();
                        }
                    }


                }
                while (Utilitarios.Cambio)
                {
                    btnConfirmarIngreso.Text = "Aceptar y someter cambios";

                    btnEditarProducto.Visible = false;
                    tbcProductos.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        tbOperacionesProductos.TabPages.Add(tbReceta);
                        tbOperacionesProductos.TabPages.Add(tbCostos);
                        txtIdProducto.Text = EditProducto.Codigo;
                        lblConsecutivo.Text = EditProducto.Consecutivo.ToString();
                        txtNombre.Text = EditProducto.Nombre;
                        txtIdProducto.ReadOnly = true;
                        //Carga de Categoria

                        DATOS.CategoriaProductos TCat = Utilitarios.OpCategorias.BuscarCategoriaProductos(EditProducto.Categoria);

                        cbCategoriaProducto.SelectedText = TCat.DescripcionCategoria;
                        txtDescricpion.Text = EditProducto.Descripcion;
                        chkActivo.Visible = true;

                        if (EditProducto.Activo)
                        {
                            chkActivo.Checked = true;
                        }
                        else
                        {
                            chkActivo.Checked = false;
                        }

                        txtPrecioTotal.Text = EditProducto.Precio.ToString();
                        try
                        {
                            Receta = Utilitarios.OpProductoInsumo.ListarProductoInsumo().Where(x => x.CodigoProducto == EditProducto.Codigo).ToList();
                            foreach (var item in Receta)
                            {
                                DATOS.Insumos Ins = Utilitarios.OpInsumos.BuscarInsumos(item.IdInsumo);
                                ListaInsumos.Add(new Insumos()
                                {
                                    IdInsumo = Ins.IdInsumo,
                                    Consecutivo = Ins.Consecutivo,
                                    Activo = Ins.Activo,
                                    CantInventario = Ins.CantInventario,
                                    IdMedida = Ins.IdMedida,
                                    Nombre = Ins.Nombre,
                                    PrecioCompra = Ins.PrecioCompra,
                                    PrecioMermado = Ins.PrecioMermado,
                                    Proveedor = Ins.Proveedor,
                                    RendimientoPorcion = Ins.RendimientoPorcion,
                                    RendimientoUM = Ins.RendimientoUM
                                });

                                for (int i = 0; i < item.CantidadRequerida; i++)
                                {
                                    lstInsumosSelected.Items.Add(Ins.Nombre);
                                }
                            }
                        }
                        catch (Exception x)
                        {
                            if (x.Message == "La secuencia no contiene elementos")
                            {
                                continue;
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


                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Cargar Formulario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.Cambio = false;
            EditProducto = new Producto();
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Productos");
            ClearForm();

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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Insumos a un producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lstAllInsumos.Refresh();
   
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Refrescar Lista de Insumos en Modulo de Produtos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                FrmEdicionProducto a = new FrmEdicionProducto();
                a.Show();
                btnEditarProducto.Visible = false;
                btnConfirmarIngreso.Text = "Aceptar y someter cambios";
                this.Dispose();
            }
            else
            {
                if (Utilitarios.OpProducto.ExisteProducto(txtIdProducto.Text))
                {
                    EditProducto = Utilitarios.OpProducto.BuscarProducto(txtIdProducto.Text);
                    Utilitarios.Cambio = true;
                    this.FrmProductosVenta_Load(sender, e);
                    btnEditarProducto.Visible = false;
                    btnConfirmarIngreso.Text = "Aceptar y someter cambios";

                }
                else
                {
                    MessageBox.Show("Producto No existe",
                    "Codigo No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnQuitar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lstInsumosSelected.SelectedItems.Count >= 1)
                {
                    for (int i = 0; i < lstInsumosSelected.SelectedItems.Count; i++)
                    {
                        lstInsumosSelected.Items.Remove(lstInsumosSelected.SelectedItems[i].ToString());
                        i--;
                    }
       
                }
                else
                {
                    MessageBox.Show("Selecciona al menos un Insumo", "Selecciona al menos un Insumo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Quitar Insumos del Producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarInsumosaLista(object sender, EventArgs e)
        {
            try
            {
                if (lstAllInsumos.SelectedItems.Count >= 1)
                {
                    foreach (var item in lstAllInsumos.SelectedItems)
                    {
                        lstInsumosSelected.Items.Add(item);

                    }
                    lstAllInsumos.ClearSelected();

                }
                else
                {
                    MessageBox.Show("Selecciona al menos un Insumo", "Selecciona al menos un Insumo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Agregar Insumos del Producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmInsumos a = new FrmInsumos();
                a.MdiParent = FrmLogin.MN;
                a.Show();
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Insumos desde Modulo de Productos ");
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Tratar de Ingresar al modulo de Insumos del Producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditarProducto(object sender, EventArgs e)
        {

        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpProducto.ExisteProducto(txtIdProducto.Text) && !Utilitarios.Cambio)
                {
                    MessageBox.Show("Ya Existe Un Codigo de Producto Relacionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtIdProducto.Text) || string.IsNullOrWhiteSpace(txtIdProducto.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DATOS.CategoriaProductos CategoriaLocal = Utilitarios.OpCategorias.BuscarCategoriaPorDescripcion(cbCategoriaProducto.SelectedItem.ToString());

                    NuevoProducto.Activo = true;
                    NuevoProducto.Categoria = CategoriaLocal.IdTipo;
                    NuevoProducto.Codigo = txtIdProducto.Text;
                    //  NuevoProducto.Consecutivo = lblConsecutivo.Text;
                    NuevoProducto.Descripcion = txtDescricpion.Text;
                    NuevoProducto.Nombre = txtNombre.Text;

                    tbOperacionesProductos.SelectedTab = tbReceta;
                    if (!tbOperacionesProductos.Contains(tbReceta))
                    {
                        tbOperacionesProductos.TabPages.Add(tbReceta);
                    }
                    Receta.Clear();
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Presionar Click en la continuacion de los Datos del Producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinuar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProducto.Text) || string.IsNullOrWhiteSpace(txtIdProducto.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (lstInsumosSelected.Items.Count > 0)
                    {
                        Receta.Clear();
                        ListaInsumos.Clear();
                        //  DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto-Insumo");


                        foreach (var item in lstInsumosSelected.Items)
                        {
                            ListaInsumos.Add(Utilitarios.OpInsumos.ListarInsumos().Where(c => c.Nombre == item.ToString()).FirstOrDefault());
                        }
                        ListaInsumos = ListaInsumos.OrderBy(x => x.IdInsumo).ToList();
                        var ListaInsumos2 = ListaInsumos.OrderBy(x => x.IdInsumo).ToList();
                        NuevoProducto.Precio = 0;
                        foreach (var item in ListaInsumos2)
                        {
                            if (ListaInsumos.Contains(item))
                            {

                                //   Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                                //     IngredienteNuevo.Consecutivo = "PIN-" + Consecutivo.ConsecutivoActual;
                                IngredienteNuevo.CodigoProducto = NuevoProducto.Codigo;
                                IngredienteNuevo.IdInsumo = ListaInsumos.FirstOrDefault().IdInsumo;
                                IngredienteNuevo.CantidadRequerida = float.Parse(ListaInsumos.Where(c => c.IdInsumo == IngredienteNuevo.IdInsumo).Count().ToString());

                                NuevoProducto.Precio = NuevoProducto.Precio + (item.PrecioMermado * (Convert.ToDecimal(IngredienteNuevo.CantidadRequerida)));

                                ListaInsumos.RemoveAll(x => x.IdInsumo == IngredienteNuevo.IdInsumo);

                                Receta.Add(new ProductoInsumo()
                                {
                                    IdInsumo = IngredienteNuevo.IdInsumo,
                                    Consecutivo = IngredienteNuevo.Consecutivo,
                                    CantidadRequerida = IngredienteNuevo.CantidadRequerida,
                                    CodigoProducto = IngredienteNuevo.CodigoProducto
                                });
                            }
                        }
                        decimal Cargas = 0;
                        foreach (var item in Utilitarios.OpCargas.ListarCargas().Where(x => x.Activo = true))
                        {
                            Cargas = Cargas + ((item.Porcentaje / 100) * NuevoProducto.Precio);
                        }
                        txtPrecioBase.Text = NuevoProducto.Precio.ToString("N");
                        txtPrecioCargas.Text = Cargas.ToString("N");
                        NuevoProducto.Precio = NuevoProducto.Precio + Cargas;
                        txtPrecioSugerido.Text = NuevoProducto.Precio.ToString("N");
                        if (!tbOperacionesProductos.Contains(tbCostos))
                        {
                            tbOperacionesProductos.TabPages.Add(tbCostos);
                        }
                        tbOperacionesProductos.SelectedTab = tbCostos;

                    }
                    else
                    {
                        MessageBox.Show("Debes Seleccionar Los insumos que requiere el producto " + txtNombre.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Presionar Click en la continuacion de los Insumos del Producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinuar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProducto.Text) || string.IsNullOrWhiteSpace(txtIdProducto.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDatosG.Focus();
                    return;
                }
                if (lstInsumosSelected.Items.Count == 0)
                {
                    MessageBox.Show("Debes Seleccionar Los insumos que requiere el producto " + txtNombre.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbReceta.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecioTotal.Text) || string.IsNullOrWhiteSpace(txtPrecioTotal.Text))
                {
                    MessageBox.Show("Debes Especificar el precio del Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioTotal.Focus();
                    return;
                }
                NuevoProducto.Precio = Convert.ToDecimal(txtPrecioTotal.Text);
                tbOperacionesProductos.TabPages.Add(tbResumen);
                lblProductoR.Text = NuevoProducto.Nombre;
                lblCodigo.Text = NuevoProducto.Codigo;
                lblConsecutivoResumen.Text = NuevoProducto.Consecutivo.ToString();
                lblDescripcionResumen.Text = NuevoProducto.Descripcion;
                lblPrecioVenta.Text = "₡ " + NuevoProducto.Precio.ToString("N");

                var result = Receta.Join(
                    Utilitarios.OpInsumos.ListarInsumos(),
                a => a.IdInsumo,
                b => b.IdInsumo,
                (a, b) => new { b.IdInsumo, b.Nombre, a.CantidadRequerida });

                dgvResumen.DataSource = result.ToList();
                dgvResumen.RowHeadersVisible = false;
                dgvResumen.ColumnHeadersVisible = false;
                dgvResumen.GridColor = Color.White;
                dgvResumen.BackgroundColor = Color.White;
                tbOperacionesProductos.SelectedTab = tbResumen;

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Presionar Click en la continuacion de los Costos del Producto");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegresar3_Click(object sender, EventArgs e)
        {
            tbOperacionesProductos.SelectedTab = tbReceta;
            tbOperacionesProductos.TabPages.Remove(tbCostos);

        }

        private void btnDescartarProducto_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("Esta a punto de Descartar el producto " + NuevoProducto.Nombre + " ¿Desea continuar?", "Advertencia",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (mensaje == DialogResult.Yes)
            {
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Productos");
                this.Dispose();
            }
            else
            {
                return;
            }

        }

        private void btnConfirmarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnConfirmarIngreso.Text == "Aceptar y someter cambios")
                {
                    var mensajex = MessageBox.Show("Esta a Punto de Modificar el producto " + EditProducto.Nombre + " ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (mensajex == DialogResult.Yes)
                    {
                        EditProducto.Activo = chkActivo.Checked;
                        EditProducto.Nombre = txtNombre.Text;
                        EditProducto.Precio =Convert.ToInt32( txtPrecioTotal.Text);
                        EditProducto.Descripcion = txtDescricpion.Text;
                        Utilitarios.OpProducto.ActualizarProductO(EditProducto);

                        foreach (var item in Utilitarios.OpProductoInsumo.ListarProductoInsumo().Where(x => x.CodigoProducto == EditProducto.Codigo))
                        {
                            Utilitarios.OpProductoInsumo.EliminarInsumodeProducto(item);
                        }

                        foreach (var Ingrediente in Receta)
                        {

                            Ingrediente.CodigoProducto = EditProducto.Codigo;
                            Utilitarios.OpProductoInsumo.AgregarProductoInsumo(Ingrediente);
                            //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto-Insumo");
                            //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                            // Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Ingrediente a producto ya existente " + Ingrediente.Consecutivo);

                        }
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Producto Nuevo " + NuevoProducto.Nombre);
                        ClearForm();
                        Utilitarios.Cambio = false;
                        EditProducto = new Producto();
                        MessageBox.Show("Los datos del Producto se Modificaron correctamente",
    "Modificacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                    ClearForm();
                    this.FrmProductosVenta_Load(sender, e);
                }
                else
                {

                    var mensaje = MessageBox.Show("Esta a Punto de Ingresar el producto " + NuevoProducto.Nombre + " ¿Desea continuar?", "Advertencia",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (mensaje == DialogResult.Yes)
                    {
                        NuevoProducto.Activo = true;
                        Utilitarios.OpProducto.AgregarProducto(NuevoProducto);
                        //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto");
                        //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        foreach (var Ingrediente in Receta)
                        {
                            Utilitarios.OpProductoInsumo.AgregarProductoInsumo(Ingrediente);
                            //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto-Insumo");
                            //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                            //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Ingrediente nuevo " + Ingrediente.Consecutivo);
                        }
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Producto Nuevo " + NuevoProducto.Nombre);
                        ClearForm();

                        MessageBox.Show("Los datos del Producto Nuevo se ingresaron correctamente",
    "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ClearForm();

                        return;
                    }

                }
                ClearForm();
                this.FrmProductosVenta_Load(sender, e);
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Confirmar Ingreso de Producto Nuevo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaProductos = Utilitarios.OpProducto.ListarProductos();
                var ListaLocal = ListaProductos.ToList();
                ListaLocal = ListaLocal.Where(x => x.Nombre == txtBuscar.Text).ToList();
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Intentar Buscar una Un producto ");
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

        private void ClearForm()
        {
            txtIdProducto.Enabled = true;
            lstInsumosSelected.Items.Clear();
            Receta.Clear();
            txtIdProducto.Clear();
            txtNombre.Clear();
            txtPrecioBase.Clear();
            txtPrecioSugerido.Clear();
            txtPrecioTotal.Clear();
            txtBuscar.Clear();
            txtDescricpion.Clear();
            txtPrecioCargas.Clear();

        }
    }
}

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
                dgvListado.DataSource = Utilitarios.OpProducto.ListarProductos();
                lstAllInsumos.DataSource = Utilitarios.OpInsumos.ListarInsumos().Select(x => x.Nombre).ToList();
                tbOperacionesProductos.TabPages.Remove(tbReceta);
                tbOperacionesProductos.TabPages.Remove(tbCostos);
                tbOperacionesProductos.TabPages.Remove(tbResumen);
                cbCategoriaProducto.SelectedIndex = 1;
                dgvCargas.DataSource = Utilitarios.OpCargas.ListarCargas().Where(x => x.Activo = true).ToList();

                if (Utilitarios.Cambio == false)
                {
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Producto UltimoProducto = Utilitarios.OpProducto.ListarProductos().OrderByDescending(x => x.Consecutivo).First();
                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Producto").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSProdcuto = Consecutivo.ConsecutivoActual + 1;
                    UltimoProducto.Consecutivo = Prefijo + "-" + CSProdcuto;
                    if (Utilitarios.OpProducto.ExisteConsecutivo(UltimoProducto.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimoProducto.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnAgregar.Enabled = false;
                    }
                    lblConsecutivo.Text = UltimoProducto.Consecutivo;
                }

                //cb.DataSource = Utilitarios.OpRol.ListarRoles().Select(p =>
                //    p.Descripcion).ToList();
                //ListaUsuarios = Utilitarios.OpUsuarios.ListarUsuarios();
                //var ListaLocal = ListaUsuarios.Select(a => new
                //{
                //    a.Consecutivo,
                //    a.Username,
                //    a.IdPersonal,
                //    a.Nombre,
                //    a.Apellido1,
                //    a.Apellido2,
                //    a.Correo,
                //    a.Direccion,
                //    a.Telefono,
                //    a.Rol
                //}).ToList();
                //dgvListado.DataSource = ListaLocal;

                //var autosearch = new AutoCompleteStringCollection();
                //txtBuscar.AutoCompleteCustomSource = autosearch;
                //txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                //txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //foreach (var pos in ListaLocal)
                //{
                //    autosearch.Add(Convert.ToString(pos.Username));
                //}
                //txtBuscar.AutoCompleteCustomSource = autosearch;

                ////------------------------------

                //while (Utilitarios.Cambio)
                //{
                //    tbControl1.SelectedIndex = 1;
                //    if (Utilitarios.Cambio)
                //    {
                //        lblConsecutivo.Text = EditUser.Consecutivo;
                //        txtUsername.Text = EditUser.Username;
                //        txtNombre.Text = EditUser.Nombre;
                //        txtApellido.Text = EditUser.Apellido1;
                //        txtApellido2.Text = EditUser.Apellido2;
                //        txtDireccion.Text = EditUser.Direccion;
                //        txtDescricpion.Text = EditUser.Correo;
                //        txtTelefono.Text = EditUser.Telefono;
                //        txtIdPersonal.Text = EditUser.IdPersonal;
                //        if (EditUser.Activo)
                //        {
                //            chkEstado.Checked = true;
                //        }
                //        else
                //        {
                //            chkEstado.Checked = false;
                //        }
                //        return;
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Cargar Formulario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Productos");
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
                lstAllInsumos.Items.Clear();
                lstAllInsumos.DataSource = Utilitarios.OpInsumos.ListarInsumos().Select(x => x.Nombre);

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
                this.Dispose();
            }
            else
            {
                if (Utilitarios.OpProducto.ExisteProducto(txtIdProducto.Text))
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
                if (string.IsNullOrEmpty(txtIdProducto.Text) || string.IsNullOrWhiteSpace(txtIdProducto.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtDescricpion.Text) || string.IsNullOrWhiteSpace(txtDescricpion.Text))
                {
                    MessageBox.Show("Debes Llenar los espacios en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DATOS.CategoriaProductos CategoriaLocal = Utilitarios.OpCategorias.ListarCategorias().Where(x => x.Descripcion == cbCategoriaProducto.SelectedItem.ToString()).FirstOrDefault();

                    NuevoProducto.Activo = true;
                    NuevoProducto.Categoria = CategoriaLocal.IdTipo;
                    NuevoProducto.Codigo = txtIdProducto.Text;
                    NuevoProducto.Consecutivo = lblConsecutivo.Text;
                    NuevoProducto.Descripcion = txtDescricpion.Text;
                    NuevoProducto.Nombre = txtNombre.Text;

                    tbOperacionesProductos.SelectedTab = tbReceta;
                    tbOperacionesProductos.TabPages.Add(tbReceta);
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
                        ListaInsumos.Clear();
                        DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto-Insumo");


                        foreach (var item in lstInsumosSelected.Items)
                        {
                            ListaInsumos.Add(Utilitarios.OpInsumos.ListarInsumos().Where(c => c.Nombre == item.ToString()).FirstOrDefault());
                        }
                        ListaInsumos = ListaInsumos.OrderBy(x => x.IdInsumo).ToList();
                        var ListaInsumos2 = ListaInsumos.OrderBy(x => x.IdInsumo).ToList();
                        foreach (var item in ListaInsumos2)
                        {
                            if (ListaInsumos.Contains(item))
                            {

                                Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                                IngredienteNuevo.Consecutivo = "PIN-" + Consecutivo.ConsecutivoActual;
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
                        txtPrecioBase.Text = NuevoProducto.Precio.ToString();
                        txtPrecioCargas.Text = Cargas.ToString();
                        NuevoProducto.Precio = NuevoProducto.Precio + Cargas;
                        txtPrecioSugerido.Text = NuevoProducto.Precio.ToString();
                        tbOperacionesProductos.SelectedTab = tbCostos;
                        tbOperacionesProductos.TabPages.Add(tbCostos);
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
                lblConsecutivoResumen.Text = NuevoProducto.Consecutivo;
                lblDescripcionResumen.Text = NuevoProducto.Descripcion;
                lblPrecioVenta.Text = "₡ " + NuevoProducto.Precio.ToString();

                var result = Receta.Join(
                    Utilitarios.OpInsumos.ListarInsumos(),
                a => a.IdInsumo,
                b => b.IdInsumo,
                (a, b) => new { a.Consecutivo, b.IdInsumo, b.Nombre, a.CantidadRequerida });

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
                this.Refresh();

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
                var mensaje = MessageBox.Show("Esta a Punto de Ingresar el producto " + NuevoProducto.Nombre + " ¿Desea continuar?", "Advertencia",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    Utilitarios.OpProducto.AgregarProducto(NuevoProducto);
                    DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto");
                    Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                    Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                    foreach (var Ingrediente in Receta)
                    {
                        Utilitarios.OpProductoInsumo.AgregarProductoInsumo(Ingrediente);
                        Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Producto-Insumo");
                        Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Ingrediente nuevo " + Ingrediente.Consecutivo);
                    }
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Producto Nuevo " + NuevoProducto.Nombre);

                    MessageBox.Show("Los datos del Producto Nuevo se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Productos al Confirmar Ingreso de Producto Nuevo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

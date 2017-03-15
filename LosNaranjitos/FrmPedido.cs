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
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        public static List<Producto> ListaProductos = new List<Producto>();
        public static List<Combo> ListaCombos = new List<Combo>();
        public static List<DetallePedido> OrdenDetalle = new List<DetallePedido>();
        public static Pedido NuevaOrden = new Pedido();
        public static Pedido EditOrden = new Pedido();

        private void tmerTiempo_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            dgvPendientes.Refresh();
            dgvOrden.DataSource = OrdenDetalle.Select(a => new
            {
                a.Consecutivo,
                a.Cantidad,
                a.Producto,
                a.SubTotal,
                a.ObservacionesDT,
            }).ToList();
            dgvOrden.Refresh();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            tmerTiempo.Start();
            dgvOrden.BackgroundColor = Color.White;
            dgvPendientes.BackgroundColor = Color.White;

            try
            {
                //Carga de datos  ListBoxes y datagrids
                var ListaLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo || !x.Cancelado).ToList().Select(a => new
                {
                    a.Consecutivo,
                    a.IdCliente,
                    a.Fecha,
                    a.Subtotal,
                    a.Cancelado,
                    a.Activo,
                }).ToList();
                dgvPendientes.DataSource = ListaLocal;
                lstProductosPrincipales.DataSource = Utilitarios.OpProducto.ListarProductos().Where(x => x.Categoria == "CTP-1" && x.Activo).Select(x => x.Nombre).ToList();
                lstAdicionales.DataSource = Utilitarios.OpProducto.ListarProductos().Where(x => x.Categoria == "CTP-2" || x.Categoria == "CTP-4" && x.Activo).Select(x => x.Nombre).ToList();
                lstBebidas.DataSource = Utilitarios.OpProducto.ListarProductos().Where(x => x.Categoria == "CTP-3" && x.Activo).Select(x => x.Nombre).ToList();
                lstCombos.DataSource = Utilitarios.OpCombo.ListarCombo().Where(x => x.Activo).Select(x => x.Nombre).ToList();

                lblOperador.Text = FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1 + " " + FrmLogin.UsuarioGlobal.Apellido2;
                dgvOrden.DataSource = OrdenDetalle.ToList();
                DATOS.Pedido UltimoPedido = new Pedido();

                if (!Utilitarios.CambioEnCajas)
                {
                    //Validacion Consecutivos Pedidos
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    try
                    {
                        UltimoPedido = Utilitarios.OpPedidos.ListarPedido().OrderByDescending(x => x.Consecutivo).First();
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos")
                        {
                            UltimoPedido.Consecutivo = "PDD-1";
                        }
                    }

                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Pedido").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSPedido = Consecutivo.ConsecutivoActual + 1;
                    UltimoPedido.Consecutivo = Prefijo + "-" + CSPedido;
                    if (Utilitarios.OpProducto.ExisteConsecutivo(UltimoPedido.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimoPedido.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnPagar.Enabled = false;
                        btnDescartar.Enabled = false;
                        btnBuscarOrden.Enabled = false;
                        btnSometerOrden.Enabled = false;
                        tbProductosVenta.Enabled = false;
                    }
                    cbbCliente.DataSource = Utilitarios.OpClientes.ListarClientes().Select(x => x.IdPersonal).ToList();
                    lblConsecutivo.Text = UltimoPedido.Consecutivo;

                    //Validacion Consecutivos Detalles de Ordenes
                    DATOS.DetallePedido UltimoDetallePedido = new DetallePedido();
                    try
                    {
                        UltimoDetallePedido = Utilitarios.OpDetallePedido.ListarDetallesPedido().OrderByDescending(x => x.Consecutivo).First();
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos")
                        {
                            UltimoPedido.Consecutivo = "DPD-1";
                        }
                    }

                    Prefijo = Consecutivos.Where(x => x.Tipo == "Detalle-Pedido").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSDetallePedido = Consecutivo.ConsecutivoActual + 1;
                    UltimoDetallePedido.Consecutivo = Prefijo + "-" + CSDetallePedido;
                    if (Utilitarios.OpDetallePedido.ExisteConsecutivo(UltimoDetallePedido.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimoDetallePedido.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnPagar.Enabled = false;
                        btnDescartar.Enabled = false;
                        btnBuscarOrden.Enabled = false;
                        btnSometerOrden.Enabled = false;
                        tbProductosVenta.Enabled = false;
                    }
                    NuevaOrden.Consecutivo = lblConsecutivo.Text;
                    NuevaOrden.Activo = true;
                    NuevaOrden.Cancelado = false;
                    NuevaOrden.Fecha = DateTime.Today;
                    NuevaOrden.IdCliente = cbbCliente.Text;
                    NuevaOrden.Operador = FrmLogin.UsuarioGlobal.Username;
                    NuevaOrden.Subtotal = 0;
                }
                while (Utilitarios.CambioEnCajas)
                {
                    if (Utilitarios.CambioEnCajas)
                    {
                        //    tbOperacionesProductos.TabPages.Add(tbReceta);
                        //    tbOperacionesProductos.TabPages.Add(tbCostos);
                        //    txtIdProducto.Text = EditProducto.Codigo;
                        //    lblConsecutivo.Text = EditProducto.Consecutivo;
                        //    txtNombre.Text = EditProducto.Nombre;
                        //    //Carga de Categoria

                        //    DATOS.CategoriaProductos TCat = Utilitarios.OpCategorias.BuscarCategoriaProductos(EditProducto.Categoria);

                        //    cbCategoriaProducto.SelectedText = TCat.Descripcion;
                        //    txtDescricpion.Text = EditProducto.Descripcion;
                        //    chkActivo.Visible = true;

                        //    if (EditProducto.Activo)
                        //    {
                        //        chkActivo.Checked = true;
                        //    }
                        //    else
                        //    {
                        //        chkActivo.Checked = false;
                        //    }

                        //    txtPrecioTotal.Text = EditProducto.Precio.ToString();
                        //    Receta = Utilitarios.OpProductoInsumo.ListarProductoInsumo().Where(x => x.CodigoProducto == EditProducto.Codigo).ToList();
                        //    foreach (var item in Receta)
                        //    {
                        //        DATOS.Insumos Ins = Utilitarios.OpInsumos.BuscarInsumos(item.IdInsumo);
                        //        ListaInsumos.Add(new Insumos()
                        //        {
                        //            IdInsumo = Ins.IdInsumo,
                        //            Consecutivo = Ins.Consecutivo,
                        //            Activo = Ins.Activo,
                        //            CantInventario = Ins.CantInventario,
                        //            IdMedida = Ins.IdMedida,
                        //            Nombre = Ins.Nombre,
                        //            PrecioCompra = Ins.PrecioCompra,
                        //            PrecioMermado = Ins.PrecioMermado,
                        //            Proveedor = Ins.Proveedor,
                        //            RendimientoPorcion = Ins.RendimientoPorcion,
                        //            RendimientoUM = Ins.RendimientoUM
                        //        });

                        //        for (int i = 0; i < item.CantidadRequerida; i++)
                        //        {
                        //            lstInsumosSelected.Items.Add(Ins.Nombre);

                        //        }
                        //    }
                        //    Receta.Clear();
                        //    return;
                        //}
                        //else
                        //{
                        //    return;
                    }
                }

            }
            catch (Exception ex)
            {
                   
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Cargar Formulario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtCantidadPPrincipales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtCantidadPPrincipales.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cbbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Utilitarios.OpClientes.ExisteCLIENTE(cbbCliente.SelectedItem.ToString()))
                {
                    MessageBox.Show("Seleccione un cliente de la lista o digite un cliente existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DATOS.Cliente ClieNteLocal = Utilitarios.OpClientes.BuscarCliente(cbbCliente.SelectedValue.ToString());
                    lblCliente.Text = ClieNteLocal.Nombre + " " + ClieNteLocal.Apellido1 + " " + ClieNteLocal.Apellido2;
                }

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Cliente");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Caja");
            FrmMenuPrincipal.GR.Visible = true;
            this.Dispose();

        }

        private void cbbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {

                    if (!Utilitarios.OpClientes.ExisteCLIENTE(cbbCliente.SelectedText.ToString()))
                    {
                        MessageBox.Show("Seleccione un cliente de la lista o digite un cliente existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DATOS.Cliente ClieNteLocal = Utilitarios.OpClientes.BuscarCliente(cbbCliente.SelectedValue.ToString());
                        lblCliente.Text = ClieNteLocal.Nombre + " " + ClieNteLocal.Apellido1 + " " + ClieNteLocal.Apellido2;
                    }
                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Cliente");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkExpress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpress.Checked)
            {
                txtObservacionesExpress.Visible = true;
                txtPrecioExpress.Visible = true;
            }
            else
            {
                txtObservacionesExpress.Visible = false;
                txtPrecioExpress.Visible = false;
            }
        }

        private void btnAgregarProductoPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                Producto PLocal = Utilitarios.OpProducto.BuscarProductoPorNombre(lstProductosPrincipales.SelectedValue.ToString());

                if (lstProductosPrincipales.SelectedItems.Count != 0)
                {
                    DetallePedido DetailPP = new DetallePedido();

                    if ((OrdenDetalle.Find(x => x.Producto == lstProductosPrincipales.SelectedValue.ToString())) != null)
                    {
                        DetailPP = OrdenDetalle.Find(x => x.Producto == lstProductosPrincipales.SelectedValue.ToString());
                        DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + " \n " + txtObservacionesPP.Text;
                        if (string.IsNullOrEmpty(txtCantidadPPrincipales.Text) || string.IsNullOrWhiteSpace(txtCantidadPPrincipales.Text) || txtCantidadPPrincipales.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantidadPPrincipales.Text);
                        }

                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Remove(DetailPP);
                        OrdenDetalle.Add(DetailPP);
                        int CNT = 0;
                        if (string.IsNullOrEmpty(txtCantidadPPrincipales.Text) || string.IsNullOrWhiteSpace(txtCantidadPPrincipales.Text) || txtCantidadPPrincipales.Text == "1")
                        {
                            CNT = 1;
                        }
                        else
                        {
                            CNT = Convert.ToInt32(txtCantidadPPrincipales.Text);
                        }

                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + (CNT * PLocal.Precio);
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString();
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString();
                        lblTotal.Text = NuevaOrden.Subtotal.ToString();
                        txtCantidadPPrincipales.Clear();
                        txtObservacionesPP.Clear();
                    }
                    else
                    {
                        DetailPP.Producto = lstProductosPrincipales.SelectedValue.ToString();
                        DetailPP.Consecutivo = "DPD-" + NxtConsecutivoDetallePedido().ToString();
                        DetailPP.IdOrden = lblConsecutivo.Text;
                        if (string.IsNullOrEmpty(txtObservacionesPP.Text) || string.IsNullOrWhiteSpace(txtObservacionesPP.Text))
                        {
                            DetailPP.ObservacionesDT = null;
                        }
                        else
                        {
                            DetailPP.ObservacionesDT = txtObservacionesPP.Text;
                        }
                        if (string.IsNullOrEmpty(txtCantidadPPrincipales.Text) || string.IsNullOrWhiteSpace(txtCantidadPPrincipales.Text) || txtCantidadPPrincipales.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantidadPPrincipales.Text);
                        }

                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Add(DetailPP);
                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + DetailPP.SubTotal;
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString();
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString();
                        lblTotal.Text = NuevaOrden.Subtotal.ToString();
                        txtCantidadPPrincipales.Clear();
                        txtObservacionesPP.Clear();

                    }
                }
                else
                {

                    MessageBox.Show("Seleccione un Producto de la lista ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lstProductosPrincipales.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Agregar Producto a Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int NxtConsecutivoDetallePedido()
        {
            string Retorno;
            if (OrdenDetalle.Count != 0)
            {
                Retorno = OrdenDetalle.OrderByDescending(x => x.Consecutivo).FirstOrDefault().Consecutivo.Remove(0, 4);
                return Convert.ToInt32(Retorno);
            }
            else
            {
                Consecutivo Consecutivo = new Consecutivo();
                List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                DetallePedido UltimoDetallePedido = new DetallePedido();
                try
                {
                    UltimoDetallePedido = Utilitarios.OpDetallePedido.ListarDetallesPedido().OrderByDescending(x => x.Consecutivo).FirstOrDefault();
                }
                catch (Exception x)
                {
                    if (x.Message == "La secuencia no contiene elementos")
                    {
                        UltimoDetallePedido.Consecutivo = "DTP-1";
                    }
                }

                string Prefijo = Consecutivos.Where(x => x.Tipo == "Detalle-Pedido").Select(x => x.Prefijo).FirstOrDefault();
                Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                int CSDetallePedido = Consecutivo.ConsecutivoActual + 1;
                return CSDetallePedido;
            }
        }
    }
}

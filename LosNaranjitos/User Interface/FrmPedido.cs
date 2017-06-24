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
using LosNaranjitos.Tools;

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

            dgvOrden.DataSource = OrdenDetalle.Select(a => new
            {
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

            dgvOrden.GridColor = Color.White;


            try
            {
                //Carga de datos  ListBoxes y datagrids

                lstProductosPrincipales.DataSource = Utilitarios.OpProducto.ListarProductos().Where(x => x.Categoria == 1 && x.Activo).Select(x => x.Nombre).ToList();
                lstAdicionales.DataSource = Utilitarios.OpProducto.ListarProductos().Where(x => x.Categoria == 2 || x.Categoria == 4 && x.Activo).Select(x => x.Nombre).ToList();
                lstBebidas.DataSource = Utilitarios.OpProducto.ListarProductos().Where(x => x.Categoria == 3 && x.Activo).Select(x => x.Nombre).ToList();
                lstCombos.DataSource = Utilitarios.OpCombo.ListarCombo().Where(x => x.Activo).Select(x => x.Nombre).ToList();

                lblOperador.Text = FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1 + " " + FrmLogin.UsuarioGlobal.Apellido2;
                dgvOrden.DataSource = OrdenDetalle.ToList();
                DATOS.Pedido UltimoPedido = new Pedido();

                if (!Utilitarios.CambioEnCajas)
                {
                    //Validacion Consecutivos Pedidos
                    //DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    //List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    try
                    {
                        UltimoPedido = Utilitarios.OpPedidos.ListarPedido().OrderByDescending(x => x.Consecutivo).First();
                        lblConsecutivo.Text = (UltimoPedido.Consecutivo + 1).ToString();

                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos")
                        {
                            UltimoPedido.Consecutivo = 1;
                            lblConsecutivo.Text = UltimoPedido.Consecutivo.ToString();
                        }
                    }

                    //string Prefijo = Consecutivos.Where(x => x.Tipo == "Pedido").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSPedido = Consecutivo.ConsecutivoActual + 1;
                    //UltimoPedido.Consecutivo = Prefijo + "-" + CSPedido;
                    //if (Utilitarios.OpProducto.ExisteConsecutivo(UltimoPedido.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimoPedido.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnPagar.Enabled = false;
                    //    btnDescartar.Enabled = false;
                    //    btnBuscarOrden.Enabled = false;
                    //    btnSometerOrden.Enabled = false;
                    //    tbProductosVenta.Enabled = false;
                    //}
                    cbbCliente.DataSource = Utilitarios.OpClientes.ListarClientes().OrderBy(x => x.IdPersonal).Select(x => x.IdPersonal).ToList();

                    //Validacion Consecutivos Detalles de Ordenes
                    //DATOS.DetallePedido UltimoDetallePedido = new DetallePedido();
                    //try
                    //{
                    //    UltimoDetallePedido = Utilitarios.OpDetallePedido.ListarDetallesPedido().OrderByDescending(x => x.Consecutivo).First();
                    //}
                    //catch (Exception x)
                    //{
                    //    if (x.Message == "La secuencia no contiene elementos")
                    //    {
                    //        UltimoPedido.Consecutivo = 1;
                    //    }
                    //}

                    //Prefijo = Consecutivos.Where(x => x.Tipo == "Detalle-Pedido").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSDetallePedido = Consecutivo.ConsecutivoActual + 1;
                    //UltimoDetallePedido.Consecutivo = Prefijo + "-" + CSDetallePedido;
                    //if (Utilitarios.OpDetallePedido.ExisteConsecutivo(UltimoDetallePedido.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimoDetallePedido.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnPagar.Enabled = false;
                    //    btnDescartar.Enabled = false;
                    //    btnBuscarOrden.Enabled = false;
                    //    btnSometerOrden.Enabled = false;
                    //    tbProductosVenta.Enabled = false;
                    //}
                    //NuevaOrden.Consecutivo = lblConsecutivo.Text;
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
            try
            {
                if (FrmLogin.UsuarioGlobal.Rol != 3)
                {
                    if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Operador == FrmLogin.UsuarioGlobal.Username && x.CierreOperador == false).Count() == 0)
                    {
                        Caja XCaja = Utilitarios.OpCaja.ListarCajas().Where(x => x.OperadorActual == FrmLogin.UsuarioGlobal.Username).FirstOrDefault();
                        Caja CajaY = new Caja();
                        CajaY.Consecutivo = XCaja.Consecutivo;
                        CajaY.OperadorActual = "Libre";
                        CajaY.Estado = false;
                        CajaY.UltimaModificacion = DateTime.Now;
                        CajaY.Disponible = XCaja.Disponible;
                        Utilitarios.OpCaja.ActualizarCajas(CajaY);
                        MessageBox.Show("Caja Cerrada debido a ausencia de Pedidos registrados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Caja");
                        FrmMenuPrincipal.GR.Visible = true;
                        OrdenDetalle.Clear();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Registraste Ventas, debes cerrar la caja en el modulo de cierre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Operador == FrmLogin.UsuarioGlobal.Username && x.CierreOperador == false).Count() == 0)
                    {
                        Caja XCaja = Utilitarios.OpCaja.ListarCajas().Where(x => x.OperadorActual == FrmLogin.UsuarioGlobal.Username).FirstOrDefault();
                        Caja CajaY = new Caja();
                        CajaY.Consecutivo = XCaja.Consecutivo;
                        CajaY.OperadorActual = "Libre";
                        CajaY.Estado = false;
                        CajaY.UltimaModificacion = DateTime.Now;
                        CajaY.Disponible = XCaja.Disponible;
                        Utilitarios.OpCaja.ActualizarCajas(CajaY);
                        MessageBox.Show("Caja Cerrada debido a ausencia de Pedidos registrados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Caja");
                        FrmLogin.MC.Visible = true;
                        OrdenDetalle.Clear();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Registraste Ventas, debes cerrar la caja en el modulo de cierre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }


            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Cliente");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cbbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {

                    if (!Utilitarios.OpClientes.ExisteCLIENTE(cbbCliente.Text.ToString()))
                    {
                        MessageBox.Show("Seleccione un cliente de la lista o digite un cliente existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DATOS.Cliente ClieNteLocal = Utilitarios.OpClientes.BuscarCliente(cbbCliente.Text.ToString());
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
                if ((OrdenDetalle.Find(x => x.Producto == "Servicio Express") != null))
                {
                    MessageBox.Show("Ya Existe Un Servicio Express definido para la orden en curso", "No puedes Agregar dos servicios Express", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                txtDireccion.Visible = true;
                txtPrecioExpress.Visible = true;
                txtTelefono.Visible = true;
                btnExpress.Visible = true;
            }
            else
            {
                txtDireccion.Visible = false;
                txtPrecioExpress.Visible = false;
                txtTelefono.Visible = false;
                btnExpress.Visible = false;
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
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantidadPPrincipales.Clear();
                        txtObservacionesPP.Clear();
                    }
                    else
                    {
                        DetailPP.Producto = lstProductosPrincipales.SelectedValue.ToString();
                        //DetailPP.Consecutivo = "DPD-" + NxtConsecutivoDetallePedido().ToString();
                        DetailPP.IdOrden = Int32.Parse(lblConsecutivo.Text);
                        if (string.IsNullOrEmpty(txtObservacionesPP.Text) || string.IsNullOrWhiteSpace(txtObservacionesPP.Text))
                        {
                            DetailPP.ObservacionesDT = "";
                        }
                        else
                        {
                            DetailPP.ObservacionesDT = txtObservacionesPP.Text;
                        }

                        if (!chkLechuga.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN LECHUGA,";
                        }
                        if (!chkMayonesa.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN MAYONESA,";
                        }
                        if (!chkPepino.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN PEPINILLO,";
                        }
                        if (!chkPepino.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN PEPINO,";
                        }
                        if (!chkSalsaTomate.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN S.TOMATE,";
                        }
                        if (!chkTomate.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN TOMATE,";
                        }
                        if (!chkCebolla.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "SIN CEBOLLA,";
                        }
                        if (chkCebollaFrita.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "CEBOLLA FRITA,";
                        }
                        if (chkRepollo.Checked)
                        {
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + "CON REPOLLO,";
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
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
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


        private void btnAgregarAdicionales_Click(object sender, EventArgs e)
        {
            try
            {
                Producto PLocal = Utilitarios.OpProducto.BuscarProductoPorNombre(lstAdicionales.SelectedValue.ToString());

                if (lstAdicionales.SelectedItems.Count != 0)
                {
                    DetallePedido DetailPP = new DetallePedido();

                    if ((OrdenDetalle.Find(x => x.Producto == lstAdicionales.SelectedValue.ToString())) != null)
                    {
                        DetailPP = OrdenDetalle.Find(x => x.Producto == lstAdicionales.SelectedValue.ToString());
                        DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + " \n " + txtObAdicionales.Text;
                        if (string.IsNullOrEmpty(txtCantidadPPrincipales.Text) || string.IsNullOrWhiteSpace(txtCantidadAdicionales.Text) || txtCantidadAdicionales.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantidadAdicionales.Text);
                        }

                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Remove(DetailPP);
                        OrdenDetalle.Add(DetailPP);
                        int CNT = 0;
                        if (string.IsNullOrEmpty(txtCantidadPPrincipales.Text) || string.IsNullOrWhiteSpace(txtCantidadAdicionales.Text) || txtCantidadAdicionales.Text == "1")
                        {
                            CNT = 1;
                        }
                        else
                        {
                            CNT = Convert.ToInt32(txtCantidadAdicionales.Text);
                        }

                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + (CNT * PLocal.Precio);
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantidadAdicionales.Clear();
                        txtObAdicionales.Clear();
                    }
                    else
                    {
                        DetailPP.Producto = lstAdicionales.SelectedValue.ToString();

                        DetailPP.IdOrden = Int32.Parse(lblConsecutivo.Text);
                        if (string.IsNullOrEmpty(txtObAdicionales.Text) || string.IsNullOrWhiteSpace(txtObAdicionales.Text))
                        {
                            DetailPP.ObservacionesDT = " ";
                        }
                        else
                        {
                            DetailPP.ObservacionesDT = " " + txtObAdicionales.Text;
                        }
                        if (string.IsNullOrEmpty(txtCantidadAdicionales.Text) || string.IsNullOrWhiteSpace(txtCantidadAdicionales.Text) || txtCantidadAdicionales.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantidadAdicionales.Text);
                        }

                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Add(DetailPP);
                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + DetailPP.SubTotal;
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantidadPPrincipales.Clear();
                        txtCantidadAdicionales.Clear();
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

        private void btnAgregarBebidas_Click(object sender, EventArgs e)
        {
            try
            {
                Producto PLocal = Utilitarios.OpProducto.BuscarProductoPorNombre(lstBebidas.SelectedValue.ToString());

                if (lstBebidas.SelectedItems.Count != 0)
                {
                    DetallePedido DetailPP = new DetallePedido();

                    if ((OrdenDetalle.Find(x => x.Producto == lstBebidas.SelectedValue.ToString())) != null)
                    {
                        DetailPP = OrdenDetalle.Find(x => x.Producto == lstBebidas.SelectedValue.ToString());
                        DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + " \n " + txtObBebidas.Text;
                        if (string.IsNullOrEmpty(txtCantBebidas.Text) || string.IsNullOrWhiteSpace(txtCantBebidas.Text) || txtCantBebidas.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantBebidas.Text);
                        }

                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Remove(DetailPP);
                        OrdenDetalle.Add(DetailPP);
                        int CNT = 0;
                        if (string.IsNullOrEmpty(txtCantBebidas.Text) || string.IsNullOrWhiteSpace(txtCantBebidas.Text) || txtCantBebidas.Text == "1")
                        {
                            CNT = 1;
                        }
                        else
                        {
                            CNT = Convert.ToInt32(txtCantBebidas.Text);
                        }

                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + (CNT * PLocal.Precio);
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantBebidas.Clear();
                        txtObBebidas.Clear();
                    }
                    else
                    {
                        DetailPP.Producto = lstBebidas.SelectedValue.ToString();

                        DetailPP.IdOrden = Int32.Parse(lblConsecutivo.Text);
                        if (string.IsNullOrEmpty(txtObBebidas.Text) || string.IsNullOrWhiteSpace(txtObBebidas.Text))
                        {
                            DetailPP.ObservacionesDT = " ";
                        }
                        else
                        {
                            DetailPP.ObservacionesDT = " " + txtObBebidas.Text;
                        }
                        if (string.IsNullOrEmpty(txtCantBebidas.Text) || string.IsNullOrWhiteSpace(txtCantBebidas.Text) || txtCantBebidas.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantBebidas.Text);
                        }

                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Add(DetailPP);
                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + DetailPP.SubTotal;
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantBebidas.Clear();
                        txtObBebidas.Clear();
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

        private void btnAgregarCombos_Click(object sender, EventArgs e)
        {
            try
            {
                Combo PLocal = Utilitarios.OpCombo.BuscarComboPorNombre(lstCombos.SelectedValue.ToString());

                if (lstCombos.SelectedItems.Count != 0)
                {
                    DetallePedido DetailPP = new DetallePedido();

                    if ((OrdenDetalle.Find(x => x.Producto == lstCombos.SelectedValue.ToString())) != null)
                    {
                        DetailPP = OrdenDetalle.Find(x => x.Producto == lstCombos.SelectedValue.ToString());
                        DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + " \n " + txtObCombos.Text;
                        if (string.IsNullOrEmpty(txtCantCombos.Text) || string.IsNullOrWhiteSpace(txtCantCombos.Text) || txtCantCombos.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantCombos.Text);
                        }

                        var ComboEnProceso = Utilitarios.OpComboProducto.ListarComboProductos().Where(C => C.CodCombo == PLocal.Codigo);
                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;

                        foreach (var item in ComboEnProceso)
                        {
                            item.CodProducto = Utilitarios.OpProducto.BuscarProducto(item.CodProducto).Nombre;
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + " \n " + item.CodProducto + " " + item.CantidadProducto;
                        }

                        OrdenDetalle.Remove(DetailPP);
                        OrdenDetalle.Add(DetailPP);
                        int CNT = 0;
                        if (string.IsNullOrEmpty(txtCantCombos.Text) || string.IsNullOrWhiteSpace(txtCantCombos.Text) || txtCantCombos.Text == "1")
                        {
                            CNT = 1;
                        }
                        else
                        {
                            CNT = Convert.ToInt32(txtCantCombos.Text);
                        }

                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + (CNT * PLocal.Precio);
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantCombos.Clear();
                        txtObCombos.Clear();
                    }
                    else
                    {
                        DetailPP.Producto = lstCombos.SelectedValue.ToString();
                        //   DetailPP.Consecutivo = "DPD-" + NxtConsecutivoDetallePedido().ToString();
                        DetailPP.IdOrden = Int32.Parse(lblConsecutivo.Text);
                        if (string.IsNullOrEmpty(txtObCombos.Text) || string.IsNullOrWhiteSpace(txtObCombos.Text))
                        {
                            DetailPP.ObservacionesDT = " ";
                        }
                        else
                        {
                            DetailPP.ObservacionesDT = " " + txtObCombos.Text;
                        }
                        if (string.IsNullOrEmpty(txtCantCombos.Text) || string.IsNullOrWhiteSpace(txtCantCombos.Text) || txtCantCombos.Text == "1")
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + 1;
                        }
                        else
                        {
                            DetailPP.Cantidad = DetailPP.Cantidad + Convert.ToInt32(txtCantCombos.Text);
                        }
                        var ComboEnProceso = Utilitarios.OpComboProducto.ListarComboProductos().Where(C => C.CodCombo == PLocal.Codigo);
                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;

                        foreach (var item in ComboEnProceso)
                        {
                            item.CodProducto = Utilitarios.OpProducto.BuscarProducto(item.CodProducto).Nombre;
                            DetailPP.ObservacionesDT = DetailPP.ObservacionesDT + " \n " + item.CodProducto + " " + item.CantidadProducto;
                        }
                        DetailPP.SubTotal = PLocal.Precio * DetailPP.Cantidad;
                        OrdenDetalle.Add(DetailPP);
                        NuevaOrden.Subtotal = NuevaOrden.Subtotal + DetailPP.SubTotal;
                        decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                        lblImpuesto.Text = impuesto.ToString("N");
                        lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                        lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                        txtCantCombos.Clear();
                        txtObCombos.Clear();

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

        private void btnSometerOrden_Click(object sender, EventArgs e)
        {
            try
            {
                if (OrdenDetalle.Count == 0)
                {
                    MessageBox.Show("Debes agregar productos a la orden", "Advertencia",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var mensaje = MessageBox.Show("¿ Desea Someter la orden " + lblConsecutivo.Text + "  al sistema?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    //  Consecutivo Consec = Utilitarios.OpConsecutivo.BuscarConsecutivo("PDD");
                    NuevaOrden.Activo = true;
                    NuevaOrden.CompletoCocina = false;
                    NuevaOrden.Cancelado = false;
                    Utilitarios.OpPedidos.AgregarPedido(NuevaOrden);
                    // Consec.ConsecutivoActual = Consec.ConsecutivoActual + 1;
                    //tilitarios.OpConsecutivo.ActualizarConsecutivo(Consec);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + lblConsecutivo.Text + " Agregada a pendientes, Orden Aun NO cancelada");
                    List<DetallePedido> ListaSoporte = new List<DetallePedido>();
                    foreach (var item in OrdenDetalle)
                    {
                        if (Utilitarios.OpProducto.ExisteProductoPorNombre(item.Producto))
                        {
                            var newitem = Utilitarios.OpProducto.BuscarProductoPorNombre(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Codigo.ToString();
                            ListaSoporte.Add(DetalleSoporte);
                        }
                        else if (item.Producto == "Servicio Express")
                        {
                            ListaSoporte.Add(item);
                        }
                        else
                        {
                            var newitem = Utilitarios.OpCombo.BuscarComboPorNombre(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Codigo.ToString();
                            ListaSoporte.Add(DetalleSoporte);
                        }
                    }
                    for (int i = 0; i < ListaSoporte.Count; i++)
                    {
                        Utilitarios.OpDetallePedido.AgregarDetalle(ListaSoporte[i]);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Producto perteneciente a la orden  " + lblConsecutivo.Text + " Agregado a pendientes, Orden Aun NO cancelada");
                    }
                    DATOS.Cliente CLIENTE = Utilitarios.OpClientes.BuscarCliente(cbbCliente.Text);
                    CLIENTE.UltimaVisita = DateTime.Now;
                    Utilitarios.OpClientes.ActualizarCLIENTE(CLIENTE);

                    OrdenDetalle.Clear();
                    lblImpuesto.Text = "";
                    lblTotal.Text = "";
                    lblServiciosAd.Text = "";
                    lblSubtotal.Text = "";
                    this.FrmPedido_Load(sender, e);
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Someter Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Desea Descartar la orden " + lblConsecutivo.Text + "  del sistema?", "Advertencia",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (mensaje == DialogResult.Yes)
            {
                OrdenDetalle.Clear();
                lblImpuesto.Text = "";
                lblTotal.Text = "";
                lblServiciosAd.Text = "";
                lblSubtotal.Text = "";
                this.FrmPedido_Load(sender, e);
            }
            else
            {
                return;
            }

        }

        private void chkTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTarjeta.Checked)
            {
                txtTarjeta.Visible = true;
            }
            else
            {
                txtTarjeta.Visible = false;
            }
        }

        private void chkEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEfectivo.Checked)
            {
                txtEfectivo.Visible = true;
            }
            else
            {
                txtEfectivo.Visible = false;
            }
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtro.Checked)
            {
                txtOtro.Visible = true;
            }
            else
            {
                txtOtro.Visible = false;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtTarjeta.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtEfectivo.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtOtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtOtro.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExpress_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text == "    -")
                {
                    MessageBox.Show("Digita el numero de contacto para este servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefono.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Digita la Direccion del contacto para este servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDireccion.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecioExpress.Text) || string.IsNullOrWhiteSpace(txtPrecioExpress.Text))
                {
                    MessageBox.Show("Digita el precio del servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioExpress.Focus();
                    return;
                }

                DetallePedido DetailPP = new DetallePedido();

                DetailPP.Producto = "Servicio Express";
                //DetailPP.Consecutivo = "DPD-" + NxtConsecutivoDetallePedido().ToString();
                DetailPP.IdOrden = Int32.Parse(lblConsecutivo.Text);
                DetailPP.ObservacionesDT = "Telefono: " + txtTelefono.Text + " Direccion: " + txtDireccion.Text;
                DetailPP.Cantidad = 1;
                DetailPP.SubTotal = Convert.ToDecimal(txtPrecioExpress.Text);
                OrdenDetalle.Add(DetailPP);
                NuevaOrden.Subtotal = NuevaOrden.Subtotal + DetailPP.SubTotal;
                decimal impuesto = (NuevaOrden.Subtotal * Convert.ToDecimal(0.13));
                lblImpuesto.Text = impuesto.ToString("N");
                lblServiciosAd.Text = DetailPP.SubTotal.ToString("N");
                lblSubtotal.Text = (NuevaOrden.Subtotal - impuesto).ToString("N");
                lblTotal.Text = NuevaOrden.Subtotal.ToString("N");
                txtTelefono.Clear();
                txtPrecioExpress.Clear();
                txtDireccion.Clear();
                chkExpress.Checked = false;

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Agregar Servicio Express a Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioExpress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utilitarios.EsNumerico(e.KeyChar.ToString()))
            {
                this.txtPrecioExpress.Clear();
                e.Handled = true;
                MessageBox.Show("Digita unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (OrdenDetalle.Count == 0)
            {
                MessageBox.Show("Debes Agregar Productos a la Orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkEfectivo.Checked && !chkTarjeta.Checked && !chkOtro.Checked)
            {
                MessageBox.Show("Debes seleccionar al menos un metodo de Pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chkEfectivo.Checked && (string.IsNullOrEmpty(txtEfectivo.Text) || string.IsNullOrWhiteSpace(txtEfectivo.Text)))
            {
                MessageBox.Show("Digita el monto a Pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEfectivo.Focus();
                return;
            }
            if (chkTarjeta.Checked && (string.IsNullOrEmpty(txtTarjeta.Text) || string.IsNullOrWhiteSpace(txtTarjeta.Text)))
            {
                MessageBox.Show("Digita el monto a Pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTarjeta.Focus();
                return;
            }
            if (chkOtro.Checked && (string.IsNullOrEmpty(txtOtro.Text) || string.IsNullOrWhiteSpace(txtOtro.Text)))
            {
                MessageBox.Show("Digita el monto a Pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOtro.Focus();
                return;
            }
            try
            {
                var mensaje = MessageBox.Show("¿ Desea Someter  y Pagar la orden " + lblConsecutivo.Text + "?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    decimal MontoDigitado, Otro, Tarjeta, Efectivo = 0;
                    if (chkTarjeta.Checked)
                    {
                        Tarjeta = Convert.ToDecimal(txtTarjeta.Text);
                    }
                    else
                    {
                        Tarjeta = 0;
                    }
                    if (chkEfectivo.Checked)
                    {
                        Efectivo = Convert.ToDecimal(txtEfectivo.Text);
                    }
                    else
                    {
                        Efectivo = 0;
                    }
                    if (chkOtro.Checked)
                    {
                        Otro = Convert.ToDecimal(txtOtro.Text);
                    }
                    else
                    {
                        Otro = 0;
                    }
                    MontoDigitado = Otro + Tarjeta + Efectivo;

                    if (MontoDigitado < NuevaOrden.Subtotal)
                    {
                        MessageBox.Show("Digita el monto a Pagar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Consecutivo Consec = Utilitarios.OpConsecutivo.BuscarConsecutivo("PDD");
                    NuevaOrden.MontoEfectivo = Efectivo;
                    NuevaOrden.MontoOtro = Otro;
                    NuevaOrden.MontoTarjeta = Tarjeta;
                    NuevaOrden.MontoCambio = MontoDigitado - NuevaOrden.Subtotal;
                    NuevaOrden.Activo = true;
                    NuevaOrden.Cancelado = true;
                    NuevaOrden.CompletoCocina = false;

                    Utilitarios.OpPedidos.AgregarPedido(NuevaOrden);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + lblConsecutivo.Text + " Agregada a pendientes, Orden cancelada");

                    Utilitarios.TicketeGeneral(Utilitarios.OpCaja.ListarCajas().Where(X => X.OperadorActual == FrmLogin.UsuarioGlobal.Username).Select(x => x.Consecutivo).FirstOrDefault().ToString(), FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1, lblCliente.Text, OrdenDetalle, NuevaOrden);

                    List<DetallePedido> ListaSoporte = new List<DetallePedido>();
                    foreach (var item in OrdenDetalle)
                    {

                        if (Utilitarios.OpProducto.ExisteProductoPorNombre(item.Producto))
                        {

                            var newitem = Utilitarios.OpProducto.BuscarProductoPorNombre(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Codigo.ToString();
                            ListaSoporte.Add(DetalleSoporte);
                        }
                        else if (item.Producto == "Servicio Express")
                        {
                            ListaSoporte.Add(item);
                        }
                        else
                        {
                            var newitem = Utilitarios.OpCombo.BuscarComboPorNombre(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Codigo.ToString();
                            ListaSoporte.Add(DetalleSoporte);
                        }
                    }
                    for (int i = 0; i < ListaSoporte.Count; i++)
                    {
                        Utilitarios.OpDetallePedido.AgregarDetalle(ListaSoporte[i]);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Producto perteneciente a la orden  " + lblConsecutivo.Text + " Agregado a pendientes, Orden cancelada");
                    }


                    OrdenDetalle.Clear();
                    lblImpuesto.Text = "";
                    lblTotal.Text = "";
                    lblServiciosAd.Text = "";
                    lblSubtotal.Text = "";
                    txtTarjeta.Clear();
                    txtOtro.Clear();
                    txtEfectivo.Clear();
                    chkTarjeta.Checked = false;
                    FrmCambioCaja a = new FrmCambioCaja();
                    FrmCambioCaja.CambioShow = NuevaOrden.MontoCambio.ToString();
                    a.Show();
                    this.FrmPedido_Load(sender, e);

                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Someter y pagar la Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            FrmGestionOrden a = new FrmGestionOrden();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(FrmMenuPrincipal))
                {
                    a.MdiParent = FrmLogin.MN;
                    a.WindowState = FormWindowState.Maximized;
                }
            }
            a.WindowState = FormWindowState.Maximized;
            a.Show();

        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCierreCajero a = new FrmCierreCajero();
                a.Show();
                a.WindowState = FormWindowState.Maximized;
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Cierre desde menu de Pedido ");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtObservacionesPP_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkLechuga_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


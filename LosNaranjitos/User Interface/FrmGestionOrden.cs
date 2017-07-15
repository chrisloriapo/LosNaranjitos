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
    public partial class FrmGestionOrden : Form
    {
        public FrmGestionOrden()
        {
            InitializeComponent();
        }

        private void chkOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOrden.Checked)
            {
                chkCliente.Checked = false;
                cbbCliente.Visible = false;
                cbbOrden.Visible = true;
            }
            else
            {
                cbbOrden.Visible = false;
            }
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCliente.Checked)
            {
                chkOrden.Checked = false;
                cbbOrden.Visible = false;
                cbbCliente.Visible = true;
            }
            else
            {
                cbbCliente.Visible = false;
            }
        }

        private void FrmGestionOrden_Load(object sender, EventArgs e)
        {
            try
            {
                cbbCliente.DataSource = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo == true).Select(x => x.IdCliente).ToList();
                cbbOrden.DataSource = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo == true).Select(x => x.Consecutivo).ToList();
                dgvOrdenesVista.DataSource = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo == true).ToList();

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Gestionar Ordenes en Modulo de Carga");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (!Utilitarios.OpPedidos.ExisteConsecutivo(Int32.Parse(cbbOrden.SelectedValue.ToString())))
                {
                    MessageBox.Show("Seleccione una orden de la lista o digite una orden existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Pedido PedidoLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(cbbOrden.SelectedValue.ToString()));
                    lblOrden.Text = PedidoLocal.Consecutivo.ToString();
                    lblTotal.Text = "₡ " + PedidoLocal.Subtotal;
                    chkEntregado.Checked = !PedidoLocal.Activo;
                    chkCancelado.Checked = PedidoLocal.Cancelado;
                    chkCocinado.Checked = PedidoLocal.CompletoCocina;

                    Cliente ClienteLocal = Utilitarios.OpClientes.BuscarCliente(PedidoLocal.IdCliente);
                    lblNombre.Text = "Nombre: " + ClienteLocal.Nombre;
                    lblApellidos.Text = "Apellidos: " + ClienteLocal.Apellido1 + " " + ClienteLocal.Apellido2;
                    lbIdcliente.Text = ClienteLocal.IdPersonal;

                    List<DetallePedido> ListaSoporte = new List<DetallePedido>();
                    List<DetallePedido> OrdenDetalle = Utilitarios.OpDetallePedido.ListarDetallesPedido().Where(x => x.IdOrden == PedidoLocal.Consecutivo).ToList();
                    foreach (var item in OrdenDetalle)
                    {

                        if (Utilitarios.OpProducto.ExisteProducto(item.Producto))
                        {

                            var newitem = Utilitarios.OpProducto.BuscarProducto(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                        else if (item.Producto == "Servicio Express")
                        {
                            ListaSoporte.Add(item);
                        }
                        else
                        {
                            var newitem = Utilitarios.OpCombo.BuscarCombo(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                    }
                    dgvOrdenesVista.DataSource = ListaSoporte.ToList();
                }

            }
            catch (Exception ex)
            {
                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    return;
                }
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Utilitarios.OpClientes.ExisteCLIENTE(cbbCliente.SelectedValue.ToString()))
                {
                    MessageBox.Show("Seleccione un cliente de la lista o digite un cliente existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cliente ClienteLocal = Utilitarios.OpClientes.BuscarCliente(cbbCliente.SelectedValue.ToString());
                    lblNombre.Text = "Nombre: " + ClienteLocal.Nombre;
                    lblApellidos.Text = "Apellidos: " + ClienteLocal.Apellido1 + " " + ClienteLocal.Apellido2;
                    lbIdcliente.Text = ClienteLocal.IdPersonal;

                    Pedido PedidoLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.IdCliente == ClienteLocal.IdPersonal).FirstOrDefault();
                    lblOrden.Text = PedidoLocal.Consecutivo.ToString();
                    lblTotal.Text = "₡ " + PedidoLocal.Subtotal;
                    chkEntregado.Checked = !PedidoLocal.Activo;
                    chkCancelado.Checked = PedidoLocal.CompletoCocina;
                    chkCocinado.Checked = PedidoLocal.Cancelado;

                    List<DetallePedido> ListaSoporte = new List<DetallePedido>();
                    List<DetallePedido> OrdenDetalle = Utilitarios.OpDetallePedido.ListarDetallesPedido().Where(x => x.Consecutivo == PedidoLocal.Consecutivo).ToList();
                    foreach (var item in OrdenDetalle)
                    {

                        if (Utilitarios.OpProducto.ExisteProducto(item.Producto))
                        {

                            var newitem = Utilitarios.OpProducto.BuscarProducto(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                        else if (item.Producto == "Servicio Express")
                        {
                            ListaSoporte.Add(item);
                        }
                        else
                        {
                            var newitem = Utilitarios.OpCombo.BuscarCombo(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                    }
                    dgvOrdenesVista.DataSource = ListaSoporte.ToList();
                }

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (chkEntregado.Checked)
            {
                MessageBox.Show("La Orden ya fue entregada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkCancelado.Checked)
            {
                MessageBox.Show("La Orden debe ser cancelada antes de entregar", "Orden No Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                var mensaje = MessageBox.Show("¿ Desea dar la orden " + lblOrden.Text + " por entregada?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                Pedido OrdenLocal = new Pedido();
                OrdenLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(lblOrden.Text));

                if (mensaje == DialogResult.Yes)
                {
                    OrdenLocal.Activo = false;
                    OrdenLocal.CompletoCocina = true;
                    OrdenLocal.Observaciones = OrdenLocal.Observaciones + " Orden Entregada a las " + DateTime.Now + ";";
                    Utilitarios.OpPedidos.ActualizarPedido(OrdenLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + OrdenLocal.Consecutivo + " Entregada");

                    lblOrden.Text = "";
                    lblTotal.Text = "";
                    lblNombre.Text = "";
                    lblApellidos.Text = "";
                    txtTarjeta.Clear();
                    txtOtro.Clear();
                    txtEfectivo.Clear();
                    chkTarjeta.Checked = false;
                    chkEfectivo.Checked = false;
                    chkOtro.Checked = false;
                    this.FrmGestionOrden_Load(sender, e);

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


        private void btnPagar_Click(object sender, EventArgs e)
        {

            if (chkCocinado.Checked)
            {
                MessageBox.Show("La Orden ya ha sido cancelada", "Orden ya  Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var mensaje = MessageBox.Show("¿ Desea pagar la orden " + lblOrden.Text + " ?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                Pedido OrdenLocal = new Pedido();
                OrdenLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(lblOrden.Text));

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

                    if (MontoDigitado < OrdenLocal.Subtotal)
                    {
                        MessageBox.Show("Digita el monto a Pagar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    OrdenLocal.Cancelado = true;
                    OrdenLocal.MontoEfectivo = Efectivo;
                    OrdenLocal.MontoOtro = Otro;
                    OrdenLocal.CompletoCocina = false;
                    OrdenLocal.MontoTarjeta = Tarjeta;
                    OrdenLocal.MontoCambio = MontoDigitado - OrdenLocal.Subtotal;
                    OrdenLocal.Observaciones = OrdenLocal.Observaciones + " Orden Cancelada a las " + DateTime.Now + ";";
                    Utilitarios.OpPedidos.ActualizarPedido(OrdenLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + OrdenLocal.Consecutivo + " Cancelada");
                    FrmCambioCaja a = new FrmCambioCaja();
                    FrmCambioCaja.CambioShow = (MontoDigitado - OrdenLocal.Subtotal).ToString();
                    a.Show();
                    var OrdenDetalle = Utilitarios.OpDetallePedido.ListarDetallesPedido().Where(x => x.IdOrden == OrdenLocal.Consecutivo);

                    List<DetallePedido> ListaSoporte = new List<DetallePedido>();
                    foreach (var item in OrdenDetalle)
                    {

                        if (Utilitarios.OpProducto.ExisteProducto(item.Producto))
                        {

                            var newitem = Utilitarios.OpProducto.BuscarProducto(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                        else if (item.Producto == "Servicio Express")
                        {
                            ListaSoporte.Add(item);
                        }
                        else
                        {
                            var newitem = Utilitarios.OpCombo.BuscarCombo(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.IdOrden = item.IdOrden;
                            DetalleSoporte.ObservacionesDT = item.ObservacionesDT;
                            DetalleSoporte.SubTotal = item.SubTotal;
                            DetalleSoporte.Cantidad = item.Cantidad;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                    }


                    Utilitarios.TicketeGeneral(Utilitarios.OpCaja.ListarCajas().Where(X => X.OperadorActual == FrmLogin.UsuarioGlobal.Username).Select(x => x.Consecutivo).FirstOrDefault().ToString(), FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1, Utilitarios.OpClientes.BuscarCliente(OrdenLocal.IdCliente).Nombre + " " + Utilitarios.OpClientes.BuscarCliente(OrdenLocal.IdCliente).Apellido1, ListaSoporte, OrdenLocal);
                    if (OrdenLocal.IdCliente != "0")
                    {
                        FrmPedido.EjecutarReporte(Utilitarios.OpClientes.BuscarCliente(OrdenLocal.IdCliente), OrdenLocal, ListaSoporte);

                    }

                    lblOrden.Text = "";
                    lblTotal.Text = "";
                    lblNombre.Text = "";
                    lblApellidos.Text = "";
                    txtTarjeta.Clear();
                    txtOtro.Clear();
                    txtEfectivo.Clear();
                    chkTarjeta.Checked = false;
                    chkEfectivo.Checked = false;
                    chkOtro.Checked = false;
                    this.FrmGestionOrden_Load(sender, e);
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

        private void btnEntregarPagar_Click(object sender, EventArgs e)
        {

            if (chkCocinado.Checked)
            {
                MessageBox.Show("La Orden ya ha sido cancelada", "Orden ya  Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var mensaje = MessageBox.Show("¿ Desea dar la orden " + lblOrden.Text + " por entregada?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                Pedido OrdenLocal = new Pedido();
                OrdenLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(lblOrden.Text));

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

                    if (MontoDigitado < OrdenLocal.Subtotal)
                    {
                        MessageBox.Show("Digita el monto a Pagar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    OrdenLocal.Cancelado = true;
                    OrdenLocal.Activo = false;
                    OrdenLocal.CompletoCocina = true;
                    OrdenLocal.MontoEfectivo = Efectivo;
                    OrdenLocal.MontoOtro = Otro;
                    OrdenLocal.MontoTarjeta = Tarjeta;
                    OrdenLocal.MontoCambio = MontoDigitado - OrdenLocal.Subtotal;
                    OrdenLocal.Observaciones = OrdenLocal.Observaciones + " Orden Cancelada a las " + DateTime.Now + ";";
                    Utilitarios.OpPedidos.ActualizarPedido(OrdenLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + OrdenLocal.Consecutivo.ToString() + " Cancelada");
                    FrmCambioCaja a = new FrmCambioCaja();
                    FrmCambioCaja.CambioShow = (MontoDigitado - OrdenLocal.Subtotal).ToString();
                    a.Show();
                    var OrdenDetalle = Utilitarios.OpDetallePedido.ListarDetallesPedido().Where(x => x.IdOrden == OrdenLocal.Consecutivo);

                    List<DetallePedido> ListaSoporte = new List<DetallePedido>();
                    foreach (var item in OrdenDetalle)
                    {

                        if (Utilitarios.OpProducto.ExisteProducto(item.Producto))
                        {

                            var newitem = Utilitarios.OpProducto.BuscarProducto(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                        else if (item.Producto == "Servicio Express")
                        {
                            ListaSoporte.Add(item);
                        }
                        else
                        {
                            var newitem = Utilitarios.OpCombo.BuscarCombo(item.Producto);
                            DetallePedido DetalleSoporte = item;
                            DetalleSoporte.IdOrden = item.IdOrden;
                            DetalleSoporte.ObservacionesDT = item.ObservacionesDT;
                            DetalleSoporte.SubTotal = item.SubTotal;
                            DetalleSoporte.Cantidad = item.Cantidad;
                            DetalleSoporte.Producto = newitem.Nombre;
                            ListaSoporte.Add(DetalleSoporte);
                        }
                    }


                    Utilitarios.TicketeGeneral(Utilitarios.OpCaja.ListarCajas().Where(X => X.OperadorActual == FrmLogin.UsuarioGlobal.Username).Select(x => x.Consecutivo).FirstOrDefault().ToString(), FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1, Utilitarios.OpClientes.BuscarCliente(OrdenLocal.IdCliente).Nombre + " " + Utilitarios.OpClientes.BuscarCliente(OrdenLocal.IdCliente).Apellido1, ListaSoporte, OrdenLocal);
                    if (OrdenLocal.IdCliente != "0")
                    {
                        FrmPedido.EjecutarReporte(Utilitarios.OpClientes.BuscarCliente(OrdenLocal.IdCliente), OrdenLocal, ListaSoporte);

                    }
                    lblOrden.Text = "";
                    lblTotal.Text = "";
                    lblNombre.Text = "";
                    lblApellidos.Text = "";
                    txtTarjeta.Clear();
                    txtOtro.Clear();
                    txtEfectivo.Clear();
                    chkTarjeta.Checked = false;
                    chkEfectivo.Checked = false;
                    chkOtro.Checked = false;

                    this.FrmGestionOrden_Load(sender, e);

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

        private void btnModificar_Click(object sender, EventArgs e)
        {

            FrmModificarOrden a = new FrmModificarOrden();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(FrmMenuPrincipal))
                {
                    a.MdiParent = FrmLogin.MN;
                    a.WindowState = FormWindowState.Maximized;
                }
            }
            a.Show();
            a.WindowState = FormWindowState.Maximized;
            this.Dispose();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCompletarOrden_Click(object sender, EventArgs e)
        {
            if (chkCocinado.Checked)
            {
                MessageBox.Show("La Orden ya Esta lista para entrega y Cobro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                var mensaje = MessageBox.Show("¿ Desea dar la orden " + lblOrden.Text + " por Completada?", "Advertencia",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                Pedido OrdenLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(lblOrden.Text));

                if (mensaje == DialogResult.Yes)
                {
                    OrdenLocal.Activo = false;
                    OrdenLocal.CompletoCocina = true;
                    OrdenLocal.Observaciones = OrdenLocal.Observaciones + " Orden Entregada a las " + DateTime.Now + ";";
                    Utilitarios.OpPedidos.ActualizarPedido(OrdenLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + OrdenLocal.Consecutivo + " Entregada");
                    //Bandera para desplegar orden en pantalla adicional

                    DATOS.Parametros Flag = new Parametros();
                    Flag = Utilitarios.OpParametros.BuscarParametrosPorNombre("BanderaMonitor");
                    Flag.Valor = "1";
                    Utilitarios.OpParametros.ActualizarParametro(Flag);

                    lblOrden.Text = "";
                    lblTotal.Text = "";
                    lblNombre.Text = "";
                    lblApellidos.Text = "";
                    txtTarjeta.Clear();
                    txtOtro.Clear();
                    txtEfectivo.Clear();
                    chkTarjeta.Checked = false;
                    chkEfectivo.Checked = false;
                    chkOtro.Checked = false;
                    OrdenLocal = new Pedido();
                    this.FrmGestionOrden_Load(sender, e);

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
    }
}

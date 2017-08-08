using LosNaranjitos.DATOS;
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
    public partial class FrmModificarOrden : Form
    {
        public FrmModificarOrden()
        {
            InitializeComponent();
        }
        public List<DetallePedido> ListaSoporte = new List<DetallePedido>();

        private void FrmModificarOrden_Load(object sender, EventArgs e)
        {
            try
            {

                cbbOrden.DataSource = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo == true).Select(x => x.Consecutivo).ToList();

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
                ListaSoporte.Clear();
                if (!Utilitarios.OpPedidos.ExisteConsecutivo(Int32.Parse( cbbOrden.SelectedValue.ToString())))
                {
                    MessageBox.Show("Seleccione una orden de la lista o digite una orden existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Pedido PedidoLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(cbbOrden.SelectedValue.ToString()));
                    lblOrden.Text = PedidoLocal.Consecutivo.ToString() ;
                    lblTotal.Text = "₡ " + PedidoLocal.Subtotal;
                    chkEntregado.Checked = !PedidoLocal.Activo;
                    chkCancelado.Checked = PedidoLocal.Cancelado;

                    Cliente ClienteLocal = Utilitarios.OpClientes.BuscarCliente(PedidoLocal.IdCliente);
                    lblNombre.Text = "Nombre: " + ClienteLocal.Consecutivo;
                    lblApellidos.Text = "Apellidos: " + ClienteLocal.Apellido1 + " " + ClienteLocal.Apellido2;
                    lbIdcliente.Text = ClienteLocal.IdPersonal;

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
                    cmbProducto.DataSource = ListaSoporte.Select(x => x.Producto).ToList();
                    dgvOrdenesVista.DataSource = ListaSoporte.ToList();
                }

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var detalle = ListaSoporte.Find(x => x.Producto == cmbProducto.SelectedValue.ToString());
                lbl1.Text = "Cantidad: " + detalle.Cantidad;
                lbl2.Text = "Subtotal: " + detalle.SubTotal;
                lbl3.Text = "Observacion: " + detalle.ObservacionesDT;
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescartarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿ Desea dar la orden " + lblOrden.Text + " por descartada?", "Advertencia",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mensaje == DialogResult.No)
                {
                    return;
                }
                if (ValidarUsuario())
                {
                    Pedido OrdenLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(lblOrden.Text));
                    OrdenLocal.Observaciones = "Orden Descartada por: " + FrmLogin.UsuarioGlobal.Username + ", Autorizado por: " + txtUsuario.Text + ". Razón: " + txtComentario.Text + "Monto: ₡" + OrdenLocal.Subtotal;
                    OrdenLocal.Activo = false;
                    OrdenLocal.Cancelado = true;
                    OrdenLocal.Subtotal = 0;
                    OrdenLocal.MontoEfectivo = 0;
                    OrdenLocal.MontoOtro = 0;
                    OrdenLocal.MontoTarjeta = 0;
                    OrdenLocal.MontoCambio = 0;
                    Utilitarios.OpPedidos.ActualizarPedido(OrdenLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + lblOrden.Text + " descartada correctamente.");
                    MessageBox.Show("Orden Descartada Correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();

                }

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿ Desea Eliminar el producto " + cmbProducto.SelectedValue.ToString() + " de la orden " + lblOrden.Text + "?", "Advertencia",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mensaje == DialogResult.No)
                {
                    return;
                }
                if (ValidarUsuario())
                {
                    Pedido OrdenLocal = Utilitarios.OpPedidos.BuscarPedido(Int32.Parse(lblOrden.Text));
                    OrdenLocal.Observaciones = "Producto: " + cmbProducto.SelectedValue.ToString() + " eliminado de la orden por " + FrmLogin.UsuarioGlobal.Username + ", Autorizado por: " + txtUsuario.Text + ". Razón: " + txtComentario.Text;

                    var detalle = ListaSoporte.Find(x => x.Producto == cmbProducto.SelectedValue.ToString());
                    DetallePedido DetalleSoporte = new DetallePedido();

                    if (Utilitarios.OpProducto.ExisteProductoPorNombre(detalle.Producto))
                    {
                        var newitem = Utilitarios.OpProducto.BuscarProductoPorNombre(detalle.Producto);
                        DetalleSoporte = new DetallePedido();
                        DetalleSoporte = detalle;
                        DetalleSoporte.Producto = newitem.Codigo;
                    }
                    else if (detalle.Producto == "Servicio Express")
                    {

                    }
                    else
                    {
                        var newitem = Utilitarios.OpCombo.BuscarComboPorNombre(detalle.Producto);
                        DetalleSoporte = new DetallePedido();
                        DetalleSoporte = detalle;
                        DetalleSoporte.Producto = newitem.Codigo;
                    }

                    OrdenLocal.Subtotal = OrdenLocal.Subtotal - detalle.SubTotal;
                    OrdenLocal.MontoEfectivo = OrdenLocal.MontoEfectivo - detalle.SubTotal;

                    Utilitarios.OpDetallePedido.EliminarDetalleDeOrden(detalle);
                    Utilitarios.OpPedidos.ActualizarPedido(OrdenLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Orden " + lblOrden.Text + " modificada correctamente.");
                    MessageBox.Show("Orden Modificada Correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATOS.Parametros Flag = new Parametros();
                    Flag = Utilitarios.OpParametros.BuscarParametrosPorNombre("BanderaMonitor");
                    Flag.Valor = "1";
                    Utilitarios.OpParametros.ActualizarParametro(Flag);

                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Caja al Buscar Orden");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarUsuario()
        {
            try
            {
                if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("NO se permite espacios en blanco ni casillas vacias", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(txtComentario.Text) || String.IsNullOrEmpty(txtComentario.Text))
                {
                    MessageBox.Show("Debes ingresar un comentario de Aprobacion", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtComentario.Focus();
                    return false;
                }
                if (!Utilitarios.OpUsuarios.ExisteUsuario(txtUsuario.Text.ToLower()))
                {
                    MessageBox.Show("Usuario No existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    txtUsuario.Focus();
                    return false;
                }
                else
                {
                    Utilitarios.Autorizante = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(txtUsuario.Text.ToLower());
                    if (Utilitarios.Autorizante.Rol == 1 || Utilitarios.Autorizante.Rol == -2)
                    {
                        if (Utilitarios.Autorizante.Contrasena == txtPassword.Text)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta", "No Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtPassword.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario No Posee la autoridad suficiente para aprobar el cambio", "No Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Clear();
                        txtPassword.Clear();
                        txtUsuario.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error al Popular Datos", FrmLogin.UsuarioGlobal.Username, "Error durante Autorizacion del Sistema ");
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}



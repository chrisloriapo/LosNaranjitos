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
                cbbCliente.DataSource = Utilitarios.OpClientes.ListarClientes().Select(x => x.IdPersonal).ToList();
                cbbOrden.DataSource = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo = true).Select(x => x.Consecutivo).ToList();
                dgvOrdenesVista.DataSource = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Activo = true).ToList();

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
                if (!Utilitarios.OpPedidos.ExisteConsecutivo(cbbOrden.SelectedValue.ToString()))
                {
                    MessageBox.Show("Seleccione una orden de la lista o digite una orden existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Pedido PedidoLocal = Utilitarios.OpPedidos.BuscarPedido(cbbOrden.SelectedValue.ToString());
                    lblOrden.Text = PedidoLocal.Consecutivo;
                    lblTotal.Text = "₡ " + PedidoLocal.Subtotal;
                    chkEntregado.Checked = !PedidoLocal.Activo;
                    chkCancelado.Checked = PedidoLocal.Cancelado;

                    Cliente ClienteLocal = Utilitarios.OpClientes.BuscarCliente(PedidoLocal.IdCliente);
                    lblNombre.Text = lblNombre.Text + ClienteLocal.Consecutivo;
                    lblApellidos.Text = lblApellidos.Text + ClienteLocal.Apellido1 + " " + ClienteLocal.Apellido2;
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
                    lblNombre.Text = lblNombre.Text + ClienteLocal.Consecutivo;
                    lblApellidos.Text = lblApellidos.Text + ClienteLocal.Apellido1 + " " + ClienteLocal.Apellido2;
                    lbIdcliente.Text = ClienteLocal.IdPersonal;

                    Pedido PedidoLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.IdCliente == ClienteLocal.IdPersonal).FirstOrDefault();
                    lblOrden.Text = PedidoLocal.Consecutivo;
                    lblTotal.Text = "₡ " + PedidoLocal.Subtotal;
                    chkEntregado.Checked = !PedidoLocal.Activo;
                    chkCancelado.Checked = PedidoLocal.Cancelado;


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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosNaranjitos.User_Interface
{
    public partial class FrmParametros_de_Impresion : Form
    {
        public FrmParametros_de_Impresion()
        {
            InitializeComponent();
        }

        private void FrmParametros_de_Impresion_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbbImpresora.Items.Add(printer);
            }
            cbbImpresora.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿ Desea Cambiar la Impresora por " + cbbImpresora.SelectedItem.ToString() + "?", "Advertencia",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    DATOS.Parametros ParametroLocal = new DATOS.Parametros();
                    ParametroLocal = Utilitarios.OpParametros.BuscarParametrosPorNombre("Impresora de Ticketes");
                    ParametroLocal.Fecha = DateTime.Now;
                    ParametroLocal.Operador = FrmLogin.UsuarioGlobal.Username;
                    ParametroLocal.Valor = cbbImpresora.SelectedItem.ToString();
                    Utilitarios.OpParametros.ActualizarParametro(ParametroLocal);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Impresora de Ticketes Actualizada ");
                    MessageBox.Show("Impresora Actualizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DATOS.Pedido OrdenPrueba = new DATOS.Pedido { Activo = true, Cancelado = true, Cerrado = true, CierreOperador = true, Consecutivo = 1, Fecha = DateTime.Now, IdCliente = "Cliente Prueba", MontoCambio = 500, MontoEfectivo = 1000, MontoOtro = 1000, MontoTarjeta = 1000, Observaciones = "Observaciones", Operador = FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1, Subtotal = 10000 };
                    List<DATOS.DetallePedido> DetallePrueba = new List<DATOS.DetallePedido>();
                    DATOS.DetallePedido Prueba = new DATOS.DetallePedido { Consecutivo = 1, Cantidad = 6, IdOrden = OrdenPrueba.Consecutivo, ObservacionesDT = "", Producto = "Producto Prueba 1", SubTotal = 5000 };
                    DATOS.DetallePedido Prueba2 = new DATOS.DetallePedido { Consecutivo = 2, Cantidad = 5, IdOrden = OrdenPrueba.Consecutivo, ObservacionesDT = "", Producto = "Producto Prueba 2", SubTotal = 4500 };
                    DetallePrueba.Add(Prueba);
                    DetallePrueba.Add(Prueba2);

                    Utilitarios.TicketeGeneral("1", "Prueba", "Cliente Prueba", DetallePrueba, OrdenPrueba);
                    this.Dispose();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error al Seleccionar Impresora default ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

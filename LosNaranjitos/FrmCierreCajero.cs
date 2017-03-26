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
    public partial class FrmCierreCajero : Form
    {
        public FrmCierreCajero()
        {
            InitializeComponent();
        }

        private void FrmCierreCajero_Load(object sender, EventArgs e)
        {

        }

        private void cbbTipoCierre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbTipoCierre.SelectedItem.ToString() == "Cierre de Caja")
                {
                    var ListaLocal = Utilitarios.OpCaja.ListarCajas().Where(x => x.Estado == true).Select(x => x.Consecutivo);
                    if (ListaLocal.Count() == 0)
                    {
                        MessageBox.Show("No Existen Cajas en modo de Apertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dtpFecha.Visible = false;
                    cbbCaja.DataSource = ListaLocal.ToList();
                    cbbCaja.Visible = true;
                    rptVReporteLocal.Visible = false;
                }
                else
                {
                    dtpFecha.Value = DateTime.Today.AddDays(0);
                    dtpFecha.Visible = true;
                    cbbCaja.Visible = false;
                    rptVReporteLocal.Visible = false;
                }

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cierre al Selecionar Tipo de Cirre Formulario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿ Desea Ejecutar el " + cbbTipoCierre.SelectedItem.ToString() + " ?", "Advertencia",
      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    switch (cbbTipoCierre.SelectedItem.ToString())
                    {
                        case "Cierre de Caja":
                            var ListaLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Operador == FrmLogin.UsuarioGlobal.Username && x.CierreOperador == false);
                            decimal MontoTarjeta, MontoOtro, MontoEfectivo, MontoCambio, Total = 0;
                            MontoCambio = ListaLocal.Sum(x => x.MontoCambio);
                            MontoTarjeta = ListaLocal.Sum(x => x.MontoTarjeta);
                            MontoOtro = ListaLocal.Sum(x => x.MontoOtro);
                            MontoEfectivo = ListaLocal.Sum(x => x.MontoEfectivo);
                            Total = ListaLocal.Sum(x => x.Subtotal);

                            Cierre CierreCaja = new Cierre();
                            Consecutivo Consec = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Cierre");
                            if (Consec.ConsecutivoActual == 0)
                            {
                                CierreCaja.Consecutivo = "" + Consec.Prefijo + "-1";
                            }
                            CierreCaja.Consecutivo = "" + Consec.Prefijo + "-" + Consec.ConsecutivoActual + 1;
                            CierreCaja.Usuario = FrmLogin.UsuarioGlobal.Username;
                            CierreCaja.Tipo = cbbTipoCierre.SelectedIndex.ToString();
                            CierreCaja.MontroOtro = MontoOtro;
                            CierreCaja.MontoCambio = MontoCambio;
                            CierreCaja.MontoEfectivo = MontoEfectivo;
                            CierreCaja.MontoTarjeta = MontoTarjeta;
                            CierreCaja.MontoTotal = Total;
                            CierreCaja.CantidadVentas = ListaLocal.Count();
                            CierreCaja.Caja = cbbCaja.SelectedItem.ToString();
                            CierreCaja.Fecha = DateTime.Now;
                            Consec.ConsecutivoActual = Consec.ConsecutivoActual + 1;
                            foreach (var item in ListaLocal)
                            {
                                item.CierreOperador = true;
                                Utilitarios.OpPedidos.ActualizarPedido(item);
                            }
                            Caja CAJA = new Caja();
                            CAJA = Utilitarios.OpCaja.BuscarCaja(cbbCaja.SelectedItem.ToString());
                            CAJA.Estado = false;
                            CAJA.OperadorActual = "Libre";
                            CAJA.UltimaModificacion = DateTime.Now;
                            Utilitarios.OpCaja.ActualizarCajas(CAJA);
                            Utilitarios.OpCierres.NuevoCierre(CierreCaja);
                            Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consec);
                            Utilitarios.GeneralBitacora(CierreCaja.Usuario, "Cierre de Caja (Arqueo) ejecutado");
                            MessageBox.Show("Cierre Registrado Exitosamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (var item in (this.OrangeDB1DataSet.Cierre))
                            {
                                if (item.Consecutivo != Utilitarios.Encriptar(CierreCaja.Consecutivo, Utilitarios.Llave))
                                {
                                    item.Delete();
                                    this.OrangeDB1DataSet.Cierre.AcceptChanges();
                                }
                                else
                                {
                                    item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                                    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
                                    item.Tipo = Utilitarios.Decriptar(item.Tipo, Utilitarios.Llave);
                                    item.Caja = Utilitarios.Decriptar(item.Caja, Utilitarios.Llave);
                                }
                            }
                            OrangeDB1DataSet.Cierre.OrderByDescending(x => x.Consecutivo);

                            this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);
                            this.rptVReporteLocal.RefreshReport();
                            rptVReporteLocal.Visible = true;

                            break;
                        case "Cierre Diario":

                            if (Utilitarios.OpCierres.ExisteCierreDiario(dtpFecha.Value))
                            {
                                MessageBox.Show("Ya Existe un Registro de Cierre para el dia Seleccionado", "Cierre ya ejecutado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            DateTime D1, D2;
                            D1 = Utilitarios.GetDateZeroTime(dtpFecha.Value);
                            D2 = Utilitarios.GetDateEndTime(dtpFecha.Value);
                            var ListaLocal2 = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false && (x.Fecha >= D1 || x.Fecha <= D2));

                            foreach (var item in ListaLocal2)
                            {
                                if (item.Activo || !item.Cancelado)
                                {
                                    MessageBox.Show("Verifica Las ordenes Pendientes de Entrega o Pago antes de Proceder", "Ordenes Pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!item.CierreOperador)
                                {
                                    MessageBox.Show("Debes Generar el Cierre de Caja del Operador "+item.Operador+" antes de Continuar", "Arqueo Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            decimal MontoTarjeta2, MontoOtro2, MontoEfectivo2, MontoCambio2, Total2 = 0;
                            MontoTarjeta2 = ListaLocal2.Sum(x => x.MontoTarjeta);
                            MontoOtro2 = ListaLocal2.Sum(x => x.MontoOtro);
                            MontoEfectivo2 = ListaLocal2.Sum(x => x.MontoEfectivo);
                            MontoCambio2 = ListaLocal2.Sum(x => x.MontoCambio);
                            Total2 = ListaLocal2.Sum(x => x.Subtotal);

                            Cierre CierreDiario = new Cierre();
                            Consecutivo Consec2 = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Cierre");
                            if (Consec2.ConsecutivoActual == 0)
                            {
                                CierreDiario.Consecutivo = "" + Consec2.Prefijo + "-1";
                            }
                            CierreDiario.Consecutivo = "" + Consec2.Prefijo + "-" + Consec2.ConsecutivoActual + 1;
                            CierreDiario.Usuario = FrmLogin.UsuarioGlobal.Username;
                            CierreDiario.Tipo = cbbTipoCierre.SelectedIndex.ToString();
                            CierreDiario.MontroOtro = MontoOtro2;
                            CierreDiario.MontoCambio = MontoCambio2;
                            CierreDiario.MontoEfectivo = MontoEfectivo2;
                            CierreDiario.MontoTarjeta = MontoTarjeta2;
                            CierreDiario.MontoTotal = Total2;
                            CierreDiario.CantidadVentas = ListaLocal2.Count();
                            CierreDiario.Caja = "Cierre Diario General";
                            CierreDiario.Fecha = dtpFecha.Value;
                            Consec2.ConsecutivoActual = Consec2.ConsecutivoActual + 1;
                            foreach (var item in ListaLocal2)
                            {
                                item.Cerrado = true;
                                Utilitarios.OpPedidos.ActualizarPedido(item);
                            }
                            Utilitarios.OpCierres.NuevoCierre(CierreDiario);
                            Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consec2);
                            Utilitarios.GeneralBitacora(CierreDiario.Usuario, "Cierre diario ejecutado");
                            MessageBox.Show("Cierre Registrado Exitosamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (var item in (this.OrangeDB1DataSet.Cierre))
                            {
                                if (item.Consecutivo != Utilitarios.Encriptar(CierreDiario.Consecutivo, Utilitarios.Llave))
                                {
                                    item.Delete();
                                    this.OrangeDB1DataSet.Cierre.AcceptChanges();
                                }
                                else
                                {
                                    item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                                    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
                                    item.Tipo = Utilitarios.Decriptar(item.Tipo, Utilitarios.Llave);
                                    item.Caja = Utilitarios.Decriptar(item.Caja, Utilitarios.Llave);
                                }
                            }
                            OrangeDB1DataSet.Cierre.OrderByDescending(x => x.Consecutivo);

                            this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);
                            this.rptVReporteLocal.RefreshReport();
                            rptVReporteLocal.Visible = true;
                            break;
                    }

                }
                else
                {
                    return;
                }


            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cierre al Selecionar Ejecutar Cierre ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}

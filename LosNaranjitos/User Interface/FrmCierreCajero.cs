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

            btnNuevo.Visible = false;
            btnEjecutar.Visible = true;
            rptVReporteLocal.Visible = false;

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

                    cbbItemTipodeCierre.DataSource = ListaLocal.ToList();
                    cbbItemTipodeCierre.Visible = true;
                    rptVReporteLocal.Visible = false;
                }
                else
                {
                    var ListaLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false).Select(x=>x.Fecha);
                    if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false).Count() == 0)
                    {
                        MessageBox.Show("No Existen Ventas Disponibles para un cierre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cbbItemTipodeCierre.DataSource = ListaLocal.ToList();
                    cbbItemTipodeCierre.Visible = true;
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
                            var ListaLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Operador == FrmLogin.UsuarioGlobal.Username && x.CierreOperador == false && x.Cancelado == true);
                            decimal MontoTarjeta, MontoOtro, MontoEfectivo, MontoCambio, Total = 0;
                            MontoCambio = ListaLocal.Sum(x => x.MontoCambio);
                            MontoTarjeta = ListaLocal.Sum(x => x.MontoTarjeta);
                            MontoOtro = ListaLocal.Sum(x => x.MontoOtro);
                            MontoEfectivo = ListaLocal.Sum(x => x.MontoEfectivo);
                            Total = ListaLocal.Sum(x => x.Subtotal);

                            Cierre CierreCaja = new Cierre();
                            // Consecutivo Consec = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Cierre");
                            //if (Consec.ConsecutivoActual == 0)
                            //{
                            //    CierreCaja.Consecutivo = "" + Consec.Prefijo + "-1";
                            //}
                            //CierreCaja.Consecutivo = "" + Consec.Prefijo + "-" + Consec.ConsecutivoActual + 1;
                            CierreCaja.Usuario = FrmLogin.UsuarioGlobal.Username;
                            CierreCaja.Tipo = cbbTipoCierre.SelectedIndex.ToString();
                            CierreCaja.MontroOtro = MontoOtro;
                            CierreCaja.MontoCambio = MontoCambio;
                            CierreCaja.MontoEfectivo = MontoEfectivo;
                            CierreCaja.MontoTarjeta = MontoTarjeta;
                            CierreCaja.MontoTotal = Total;
                            CierreCaja.CantidadVentas = ListaLocal.Count();
                            CierreCaja.Caja = cbbItemTipodeCierre.SelectedItem.ToString();
                            CierreCaja.Fecha = DateTime.Now;
                            //    Consec.ConsecutivoActual = Consec.ConsecutivoActual + 1;
                            foreach (var item in ListaLocal)
                            {
                                item.CierreOperador = true;
                                Utilitarios.OpPedidos.ActualizarPedido(item);
                            }
                            Caja CAJA = new Caja();
                            CAJA = Utilitarios.OpCaja.BuscarCaja(Int32.Parse(cbbItemTipodeCierre.SelectedItem.ToString()));
                            CAJA.Estado = false;
                            CAJA.OperadorActual = "Libre";
                            CAJA.UltimaModificacion = DateTime.Now;
                            Utilitarios.OpCaja.ActualizarCajas(CAJA);
                            Utilitarios.OpCierres.NuevoCierre(CierreCaja);
                            //     Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consec);
                            Utilitarios.GeneralBitacora(CierreCaja.Usuario, "Cierre de Caja (Arqueo) ejecutado");
                            MessageBox.Show("Cierre Registrado Exitosamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);

                            foreach (DataRow dr in OrangeDB1DataSet.Cierre.Rows)
                            {
                                if (dr["Consecutivo"].ToString() != CierreCaja.Consecutivo.ToString())
                                {
                                    dr.Delete();
                                }
                            }
                            this.OrangeDB1DataSet.Cierre.AcceptChanges();

                            foreach (var item in (this.OrangeDB1DataSet.Cierre))
                            {
                                item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
                            }
                            this.rptVReporteLocal.RefreshReport();
                            rptVReporteLocal.Visible = true;
                            btnEjecutar.Visible = false;
                            btnNuevo.Visible = true;

                            break;
                        case "Cierre Diario":

                            if (Utilitarios.OpCierres.ExisteCierreDiario(DateTime.Parse( cbbItemTipodeCierre.SelectedValue.ToString())))
                            {
                                MessageBox.Show("Ya Existe un Registro de Cierre para el dia Seleccionado", "Cierre ya ejecutado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            DateTime D1, D2;
                            D1 = Utilitarios.GetDateZeroTime(DateTime.Parse(cbbItemTipodeCierre.SelectedValue.ToString()));
                            D2 = Utilitarios.GetDateEndTime(DateTime.Parse(cbbItemTipodeCierre.SelectedValue.ToString()));
                            var ListaLocal2 = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false && (x.Fecha >= D1 && x.Fecha <= D2));

                            foreach (var item in ListaLocal2)
                            {
                                if (item.Activo || !item.Cancelado)
                                {
                                    MessageBox.Show("Verifica Las ordenes Pendientes de Entrega o Pago antes de Proceder", "Ordenes Pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!item.CierreOperador)
                                {
                                    MessageBox.Show("Debes Generar el Cierre de Caja del Operador " + item.Operador + " antes de Continuar", "Arqueo Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            //  Consecutivo Consec2 = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Cierre");
                            //if (Consec2.ConsecutivoActual == 0)
                            //{
                            //    CierreDiario.Consecutivo = "" + Consec2.Prefijo + "-1";
                            //}
                            //CierreDiario.Consecutivo = "" + Consec2.Prefijo + "-" + Consec2.ConsecutivoActual + 1;
                            CierreDiario.Usuario = FrmLogin.UsuarioGlobal.Username;
                            CierreDiario.Tipo = cbbTipoCierre.SelectedIndex.ToString();
                            CierreDiario.MontroOtro = MontoOtro2;
                            CierreDiario.MontoCambio = MontoCambio2;
                            CierreDiario.MontoEfectivo = MontoEfectivo2;
                            CierreDiario.MontoTarjeta = MontoTarjeta2;
                            CierreDiario.MontoTotal = Total2;
                            CierreDiario.CantidadVentas = ListaLocal2.Count();
                            CierreDiario.Caja = "Cierre Diario General";
                            CierreDiario.Fecha = DateTime.Parse(cbbItemTipodeCierre.SelectedValue.ToString());
                            //Consec2.ConsecutivoActual = Consec2.ConsecutivoActual + 1;
                            foreach (var item in ListaLocal2)
                            {
                                item.Cerrado = true;
                                Utilitarios.OpPedidos.ActualizarPedido(item);
                            }
                            Utilitarios.OpCierres.NuevoCierre(CierreDiario);
                            //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consec2);
                            Utilitarios.GeneralBitacora(CierreDiario.Usuario, "Cierre diario ejecutado");
                            MessageBox.Show("Cierre Registrado Exitosamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);

                            //foreach (var item in (this.OrangeDB1DataSet.Cierre))
                            //{
                            //    //if (item.Consecutivo != Utilitarios.Encriptar(CierreDiario.Consecutivo, Utilitarios.Llave))
                            //    //{
                            //    //    item.Delete();
                            //    //    this.OrangeDB1DataSet.Cierre.AcceptChanges();
                            //    //}
                            //    //else
                            //    //{
                            //    //    item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                            //        item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
                            //        item.Tipo = Utilitarios.Decriptar(item.Tipo, Utilitarios.Llave);
                            //        //item.Caja = Utilitarios.Decriptar(item.Caja, Utilitarios.Llave);
                            //        this.OrangeDB1DataSet.Cierre.AcceptChanges();
                            //  //  }
                            //}
                            OrangeDB1DataSet.Cierre.Where(x => x.Consecutivo == CierreDiario.Consecutivo.ToString());

                            this.rptVReporteLocal.RefreshReport();
                            rptVReporteLocal.Visible = true;
                            btnEjecutar.Visible = false;
                            btnNuevo.Visible = true;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FrmLogin.UsuarioGlobal.Rol == 3)
                {
                    FrmMenuCaja a = new FrmMenuCaja();
                    a.Show();
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de  Cierres ");
                    this.Dispose();
                }
                else
                {
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de  Cierres ");
                    this.Dispose();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.FrmCierreCajero_Load(sender, e);
        }
    }
}

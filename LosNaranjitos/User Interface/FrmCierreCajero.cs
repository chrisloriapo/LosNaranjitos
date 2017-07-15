using iTextSharp.text;
using iTextSharp.text.pdf;
using LosNaranjitos.DATOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
                        btnEjecutar.Enabled = false;
                        return;
                    }

                    cbbItemTipodeCierre.DataSource = ListaLocal.ToList();
                    cbbItemTipodeCierre.Visible = true;
                    btnEjecutar.Enabled = true;
                }
                else
                {
                    var ListaLocal = Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false).Select(x => x.Fecha);
                    if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false).Count() == 0)
                    {
                        MessageBox.Show("No Existen Ventas Disponibles para un cierre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnEjecutar.Enabled = false;
                        return;
                    }

                    List<DateTime> ListaFechas = new List<DateTime>();

                    foreach (var item in ListaLocal)
                    {
                        if (!ListaFechas.Contains(item.Date))
                        {
                            ListaFechas.Add(item.Date);
                        }
                    }
                    btnEjecutar.Enabled = true;
                    cbbItemTipodeCierre.DataSource = ListaFechas.ToList();
                    cbbItemTipodeCierre.Visible = true;
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

                            Utilitarios.GeneralBitacora(CierreCaja.Usuario, "Cierre de Caja (Arqueo) ejecutado");
                            MessageBox.Show("Cierre Registrado Exitosamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //CierreCaja = Utilitarios.OpCierres.BuscarCierre(Utilitarios.OpCierres.ListarRegistros().Max(x => x.Consecutivo));

                            ReportedeCierre();
                            btnEjecutar.Visible = false;
                            btnNuevo.Visible = true;

                            break;
                        case "Cierre Diario":
                            if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cancelado = false).Count() != 0)
                            {
                                MessageBox.Show("Deben Cancelar todas las ordenes antes de proceder", "Orden Abierta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (Utilitarios.OpCierres.ExisteCierreDiario(DateTime.Parse(cbbItemTipodeCierre.SelectedValue.ToString())))
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
                            foreach (var item in ListaLocal2)
                            {
                                item.Cerrado = true;
                                Utilitarios.OpPedidos.ActualizarPedido(item);
                            }
                            Utilitarios.OpCierres.NuevoCierre(CierreDiario);
                            Utilitarios.GeneralBitacora(CierreDiario.Usuario, "Cierre diario ejecutado");
                            MessageBox.Show("Cierre Registrado Exitosamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //CierreDiario = Utilitarios.OpCierres.BuscarCierre(Utilitarios.OpCierres.ListarRegistros().Max(x => x.Consecutivo));
                            ReportedeCierre();
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
            cbbTipoCierre.SelectedIndex = 0;
        }

        private void ReportedeCierre()
        {
            //Cerrar PDF Reader si esta abierto
            if (Utilitarios.FindAndKillProcess("AcroRd32"))
            {
                System.Threading.Thread.Sleep(2000);
            }
            //Soporte Basico documento PDF
            MemoryStream memStream = new MemoryStream();

            string path = @"c:\tempSoda";
            if (!Directory.Exists(path))
            {
                DirectoryInfo directorio = Directory.CreateDirectory(path);

            }
            FileStream pdfFile = new FileStream("c:\\tempSoda\\Reporte.pdf", FileMode.Create);

            Document documento = new Document(PageSize.LETTER);

            PdfWriter MailWriter = PdfWriter.GetInstance(documento, memStream);//Stream para Correo
            PdfWriter FileWriter = PdfWriter.GetInstance(documento, pdfFile);// Writer para Archivo

            //Manejo de contenido de PDF
            documento.Open();
            //Formato Standar
            //Logo de la empresa
            iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(Properties.Resources.Logo1, System.Drawing.Imaging.ImageFormat.Jpeg);
            Logo.ScalePercent(05f);

            //Encabezado

            var Encabezado = new Paragraph();
            documento.Add(new Paragraph("Soda Los Naranjitos"));
            Encabezado.Add(new Phrase("Reporte de Cierre - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
            Encabezado.Add(new Chunk(Logo, 0, 0));
            documento.Add(Encabezado);
            documento.Add(Chunk.NEWLINE);
            Paragraph lineaSeparadora = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            documento.Add(lineaSeparadora);

            //Contenido

            Cierre CierreCaja = new Cierre();
            CierreCaja = Utilitarios.OpCierres.BuscarCierre(Utilitarios.OpCierres.ListarRegistros().Max(x => x.Consecutivo));

            documento.Add(Chunk.NEWLINE);
            Usuario Ejecutor = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(CierreCaja.Usuario);
            documento.Add(new Paragraph("Cierre número: " + CierreCaja.Consecutivo + Chunk.NEWLINE + "Ejecutado por: " + Ejecutor.Nombre + " " + Ejecutor.Apellido1 + " " + Ejecutor.Apellido2 + " a las " + DateTime.Now.ToString()));

            Paragraph para = new Paragraph("Cantidad de Ventas: " + CierreCaja.CantidadVentas + Chunk.NEWLINE + "Monto de Venta en Efectivo: ¢" + CierreCaja.MontoEfectivo.ToString("N") + Chunk.NEWLINE + "Monto de Venta en Tarjeta: ¢" + CierreCaja.MontoTarjeta.ToString("N") + Chunk.NEWLINE + "Monto de Venta en Otros: ¢" + CierreCaja.MontroOtro.ToString("N") + Chunk.NEWLINE + "Monto de Cambio: ¢" + CierreCaja.MontoCambio.ToString("N") + Chunk.NEWLINE + "Monto de Venta en Total: ¢" + CierreCaja.MontoTotal.ToString("N"));
            documento.Add(para);

            documento.Add(Chunk.NEWLINE);

            documento.Add(lineaSeparadora);
            Paragraph Final = new Paragraph("Fin del Reporte");
            Final.Alignment = Element.ALIGN_CENTER;
            documento.Add(Final);
            //Cierre de  Documento
            documento.Close();

            MailWriter.Close();
            FileWriter.Close();
            pdfFile.Close();
            List<string> Email = new List<string>();
            foreach (var item in Utilitarios.OpUsuarios.ListarUsuarios())
            {
                if (Utilitarios.OpRol.BuscarRol(item.Rol).Descripcion != "Cajero")
                {
                    Email.Add(item.Correo);
                }

            };

            Utilitarios.EnviarEmailAttachment(Email, "Reporte del Cierre " + CierreCaja.Consecutivo, "Adjunto encotrará el reporte de Cierre correspondiente al cierre " + CierreCaja.Consecutivo + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
            Process.Start(@"c:\tempSoda\Reporte.pdf");
            pdfFile.Dispose();
        }



        private void cbbItemTipodeCierre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace LosNaranjitos.User_Interface
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            cbTipoReporte.SelectedIndex = 0;
            dt1.Value = DateTime.Today.AddDays(-20);
            dt2.Value = DateTime.Today.AddDays(0);

        }

        private void btnEjecutarReporteSinParametros_Click(object sender, EventArgs e)
        {
            try
            {
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

                switch (cbTipoReporte.SelectedItem)
                {
                    case "Ventas":

                        //Encabezado

                        var Encabezado = new Paragraph();
                        documento.Add(new Paragraph("Soda Los Naranjitos"));
                        Encabezado.Add(new Phrase("Reporte de Ventas - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
                        Encabezado.Add(new Chunk(Logo, 0, 0));
                        documento.Add(Encabezado);
                        documento.Add(Chunk.NEWLINE);
                        Paragraph lineaSeparadora = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        documento.Add(lineaSeparadora);

                        //Contenido

                        documento.Add(Chunk.NEWLINE);
                        documento.Add(new Paragraph("Reporte de Ventas Totales"));
                        documento.Add(Chunk.NEWLINE);

                        var ListaCierres = Utilitarios.OpCierres.ListarRegistros().Where(x => x.Tipo == "1");

                        PdfPTable table = new PdfPTable(9);
                        table.TotalWidth = 600f;
                        table.LockedWidth = true;
                        float[] widths = new float[] { 20f, 65f, 60f, 30f, 65f, 65f, 65f, 65f, 65f };
                        table.SetWidths(widths);
                        PdfPCell NewCell = new PdfPCell(new Phrase("ID"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Operador"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Fecha"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Cant.Vent."));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Efectivo"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Tarjeta"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Otro"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Cambio"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        NewCell = new PdfPCell(new Phrase("Total"));
                        NewCell.BackgroundColor = BaseColor.GRAY;
                        table.AddCell(NewCell);

                        foreach (var CierreCaja in ListaCierres)
                        {

                            table.AddCell(CierreCaja.Consecutivo.ToString());
                            Usuario Ejecutor = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(CierreCaja.Usuario);

                            table.AddCell(Ejecutor.Nombre + " " + Ejecutor.Apellido1);

                            table.AddCell(CierreCaja.Fecha.ToShortDateString());
                            table.AddCell(CierreCaja.CantidadVentas.ToString());

                            table.AddCell("¢ " + CierreCaja.MontoEfectivo.ToString("N"));
                            table.AddCell("¢ " + CierreCaja.MontoTarjeta.ToString("N"));

                            table.AddCell("¢ " + CierreCaja.MontroOtro.ToString("N"));
                            table.AddCell("¢ " + CierreCaja.MontoCambio.ToString("N"));
                            table.AddCell("¢ " + CierreCaja.MontoTotal.ToString("N"));

                        }

                        documento.Add(table);
                        documento.Add(Chunk.NEWLINE);

                        Paragraph para = new Paragraph("Cantidad de Ventas: " + ListaCierres.Sum(x => x.CantidadVentas) + Chunk.NEWLINE + "Monto de Venta en Efectivo: ¢" + ListaCierres.Sum(x => x.MontoEfectivo).ToString("N") + Chunk.NEWLINE + "Monto de Venta en Tarjeta: ¢" + ListaCierres.Sum(x => x.MontoTarjeta).ToString("N") + Chunk.NEWLINE + "Monto de Venta en Otros: ¢" + ListaCierres.Sum(x => x.MontroOtro).ToString("N") + Chunk.NEWLINE + "Monto de Cambio: ¢" + ListaCierres.Sum(x => x.MontoCambio).ToString("N") + Chunk.NEWLINE + "Monto de Venta en Total: ¢" + ListaCierres.Sum(x => x.MontoTotal).ToString("N"));
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
                        if (chkMail.Checked)
                        {
                            List<string> Email = new List<string>();
                            Email.Add(FrmLogin.UsuarioGlobal.Correo);

                            Utilitarios.EnviarEmailAttachment(Email, "Reporte del Ventas ", "Adjunto encotrará el reporte de Ventas Totales " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
                        }
                        Process.Start(@"c:\tempSoda\Reporte.pdf");
                        pdfFile.Dispose();

                        break;

                    case "Clientes":

                        //Encabezado

                        var EncabezadoCliente = new Paragraph();
                        documento.Add(new Paragraph("Soda Los Naranjitos"));
                        EncabezadoCliente.Add(new Phrase("Reporte de Clientes - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
                        EncabezadoCliente.Add(new Chunk(Logo, 0, 0));
                        documento.Add(EncabezadoCliente);
                        documento.Add(Chunk.NEWLINE);
                        Paragraph lineaSeparadoraC = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        documento.Add(lineaSeparadoraC);

                        //Contenido

                        documento.Add(Chunk.NEWLINE);
                        documento.Add(new Paragraph("Reporte de Clientes"));
                        documento.Add(Chunk.NEWLINE);

                        var ListaClientes = Utilitarios.OpClientes.ListarClientes();

                        PdfPTable tableClientes = new PdfPTable(8);
                        tableClientes.TotalWidth = 600f;
                        tableClientes.LockedWidth = true;
                        float[] widthsClientes = new float[] { 50f, 65f, 60f, 60f, 50f, 65f, 50f, 20f };
                        tableClientes.SetWidths(widthsClientes);
                        PdfPCell NewCellClientes = new PdfPCell(new Phrase("Cédula"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Nombre"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Primer Apellido"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Segundo Apellido"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Télefono"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Dirección"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Ultima Visita"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);

                        NewCellClientes = new PdfPCell(new Phrase("Activo"));
                        NewCellClientes.BackgroundColor = BaseColor.GRAY;
                        tableClientes.AddCell(NewCellClientes);



                        foreach (var CLIENTE in ListaClientes)
                        {

                            tableClientes.AddCell(CLIENTE.IdPersonal);
                            tableClientes.AddCell(CLIENTE.Nombre);

                            tableClientes.AddCell(CLIENTE.Apellido1);
                            tableClientes.AddCell(CLIENTE.Apellido2);

                            tableClientes.AddCell(CLIENTE.Telefono);

                            tableClientes.AddCell(CLIENTE.Direccion);

                            tableClientes.AddCell(CLIENTE.UltimaVisita.ToString());
                            if (CLIENTE.Activo)
                            {
                                tableClientes.AddCell("SÍ");

                            }
                            else
                            {
                                tableClientes.AddCell("NO");

                            }

                        }

                        documento.Add(tableClientes);
                        documento.Add(Chunk.NEWLINE);


                        documento.Add(lineaSeparadoraC);
                        Paragraph FinalC = new Paragraph("Fin del Reporte");
                        FinalC.Alignment = Element.ALIGN_CENTER;
                        documento.Add(FinalC);
                        //Cierre de  Documento
                        documento.Close();

                        MailWriter.Close();
                        FileWriter.Close();
                        pdfFile.Close();

                        if (chkMail.Checked)
                        {
                            List<string> EmailC = new List<string>();
                            EmailC.Add(FrmLogin.UsuarioGlobal.Correo);
                            Utilitarios.EnviarEmailAttachment(EmailC, "Reporte del Ventas ", "Adjunto encotrará el reporte de Ventas Totales " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
                        }

                        Process.Start(@"c:\tempSoda\Reporte.pdf");
                        pdfFile.Dispose();

                        break;
                    case "Combos":
                        //Encabezado

                        var EncabezadoCombos = new Paragraph();
                        documento.Add(new Paragraph("Soda Los Naranjitos"));
                        EncabezadoCombos.Add(new Phrase("Reporte de Combos - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
                        EncabezadoCombos.Add(new Chunk(Logo, 0, 0));
                        documento.Add(EncabezadoCombos);
                        documento.Add(Chunk.NEWLINE);
                        Paragraph lineaSeparadoraCo = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        documento.Add(lineaSeparadoraCo);

                        //Contenido

                        documento.Add(Chunk.NEWLINE);
                        documento.Add(new Paragraph("Reporte de Combos"));
                        documento.Add(Chunk.NEWLINE);

                        var ListaCombos = Utilitarios.OpCombo.ListarCombo();

                        PdfPTable tableCombos = new PdfPTable(5);
                        tableCombos.TotalWidth = 500f;
                        tableCombos.LockedWidth = true;
                        float[] widthsCCombos = new float[] { 30f, 85f, 85f, 40f, 30f };
                        tableCombos.SetWidths(widthsCCombos);

                        PdfPCell NewCellCombos = new PdfPCell(new Phrase("Código"));
                        NewCellCombos.BackgroundColor = BaseColor.GRAY;
                        tableCombos.AddCell(NewCellCombos);

                        NewCellCombos = new PdfPCell(new Phrase("Nombre"));
                        NewCellCombos.BackgroundColor = BaseColor.GRAY;
                        tableCombos.AddCell(NewCellCombos);

                        NewCellCombos = new PdfPCell(new Phrase("Descripción"));
                        NewCellCombos.BackgroundColor = BaseColor.GRAY;
                        tableCombos.AddCell(NewCellCombos);

                        NewCellCombos = new PdfPCell(new Phrase("Precio"));
                        NewCellCombos.BackgroundColor = BaseColor.GRAY;
                        tableCombos.AddCell(NewCellCombos);

                        NewCellCombos = new PdfPCell(new Phrase("Activo"));
                        NewCellCombos.BackgroundColor = BaseColor.GRAY;
                        tableCombos.AddCell(NewCellCombos);

                        foreach (var PromoCombo in ListaCombos)
                        {

                            tableCombos.AddCell(PromoCombo.Codigo);
                            tableCombos.AddCell(PromoCombo.Nombre);

                            tableCombos.AddCell(PromoCombo.Descripcion);
                            tableCombos.AddCell("¢ " + PromoCombo.Precio.ToString("N"));


                            if (PromoCombo.Activo)
                            {
                                tableCombos.AddCell("SÍ");

                            }
                            else
                            {
                                tableCombos.AddCell("NO");

                            }

                        }

                        documento.Add(tableCombos);
                        documento.Add(Chunk.NEWLINE);


                        documento.Add(lineaSeparadoraCo);
                        Paragraph FinalCO = new Paragraph("Fin del Reporte");
                        FinalCO.Alignment = Element.ALIGN_CENTER;
                        documento.Add(FinalCO);
                        //Cierre de  Documento
                        documento.Close();

                        MailWriter.Close();
                        FileWriter.Close();
                        pdfFile.Close();

                        if (chkMail.Checked)
                        {
                            List<string> EmailC = new List<string>();
                            EmailC.Add(FrmLogin.UsuarioGlobal.Correo);
                            Utilitarios.EnviarEmailAttachment(EmailC, "Reporte del Ventas ", "Adjunto encotrará el reporte de Ventas Totales " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
                        }

                        Process.Start(@"c:\tempSoda\Reporte.pdf");
                        pdfFile.Dispose();
                        
                        break;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de  Reportes ");
                this.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

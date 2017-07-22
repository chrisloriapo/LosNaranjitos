using iTextSharp.text;
using iTextSharp.text.pdf;
using LosNaranjitos.DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            EjecutarReporte();
        }


        private void EjecutarReporte()
        {

            try
            {
                if (Utilitarios.FindAndKillProcess("AcroRd32"))
                {
                    System.Threading.Thread.Sleep(2500);
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


                        List<Cierre> ListaCierres = new List<Cierre>();
                        if (tbcReporteria.SelectedIndex == 1)
                        {
                            if (dt1.Value > dt2.Value)
                            {

                                MessageBox.Show("La fecha Posterior No puede ser mayor a la fecha incial del reporte", "Seleccione fechas válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                            ListaCierres = Utilitarios.OpCierres.ListarRegistros().Where(x => x.Tipo == "1" && x.Fecha >= Utilitarios.GetDateZeroTime(dt1.Value) && x.Fecha <= Utilitarios.GetDateEndTime(dt2.Value)).ToList();
                            documento.Add(new Paragraph("Reporte de Ventas desde el " + dt1.Value.ToShortDateString() + " al " + dt2.Value.ToShortDateString()));
                            documento.Add(Chunk.NEWLINE);
                        }
                        else
                        {
                            ListaCierres = Utilitarios.OpCierres.ListarRegistros().Where(x => x.Tipo == "1").ToList();
                            documento.Add(new Paragraph("Reporte de Ventas Totales"));
                            documento.Add(Chunk.NEWLINE);
                        }

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

                    case "Errores":
                        //Encabezado

                        var EncabezadoErrores = new Paragraph();
                        documento.Add(new Paragraph("Soda Los Naranjitos"));
                        EncabezadoErrores.Add(new Phrase("Reporte de Errores - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
                        EncabezadoErrores.Add(new Chunk(Logo, 0, 0));
                        documento.Add(EncabezadoErrores);
                        documento.Add(Chunk.NEWLINE);
                        Paragraph lineaSeparadoraError = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        documento.Add(lineaSeparadoraError);

                        //Contenido

                        documento.Add(Chunk.NEWLINE);
                        documento.Add(new Paragraph("Reporte de Errores"));
                        documento.Add(Chunk.NEWLINE);

                        var ListaErrores = Utilitarios.OpError.ListarErrores().OrderByDescending(x => x.Hora);

                        PdfPTable tableError = new PdfPTable(4);
                        tableError.TotalWidth = 500f;
                        tableError.LockedWidth = true;
                        float[] widthsError = new float[] { 30f, 85f, 120f, 40f };
                        tableError.SetWidths(widthsError);

                        PdfPCell NewCellError = new PdfPCell(new Phrase("ID"));
                        NewCellError.BackgroundColor = BaseColor.GRAY;
                        tableError.AddCell(NewCellError);

                        NewCellError = new PdfPCell(new Phrase("Tipo de Error"));
                        NewCellError.BackgroundColor = BaseColor.GRAY;
                        tableError.AddCell(NewCellError);

                        NewCellError = new PdfPCell(new Phrase("Descripcion del Error"));
                        NewCellError.BackgroundColor = BaseColor.GRAY;
                        tableError.AddCell(NewCellError);

                        NewCellError = new PdfPCell(new Phrase("Fecha"));
                        NewCellError.BackgroundColor = BaseColor.GRAY;
                        tableError.AddCell(NewCellError);

                        foreach (var ERRROR in ListaErrores)
                        {
                            tableError.AddCell(ERRROR.IdError.ToString());
                            tableError.AddCell(ERRROR.Tipo);
                            tableError.AddCell(ERRROR.Descripcion);
                            tableError.AddCell(ERRROR.Hora.ToString());

                        }

                        documento.Add(tableError);
                        documento.Add(Chunk.NEWLINE);


                        documento.Add(lineaSeparadoraError);
                        Paragraph FinalError = new Paragraph("Fin del Reporte");
                        FinalError.Alignment = Element.ALIGN_CENTER;
                        documento.Add(FinalError);

                        //Cierre de  Documento
                        documento.Close();
                        MailWriter.Close();
                        FileWriter.Close();
                        pdfFile.Close();

                        if (chkMail.Checked)
                        {
                            List<string> EmailError = new List<string>();
                            EmailError.Add(FrmLogin.UsuarioGlobal.Correo);
                            Utilitarios.EnviarEmailAttachment(EmailError, "Reporte del Errores ", "Adjunto encotrará el reporte de ERRORES Totales " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
                        }

                        Process.Start(@"c:\tempSoda\Reporte.pdf");
                        pdfFile.Dispose();

                        break;

                    case "Insumos":
                        //Encabezado

                        var EncabezadoInsumos = new Paragraph();
                        documento.Add(new Paragraph("Soda Los Naranjitos"));
                        EncabezadoInsumos.Add(new Phrase("Reporte de Insumos - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
                        EncabezadoInsumos.Add(new Chunk(Logo, 0, 0));
                        documento.Add(EncabezadoInsumos);
                        documento.Add(Chunk.NEWLINE);
                        Paragraph lineaSeparadoraInsumos = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        documento.Add(lineaSeparadoraInsumos);

                        //Contenido

                        documento.Add(Chunk.NEWLINE);
                        documento.Add(new Paragraph("Reporte de Errores"));
                        documento.Add(Chunk.NEWLINE);

                        var ListaInsumos = Utilitarios.OpInsumos.ListarInsumos().Join(
                   Utilitarios.OpProveedor.ListarProveedores(),
               a => a.Proveedor,
               b => b.IdProveedor,
               (a, b) => new { a.IdInsumo, a.Nombre, a.IdMedida, a.PrecioCompra, a.RendimientoUM, a.RendimientoPorcion, a.PrecioMermado, a.CantInventario, b.NombreProveedor, a.Activo });

                        PdfPTable tableInsumos = new PdfPTable(9);
                        tableInsumos.TotalWidth = 600f;
                        tableInsumos.LockedWidth = true;
                        float[] widthsInsumos = new float[] { 40f, 70f, 60f, 50f, 50f, 50f, 50f, 60f, 40f };
                        tableInsumos.SetWidths(widthsInsumos);

                        PdfPCell NewCellInsumo = new PdfPCell(new Phrase("Código"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("Descripción"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("R. UM**")); //RendimientoUM * IDmedida
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("% R. Porción**"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("Precio de Compra*"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("Precio Mermado*"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("Cantidad"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("Proveedor"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        NewCellInsumo = new PdfPCell(new Phrase("Activo"));
                        NewCellInsumo.BackgroundColor = BaseColor.GRAY;
                        tableInsumos.AddCell(NewCellInsumo);

                        foreach (var Ins in ListaInsumos)
                        {
                            tableInsumos.AddCell(Ins.IdInsumo);
                            tableInsumos.AddCell(Ins.Nombre);
                            tableInsumos.AddCell(Ins.RendimientoPorcion + " x " + Ins.IdMedida);
                            tableInsumos.AddCell(Ins.RendimientoPorcion.ToString("P"));
                            tableInsumos.AddCell("¢ " + Ins.PrecioCompra.ToString("N"));
                            tableInsumos.AddCell("¢ " + Ins.PrecioMermado.ToString("N"));
                            tableInsumos.AddCell(Ins.CantInventario.ToString());
                            tableInsumos.AddCell(Ins.NombreProveedor);

                            if (Ins.Activo)
                            {
                                tableInsumos.AddCell("SÍ");
                            }
                            else
                            {
                                tableInsumos.AddCell("NO");

                            }


                        }

                        documento.Add(tableInsumos);
                        documento.Add(Chunk.NEWLINE);


                        documento.Add(lineaSeparadoraInsumos);
                        Paragraph FinalInsumo = new Paragraph("Fin del Reporte");
                        FinalInsumo.Alignment = Element.ALIGN_CENTER;
                        documento.Add(FinalInsumo);

                        //Cierre de  Documento
                        documento.Close();
                        MailWriter.Close();
                        FileWriter.Close();
                        pdfFile.Close();

                        if (chkMail.Checked)
                        {
                            List<string> EmailError = new List<string>();
                            EmailError.Add(FrmLogin.UsuarioGlobal.Correo);
                            Utilitarios.EnviarEmailAttachment(EmailError, "Reporte del Insumos ", "Adjunto encotrará el reporte de Isumos Totales " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
                        }

                        Process.Start(@"c:\tempSoda\Reporte.pdf");
                        pdfFile.Dispose();

                        break;

                    case "Compras":
                        //Encabezado

                        var EncabezadoCompras = new Paragraph();
                        documento.Add(new Paragraph("Soda Los Naranjitos"));
                        EncabezadoCompras.Add(new Phrase("Reporte de Compras - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
                        EncabezadoCompras.Add(new Chunk(Logo, 0, 0));
                        documento.Add(EncabezadoCompras);
                        documento.Add(Chunk.NEWLINE);
                        Paragraph lineaSeparadoraCompras = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        documento.Add(lineaSeparadoraCompras);

                        //Contenido

                        documento.Add(Chunk.NEWLINE);
                        documento.Add(new Paragraph("Reporte de Compras"));
                        documento.Add(Chunk.NEWLINE);
                        var ListaCompras = Utilitarios.OpFacturaCompra.ListarFacturas().Join(Utilitarios.OpProveedor.ListarProveedores(),
a => a.IdProveedor, b => b.IdProveedor, (a, b) => new { a.IdFactura, b.NombreProveedor, a.Monto, a.Observaciones, a.Fecha, a.Operador });
                        if (tbcReporteria.SelectedIndex == 1)
                        {
                            if (dt1.Value > dt2.Value)
                            {
                                MessageBox.Show("La fecha Posterior No puede ser mayor a la fecha incial del reporte", "Seleccione fechas válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ListaCompras = ListaCompras.Where(x => x.Fecha >= Utilitarios.GetDateZeroTime(dt1.Value) && x.Fecha <= Utilitarios.GetDateEndTime(dt2.Value));

                            documento.Add(new Paragraph("Reporte de Compras desde el " + dt1.Value.ToShortDateString() + " al " + dt2.Value.ToShortDateString()));
                            documento.Add(Chunk.NEWLINE);
                        }
                        else
                        {

                            documento.Add(new Paragraph("Reporte de Compras Totales"));
                            documento.Add(Chunk.NEWLINE);
                        }




                        PdfPTable TableCompras = new PdfPTable(6);
                        TableCompras.TotalWidth = 600f;
                        TableCompras.LockedWidth = true;
                        float[] widthsCompras = new float[] { 40f, 70f, 60f, 80f, 50f, 50f };
                        TableCompras.SetWidths(widthsCompras);

                        PdfPCell NewCellCompras = new PdfPCell(new Phrase("N° de Factura"));
                        NewCellCompras.BackgroundColor = BaseColor.GRAY;
                        TableCompras.AddCell(NewCellCompras);

                        NewCellCompras = new PdfPCell(new Phrase("Proveedor"));
                        NewCellCompras.BackgroundColor = BaseColor.GRAY;
                        TableCompras.AddCell(NewCellCompras);

                        NewCellCompras = new PdfPCell(new Phrase("Monto"));
                        NewCellCompras.BackgroundColor = BaseColor.GRAY;
                        TableCompras.AddCell(NewCellCompras);

                        NewCellCompras = new PdfPCell(new Phrase("Observaciones"));
                        NewCellCompras.BackgroundColor = BaseColor.GRAY;
                        TableCompras.AddCell(NewCellCompras);

                        NewCellCompras = new PdfPCell(new Phrase("Fecha"));
                        NewCellCompras.BackgroundColor = BaseColor.GRAY;
                        TableCompras.AddCell(NewCellCompras);

                        NewCellCompras = new PdfPCell(new Phrase("Oerador"));
                        NewCellCompras.BackgroundColor = BaseColor.GRAY;
                        TableCompras.AddCell(NewCellCompras);


                        foreach (var Compra in ListaCompras)
                        {
                            TableCompras.AddCell(Compra.IdFactura);
                            TableCompras.AddCell(Compra.NombreProveedor);
                            TableCompras.AddCell("¢ " + Compra.Monto.ToString("N"));
                            TableCompras.AddCell(Compra.Observaciones);
                            TableCompras.AddCell(Compra.Fecha.ToShortDateString());

                            var Operador = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(Compra.Operador);
                            TableCompras.AddCell(Operador.Nombre + " " + Operador.Apellido1);

                        }

                        documento.Add(TableCompras);
                        documento.Add(Chunk.NEWLINE);


                        documento.Add(lineaSeparadoraCompras);
                        Paragraph FinalCompras = new Paragraph("Fin del Reporte");
                        FinalCompras.Alignment = Element.ALIGN_CENTER;
                        FinalCompras.Add(FinalCompras);

                        //Cierre de  Documento
                        documento.Close();
                        MailWriter.Close();
                        FileWriter.Close();
                        pdfFile.Close();

                        if (chkMail.Checked)
                        {
                            List<string> EmailError = new List<string>();
                            EmailError.Add(FrmLogin.UsuarioGlobal.Correo);
                            Utilitarios.EnviarEmailAttachment(EmailError, "Reporte del Compras ", "Adjunto encotrará el reporte de Compras  " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
                        }

                        Process.Start(@"c:\tempSoda\Reporte.pdf");
                        pdfFile.Dispose();

                        break;

//                    case "Producto Por Insumo":
//                        //Encabezado

//                        var EncabezadoProductos = new Paragraph();
//                        documento.Add(new Paragraph("Soda Los Naranjitos"));
//                        EncabezadoProductos.Add(new Phrase("Reporte de Productos - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
//                        EncabezadoProductos.Add(new Chunk(Logo, 0, 0));
//                        documento.Add(EncabezadoProductos);
//                        documento.Add(Chunk.NEWLINE);
//                        Paragraph lineaSeparadoraProductos = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
//                        documento.Add(lineaSeparadoraProductos);

//                        //Contenido

//                        documento.Add(Chunk.NEWLINE);
//                        documento.Add(new Paragraph("Reporte de Productos"));
//                        documento.Add(Chunk.NEWLINE);
//                        var ListaProductos = Utilitarios.OpProducto.ListarProductos().Join(Utilitarios.OpCategorias.ListarCategorias(),
//a => a.Categoria, b => b.IdTipo, (a, b) => new { a.Codigo, a.Nombre, a.Descripcion, b.DescripcionCategoria, a.Precio, a.Activo });
//                        if (tbcReporteria.SelectedIndex == 1)
//                        {
//                            ListaProductos = ListaProductos.Where(x => x.Codigo == Utilitarios.OpProducto.BuscarProductoPorNombre(cmbItemsParametros.SelectedItem.ToString()).Codigo);

//                            documento.Add(new Paragraph("Reporte de Producto " + Utilitarios.OpProducto.BuscarProductoPorNombre(cmbItemsParametros.SelectedItem.ToString()).Nombre));
//                            documento.Add(Chunk.NEWLINE);
//                        }
//                        else
//                        {

//                            documento.Add(new Paragraph("Reporte Total de Insomos por Producto"));
//                            documento.Add(Chunk.NEWLINE);
//                        }
//                        var ListaResultado = Utilitarios.OpProductoInsumo.ListarProductoInsumo().Join(Utilitarios.OpInsumos.ListarInsumos(),
//a => a.IdInsumo, b => b.IdInsumo, (a, b) => new { a.IdInsumo, b.Nombre, a.CantidadRequerida, b.IdMedida, });

//                        PdfPTable TableProductos = new PdfPTable(6);
//                        TableProductos.TotalWidth = 600f;
//                        TableProductos.LockedWidth = true;
//                        float[] widthsProductos = new float[] { 40f, 70f, 60f, 80f, 50f, 50f };
//                        TableProductos.SetWidths(widthsProductos);

//                        PdfPCell NewCellProductos = new PdfPCell(new Phrase("N° de Factura"));
//                        NewCellProductos.BackgroundColor = BaseColor.GRAY;
//                        TableProductos.AddCell(NewCellProductos);

//                        NewCellProductos = new PdfPCell(new Phrase("Proveedor"));
//                        NewCellProductos.BackgroundColor = BaseColor.GRAY;
//                        TableProductos.AddCell(NewCellProductos);



//                        foreach (var Compra in ListaCompras)
//                        {
//                            TableCompras.AddCell(Compra.IdFactura);
//                            TableCompras.AddCell(Compra.NombreProveedor);
//                            TableCompras.AddCell("¢ " + Compra.Monto.ToString("N"));
//                            TableCompras.AddCell(Compra.Observaciones);
//                            TableCompras.AddCell(Compra.Fecha.ToShortDateString());

//                            var Operador = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(Compra.Operador);
//                            TableCompras.AddCell(Operador.Nombre + " " + Operador.Apellido1);

//                        }

//                        documento.Add(TableCompras);
//                        documento.Add(Chunk.NEWLINE);


//                        documento.Add(lineaSeparadoraCompras);
//                        Paragraph FinalCompras = new Paragraph("Fin del Reporte");
//                        FinalCompras.Alignment = Element.ALIGN_CENTER;
//                        FinalCompras.Add(FinalCompras);

//                        //Cierre de  Documento
//                        documento.Close();
//                        MailWriter.Close();
//                        FileWriter.Close();
//                        pdfFile.Close();

//                        if (chkMail.Checked)
//                        {
//                            List<string> EmailError = new List<string>();
//                            EmailError.Add(FrmLogin.UsuarioGlobal.Correo);
//                            Utilitarios.EnviarEmailAttachment(EmailError, "Reporte del Compras ", "Adjunto encotrará el reporte de Compras  " + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
//                        }

//                        Process.Start(@"c:\tempSoda\Reporte.pdf");
//                        pdfFile.Dispose();

//                        break;
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

        private void rbtVentasporFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtVentasporFecha.Checked)
            {
                cbTipoReporte.SelectedItem = "Ventas";
                dt1.Enabled = true;
                dt2.Enabled = true;
                cmbItemsParametros.Enabled = false;
            }
        }

        private void rbtComprasPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtComprasPorFecha.Checked)
            {
                cbTipoReporte.SelectedItem = "Compras";
                dt1.Enabled = true;
                dt2.Enabled = true;
                cmbItemsParametros.Enabled = false;
            }
        }

        private void rbtVentaProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtVentaProducto.Checked)
            {
                cbTipoReporte.SelectedItem = "Ventas Por Producto";
                dt1.Enabled = false;
                dt2.Enabled = false;
                try
                {
                    var lista = Utilitarios.OpProducto.ListarProductos().Select(x => x.Nombre).ToList();

                    cmbItemsParametros.Items.Clear();
                    foreach (var item in lista)
                    {
                        cmbItemsParametros.Items.Add(item);
                    }
                    cmbItemsParametros.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmbItemsParametros.Enabled = true;

            }
        }

        private void rbtVentasCombo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtVentasCombo.Checked)
            {
                cbTipoReporte.SelectedItem = "Ventas Por Combo";
                dt1.Enabled = false;
                dt2.Enabled = false;
                try
                {
                    var lista = Utilitarios.OpCombo.ListarCombo().Select(x => x.Nombre).ToList();

                    cmbItemsParametros.Items.Clear();
                    foreach (var item in lista)
                    {
                        cmbItemsParametros.Items.Add(item);
                    }
                    cmbItemsParametros.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmbItemsParametros.Enabled = true;

            }
        }

        private void btnEjecutarConParametros_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

        private void tbcReporteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

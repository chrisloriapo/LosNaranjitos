using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LosNaranjitos.Tools;
using LosNaranjitos.DATOS;
using System.Diagnostics;

namespace LosNaranjitos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            //var ListaLocal = Utilitarios.OpPedidos.ListarPedido().Select(x => x.Fecha);

            //List<DateTime> Listasss = new List<DateTime>();

            //foreach (var item in ListaLocal)
            //{
            //    if (!Listasss.Contains(item.Date))
            //    {
            //        Listasss.Add(item.Date);
            //    }
            //}

            // comboBox1.DataSource = Listasss.ToList();

            //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    comboBox1.Items.Add(printer);
            //}



            // TODO: esta línea de código carga datos en la tabla 'OrangeDB1DataSet.Cierre' Puede moverla o quitarla según sea necesario.
            //this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);
            //try
            //{
            //    foreach (DataRow dr in OrangeDB1DataSet.Cierre.Rows)
            //    {
            //        if (dr["Consecutivo"].ToString() != "7")
            //        {
            //            dr.Delete();
            //        }
            //   //    }
            ////   this.OrangeDB1DataSet.Cierre.AcceptChanges();

            //   foreach (var item in (this.DSCierre.LastCierre))
            //   {
            //       item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
            //   }
            //   this.rpvBitacora.RefreshReport();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}



            //    this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);

            //    var xlist = this.OrangeDB1DataSet.Cierre;


            //    for (int i = 0; i < xlist.Count; i++)
            //    {
            //        if (item.Consecutivo != Utilitarios.Encriptar("CLS-01", Utilitarios.Llave))
            //        {
            //            OrangeDB1DataSet.Cierre.RemoveCierreRow(item);
            //            this.OrangeDB1DataSet.Cierre.AcceptChanges();
            //        }
            //        else
            //        {
            //            item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
            //            item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
            //            item.Tipo = Utilitarios.Decriptar(item.Tipo, Utilitarios.Llave);
            //            //item.Caja = Utilitarios.Decriptar(item.Caja, Utilitarios.Llave);
            //        }

            //    }


            //    foreach (var item in (xlist))
            //    {
            //              }
            //    OrangeDB1DataSet.Cierre.Where(x => x.Consecutivo == "CLS-01");



            //    //// TODO: esta línea de código carga datos en la tabla 'OrangeDB1DataSet.Bitacora' Puede moverla o quitarla según sea necesario.
            //    //this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);
            //    //foreach (var item in (this.OrangeDB1DataSet.Cierre))
            //    //{
            //    //    if (item.Consecutivo != Utilitarios.Encriptar("Prueba", Utilitarios.Llave))
            //    //    {
            //    //        item.Delete();
            //    //        this.OrangeDB1DataSet.Cierre.AcceptChanges();
            //    //    }
            //    //    item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
            //}
            //OrangeDB1DataSet.Cierre.OrderByDescending(x => x.Consecutivo);

            //this.rpvBitacora.RefreshReport();
        }

        private void chkLechuga_CheckedChanged(object sender, EventArgs e)
        {
            List<string> ListaLocalComentarios = new List<string>();
            if (chkLechuga.Checked)
            {
                if (txtObservacionesPP.Text.Contains("SIN-LECHUGA"))
                {
                    txtObservacionesPP.Text.Replace("SIN-LECHUGA", "");
                }
            }
            else
            {
                txtObservacionesPP.Text = txtObservacionesPP.Text + " SIN-LECHUGA ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Utilitarios.FindAndKillProcess("AcroRd32"))
            {
                System.Threading.Thread.Sleep(2000);
            }
            
            if (dt1.Value >= dt2.Value)
            {
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            Encabezado.Add(new Phrase("Reporte de Ventas - CONTENIDO CONFIDENCIAL", FontFactory.GetFont("Times New Roman", 18, BaseColor.BLUE)));
            Encabezado.Add(new Chunk(Logo, 0, 0));
            documento.Add(Encabezado);
            documento.Add(Chunk.NEWLINE);
            Paragraph lineaSeparadora = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            documento.Add(lineaSeparadora);

            //Contenido

            documento.Add(Chunk.NEWLINE);
            documento.Add(new Paragraph("Reporte de Ventas desde el: " + Utilitarios.GetDateZeroTime(dt1.Value).ToShortDateString() + " hasta  el " + Utilitarios.GetDateEndTime(dt2.Value).ToShortDateString()));
            documento.Add(Chunk.NEWLINE);

            var ListaCierres = Utilitarios.OpCierres.ListarRegistros().Where(x => x.Fecha >= Utilitarios.GetDateZeroTime(dt1.Value) && x.Fecha <= Utilitarios.GetDateEndTime(dt2.Value) && x.Tipo == "1");


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

                //documento.Add(Chunk.NEWLINE);
                //Usuario Ejecutor = Utilitarios.OpUsuarios.BuscarUsuarioXUsername(CierreCaja.Usuario);
                //documento.Add(new Paragraph("Cierre número: " + CierreCaja.Consecutivo + Chunk.NEWLINE + "Ejecutado por: " + Ejecutor.Nombre + " " + Ejecutor.Apellido1 + " " + Ejecutor.Apellido2 + " a las " + CierreCaja.Fecha));

                //Paragraph para = new Paragraph("Cantidad de Ventas: " + CierreCaja.CantidadVentas + Chunk.NEWLINE + "Monto de Venta en Efectivo: ¢" + CierreCaja.MontoEfectivo.ToString("N") + Chunk.NEWLINE + "Monto de Venta en Tarjeta: ¢" + CierreCaja.MontoTarjeta.ToString("N") + Chunk.NEWLINE + "Monto de Venta en Otros: ¢" + CierreCaja.MontroOtro.ToString("N") + Chunk.NEWLINE + "Monto de Cambio: ¢" + CierreCaja.MontoCambio.ToString("N") + Chunk.NEWLINE + "Monto de Venta en Total: ¢" + CierreCaja.MontoTotal.ToString("N"));
                //documento.Add(para);
            }

            documento.Add(table);
            documento.Add(Chunk.NEWLINE);

            Paragraph para = new Paragraph("Cantidad de Ventas: " + ListaCierres.Sum(x=>x.CantidadVentas) + Chunk.NEWLINE + "Monto de Venta en Efectivo: ¢" + ListaCierres.Sum(x => x.MontoEfectivo).ToString("N") + Chunk.NEWLINE + "Monto de Venta en Tarjeta: ¢" + ListaCierres.Sum(x => x.MontoTarjeta).ToString("N") + Chunk.NEWLINE + "Monto de Venta en Otros: ¢" + ListaCierres.Sum(x => x.MontroOtro).ToString("N") + Chunk.NEWLINE + "Monto de Cambio: ¢" + ListaCierres.Sum(x => x.MontoCambio).ToString("N") + Chunk.NEWLINE + "Monto de Venta en Total: ¢" + ListaCierres.Sum(x => x.MontoTotal).ToString("N"));
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

            // Utilitarios.EnviarEmailAttachment(Email, "Reporte del Ventas ", "Adjunto encotrará el reporte de Cierre //correspondiente al cierre "  + " ejecutado el " + DateTime.Now.ToShortDateString(), memStream);
            Process.Start(@"c:\tempSoda\Reporte.pdf");
            pdfFile.Dispose();
        }


        private void button2_Click(object sender, EventArgs e)
        {




            Utilitarios.TicketeGeneral("1", "Test", "Cliente General", Utilitarios.OpDetallePedido.ListarDetallesPedido().Where(x => x.IdOrden == 6).ToList(), Utilitarios.OpPedidos.BuscarPedido(6));

            ////Creamos una instancia d ela clase CrearTicket
            //Ticket ticket = new Ticket();
            ////Ya podemos usar todos sus metodos
            //ticket.AbreCajon();//Para abrir el cajon de dinero.

            ////De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            ////Datos de la cabecera del Ticket.
            //ticket.TextoCentro("SODA LOS NARANJITOS");
            //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            //ticket.TextoIzquierda("DIREC: 25 SUR Y 75 OESTE DE LA MEGASUPER TEJAR");
            //ticket.TextoIzquierda("TELEF: 25910412");
            //ticket.TextoIzquierda("C.J.: 302860224");
            //ticket.TextoIzquierda("EMAIL: orangesrestaurants@gmail.com");//Es el mio por si me quieren contactar ...
            //ticket.TextoIzquierda("");
            //ticket.TextoExtremos("Caja # 1", "Ticket # 0000");
            //ticket.lineasAsteriscos();

            ////Sub cabecera.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ATENDIÓ: " /*+ FrmLogin.UsuarioGlobal.Nombre + " " + FrmLogin.UsuarioGlobal.Apellido1*/);
            //ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
            //ticket.TextoIzquierda("");
            //ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            //ticket.lineasAsteriscos();

            ////Articulos a vender.
            //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            //ticket.lineasAsteriscos();
            ////Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            ////foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
            ////{
            ////ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
            ////decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            ////}
            ////ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ////ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ////ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
            //foreach (var item in Utilitarios.OpProducto.ListarProductos())
            //{
            //    ticket.AgregaArticulo(item.Nombre, 1, item.Precio, 0);
            //}
            //ticket.lineasIgual();

            ////Resumen de la venta. Sólo son ejemplos
            //ticket.AgregarTotales("         SUBTOTAL......C", Utilitarios.OpProducto.ListarProductos().Sum(x => x.Precio));
            //ticket.AgregarTotales("         IVA...........C", Utilitarios.OpProducto.ListarProductos().Sum(x => x.Precio));//La M indica que es un decimal en C#
            //ticket.AgregarTotales("         TOTAL.........C", Utilitarios.OpProducto.ListarProductos().Sum(x => x.Precio));
            //ticket.TextoIzquierda("");
            //ticket.AgregarTotales("         EFECTIVO......C", Utilitarios.OpProducto.ListarProductos().Sum(x => x.Precio));
            //ticket.AgregarTotales("         CAMBIO........C", Utilitarios.OpProducto.ListarProductos().Sum(x => x.Precio));

            ////Texto final del Ticket.
            //ticket.TextoIzquierda("IMPUESTO DE VENTA INCLUIDO");
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + Utilitarios.OpProducto.ListarProductos().Count());
            //ticket.TextoIzquierda("");
            //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("");
            //ticket.CortaTicket();
            //ticket.ImprimirTicket("POS-80");//Nombre de la impresora ticketera

        }
    }
}
//            this.BitacoraTableAdapter.Fill(this.OrangeDB1DataSet.Bitacora);
//            foreach (var item in (this.OrangeDB1DataSet.Bitacora))
//            {
//    item.IdBitacora = Utilitarios.Decriptar(item.IdBitacora, Utilitarios.Llave);
//    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
//    item.Accion = Utilitarios.Decriptar(item.Accion, Utilitarios.Llave);
//}
//OrangeDB1DataSet.Bitacora.OrderByDescending(x => x.IdBitacora);
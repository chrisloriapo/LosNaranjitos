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
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(printer);
            }



            // TODO: esta línea de código carga datos en la tabla 'OrangeDB1DataSet.Cierre' Puede moverla o quitarla según sea necesario.
            this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);
            try
            {
                foreach (DataRow dr in OrangeDB1DataSet.Cierre.Rows)
                {
                    if (dr["Consecutivo"].ToString() != "4")
                    {
                        dr.Delete();
                    }
                }
                this.OrangeDB1DataSet.Cierre.AcceptChanges();

                foreach (var item in (this.OrangeDB1DataSet.Cierre))
                {
                    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
                }
                this.rpvBitacora.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }



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

            this.rpvBitacora.RefreshReport();
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
            Document dox = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(dox, new FileStream("Test.pdf", FileMode.Create));
            dox.Open();
            foreach (var item in Utilitarios.OpBitacora.ListarRegistros())
            {
                Paragraph para = new Paragraph(item.Accion + "\n");
                dox.Add(para);

            }
            dox.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
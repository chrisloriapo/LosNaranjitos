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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


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
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
            // TODO: esta línea de código carga datos en la tabla 'OrangeDB1DataSet.Bitacora' Puede moverla o quitarla según sea necesario.
            this.CierreTableAdapter.Fill(this.OrangeDB1DataSet.Cierre);
            foreach (var item in (this.OrangeDB1DataSet.Cierre))
            {
                if (item.Consecutivo != Utilitarios.Encriptar("Prueba", Utilitarios.Llave))
                {
                    item.Delete();
                    this.OrangeDB1DataSet.Cierre.AcceptChanges();
                }
                item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
            }
            OrangeDB1DataSet.Cierre.OrderByDescending(x => x.Consecutivo);

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
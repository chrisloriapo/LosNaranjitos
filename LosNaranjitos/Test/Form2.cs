using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LosNaranjitos.Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {



            dtpkDesdeReporte.Value = DateTime.Today;
            dtpkHastaReporte.Value = DateTime.Today.AddDays(7);
            DateTime D1, D2;
            D1 = Utilitarios.GetDateZeroTime(dtpkDesdeReporte.Value);
            D2 = Utilitarios.GetDateEndTime(dtpkHastaReporte.Value);

            this.pedidoTableAdapter1.Fill(this.OrangeDB1DataSet.Pedido);


            foreach (DataRow dr in OrangeDB1DataSet.Pedido.Rows)
            {
                if (Convert.ToDateTime(dr["Fecha"]) >= D1 && Convert.ToDateTime(dr["Fecha"]) <= D2)
                {
                    dr.Delete();
                }
            }
            this.OrangeDB1DataSet.Pedido.AcceptChanges();
            
            foreach (var item in (this.OrangeDB1DataSet.Pedido))
            {
                DATOS.Cliente ClientTemporal = new DATOS.Cliente();

                ClientTemporal = Utilitarios.OpClientes.BuscarCliente(item.IdCliente);

                item.IdCliente = ClientTemporal.Nombre + " " + ClientTemporal.Apellido1 + " " + ClientTemporal.Apellido2;
                
                item.Operador = Utilitarios.Decriptar(item.Operador, Utilitarios.Llave);
            }

            ReportParameter[] paramss = new ReportParameter[2];
            paramss[0] = new ReportParameter("Fechas", D1.ToShortDateString(), false);
            paramss[1] = new ReportParameter("Fechas2", D2.ToShortDateString(), false); 
        this.reportViewer1.LocalReport.SetParameters(paramss);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime D1, D2;
            D1 = Utilitarios.GetDateZeroTime(dtpkDesdeReporte.Value);
            D2 = Utilitarios.GetDateEndTime(dtpkHastaReporte.Value);

            this.pedidoTableAdapter1.Fill(this.OrangeDB1DataSet.Pedido);


            foreach (DataRow dr in OrangeDB1DataSet.Pedido.Rows)
            {
                if (Convert.ToDateTime(dr["Fecha"]) <= D1 && Convert.ToDateTime(dr["Fecha"]) >= D2)
                {
                    dr.Delete();
                }
            }
            this.OrangeDB1DataSet.Pedido.AcceptChanges();

            foreach (var item in (this.OrangeDB1DataSet.Pedido))
            {
                DATOS.Cliente ClientTemporal = new DATOS.Cliente();

                ClientTemporal = Utilitarios.OpClientes.BuscarCliente(item.IdCliente);

                item.IdCliente = ClientTemporal.Nombre + " " + ClientTemporal.Apellido1 + " " + ClientTemporal.Apellido2;

                item.Operador = Utilitarios.Decriptar(item.Operador, Utilitarios.Llave);
            }

            ReportParameter[] paramss = new ReportParameter[2];
            paramss[0] = new ReportParameter("Fechas", D1.ToShortDateString(), false);
            paramss[1] = new ReportParameter("Fechas2", D2.ToShortDateString(), false);
            this.reportViewer1.LocalReport.SetParameters(paramss);

            this.reportViewer1.RefreshReport();
        }
    }
}

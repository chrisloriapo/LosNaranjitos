using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosNaranjitos.User_Interface
{
    public partial class FrmReporteVentasRango : Form
    {
        public FrmReporteVentasRango()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            DateTime D1, D2;
            D1 = Utilitarios.GetDateZeroTime(dtpkDesdeReporte.Value);
            D2 = Utilitarios.GetDateEndTime(dtpkHastaReporte.Value);

            this.pedidoTableAdapter.Fill(this.dataSet11.Pedido);


            foreach (DataRow dr in dataSet11.Pedido.Rows)
            {
                if (Convert.ToDateTime(dr["Fecha"]) <= D1 && Convert.ToDateTime(dr["Fecha"]) >= D2)
                {
                    dr.Delete();
                }
            }
            this.dataSet11.Pedido.AcceptChanges();

            foreach (var item in (this.dataSet11.Pedido))
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

        private void FrmReporteVentasRango_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet11.Pedido' Puede moverla o quitarla según sea necesario.
            this.pedidoTableAdapter.Fill(this.dataSet11.Pedido);

        }
    }
}

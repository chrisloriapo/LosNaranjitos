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

namespace LosNaranjitos
{
    public partial class FrmReporteVentas : Form
    {
        public FrmReporteVentas()
        {
            InitializeComponent();
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {
            dtpkDesdeReporte.Value = DateTime.Today;
            dtpkHastaReporte.Value = DateTime.Today.AddDays(7);
          
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime D1, D2;
                D1 = Utilitarios.GetDateZeroTime(dtpkDesdeReporte.Value);
                D2 = Utilitarios.GetDateEndTime(dtpkHastaReporte.Value);


                if (D1 > D2)
                {
                    MessageBox.Show("La fecha posterior debe ser mayor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //this.pedidoTableAdapter1.Fill(this.orangeDB1DataSet1.Pedido);


                //foreach (DataRow dr in orangeDB1DataSet1.Pedido.Rows)
                //{
                //    if (Convert.ToDateTime(dr["Fecha"]) >= D1 && Convert.ToDateTime(dr["Fecha"]) <= D2)
                //    {
                //        dr.Delete();
                //    }
                //}
                //this.orangeDB1DataSet1.Pedido.AcceptChanges();

                //foreach (var item in (this.orangeDB1DataSet1.Pedido))
                //{
                //    DATOS.Cliente ClientTemporal = new DATOS.Cliente();

                //    ClientTemporal = Utilitarios.OpClientes.BuscarCliente(item.IdCliente);

                //    item.IdCliente = ClientTemporal.Nombre + " " + ClientTemporal.Apellido1 + " " + ClientTemporal.Apellido2;

                //    item.Operador = Utilitarios.Decriptar(item.Operador, Utilitarios.Llave);
                //}

                //ReportParameter[] paramss = new ReportParameter[2];
                //paramss[0] = new ReportParameter("Fechas", D1.ToShortDateString(), false);
                //paramss[1] = new ReportParameter("Fechas2", D2.ToShortDateString(), false);
                //this.rptVReporteLocal.LocalReport.SetParameters(paramss);

                //this.rptVReporteLocal.RefreshReport();



            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Reportes al generar Reporte de Ventas por rangos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

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
    public partial class FrmErrores : Form
    {
        public DATOS.Error ER = new DATOS.Error();

        public FrmErrores()
        {
            InitializeComponent();
        }

        private void FrmErrores_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = Utilitarios.OpError.ListarErrores().OrderByDescending(x => x.Hora).ToList();
                cmbBusqueda.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Insumos al Intentar Cargar los Errores Registrados");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Insumos");
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = Utilitarios.OpError.ListarErrores().ToList();

                var Lista = Utilitarios.OpError.ListarErrores().OrderByDescending(x => x.Hora);
                var Listax = new List<DATOS.Error>();

                switch (cmbBusqueda.SelectedItem.ToString())
                {

                    case "Consecutivo":
                        Listax = Lista.Where(x => x.IdError == txtBuscar.Text).ToList();
                        dgvListado.DataSource = Listax.ToList();
                        break;
                    case "Descripción":
                        Listax = Lista.Where(x => x.Descripcion == txtBuscar.Text).ToList();
                        dgvListado.DataSource = Listax.ToList();
                        break;
                    case "Fecha":
                        DateTime D1, D2;
                        D1 = GetDateZeroTime(dtpFechaBusqueda.Value);
                        D2 = GetDateEndTime(dtpFechaBusqueda.Value);
                        Listax = Lista.Where(x => x.Hora > D1 && x.Hora < D2).ToList();
                        dgvListado.DataSource = Listax.ToList();
                        break;
                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Errores al Buscar en el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var autosearch = new AutoCompleteStringCollection();
                var autosearch2 = new AutoCompleteStringCollection();
                var Lista = Utilitarios.OpError.ListarErrores().OrderByDescending(x => x.Hora);
                foreach (var item in Lista)
                {
                    autosearch.Add(Convert.ToString(item.IdError));
                    autosearch2.Add(Convert.ToString(item.Descripcion));

                }
                switch (cmbBusqueda.SelectedItem.ToString())
                {
                    case "Consecutivo":
                        txtBuscar.AutoCompleteCustomSource = autosearch;
                        txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        txtBuscar.Visible = true;
                        btnBuscar.Visible = true;
                        dtpFechaBusqueda.Visible = false;

                        dgvListado.DataSource = Lista.ToList();
                        break;
                    case "Descripción":

                        txtBuscar.AutoCompleteCustomSource = autosearch2;
                        txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        txtBuscar.Visible = true;
                        btnBuscar.Visible = true;
                        dtpFechaBusqueda.Visible = false;


                        break;
                    case "Fecha":
                        txtBuscar.Visible = false;
                        btnBuscar.Visible = true;
                        dtpFechaBusqueda.Visible = true;
                        dtpFechaBusqueda.Value = DateTime.Today.AddDays(-1);

                        break;
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Errores al Buscar en el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static DateTime GetDateZeroTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        public static DateTime GetDateEndTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
    }

}

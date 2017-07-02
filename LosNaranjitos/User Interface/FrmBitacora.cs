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
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.BackgroundColor = Color.Black;
                dgvListado.GridColor = Color.White;
                var Lista = Utilitarios.OpBitacora.ListarRegistros().OrderByDescending(x => x.Fecha);
                var Listax = new List<DATOS.Bitacora>();
                //foreach (var item in Lista)
                //{
                //    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitario.Llave);
                //}

                dgvListado.DataSource = Lista.ToList();
                dgvListado.Columns[0].HeaderText = "ID";
                dgvListado.Columns[1].HeaderText = "Fecha";
                dgvListado.Columns[2].HeaderText = "Registro";
                dgvListado.Columns[3].HeaderText = "Usuario";
                
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Bitacora al Cargar formulario");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbBusqueda.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = Utilitarios.OpBitacora.ListarRegistros().ToList();

                var Lista = Utilitarios.OpBitacora.ListarRegistros().OrderByDescending(x => x.Fecha);
                var Listax = new List<DATOS.Bitacora>();
                //foreach (var item in Lista)
                //{
                //    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitario.Llave);
                //}
                switch (cmbBusqueda.SelectedItem.ToString())
                {

                    case "Usuario":
                        Listax = Lista.Where(x => x.Usuario == txtBuscar.Text).ToList();
                        dgvListado.DataSource = Listax.ToList();


                        break;
                    case "Fecha":
                        DateTime D1, D2;
                        D1 = GetDateZeroTime(dtpFechaBusqueda.Value);
                        D2 = GetDateEndTime(dtpFechaBusqueda.Value);
                        Listax = Lista.Where(x => x.Fecha > D1 && x.Fecha < D2).ToList();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Bitacora");
            this.Dispose();
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                var Lista = Utilitarios.OpBitacora.ListarRegistros().OrderByDescending(x => x.Fecha);
                foreach (var item in Lista)
                {
                    //item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitario.Llave);
                    autosearch.Add(Convert.ToString(item.Usuario));

                }
                switch (cmbBusqueda.SelectedItem.ToString())
                {
                    case "General":
                        txtBuscar.Visible = false;
                        btnBuscar.Visible = false;
                        dtpFechaBusqueda.Visible = false;

                        dgvListado.DataSource = Lista.ToList();
                        break;
                    case "Usuario":
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

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Errores al Seleccionar Criterio de Busqueda en el formulario ");
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

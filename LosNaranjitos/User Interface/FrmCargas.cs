using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LosNaranjitos.DATOS;

namespace LosNaranjitos
{
    public partial class FrmCargas : Form
    {
        public FrmCargas()
        {
            InitializeComponent();
        }
        public static DATOS.Cargas EditarCarga = new DATOS.Cargas();
        public static List<DATOS.Cargas> ListaCargas = new List<DATOS.Cargas>();

        private void FrmCargas_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpCargas.ListarCargas().Count == 0)
                {
                    btnActualizar.Enabled = false;
                }

                for (int i = 0; i < 101; i++)
                {
                    cbbPorcentajeCarga.Items.Add(i);
                }
                cbbCargas.SelectedIndex = 0;
                cbbPorcentajeCarga.SelectedIndex = 0;
                cbbPorcentajeCarga.Sorted = true;
                //Verificacion de Consecutivo
                if (Utilitarios.Cambio == false)
                {
                    DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    //List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Cargas UltimaCarga = new Cargas();
                    try
                    {
                        UltimaCarga = Utilitarios.OpCargas.ListarCargas().OrderByDescending(x => x.Consecutivo).First();
                        if (UltimaCarga == null)
                        {
                            UltimaCarga = new Cargas()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimaCarga.Consecutivo.ToString();

                        }
                        else
                        {
                            lblConsecutivo.Text = (UltimaCarga.Consecutivo + 1).ToString();

                        }
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimaCarga = new Cargas()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimaCarga.Consecutivo.ToString();

                        }
                    }

                    //string Prefijo = Consecutivos.Where(x => x.Tipo == "Cargas").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSCarga = Consecutivo.ConsecutivoActual + 1;
                    //UltimaCarga.Consecutivo = Prefijo + "-" + CSCarga;
                    //if (Utilitarios.OpCargas.ExisteConsecutivo(UltimaCarga.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimaCarga.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnAgregar.Enabled = false;
                    //}
                }
                //Carga de Formulario Usual


                var ListaLocal = Utilitarios.OpCargas.ListarCargas();
                dgvCargas.DataSource = ListaLocal;

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.Consecutivo));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;
                //--------------------------------------------


                while (Utilitarios.Cambio)
                {
                    DATOS.Cargas Carg = new DATOS.Cargas();
                    Carg = Utilitarios.OpCargas.BuscarCarga(EditarCarga.Consecutivo);

                    tbC2.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtDescripcion.Text = EditarCarga.Descripcion;
                        lblConsecutivo.Text = EditarCarga.Consecutivo.ToString();
                        chkActivo.Checked = EditarCarga.Activo;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cargas al Cargar el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Utilitarios.Cambio)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtDescripcion.Text) != true)
                    {
                        EditarCarga.Activo = chkActivo.Checked;
                        EditarCarga.Descripcion = txtDescripcion.Text;
                        EditarCarga.Porcentaje = Convert.ToDecimal(cbbPorcentajeCarga.SelectedItem.ToString());
                        Utilitarios.OpCargas.ActualizarCargas(EditarCarga);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Actualización de Carga " + EditarCarga.Consecutivo);

                        MessageBox.Show("Registro Actualizado", "Actualizacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cargas al Actualizar la Carga ");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                FrmEdicionCargas a = new FrmEdicionCargas();
                a.Show();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text) != true)
                {
                    DATOS.Cargas NuevaCarga = new Cargas();
                    NuevaCarga.Activo = chkActivo.Checked;
                    NuevaCarga.Descripcion = txtDescripcion.Text;
                    NuevaCarga.Porcentaje = Convert.ToDecimal(cbbPorcentajeCarga.SelectedItem.ToString());
                    //  NuevaCarga.Consecutivo = lblConsecutivo.Text;
                    Utilitarios.OpCargas.AgregarCargas(EditarCarga);

                    //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Cargas");
                    //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual + 1;
                    //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Carga Nueva " + NuevaCarga.Descripcion);

                    MessageBox.Show("Los datos de la Carga  se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Cargas");
                    this.Dispose();

                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cargas al Actualizar la Carga ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Cargas");
            Utilitarios.Cambio = false;
            this.Dispose();
        }
    }
}

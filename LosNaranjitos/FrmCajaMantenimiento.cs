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
    public partial class FrmCajaMantenimiento : Form
    {
        public FrmCajaMantenimiento()
        {
            InitializeComponent();
        }
        public static List<DATOS.Cargas> ListaCargas = new List<DATOS.Cargas>();

        private void FrmCajaMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpCaja.ListarCajas().Count == 0)
                {
                    btnActualizar.Enabled = false;
                    cbbCajasId.Enabled = false;
                }

                //Verificacion de Consecutivo
                if (Utilitarios.Cambio == false)
                {
                    Consecutivo Consecutivo = new Consecutivo();
                    List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    Caja UltimaCaja = new Caja();
                    try
                    {
                        UltimaCaja = Utilitarios.OpCaja.ListarCajas().OrderByDescending(x => x.Consecutivo).First();
                        if (UltimaCaja == null)
                        {
                            UltimaCaja = new Caja()
                            {
                                Consecutivo = "CAJ-1"
                            };
                        }
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimaCaja = new Caja()
                            {
                                Consecutivo = "CAJ-1"
                            };
                        }
                    }

                    string Prefijo = Consecutivos.Where(x => x.Tipo == "Caja").Select(x => x.Prefijo).FirstOrDefault();
                    Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    int CSCaja = Consecutivo.ConsecutivoActual + 1;
                    UltimaCaja.Consecutivo = Prefijo + "-" + CSCaja;
                    if (Utilitarios.OpCargas.ExisteConsecutivo(UltimaCaja.Consecutivo))
                    {
                        MessageBox.Show("Existe otro Consecutivo " + UltimaCaja.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnAgregar.Enabled = false;
                    }
                    lblConsecutivo.Text = UltimaCaja.Consecutivo;
                }
                //Carga de Formulario Usual


                var ListaLocal = Utilitarios.OpCaja.ListarCajas();
                dgvCajas.DataSource = ListaLocal;

                cbbCajasId.DataSource = Utilitarios.OpCaja.ListarCajas().Select(X => X.Consecutivo).ToList();
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

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cajas al Cargar el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿Deseas Agregar una Nueva Caja ?", "Advertencia",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.Yes)
                {
                    Caja CajaNueva = new Caja();
                    CajaNueva.Consecutivo = lblConsecutivo.Text;
                    CajaNueva.Disponible = true;
                    CajaNueva.Estado = false;
                    CajaNueva.OperadorActual = FrmLogin.UsuarioGlobal.Username;
                    CajaNueva.UltimaModificacion = DateTime.Now;
                    Consecutivo Consecutivox = new Consecutivo();
                    Consecutivox = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Caja");
                    Consecutivox.ConsecutivoActual = Consecutivox.ConsecutivoActual + 1;
                    Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivox);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Caja Nueva Agregada");
                    MessageBox.Show("Caja Nueva Agregada y Disponible", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMain.SelectedIndex = 0;
                    this.FrmCajaMantenimiento_Load(sender, e);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cajas al Agregar Nueva Caja ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbCajasId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Caja Cajalocal = Utilitarios.OpCaja.ListarCajas().FirstOrDefault(x => x.Consecutivo == cbbCajasId.SelectedItem.ToString());
                chkActivo.Checked = Cajalocal.Disponible;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cajas al Intentar Seleccionar la Caja a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCajaModificar.Text))
                {
                    MessageBox.Show("Debes proveer una Justificacion", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var mensaje = MessageBox.Show("¿Deseas Modificar la Caja " + cbbCajasId.SelectedItem.ToString() + " ?", "Advertencia",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.Yes)
                {
                    Caja CajaDB = Utilitarios.OpCaja.BuscarCaja(cbbCajasId.SelectedItem.ToString());
                    if (CajaDB.Disponible == chkActivo.Checked)
                    {
                        if (chkActivo.Checked)
                        {
                            MessageBox.Show("Caja Ya esta activa, debes seleccionar otro estado", "Caja activa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Caja Ya esta desactivada,debes seleccionar otro estado", "Caja activa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    Caja CajaModificada = new Caja();
                    CajaModificada.Consecutivo = CajaDB.Consecutivo;
                    CajaModificada.Disponible = chkActivo.Checked;
                    CajaModificada.Estado = false;
                    CajaModificada.OperadorActual = FrmLogin.UsuarioGlobal.Username;
                    CajaModificada.UltimaModificacion = DateTime.Now;
                    Utilitarios.OpCaja.ActualizarCajas(CajaModificada);
                    if (chkActivo.Checked)
                    {
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Caja Activada segun justificacion: " + txtCajaModificar.Text);

                    }
                    else
                    {
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Caja Desactivada segun justificacion: " + txtCajaModificar.Text);
                    }
                    MessageBox.Show("Caja Modificada", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMain.SelectedIndex = 0;
                    this.FrmCajaMantenimiento_Load(sender, e);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Cajas al Agregar Nueva Caja ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Cajas");
            this.Dispose();
        }
    }
}

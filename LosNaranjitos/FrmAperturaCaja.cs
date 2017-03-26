using LosNaranjitos.DATOS;
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
    public partial class FrmAperturaCaja : Form
    {
        public FrmAperturaCaja()
        {
            InitializeComponent();
        }

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            try
            {
                List<Caja> ListaLocal = Utilitarios.OpCaja.ListarCajas().Where(x => x.Estado == false).ToList();
                if (ListaLocal.Count() == 0)
                {
                    MessageBox.Show("No Hay Cajas Libres para Apertura", "No hay Cajas disponibles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnApertura.Enabled = false;
                    return;
                }
                cbbCaja.DataSource = ListaLocal.Select(p => p.Consecutivo).ToList();
                cbbCaja.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Apertura de Caja");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmMenuCaja a = new FrmMenuCaja();
            a.Show();
            this.Dispose();
        }

        private void btnApertura_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿Deseas Modificar la Caja " + cbbCaja.SelectedItem.ToString() + " ?", "Advertencia",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.Yes)
                {
                    Caja CajaDB = Utilitarios.OpCaja.BuscarCaja(cbbCaja.SelectedItem.ToString());
                    Caja CajaAperturar = new Caja();
                    CajaAperturar.Consecutivo = CajaDB.Consecutivo;
                    CajaAperturar.Disponible = CajaDB.Disponible;
                    CajaAperturar.Estado = true;
                    CajaAperturar.OperadorActual = FrmLogin.UsuarioGlobal.Username;
                    CajaAperturar.UltimaModificacion = DateTime.Now;
                    Utilitarios.OpCaja.ActualizarCajas(CajaAperturar);
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Apertura de Caja Correcta");
                    
                    MessageBox.Show("Caja Seleccionada Correctamente", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmPedido a = new FrmPedido();
                    a.Show();
                    this.Dispose();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Apertura de Caja");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

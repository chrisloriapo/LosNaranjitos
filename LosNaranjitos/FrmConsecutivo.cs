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
    public partial class FrmConsecutivo : Form
    {
        public FrmConsecutivo()
        {
            InitializeComponent();
        }
        private void Carga(object sender, EventArgs e)
        {
            try
            {
                cbbTipo.DataSource = Utilitarios.OpConsecutivo.ListarConsecutivos().Select(x => x.Tipo).ToList();
                cbbTipo.SelectedIndex = 0;
                dgvConsecutivo.DataSource = Utilitarios.OpConsecutivo.ListarConsecutivos().ToList();
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Consecutivos al Cargar el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre Modulo de Proveedores");
            this.Dispose();
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ConsecutivoSelected = Utilitarios.OpConsecutivo.ListarConsecutivos().Where(x => x.Tipo == cbbTipo.SelectedItem.ToString()).FirstOrDefault();

                lbl1.Text = "Prefijo:";
                lbl2.Text = "       " + ConsecutivoSelected.Prefijo;
                lbl3.Text = "Descripción:";
                lbl4.Text = "       " + ConsecutivoSelected.Tipo;
                lbl5.Text = "Consecutivo Actual:";
                lbl6.Text = "       " + ConsecutivoSelected.ConsecutivoActual;

            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Consecutivos al Cargar el informacion de Consecutivo ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DATOS.Consecutivo Consecutivl = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo(cbbTipo.SelectedValue.ToString());

                if (string.IsNullOrEmpty(txtNuevo.Text) || string.IsNullOrWhiteSpace(txtNuevo.Text))
                {
                    MessageBox.Show("Ingresa un valor numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var mensaje = MessageBox.Show("¿Desea cambiar el consecutivo actual de "
                    + Consecutivl.Tipo + " de " + lbl6.Text.Replace(" ", "") + " por " + txtNuevo.Text.Replace(" ", "") + " ?", "Advertencia",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    if (Consecutivl.ConsecutivoActual > Convert.ToInt32(txtNuevo.Text.Replace(" ", "")))
                    {
                        var mensaje2 = MessageBox.Show("Esta a punto de Cambiar el consecutivo actual de " + Consecutivl.Tipo + " por un consecutivo menor al registrado. \n Esto puede ocacionarle problemas en el modulo de " + Consecutivl.Tipo + " Inclusive puede ocacionar un fallo completo del sistema \n ¿Aùn así desea continuar?", "Advertencia",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (mensaje == DialogResult.Yes)
                        {
                            Consecutivl.ConsecutivoActual = Convert.ToInt32(txtNuevo.Text.Replace(" ", ""));
                            Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivl);
                            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Consecutivo " + Consecutivl.Tipo + " Actualizado");

                            MessageBox.Show("Consecutivo actualizado", "Actualización",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNuevo.Clear();
                            Carga(sender, e);
                            tbC2.SelectedIndex = 0;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Consecutivl.ConsecutivoActual = Convert.ToInt32(txtNuevo.Text.Replace(" ", ""));
                        Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivl);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Consecutivo " + Consecutivl.Tipo + " Actualizado");

                        MessageBox.Show("Consecutivo actualizado", "Actualización",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNuevo.Clear();
                        Carga(sender, e);
                        tbC2.SelectedIndex = 0;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Consecutivos al Tratar de actualizar el Consecutivo ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ListaConsecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                var ListaLocal = ListaConsecutivos.ToList();
                switch (cbbConsecutivos.SelectedItem.ToString())
                {
                    case "Prefijo":

                        ListaLocal = ListaLocal.Where(x => x.Prefijo == txtBuscar.Text).ToList();

                        break;
                    case "Tipo":

                        ListaLocal = ListaLocal.Where(x => x.Tipo == txtBuscar.Text).ToList();
                        break;
                }
                dgvConsecutivo.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Consecutivos al Buscar en el formulario ");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

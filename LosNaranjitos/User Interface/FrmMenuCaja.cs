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
    public partial class FrmMenuCaja : Form
    {
        public FrmMenuCaja()
        {
            InitializeComponent();
        }

        private void btnAperturaCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.OpCaja.ListarCajas().Where(x => x.Estado == true && x.OperadorActual == FrmLogin.UsuarioGlobal.Username).Count() > 0)
                {
                    FrmPedido a = new FrmPedido();
                    a.Show();
                    a.WindowState = FormWindowState.Maximized;
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Caja desde menu de Caja ");
                    this.Visible = false;
                }
                else
                {
                    FrmAperturaCaja a = new FrmAperturaCaja();
                    a.Show();
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Caja desde menu de Caja ");
                    this.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿Desea salir del sistema?", "Advertencia",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false && x.Operador == FrmLogin.UsuarioGlobal.Username).Count() > 0)
                    {
                        MessageBox.Show("Debes Generar el Cierre de Caja (Arqueo)", "Debes Cerrar tus Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Aplicación ");
                    this.Dispose();
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCierreCajero a = new FrmCierreCajero();
                a.Show();
                a.WindowState = FormWindowState.Maximized;
                Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso a Modulo de Cierre desde menu de Caja ");
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿Desea Cerrar la sesion del sistema?", "Advertencia",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                    if (Utilitarios.OpPedidos.ListarPedido().Where(x => x.Cerrado == false && x.Operador == FrmLogin.UsuarioGlobal.Username).Count() > 0)
                    {
                        MessageBox.Show("Debes Generar el Cierre de Caja (Arqueo)", "Debes Cerrar tus Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                    Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Sesion ");
                    FrmLogin a = new FrmLogin();
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
                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void FrmMenuCaja_Load(object sender, EventArgs e)
        {
            try
            {
                if (FrmLogin.UsuarioGlobal.CambioContrasena)
                {

                    try
                    {
                        User_Interface.FrmPasswordChange a = new User_Interface.FrmPasswordChange();
                        a.TopMost = true;
                        a.ControlBox = false;
                        a.MinimizeBox = false;
                        a.MaximizeBox = false;
                        a.StartPosition = FormStartPosition.CenterScreen;
                        a.Show();
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Usuario debe Cambiar Contraseña ");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message, "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

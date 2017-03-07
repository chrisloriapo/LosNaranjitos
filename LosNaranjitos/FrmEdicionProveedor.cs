﻿using System;
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
    public partial class FrmEdicionProveedor : Form
    {
        public static DATOS.Proveedor ProveedorEditar = new DATOS.Proveedor();

        public FrmEdicionProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.Cambio = false;
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ProveedorEditar = Utilitarios.OpProveedor.ListarProveedores().FirstOrDefault(x => x.Nombre == cbbProveedores.SelectedValue.ToString());
            FrmProveedor.EditProveedor = ProveedorEditar;
            Utilitarios.Cambio = true;
            this.Dispose();
            FrmProveedor a = new FrmProveedor();
            a.WindowState= FormWindowState.Maximized;
            a.MdiParent = FrmLogin.MN;
            a.Show();
        }

        private void FrmEdicionProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                cbbProveedores.DataSource = Utilitarios.OpProveedor.ListarProveedores().Select(p => p.Nombre).ToList();
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Intentar Seleccionar el Proveedor a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProveedorEditar = Utilitarios.OpProveedor.ListarProveedores().FirstOrDefault(x => x.Nombre == cbbProveedores.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + ProveedorEditar.Nombre;
                lblIdPersonal.Text = "Id Proveedor: " + ProveedorEditar.IdProveedor;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Proveedores al Intentar Seleccionar el Proveedor a editar");
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

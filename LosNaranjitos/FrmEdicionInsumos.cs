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
    public partial class FrmEdicionInsumos : Form
    {
        BL.Interfaces.IInsumos OpInsumos = new BL.Clases.Insumos();
        BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        DATOS.Error ER = new DATOS.Error();
        public static DATOS.Insumos InsumosEditar = new DATOS.Insumos();

        public FrmEdicionInsumos()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbInsumos.DataSource = OpInsumos.ListarInsumos().Select(p => p.IdInsumo).ToList();
            }
            catch (Exception ex)
            {

                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                InsumosEditar = OpInsumos.ListarInsumos().FirstOrDefault(x => x.IdInsumo == cbbInsumos.SelectedValue.ToString());
                lblNombre.Text = "Nombre: " + InsumosEditar.Nombre;
                lblIdPersonal.Text = "Id : " + InsumosEditar.IdInsumo   ;
            }
            catch (Exception ex)
            {
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilitarios.Cambio = false;
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            InsumosEditar = OpInsumos.ListarInsumos().FirstOrDefault(x => x.IdInsumo == cbbInsumos.SelectedValue.ToString());
            FrmInsumos.EditInsumo = InsumosEditar;
            Utilitarios.Cambio = true;
            this.Dispose();
            FrmInsumos a = new FrmInsumos();
            a.MdiParent = FrmLogin.MN;
            a.WindowState = FormWindowState.Maximized;
            a.Show();

        }
    }
}

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
    public partial class FrmEdicionMedida : Form
    {
        BL.Interfaces.IMedida OpMedida = new BL.Clases.Medida();
        BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        DATOS.Error ER = new DATOS.Error();
        public static DATOS.Medida MedidaEditar = new DATOS.Medida();

        public FrmEdicionMedida()
        {
            InitializeComponent();
        }

        private void FrmEdicionUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cbbMedida.DataSource = OpMedida.ListarMedidas().Select(p => p.IdMedida).ToList();
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
                MedidaEditar = OpMedida.ListarMedidas().FirstOrDefault(x => x.IdMedida == cbbMedida.SelectedValue.ToString());
                lblNombre.Text = "Medida: " + MedidaEditar.Descripcion;
                lblIdPersonal.Text = "Unidad de Medida: " + MedidaEditar.IdMedida;
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
            MedidaEditar = OpMedida.ListarMedidas().FirstOrDefault(x => x.IdMedida == cbbMedida.SelectedValue.ToString());
            FrmMedidas.EditMedida = MedidaEditar;
            Utilitarios.Cambio = true;

            this.Dispose();
            FrmMedidas a = new FrmMedidas();
            a.Show();
        }
    }
}

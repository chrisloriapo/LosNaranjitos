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
    public partial class FrmMedidas : Form

    {
        BL.Interfaces.IMedida Med = new BL.Clases.Medida();

        public FrmMedidas()
        {
            InitializeComponent();
        }

        private void FrmMedidas_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbTipoMedida.Text) || string.IsNullOrWhiteSpace(cbTipoMedida.Text) ||
               string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar los datos necesarios",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    MessageBox.Show("Las medidas se ingresaron de manera correcta",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                catch (Exception)
                {

                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtMedida.Text = string.Empty;
            this.cbTipoMedida.Text = string.Empty;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.txtDescripcion.Text = string.Empty;
            this.txtMedida.Text = string.Empty;
            this.cbTipoMedida.Text = string.Empty;
        }


    }


}

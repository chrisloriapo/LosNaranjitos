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
    public partial class FrmTecladoNumerico : Form
    {
        public FrmTecladoNumerico()
        {
            InitializeComponent();
        }

        private void FrmTecladoNumerico_Load(object sender, EventArgs e)
        {
            Utilitarios.CantidadSeleccionada = 0;
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "1";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "1";
            }
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "2";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "2";
            }
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "3";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "3";
            }
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "4";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "4";
            }
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "5";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "5";
            }
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "6";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "6";
            }
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "7";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "7";
            }
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "8";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "8";
            }
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "9";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "9";
            }
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "0";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text + "0";
            }
        }

        private void brnBorrar_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text == "0" || string.IsNullOrEmpty(lblCantidad.Text))
            {
                lblCantidad.Text = "0";
            }
            else
            {
                lblCantidad.Text = lblCantidad.Text.Substring(0, lblCantidad.Text.Length - 1);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lblCantidad.Text != "")
            {
                Utilitarios.CantidadSeleccionada = Convert.ToInt32(lblCantidad.Text);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Utilitarios.CantidadSeleccionada = 0;
            this.Close();
        }
    }
}

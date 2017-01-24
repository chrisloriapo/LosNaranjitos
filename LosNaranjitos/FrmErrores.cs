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
    public partial class FrmErrores : Form
    {
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();

        public FrmErrores()
        {
            InitializeComponent();
        }

        private void FrmErrores_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = OpErrpr.ListarErrores().ToList();
            }
            catch (Exception ex)
            {
                ER.Descripcion = ex.Message;
                ER.Tipo = "Error al Popular Datos";
                ER.Hora = DateTime.Now;
                OpErrpr.AgregarError(ER);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

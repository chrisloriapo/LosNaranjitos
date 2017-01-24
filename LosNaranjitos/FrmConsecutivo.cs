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
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();
        BL.Interfaces.IConsecutivo OperacionesConsec = new BL.Clases.Consecutivo();
        public FrmConsecutivo()
        {
            InitializeComponent();
        }

        private void Carga(object sender, EventArgs e)
        {
            try
            {

                dgvConsecutivo.DataSource = OperacionesConsec.ListarConsecutivos();
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

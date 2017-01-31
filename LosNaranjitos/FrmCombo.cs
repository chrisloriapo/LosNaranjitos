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
    public partial class FrmCombo : Form
    {
        public static DATOS.Combo EditCombo = new DATOS.Combo();
        public static List<DATOS.Combo> ListaCombos = new List<DATOS.Combo>();
        public BL.Interfaces.ICombo OpCombo = new BL.Clases.Combo();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IComboProducto OpComboProducto = new BL.Clases.ComboProducto();
        public BL.Interfaces.IProducto OpProductos = new BL.Clases.Producto();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();


        public FrmCombo()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductosVenta_Load(object sender, EventArgs e)
        {
          

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FrmReporteProductos : Form
    {
        public FrmReporteProductos()
        {
            InitializeComponent();
        }

        private void FrmReporteProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'OrangeDB1DataSet.Producto' Puede moverla o quitarla según sea necesario.
            try
            {
                this.ProductoTableAdapter.Fill(this.OrangeDB1DataSet.Producto);

                foreach (var item in (this.OrangeDB1DataSet.Producto))
                {
                    item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                    item.Codigo = Utilitarios.Decriptar(item.Codigo, Utilitarios.Llave);
                    item.Nombre = Utilitarios.Decriptar(item.Nombre, Utilitarios.Llave);

                    DATOS.CategoriaProductos CategoriaLocal = new DATOS.CategoriaProductos();
                    CategoriaLocal = Utilitarios.OpCategorias.BuscarCategoriaProductos(Utilitarios.Decriptar(item.Categoria, Utilitarios.Llave));
                    item.Categoria = CategoriaLocal.Descripcion;
                    item.Descripcion = Utilitarios.Decriptar(item.Descripcion, Utilitarios.Llave);

                }
                OrangeDB1DataSet.Bitacora.OrderByDescending(x => x.IdBitacora);
                this.rptVReporteLocal.RefreshReport();
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Reporte de Productos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
    }
}

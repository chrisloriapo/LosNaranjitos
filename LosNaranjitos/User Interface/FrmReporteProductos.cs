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
                    //item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                    //item.Codigo = Utilitarios.Decriptar(item.Codigo, Utilitarios.Llave);
                    //item.Nombre = Utilitarios.Decriptar(item.Nombre, Utilitarios.Llave);

                    DATOS.CategoriaProductos CategoriaLocal = new DATOS.CategoriaProductos();
                    CategoriaLocal = Utilitarios.OpCategorias.BuscarCategoriaProductos(Int32.Parse( item.Categoria));
                    item.Categoria = CategoriaLocal.Descripcion;
                    //item.Descripcion = Utilitarios.Decriptar(item.Descripcion, Utilitarios.Llave);

                }
                this.rptVReporteLocal.RefreshReport();

            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Reporte de Productos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tbcMain.SelectedIndex)
                {
                    case 1:
                    this.ProductoTableAdapter.Fill(this.OrangeDB1DataSet.Producto);

                    foreach (var item in (this.OrangeDB1DataSet.Producto))
                    {
                        //item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                        //item.Codigo = Utilitarios.Decriptar(item.Codigo, Utilitarios.Llave);
                        //item.Nombre = Utilitarios.Decriptar(item.Nombre, Utilitarios.Llave);

                        DATOS.CategoriaProductos CategoriaLocal = new DATOS.CategoriaProductos();
                        CategoriaLocal = Utilitarios.OpCategorias.BuscarCategoriaProductos(Int32.Parse(item.Categoria));
                        item.Categoria = CategoriaLocal.Descripcion;
                  //      item.Descripcion = Utilitarios.Decriptar(item.Descripcion, Utilitarios.Llave);

                    }
                    this.rptVReporteLocal.RefreshReport();

                    break;
                    case 2:
                        this.ComboTableAdapter.Fill(this.OrangeDB1DataSet.Combo);

                       // foreach (var item in (this.OrangeDB1DataSet.Combo))
                       // {
                       //     item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                       //     item.Codigo = Utilitarios.Decriptar(item.Codigo, Utilitarios.Llave);
                       //     item.Nombre = Utilitarios.Decriptar(item.Nombre, Utilitarios.Llave);
                       //     item.Descripcion = Utilitarios.Decriptar(item.Descripcion, Utilitarios.Llave);
                       //}
                        this.rptCombos.RefreshReport();
                        break;
                    case 3:
                        this.InsumosTableAdapter.Fill(this.OrangeDB1DataSet.Insumos);

                        //foreach (var item in (this.OrangeDB1DataSet.Insumos))
                        //{
                        //    item.Consecutivo = Utilitarios.Decriptar(item.Consecutivo, Utilitarios.Llave);
                        //    item.Proveedor = Utilitarios.Decriptar(item.Proveedor, Utilitarios.Llave);
                        //    item.Nombre = Utilitarios.Decriptar(item.Nombre, Utilitarios.Llave);
                        //    item.IdMedida = Utilitarios.Decriptar(item.IdMedida, Utilitarios.Llave);
                        //    item.IdInsumo = Utilitarios.Decriptar(item.IdInsumo, Utilitarios.Llave);
                        //}
                        this.rptInsumos.RefreshReport();
                        break;
                    case 4:
                        this.BitacoraTableAdapter.Fill(this.OrangeDB1DataSet.Bitacora);

                        //foreach (var item in (this.OrangeDB1DataSet.Bitacora))
                        //{
                        //    item.IdBitacora = Utilitarios.Decriptar(item.IdBitacora, Utilitarios.Llave);
                        //    item.Usuario = Utilitarios.Decriptar(item.Usuario, Utilitarios.Llave);
                        //    item.Accion = Utilitarios.Decriptar(item.Accion, Utilitarios.Llave);
                           
                        //}
                        this.rptInsumos.RefreshReport();
                        break;
                }
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Reporte de Productos");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

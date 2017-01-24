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
        public static DATOS.Medida EditMedida = new DATOS.Medida();
        public static List<DATOS.Medida> ListaMedidas = new List<DATOS.Medida>();
        BL.Interfaces.IMedida OpMedidas = new BL.Clases.Medida();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();

        public FrmMedidas()
        {
            InitializeComponent();
        }

        private void FrmMedidas_Load(object sender, EventArgs e)
        {
            try
            {
                ListaMedidas = OpMedidas.ListarMedidas();
                var ListaLocal = ListaMedidas.ToList();
                dgvListado.DataSource = ListaLocal;

                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.Descripcion));
                }
                txtBuscar.AutoCompleteCustomSource = autosearch;

                //------------------------------

                while (Utilitarios.Cambio)
                {
                    tabControl1.SelectedIndex = 1;
                    if (Utilitarios.Cambio)
                    {
                        txtMedida.Text = EditMedida.IdMedida;
                        txtDescripcion.Text = EditMedida.Descripcion;

                        return;
                    }
                    else
                    {
                        return;
                    }
                }

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedida.Text) || string.IsNullOrWhiteSpace(txtMedida.Text)
                || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text)
                )
            {
                MessageBox.Show("Debe ingresar los datos necesarios",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    if (OpMedidas.ExisteMEdida(txtMedida.Text))
                    {
                        MessageBox.Show("Unidad de medida Duplicado",
                                            "No se puede Ingresar Medida duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DATOS.Medida MedidaPrivate = new DATOS.Medida
                        {
                            IdMedida = txtMedida.Text,
                            Descripcion = txtDescripcion.Text,
                        };

                        OpMedidas.AgregarMedida(MedidaPrivate);
                    }
                    MessageBox.Show("Las medidas se ingresaron de manera correcta",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
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

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedida.Text))
            {
                FrmEdicionMedida a = new FrmEdicionMedida();
                a.Show();
                this.Dispose();
            }
            else
            {
                if (OpMedidas.ExisteMEdida(txtMedida.Text))
                {
                    try
                    {
                        DATOS.Medida MedidaPrivate = new DATOS.Medida
                        {
                            IdMedida = txtMedida.Text,
                            Descripcion = txtDescripcion.Text,
                        };

                        OpMedidas.ActualizarMEdida(MedidaPrivate);
                        MessageBox.Show("Los datos de la Unidad de Medida se Actualizaron correctamente",
                       "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        txtMedida.Clear();
                        txtDescripcion.Clear();
                    }
                    catch (Exception ex)
                    {

                        ER.Descripcion = ex.Message;
                        ER.Tipo = "Error al Popular Datos";
                        ER.Hora = DateTime.Now;
                        OpErrpr.AgregarError(ER);
                        MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Utilitarios.Cambio = false;
                }
                else
                {
                    MessageBox.Show("Usuario No existe",
                    "IdUsuario No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void Limpiar()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtMedida.Text = string.Empty;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Dispose();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaMedidas = OpMedidas.ListarMedidas();
                var ListaLocal = ListaMedidas.ToList();
                ListaLocal = ListaLocal.Where(x => x.Descripcion == txtBuscar.Text).ToList();
                dgvListado.DataSource = ListaLocal;
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }
    }


}

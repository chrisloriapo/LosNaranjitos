using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LosNaranjitos.DATOS;


namespace LosNaranjitos
{
    public partial class FrmMedidas : Form

    {
        public static DATOS.Medida EditMedida = new DATOS.Medida();
        public static List<DATOS.Medida> ListaMedidas = new List<DATOS.Medida>();

        public FrmMedidas()
        {
            InitializeComponent();
        }

        private void FrmMedidas_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Utilitarios.Cambio)
                {
                    //DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                    //List<Consecutivo> Consecutivos = Utilitarios.OpConsecutivo.ListarConsecutivos();
                    DATOS.Medida UltimaMedida = new Medida();
                    txtMedida.ReadOnly = false;
                    try
                    {
                        UltimaMedida = Utilitarios.OpMedidas.ListarMedidas().OrderByDescending(x => x.Consecutivo).First();
                        if (UltimaMedida == null)
                        {
                            UltimaMedida = new Medida()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimaMedida.Consecutivo.ToString();

                        }
                        else
                        {
                            lblConsecutivo.Text = (UltimaMedida.Consecutivo + 1).ToString();

                        }
                    }
                    catch (Exception x)
                    {
                        if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                        {
                            UltimaMedida = new Medida()
                            {
                                Consecutivo = 1
                            };
                            lblConsecutivo.Text = UltimaMedida.Consecutivo.ToString();

                        }
                    }
                    //string Prefijo = Consecutivos.Where(x => x.Tipo == "Medida").Select(x => x.Prefijo).FirstOrDefault();
                    //Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivo(Prefijo);
                    //int CSMedida = Consecutivo.ConsecutivoActual + 1;
                    //UltimaMedida.Consecutivo = Prefijo + "-" + CSMedida;
                    //if (Utilitarios.OpMedidas.ExisteConsecutivo(UltimaMedida.Consecutivo))
                    //{
                    //    MessageBox.Show("Existe otro Consecutivo " + UltimaMedida.Consecutivo + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    btnNuevo.Enabled = false;
                    //}
                }
                ListaMedidas = Utilitarios.OpMedidas.ListarMedidas();
                var ListaLocal = ListaMedidas.Select(a => new
                {
                    a.IdMedida,
                    a.Descripcion,

                }).ToList();
                dgvListado.DataSource = ListaLocal;
                dgvListado.Columns[0].HeaderText = "Unidad de Medida";
                dgvListado.Columns[1].HeaderText = "Descripción";

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
                    txtMedida.ReadOnly = true;
                    tabControl1.SelectedIndex = 0;
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
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Cargar formulario de medidas");
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
                    if (Utilitarios.OpMedidas.ExisteMEdida(txtMedida.Text))
                    {
                        MessageBox.Show("Unidad de medida Duplicado",
                                            "No se puede Ingresar Medida duplicado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DATOS.Medida MedidaPrivate = new DATOS.Medida
                        {
                            //Consecutivo = lblConsecutivo.Text,
                            IdMedida = txtMedida.Text,
                            Descripcion = txtDescripcion.Text,
                        };

                        Utilitarios.OpMedidas.AgregarMedida(MedidaPrivate);

                        //DATOS.Consecutivo Consecutivo = Utilitarios.OpConsecutivo.BuscarConsecutivoPorTipo("Medida");
                        //Consecutivo.ConsecutivoActual = Consecutivo.ConsecutivoActual++;
                        //Utilitarios.OpConsecutivo.ActualizarConsecutivo(Consecutivo);

                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Ingreso de Unidad de Medida Nueva");

                        MessageBox.Show("Las medidas se ingresaron de manera correcta",
                   "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Clear(); txtDescripcion.Clear(); txtMedida.Clear();
                        this.FrmMedidas_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Ingresar una Unidad de medida");
                    MessageBox.Show("Error", "Error al Popular datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedida.Text))
            {
                if (Utilitarios.OpMedidas.ListarMedidas().Count() > 0)
                {
                    FrmEdicionMedida a = new FrmEdicionMedida();
                    a.Show();
                    this.Dispose();
                }
                else
                {

                    MessageBox.Show("No existe ninguna unidad de medida Registrada para poder editar, pureba Ingresando un nuevo registro", "No hay datos a modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEditar.Enabled = false;
                    return;

                }

            }
            else
            {
                if (Utilitarios.OpMedidas.ExisteMEdida(txtMedida.Text))
                {
                    try
                    {
                        DATOS.Medida MedidaPrivate = new DATOS.Medida
                        {
                            IdMedida = txtMedida.Text,
                            Descripcion = txtDescripcion.Text,
                        };
                        Utilitarios.OpMedidas.ActualizarMEdida(MedidaPrivate);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Edicion de Usuario " + MedidaPrivate.IdMedida);
                        MessageBox.Show("Los datos de la Unidad de Medida se Actualizaron correctamente",
                       "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Unidades de Medida");
                        txtMedida.Clear();
                        txtDescripcion.Clear();
                        this.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Editar una Unidad de medida");
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
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Unidades de Medida");
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
                ListaMedidas = Utilitarios.OpMedidas.ListarMedidas();
                var ListaLocal = ListaMedidas.Select(a => new
                {
                    a.IdMedida,
                    a.Descripcion,

                }).ToList();
                dgvListado.DataSource = ListaLocal;
                dgvListado.Columns[0].HeaderText = "Unidad de Medida";
                dgvListado.Columns[1].HeaderText = "Descripción";
                ListaLocal = ListaLocal.Where(x => x.Descripcion == txtBuscar.Text).ToList();
                dgvListado.DataSource = ListaLocal;
            }
            catch (Exception ex)
            {
                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", FrmLogin.UsuarioGlobal.Username, "Error en Modulo de Usuarios al Intentar Buscar una Unidad de medida");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Utilitarios.GeneralBitacora(FrmLogin.UsuarioGlobal.Username, "Cierre de Modulo de Unidades de Medida");
            this.Dispose();

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }
    }


}

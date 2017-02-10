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
        public BL.Interfaces.IConsecutivo ConsecutivoOperaciones = new BL.Clases.Consecutivo();
        public BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public BL.Interfaces.IUsuario OpUsuario = new BL.Clases.Usuario();
        public BL.Interfaces.IProveedor OpProveedor = new BL.Clases.Proveedor();
        public BL.Interfaces.IPedido OpPedido = new BL.Clases.Pedido();
        public BL.Interfaces.IProducto OpProducto = new BL.Clases.Producto();
        public BL.Interfaces.ICategoriaProductos OpCategoriaProductos = new BL.Clases.CategoriaProductos();
        public BL.Interfaces.IInsumos OpInsumos = new BL.Clases.Insumos();
        public BL.Interfaces.ICliente OpCliente = new BL.Clases.Cliente();
        public BL.Interfaces.ICombo OpCombo = new BL.Clases.Combo();

        public BL.Interfaces.IError OpErrpr = new BL.Clases.Error();
        public DATOS.Error ER = new DATOS.Error();
        public DATOS.Bitacora BIT = new DATOS.Bitacora();
        public DATOS.Consecutivo ConsecutivoGlobal = new DATOS.Consecutivo();

        public FrmConsecutivo()
        {
            InitializeComponent();
        }

        private void Carga(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in ConsecutivoOperaciones.ListarConsecutivos())
                {
                    cbbIdConsecutivos.Items.Add(item.IdConsecutivo);
                }
                dgvConsecutivo.DataSource = ConsecutivoOperaciones.ListarConsecutivos().ToList();
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

        private void cbbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = ConsecutivoOperaciones.ListarConsecutivos();
                var autosearch = new AutoCompleteStringCollection();
                txtBuscar.AutoCompleteCustomSource = autosearch;
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                switch (cbbConsecutivos.SelectedItem.ToString())
                {
                    case "Proveedor":

                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Proveedor");
                        break;
                    case "Cliente":

                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Cliente");

                        break;
                    case "Usuario":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Usuario");
                        foreach (var item in ListaLocal)
                        {
                            item.PKTabla = Utilitario.Decriptar(item.PKTabla, Utilitario.Llave);
                        }
                        break;
                    case "Categoria de Productos":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("CatProducto");
                        break;
                    case "Producto":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Producto");
                        break;
                    case "Insumo":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Insumo");
                        break;
                    case "Combo":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Combo");
                        break;
                    case "Pedido":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Pedido");
                        break;
                }

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.IdConsecutivo));
                }
                dgvConsecutivo.DataSource = ListaLocal;
                txtBuscar.AutoCompleteCustomSource = autosearch;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ListaLocal = ConsecutivoOperaciones.ListarConsecutivos();
                var autosearch = new AutoCompleteStringCollection();
                cbbIdConsecutivos.AutoCompleteCustomSource = autosearch;
                cbbIdConsecutivos.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbbIdConsecutivos.AutoCompleteSource = AutoCompleteSource.CustomSource;

                cbbIdConsecutivos.Items.Clear();



                switch (cbbTipo.SelectedItem.ToString())
                {
                    case "Proveedor":

                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Proveedor");

                        break;
                    case "Cliente":

                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Cliente");

                        break;
                    case "Usuario":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Usuario");
                        foreach (var item in ListaLocal)
                        {
                            item.PKTabla = Utilitario.Decriptar(item.PKTabla, Utilitario.Llave);
                        }
                        break;
                    case "Categoria de Productos":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("CatProducto");
                        break;
                    case "Producto":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Producto");
                        break;
                    case "Insumo":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Insumo");
                        break;
                    case "Combo":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Combo");
                        break;
                    case "Pedido":
                        ListaLocal = ConsecutivoOperaciones.ListaPorTipo("Pedido");
                        break;
                }

                foreach (var pos in ListaLocal)
                {
                    autosearch.Add(Convert.ToString(pos.IdConsecutivo));
                    cbbIdConsecutivos.Items.Add(pos.IdConsecutivo);
                }
                cbbIdConsecutivos.AutoCompleteCustomSource = autosearch;
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

        private void cbbIdConsecutivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ConsecutivoGlobal = ConsecutivoOperaciones.BuscarConsecutivo(cbbIdConsecutivos.SelectedItem.ToString());

                switch (cbbTipo.SelectedItem.ToString())
                {

                    case "Proveedor":
                        DATOS.Proveedor ProveedorLocal = OpProveedor.BuscarProveedor(ConsecutivoGlobal.PKTabla);
                        lbl1.Text = "Detalles de Proveedor:";
                        lbl2.Text = "Nombre: " + ProveedorLocal.Nombre;
                        lbl3.Text = "ID : " + ProveedorLocal.IdProveedor;
                        lbl4.Text = "Telefono:" + ProveedorLocal.Telefono;
                        lbl5.Text = "Correo: " + ProveedorLocal.Correo;
                        lbl6.Text = "Activo: " + ProveedorLocal.Activo.ToString();
                        break;
                    case "Cliente":
                        DATOS.Cliente ClienteLocal = OpCliente.BuscarCliente(ConsecutivoGlobal.PKTabla);
                        lbl1.Text = "Detalles de Cliente:";
                        lbl2.Text = "Nombre: " + ClienteLocal.Nombre + " " + ClienteLocal.Apellido1 + " " + ClienteLocal.Apellido2;
                        lbl3.Text = "ID : " + ClienteLocal.IdPersonal;
                        lbl4.Text = "Telefono:" + ClienteLocal.Telefono;
                        lbl5.Text = "Correo: " + ClienteLocal.Correo;
                        lbl6.Text = "Activo: " + ClienteLocal.Activo.ToString();
                        break;
                    case "Usuario":
                        DATOS.Usuario UsuarioLocal = OpUsuario.BuscarUsuarioXUsername(ConsecutivoGlobal.PKTabla);
                        lbl1.Text = "Detalles de Usuario:";
                        lbl2.Text = "Nombre: " + Utilitario.Decriptar(UsuarioLocal.Nombre, Utilitario.Llave) + " " + Utilitario.Decriptar(UsuarioLocal.Apellido1, Utilitario.Llave) + " " + Utilitario.Decriptar(UsuarioLocal.Apellido2, Utilitario.Llave);
                        lbl3.Text = "ID : " + Utilitario.Decriptar(UsuarioLocal.IdPersonal, Utilitario.Llave);
                        lbl4.Text = "Telefono:" + Utilitario.Decriptar(UsuarioLocal.Telefono, Utilitario.Llave);
                        lbl5.Text = "Correo: " + Utilitario.Decriptar(UsuarioLocal.Correo, Utilitario.Llave);
                        lbl6.Text = "Activo: " + UsuarioLocal.Activo.ToString();
                        break;
                    case "Categoria de Productos":
                        DATOS.CategoriaProductos CategoriaLocal = OpCategoriaProductos.BuscarCategoriaProductos(Convert.ToInt32(ConsecutivoGlobal.PKTabla));
                        lbl1.Text = "Detalles de Categoria de Producto:";
                        lbl2.Text = "Id: " + CategoriaLocal.IdTipo;
                        lbl3.Text = "Descripcion : " + CategoriaLocal.Descripcion;
                        lbl4.Text = "";
                        lbl5.Text = "";
                        lbl6.Text = "Activo: " + CategoriaLocal.Activo.ToString();
                        break;
                    case "Producto":
                        DATOS.Producto ProductoLocal = OpProducto.BuscarProducto(ConsecutivoGlobal.PKTabla);
                        lbl1.Text = "Detalles Producto:";
                        lbl2.Text = "Codigo: " + ProductoLocal.Codigo;
                        lbl3.Text = "Nombre : " + ProductoLocal.Nombre;
                        lbl4.Text = "Descripcion: " + ProductoLocal.Descripcion;
                        lbl5.Text = "Categoria: " + ProductoLocal.Categoria + " / Precio: ₡" + ProductoLocal.Precio;
                        lbl6.Text = "Activo: " + ProductoLocal.Activo.ToString();
                        break;
                    case "Insumo":
                        DATOS.Insumos InsumoLocal = OpInsumos.BuscarInsumos(ConsecutivoGlobal.PKTabla);
                        lbl1.Text = "Detalles Insumo:";
                        lbl2.Text = "Codigo: " + InsumoLocal.IdInsumo;
                        lbl3.Text = "Nombre : " + InsumoLocal.Nombre;
                        lbl4.Text = "Cant. en Inventario: " + InsumoLocal.CantInventario + " " + InsumoLocal.IdMedida;
                        lbl5.Text = "Proveedor: " + InsumoLocal.Proveedor + " / Precio: ₡" + InsumoLocal.PrecioCompra;
                        lbl6.Text = "Activo: " + InsumoLocal.Activo.ToString();
                        break;
                    case "Combo":
                        DATOS.Combo ComboLocal = OpCombo.BuscarCombo(ConsecutivoGlobal.PKTabla);
                        lbl1.Text = "Detalles Combo / Promoción:";
                        lbl2.Text = "Codigo: " + ComboLocal.Codigo;
                        lbl3.Text = "Nombre : " + ComboLocal.Nombre;
                        lbl4.Text = "Descripción: " + ComboLocal.Descripcion;
                        lbl5.Text = "Precio: ₡" + ComboLocal.Precio;
                        lbl6.Text = "Activo: " + ComboLocal.Activo.ToString();
                        break;
                    case "Pedido":
                        DATOS.Pedido PedidoLocal = OpPedido.BuscarPedido(Convert.ToInt32(ConsecutivoGlobal.PKTabla));
                        lbl1.Text = "Detalles Pedido:";
                        lbl2.Text = "IDPedido: " + PedidoLocal.IdPedido;
                        lbl3.Text = "Cliente: " + PedidoLocal.IdCliente;
                        lbl4.Text = "Onservaciones: " + PedidoLocal.Observaciones;
                        lbl5.Text = "Total: ₡" + PedidoLocal.Subtotal + " / Operador: " + PedidoLocal.Operador;
                        lbl6.Text = "Activo: " + PedidoLocal.Activo.ToString();
                        break;
                }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ConsecutivoGlobal = ConsecutivoOperaciones.BuscarConsecutivo(cbbIdConsecutivos.SelectedItem.ToString());

                if (String.IsNullOrEmpty( txtNuevo.Text) || String.IsNullOrWhiteSpace(txtNuevo.Text))
                {
                    MessageBox.Show("Ingresa un valor numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Siglas = "";
                switch (cbbTipo.SelectedItem.ToString())
                {
                    case "Proveedor":
                        Siglas = "PRV-";
                        break;
                    case "Cliente":
                        Siglas = "CLI-";
                        break;
                    case "Usuario":
                        Siglas = "USR-";
                        break;
                    case "Categoria de Productos":
                        Siglas = "CPR-";
                        break;
                    case "Producto":
                        Siglas = "PRD-";
                        break;
                    case "Insumo":
                        Siglas = "INS-";
                        break;
                    case "Combo":
                        Siglas = "CMB-";
                        break;
                    case "Pedido":
                        Siglas = "PDD-";
                        break;
                }
                Siglas = Siglas + txtNuevo.Text.Replace(" ","");

                var mensaje = MessageBox.Show("¿Desea cambiar el consecutivo "+ConsecutivoGlobal.IdConsecutivo+" por "+Siglas+" ?", "Advertencia",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.Yes)
                {
                   
                    if (ConsecutivoOperaciones.ExisteConsecutivo(Siglas))
                    {
                        MessageBox.Show("Ese consecutivo Ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ConsecutivoOperaciones.EliminarConsecutivo(ConsecutivoGlobal);
                        ConsecutivoGlobal.IdConsecutivo = Siglas;
                        ConsecutivoOperaciones.AgregarConsecutivo(ConsecutivoGlobal);
                        BIT.Usuario = FrmLogin.UsuarioGlobal.IdUsuario;
                        BIT.Accion = "Actualización de Consecutivo "+ConsecutivoGlobal.IdConsecutivo ;
                        BIT.Fecha = DateTime.Now;
                        OpBitacora.AgregarBitacora(BIT);
                        BIT = null;
                        MessageBox.Show("Consecutivo actualizado", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNuevo.Clear();
                        Carga(sender,e);
                        tbC2.SelectedIndex = 0;

                    }
                    
                }
                else
                {
                    return;
                }

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

using LosNaranjitos.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosNaranjitos
{
    public class Utilitarios
    {
        public static BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public static BL.Interfaces.IFacturaCompra OpFacturaCompra = new BL.Clases.FacturaCompra();

        public static BL.Interfaces.ICategoriaProductos OpCategorias = new BL.Clases.CategoriaProductos();
        public static BL.Interfaces.ICliente OpClientes = new BL.Clases.Cliente();
        public static BL.Interfaces.ICombo OpCombo = new BL.Clases.Combo();
        public static BL.Interfaces.IComboProducto OpComboProducto = new BL.Clases.ComboProducto();
        public static BL.Interfaces.IConsecutivo OpConsecutivo = new BL.Clases.Consecutivo();
        public static BL.Interfaces.IDetallePedido OpDetallePedido = new BL.Clases.DetallePedido();
        public static BL.Interfaces.IError OpError = new BL.Clases.Error();
        public static BL.Interfaces.IInsumos OpInsumos = new BL.Clases.Insumos();
        public static BL.Interfaces.IMedida OpMedidas = new BL.Clases.Medida();
        public static BL.Interfaces.IPedido OpPedidos = new BL.Clases.Pedido();
        public static BL.Interfaces.IProducto OpProducto = new BL.Clases.Producto();
        public static BL.Interfaces.IProductoInsumo OpProductoInsumo = new BL.Clases.ProductoInsumo();
        public static BL.Interfaces.IProveedor OpProveedor = new BL.Clases.Proveedor();
        public static BL.Interfaces.IRolUsuario OpRol = new BL.Clases.RolUsuario();
        public static BL.Interfaces.IUsuario OpUsuarios = new BL.Clases.Usuario();
        public static BL.Interfaces.ICargas OpCargas = new BL.Clases.Cargas();
        public static BL.Interfaces.ICaja OpCaja = new BL.Clases.Caja();
        public static BL.Interfaces.ICierre OpCierres = new BL.Clases.Cierre();


        public static int CantidadSeleccionada = 0;
        public static string Llave = "hendmsjskruwiqud";
        public static bool Cambio = false;
        public static bool CambioEnCajas = false;

        public static string ComentarioAutorizacion = "";
        public static Usuario Autorizante = new Usuario();

        public static void GeneralBitacora(string Usuario, string AccionBitacora)
        {
            try
            {
                //DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                //List<Consecutivo> Consecutivos = OpConsecutivo.ListarConsecutivos();
                DATOS.Bitacora BIT = new DATOS.Bitacora();
                //try
                //{
                //    BIT = OpBitacora.ListarRegistros().OrderByDescending(x => x.IdBitacora).First();
                //}
                //catch (Exception x)
                //{
                //    if (x.Message == "La secuencia no contiene elementos")
                //    {
                //        BIT.IdBitacora = "BIT-1";
                //    }
                //}
                //string Prefijo = Consecutivos.Where(x => x.Tipo == "Bitacora").Select(x => x.Prefijo).FirstOrDefault();
                //Consecutivo = OpConsecutivo.BuscarConsecutivo(Prefijo);
                //int CSBitacora = Consecutivo.ConsecutivoActual + 1;
                //BIT.IdBitacora = Prefijo + "-" + CSBitacora;
                //if (OpBitacora.ExisteConsecutivo(BIT.IdBitacora))
                //{
                //    MessageBox.Show("Existe otro Consecutivo" + BIT.IdBitacora + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                BIT.Usuario = Usuario;
                BIT.Accion = AccionBitacora;
                BIT.Fecha = DateTime.Now;
                OpBitacora.AgregarBitacora(BIT);
                //Consecutivo.ConsecutivoActual = CSBitacora;
                //OpConsecutivo.ActualizarConsecutivo(Consecutivo);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en el sistema al Agregar a la Bitacora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void GeneralError(string ErrorMessage, string ErrorType, string Usuario, string AccionBitacora)
        {
            try
            {
                //DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();
                //List<Consecutivo> Consecutivos = OpConsecutivo.ListarConsecutivos();
                DATOS.Error Error = new DATOS.Error();
                //try
                //{
                //    Error = OpError.ListarErrores().OrderByDescending(x => x.IdError).FirstOrDefault();
                //    if (Error == null)
                //    {
                //        Error = new Error()
                //        {
                //            IdError = "ERR-1"
                //        };
                //    }
                //}
                //catch (Exception x)
                //{
                //    if (x.Message == "La secuencia no contiene elementos" || x.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                //    {
                //        Error = new Error()
                //        {
                //            IdError = "ERR-1"
                //        };
                //    }
                //}

                //string Prefijo = Consecutivos.Where(x => x.Tipo == "Error").Select(x => x.Prefijo).FirstOrDefault();
                //Consecutivo = OpConsecutivo.BuscarConsecutivo(Prefijo);
                //int CSError = Consecutivo.ConsecutivoActual + 1;
                //Error.IdError = Prefijo + "-" + CSError;
                //if (OpError.ExisteConsecutivo(Error.IdError))
                //{
                //    MessageBox.Show("Existe otro Consecutivo" + Error.IdError + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                Error.Descripcion = ErrorMessage;
                Error.Tipo = ErrorType;
                Error.Hora = DateTime.Now;
                OpError.AgregarError(Error);
                //Consecutivo.ConsecutivoActual = CSError;
                //OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                GeneralBitacora(Usuario, AccionBitacora);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema al guardar Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static string Decriptar(string Cadena, string llave)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Convert.FromBase64String(Cadena);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            return Encoding.UTF8.GetString(resultado);
        }

        public static string Encriptar(string Cadena, string llave)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Encoding.UTF8.GetBytes(Cadena);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }


        public static bool EsNumerico(string val)
        {
            bool isNum;

            double retNum;

            isNum = Double.TryParse(Convert.ToString(val),
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            return isNum;
        }
        public static DateTime GetDateZeroTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        public static DateTime GetDateEndTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

    }
}

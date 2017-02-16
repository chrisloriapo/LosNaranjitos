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

        public static string Llave = "hendmsjskruwiqud";
        public static bool Cambio = false;


        public static void GeneralBitacora(string Usuario, string AccionBitacora)
        {
            try
            {
                DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();

                List<Consecutivo> Consecutivos = OpConsecutivo.ListarConsecutivos();

                DATOS.Bitacora BIT = new DATOS.Bitacora();
                BIT = OpBitacora.ListarRegistros().OrderByDescending(x => x.IdBitacora).First();
                string Prefijo = Consecutivos.Where(x => x.Tipo == "Bitacora").Select(x => x.Prefijo).FirstOrDefault();
                Consecutivo = OpConsecutivo.BuscarConsecutivo(Prefijo);
                int CSBitacora = Consecutivo.ConsecutivoActual + 1;
                BIT.IdBitacora = Prefijo + "-" + CSBitacora;
                if (OpBitacora.ExisteConsecutivo(BIT.IdBitacora))
                {
                    MessageBox.Show("Existe otro Consecutivo"+BIT.IdBitacora+"/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BIT.Usuario = Usuario;
                BIT.Accion = AccionBitacora;
                BIT.Fecha = DateTime.Now;
                OpBitacora.AgregarBitacora(BIT);
                Consecutivo.ConsecutivoActual = CSBitacora;
                OpConsecutivo.ActualizarConsecutivo(Consecutivo);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public static void GeneralError(string ErrorMessage, string ErrorType, string Usuario, string AccionBitacora)
        {
            try
            {
                DATOS.Consecutivo Consecutivo = new DATOS.Consecutivo();

                List<Consecutivo> Consecutivos = OpConsecutivo.ListarConsecutivos();
                DATOS.Error ER = new DATOS.Error();

                ER = OpError.ListarErrores().OrderByDescending(x => x.IdError).First();

                string Prefijo = Consecutivos.Where(x => x.Tipo == "Error").Select(x => x.Prefijo).FirstOrDefault();
                Consecutivo = OpConsecutivo.BuscarConsecutivo(Prefijo);
                int CSError = Consecutivo.ConsecutivoActual + 1;
                ER.IdError = Prefijo + "-" + CSError;
                if (OpBitacora.ExisteConsecutivo(ER.IdError))
                {
                    MessageBox.Show("Existe otro Consecutivo" + ER.IdError + "/n Debes configurar Nuevamente los Consecutivos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ER.Descripcion = ErrorMessage;
                ER.Tipo = ErrorType;
                ER.Hora = DateTime.Now;
                OpError.AgregarError(ER);
                Consecutivo.ConsecutivoActual = CSError;
                OpConsecutivo.ActualizarConsecutivo(Consecutivo);
                GeneralBitacora(Usuario, AccionBitacora);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }





        public static string Decriptar(string contra, string llave)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Convert.FromBase64String(contra);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            return Encoding.UTF8.GetString(resultado);
        }

        public static string Encriptar(string contra, string llave)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Encoding.UTF8.GetBytes(contra);

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


    }
}

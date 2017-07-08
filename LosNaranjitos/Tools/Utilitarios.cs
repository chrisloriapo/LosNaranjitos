using LosNaranjitos.DATOS;
using LosNaranjitos.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosNaranjitos
{
    public class Utilitarios
    {
        public static BL.Interfaces.IBitacora OpBitacora = new BL.Clases.Bitacora();
        public static BL.Interfaces.IFacturaCompra OpFacturaCompra = new BL.Clases.FacturaCompra();
        public static BL.Interfaces.IParametros OpParametros = new BL.Clases.Parametros();
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
                DATOS.Bitacora BIT = new DATOS.Bitacora();
                BIT.Usuario = Usuario;
                BIT.Accion = AccionBitacora;
                BIT.Fecha = DateTime.Now;
                OpBitacora.AgregarBitacora(BIT);

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
                DATOS.Error Error = new DATOS.Error();
                Error.Descripcion = ErrorMessage;
                Error.Tipo = ErrorType;
                Error.Hora = DateTime.Now;
                OpError.AgregarError(Error);
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

        public static void EnviarEmailAttachment(List<string> Destinatarios, string Asunto, string Cuerpo, MemoryStream myMemorySteam)
        {
            Tools.Email correo = new Tools.Email();


            correo.Asunto = Asunto;
            correo.Cuerpo = Cuerpo;

            correo.Destinatarios = Destinatarios;

            foreach (var item in correo.Destinatarios)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(item));
                mail.From = new MailAddress(OpParametros.BuscarParametrosPorNombre("MailDeliverer").Valor);
                mail.Subject = correo.Asunto;
                mail.Body = correo.Cuerpo;
                mail.IsBodyHtml = false;

                MemoryStream pdfstream = new MemoryStream(myMemorySteam.ToArray());

                Attachment attachment = new Attachment(pdfstream, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf));

                attachment.ContentDisposition.FileName = "Reporte" + DateTime.Now.ToShortTimeString() + ".pdf";

                mail.Attachments.Add(attachment);

                SmtpClient client = new SmtpClient(OpParametros.BuscarParametrosPorNombre("Smtp").Valor, Int32.Parse( OpParametros.BuscarParametrosPorNombre("PuertoCorreo").Valor));
                using (client)
                {
                    client.Credentials = new System.Net.NetworkCredential(OpParametros.BuscarParametrosPorNombre("MailDeliverer").Valor, Utilitarios.Decriptar( OpParametros.BuscarParametrosPorNombre("PasswordMailDeliverer").Valor,Utilitarios.Llave));
                    client.EnableSsl = true;
                    client.Send(mail);
                }
            }
        }
        public static void EnviarEmail(List<string> Destinatarios, string Asunto, string Cuerpo)
        {
            Tools.Email correo = new Tools.Email();


            correo.Asunto = Asunto;
            correo.Cuerpo = Cuerpo;

            correo.Destinatarios = Destinatarios;

            foreach (var item in correo.Destinatarios)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(item));
                mail.From = new MailAddress("orangesrestaurants@gmail.com");
                mail.Subject = correo.Asunto;
                mail.Body = correo.Cuerpo;
                mail.IsBodyHtml = false;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                using (client)
                {
                    client.Credentials = new System.Net.NetworkCredential("orangesrestaurants@gmail.com", "Vision360");
                    client.EnableSsl = true;
                    client.Send(mail);
                }
            }
        }

        public static void TicketeGeneral(string NumerodeCaja, string NombreCajero, string ClienteOrden, List<DetallePedido> Detalles, DATOS.Pedido OrdenEnCurso)
        {
            Ticket ticket = new Ticket();
            ticket.AbreCajon();

            ticket.TextoCentro("SODA LOS NARANJITOS");
            ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoIzquierda("DIREC: 25 SUR Y 75 OESTE DE LA MEGASUPER TEJAR");
            ticket.TextoIzquierda("TELEF: 25910412");
            ticket.TextoIzquierda("C.J.: 302970494");
            ticket.TextoIzquierda("EMAIL: orangesrestaurants@gmail.com");//Es el mio por si me quieren contactar ...
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("Caja # " + NumerodeCaja, "Ticket # " + OrdenEnCurso.Consecutivo.ToString());
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIO: " + NombreCajero);
            ticket.TextoIzquierda("CLIENTE: " + ClienteOrden);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();
            ticket.lineasAsteriscos();


            //   ticket.AgregaArticulo(item.Producto + " " + item.ObservacionesDT, item.Cantidad, item.SubTotal, "");

            foreach (var PRODUCTO in Detalles)
            {
                if (String.IsNullOrWhiteSpace(PRODUCTO.ObservacionesDT))
                {
                    if (PRODUCTO.Producto.ToString().Contains("Combo"))
                    {
                        ticket.AgregaArticulo(PRODUCTO.Producto, PRODUCTO.Cantidad, PRODUCTO.SubTotal, "");

                        DATOS.Combo ComboAuxiliar = new Combo();
                        ComboAuxiliar = Utilitarios.OpCombo.BuscarComboPorNombre(PRODUCTO.Producto);


                        List<ComboProducto> ProductosEnCombo = Utilitarios.OpComboProducto.ListarComboProductos().Where(x => x.CodCombo == ComboAuxiliar.Codigo).ToList();

                        foreach (var COMBO in ProductosEnCombo)
                        {
                            ticket.AgregaArticulo(Utilitarios.OpProducto.BuscarProducto(COMBO.CodProducto).Descripcion, 0, 0, "");
                        }
                    }
                    else
                    {
                        ticket.AgregaArticulo(PRODUCTO.Producto, PRODUCTO.Cantidad, PRODUCTO.SubTotal, "");
                    }

                }
                else if (PRODUCTO.Producto == "Servicio Express")
                {
                    ticket.AgregaArticulo(PRODUCTO.Producto, PRODUCTO.Cantidad, PRODUCTO.SubTotal, "");

                }

                else
                {
                    if (PRODUCTO.Producto.ToString().Contains("Combo"))
                    {
                        if (PRODUCTO.Producto.ToString().Contains("Combo"))
                        {
                            ticket.AgregaArticulo(PRODUCTO.Producto, PRODUCTO.Cantidad, PRODUCTO.SubTotal, "");

                            DATOS.Combo ComboAuxiliar = new Combo();
                            ComboAuxiliar = Utilitarios.OpCombo.BuscarComboPorNombre(PRODUCTO.Producto);


                            List<ComboProducto> ProductosEnCombo = Utilitarios.OpComboProducto.ListarComboProductos().Where(x => x.CodCombo == ComboAuxiliar.Codigo).ToList();

                            foreach (var COMBO in ProductosEnCombo)
                            {
                                ticket.AgregaArticulo(Utilitarios.OpProducto.BuscarProducto(COMBO.CodProducto).Descripcion, null, null, "");
                            }
                        }
                        else
                        {
                            ticket.AgregaArticulo(PRODUCTO.Producto, PRODUCTO.Cantidad, PRODUCTO.SubTotal, "");
                        }
                    }
                    else
                    {
                        ticket.AgregaArticulo(PRODUCTO.Producto, PRODUCTO.Cantidad, PRODUCTO.SubTotal, "");

                        List<string> stringList = PRODUCTO.ObservacionesDT.Split(',').ToList();
                        foreach (var CADENA in stringList)
                        {
                            ticket.AgregaArticulo(CADENA, null, null, "");

                        }
                    }



                }
            }
            ticket.lineasIgual();

            ticket.AgregarTotales("         SUBTOTAL......C", Convert.ToDouble(OrdenEnCurso.Subtotal) - (Convert.ToDouble(OrdenEnCurso.Subtotal) * 0.13));
            ticket.AgregarTotales("         IV...........C", (Convert.ToDouble(OrdenEnCurso.Subtotal) * 0.13));
            ticket.AgregarTotales("         TOTAL.........C", Convert.ToDouble(OrdenEnCurso.Subtotal));
            ticket.TextoIzquierda("");
            ticket.AgregarTotales("         EFECTIVO......C", Convert.ToDouble(OrdenEnCurso.MontoCambio));
            ticket.AgregarTotales("         CAMBIO........C", Convert.ToDouble(OrdenEnCurso.MontoTarjeta + OrdenEnCurso.MontoEfectivo + OrdenEnCurso.MontoOtro) - Convert.ToDouble(OrdenEnCurso.Subtotal));

            //Texto final del Ticket.
            ticket.TextoIzquierda("IMPUESTO DE VENTA INCLUIDO");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("PRODUCTOS VENDIDOS: " + Detalles.Sum(x => x.Cantidad));
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.TextoCentro("FACEBOOK: /Los Naranjitos!");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.CortaTicket();
            ticket.ImprimirTicket(Utilitarios.OpParametros.BuscarParametro(1).Valor);//Nombre de la impresora ticketera


        }

        public static Boolean emailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool FindAndKillProcess(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            return false;
        }
    }
}


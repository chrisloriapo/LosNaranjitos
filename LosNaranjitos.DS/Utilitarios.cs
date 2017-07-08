using LosNaranjitos.DATOS;
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

namespace LosNaranjitos.DS
{
    public class Utilitarios
    {
        public static DS.Interfaces.IBitacora OpBitacora = new DS.Clases.Bitacora();
        public static DS.Interfaces.IFacturaCompra OpFacturaCompra = new DS.Clases.FacturaCompra();
        public static DS.Interfaces.IParametros OpParametros = new DS.Clases.Parametros();
        public static DS.Interfaces.ICategoriaProductos OpCategorias = new DS.Clases.CategoriaProductos();
        public static DS.Interfaces.ICliente OpClientes = new DS.Clases.Cliente();
        public static DS.Interfaces.ICombo OpCombo = new DS.Clases.Combo();
        public static DS.Interfaces.IComboProducto OpComboProducto = new DS.Clases.ComboProducto();
        public static DS.Interfaces.IConsecutivo OpConsecutivo = new DS.Clases.Consecutivo();
        public static DS.Interfaces.IDetallePedido OpDetallePedido = new DS.Clases.DetallePedido();
        public static DS.Interfaces.IError OpError = new DS.Clases.Error();
        public static DS.Interfaces.IInsumos OpInsumos = new DS.Clases.Insumos();
        public static DS.Interfaces.IMedida OpMedidas = new DS.Clases.Medida();
        public static DS.Interfaces.IPedido OpPedidos = new DS.Clases.Pedido();
        public static DS.Interfaces.IProducto OpProducto = new DS.Clases.Producto();
        public static DS.Interfaces.IProductoInsumo OpProductoInsumo = new DS.Clases.ProductoInsumo();
        public static DS.Interfaces.IProveedor OpProveedor = new DS.Clases.Proveedor();
        public static DS.Interfaces.IRolUsuario OpRol = new DS.Clases.RolUsuario();
        public static DS.Interfaces.IUsuario OpUsuarios = new DS.Clases.Usuario();
        public static DS.Interfaces.ICargas OpCargas = new DS.Clases.Cargas();
        public static DS.Interfaces.ICaja OpCaja = new DS.Clases.Caja();
        public static DS.Interfaces.ICierre OpCierres = new DS.Clases.Cierre();


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
            Email correo = new Email();


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
            Email correo = new Email();


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


                SmtpClient client = new SmtpClient(OpParametros.BuscarParametrosPorNombre("Smtp").Valor, Int32.Parse(OpParametros.BuscarParametrosPorNombre("PuertoCorreo").Valor));
                using (client)
                {
                    client.Credentials = new System.Net.NetworkCredential(OpParametros.BuscarParametrosPorNombre("MailDeliverer").Valor, Utilitarios.Decriptar(OpParametros.BuscarParametrosPorNombre("PasswordMailDeliverer").Valor, Utilitarios.Llave)); client.EnableSsl = true;
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class FacturaCompra : IFacturaCompra
    {
        public DS.Interfaces.IFacturaCompra FacturasOP = new DS.Clases.FacturaCompra();

        public void ActualizarFacturaCompra(DATOS.FacturaCompra Factura_Compra)
        {
            Factura_Compra.Consecutivo = Utilitario.Encriptar(Factura_Compra.Consecutivo, Utilitario.Llave);
            Factura_Compra.IdProveedor = Utilitario.Encriptar(Factura_Compra.IdProveedor, Utilitario.Llave);
            Factura_Compra.IdFactura = Utilitario.Encriptar(Factura_Compra.IdFactura, Utilitario.Llave);
            Factura_Compra.Observaciones = Utilitario.Encriptar(Factura_Compra.Observaciones, Utilitario.Llave);
            Factura_Compra.Operador = Utilitario.Encriptar(Factura_Compra.Operador, Utilitario.Llave);
            FacturasOP.ActualizarFacturaCompra(Factura_Compra);
        }

        public void AgregarFacturaCompra(DATOS.FacturaCompra Factura_Compra)
        {
            Factura_Compra.Consecutivo = Utilitario.Encriptar(Factura_Compra.Consecutivo, Utilitario.Llave);
            Factura_Compra.IdProveedor = Utilitario.Encriptar(Factura_Compra.IdProveedor, Utilitario.Llave);
            Factura_Compra.IdFactura = Utilitario.Encriptar(Factura_Compra.IdFactura, Utilitario.Llave);
            Factura_Compra.Observaciones = Utilitario.Encriptar(Factura_Compra.Observaciones, Utilitario.Llave);
            Factura_Compra.Operador = Utilitario.Encriptar(Factura_Compra.Operador, Utilitario.Llave);
            FacturasOP.AgregarFacturaCompra(Factura_Compra);

        }

        public DATOS.FacturaCompra BuscarFactura(string IdFactura)
        {
            IdFactura = Utilitario.Encriptar(IdFactura, Utilitario.Llave);
            DATOS.FacturaCompra FacturaCompraRetorno = FacturasOP.BuscarFactura(IdFactura);
            FacturaCompraRetorno.Consecutivo = Utilitario.Decriptar(FacturaCompraRetorno.Consecutivo, Utilitario.Llave);
            FacturaCompraRetorno.IdProveedor = Utilitario.Decriptar(FacturaCompraRetorno.IdProveedor, Utilitario.Llave);
            FacturaCompraRetorno.IdFactura = Utilitario.Decriptar(FacturaCompraRetorno.IdFactura, Utilitario.Llave);
            FacturaCompraRetorno.Observaciones = Utilitario.Decriptar(FacturaCompraRetorno.Observaciones, Utilitario.Llave);
            FacturaCompraRetorno.Operador = Utilitario.Decriptar(FacturaCompraRetorno.Operador, Utilitario.Llave);
            return FacturaCompraRetorno;
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return FacturasOP.ExisteConsecutivo(Consecutivo);
        }

        public bool ExisteFactura(string IdFactura)
        {
            IdFactura = Utilitario.Encriptar(IdFactura, Utilitario.Llave);
            return FacturasOP.ExisteFactura(IdFactura);
        }

        public void Inactivar(DATOS.FacturaCompra Factura_Compra)
        {
            Factura_Compra.Consecutivo = Utilitario.Encriptar(Factura_Compra.Consecutivo, Utilitario.Llave);
            Factura_Compra.IdProveedor = Utilitario.Encriptar(Factura_Compra.IdProveedor, Utilitario.Llave);
            Factura_Compra.IdFactura = Utilitario.Encriptar(Factura_Compra.IdFactura, Utilitario.Llave);
            Factura_Compra.Observaciones = Utilitario.Encriptar(Factura_Compra.Observaciones, Utilitario.Llave);
            Factura_Compra.Operador = Utilitario.Encriptar(Factura_Compra.Operador, Utilitario.Llave);
            FacturasOP.Inactivar(Factura_Compra);
        }

        public List<DATOS.FacturaCompra> ListarFacturas()
        {
            List<DATOS.FacturaCompra> ListaRetorno = FacturasOP.ListarFacturas();
            foreach (var item in ListaRetorno)
            {
                item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
                item.IdProveedor = Utilitario.Decriptar(item.IdProveedor, Utilitario.Llave);
                item.IdFactura = Utilitario.Decriptar(item.IdFactura, Utilitario.Llave);
                item.Observaciones = Utilitario.Decriptar(item.Observaciones, Utilitario.Llave);
                item.Operador = Utilitario.Decriptar(item.Operador, Utilitario.Llave);
            }
            return ListaRetorno;
        }
    }
}

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
            FacturasOP.ActualizarFacturaCompra(Factura_Compra);
        }

        public void AgregarFacturaCompra(DATOS.FacturaCompra Factura_Compra)
        {
            FacturasOP.AgregarFacturaCompra(Factura_Compra);

        }

        public DATOS.FacturaCompra BuscarFactura(string IdFactura)
        {
            return FacturasOP.BuscarFactura(IdFactura);
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            return FacturasOP.ExisteConsecutivo(Consecutivo);
        }

        public bool ExisteFactura(string IdFactura)
        {
            return FacturasOP.ExisteFactura(IdFactura);
        }

        public void Inactivar(DATOS.FacturaCompra Factura_Compra)
        {
            FacturasOP.ActualizarFacturaCompra(Factura_Compra);
        }

        public List<DATOS.FacturaCompra> ListarFacturas()
        {
            return FacturasOP.ListarFacturas();
        }
    }
}

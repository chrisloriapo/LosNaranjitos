using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IFacturaCompra
    {
        List<DATOS.FacturaCompra> ListarFacturas();

        DATOS.FacturaCompra BuscarFactura(string IdFactura);

        void AgregarFacturaCompra(DATOS.FacturaCompra Factura_Compra);

        void ActualizarFacturaCompra(DATOS.FacturaCompra Factura_Compra);

        void Inactivar(DATOS.FacturaCompra Factura_Compra);

        bool ExisteFactura(string IdFactura);

        bool ExisteConsecutivo(int Consecutivo);

    }
}

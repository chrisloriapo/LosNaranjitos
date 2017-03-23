using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface IDetallePedido
    {
        List<DATOS.DetallePedido> ListarDetallesPedido();

        DATOS.DetallePedido BuscarPorProducto(string Producto);

        DATOS.DetallePedido BuscarPorPedido(string Orden);

        DATOS.DetallePedido BuscarPorConsecutivo(string Conse);

        void AgregarDetalle(DATOS.DetallePedido DetalleOrden);

        void ActualizarDetalleOrden(DATOS.DetallePedido DetalleOrden);

        bool ExisteDetalle(string IdProducto, string Orden);

        bool ExisteConsecutivo(string Consecutivo);

        void EliminarDetalleDeOrden(DATOS.DetallePedido Detalle);

    }
}

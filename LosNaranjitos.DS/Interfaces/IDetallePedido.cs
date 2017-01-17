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

        DATOS.DetallePedido BuscarPorPedido(int Orden);

        void AgregarDetalle(DATOS.DetallePedido DetalleOrden);

        void ActualizarDetalleOrden(DATOS.DetallePedido DetalleOrden);

        bool ExisteDetalle(string IdProducto, int Orden);
    }
}

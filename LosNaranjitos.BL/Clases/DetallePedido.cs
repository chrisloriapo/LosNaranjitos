using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class DetallePedido : IDetallePedido
    {
        public DS.Interfaces.IDetallePedido Pedprocedimientos = new DS.Clases.DetallePedido();
        public void ActualizarDetalleOrden(DATOS.DetallePedido DetalleOrden)
        {
            Pedprocedimientos.ActualizarDetalleOrden(DetalleOrden);
        }

        public void AgregarDetalle(DATOS.DetallePedido DetalleOrden)
        {
            Pedprocedimientos.AgregarDetalle(DetalleOrden);
        }

        public DATOS.DetallePedido BuscarPorPedido(int Orden)
        {
            return Pedprocedimientos.BuscarPorPedido(Orden);
        }

        public DATOS.DetallePedido BuscarPorProducto(string Producto)
        {
            return Pedprocedimientos.BuscarPorProducto(Producto);
        }

        public bool ExisteDetalle(string IdProducto, int Orden)
        {
            return Pedprocedimientos.ExisteDetalle(IdProducto, Orden);
        }

        public List<DATOS.DetallePedido> ListarDetallesPedido()
        {
            return Pedprocedimientos.ListarDetallesPedido();
        }
    }
}

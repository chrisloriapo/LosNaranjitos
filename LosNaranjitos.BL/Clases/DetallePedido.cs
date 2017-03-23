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

        public bool ExisteConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return Pedprocedimientos.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarDetalleOrden(DATOS.DetallePedido DetalleOrden)
        {
            DetalleOrden.Consecutivo = Utilitario.Encriptar(DetalleOrden.Consecutivo, Utilitario.Llave);
            DetalleOrden.IdOrden = Utilitario.Encriptar(DetalleOrden.IdOrden, Utilitario.Llave);
            DetalleOrden.Producto = Utilitario.Encriptar(DetalleOrden.Producto, Utilitario.Llave);
            DetalleOrden.ObservacionesDT = Utilitario.Encriptar(DetalleOrden.ObservacionesDT, Utilitario.Llave);
            Pedprocedimientos.ActualizarDetalleOrden(DetalleOrden);
        }

        public void AgregarDetalle(DATOS.DetallePedido DetalleOrden)
        {
            DetalleOrden.Consecutivo = Utilitario.Encriptar(DetalleOrden.Consecutivo, Utilitario.Llave);
            DetalleOrden.IdOrden = Utilitario.Encriptar(DetalleOrden.IdOrden, Utilitario.Llave);
            DetalleOrden.Producto = Utilitario.Encriptar(DetalleOrden.Producto, Utilitario.Llave);
            DetalleOrden.ObservacionesDT = Utilitario.Encriptar(DetalleOrden.ObservacionesDT, Utilitario.Llave);
            Pedprocedimientos.AgregarDetalle(DetalleOrden);
        }

        public DATOS.DetallePedido BuscarPorConsecutivo(string Conse)
        {
            Conse = Utilitario.Encriptar(Conse, Utilitario.Llave);
            DATOS.DetallePedido DetallePedidoRetorno = Pedprocedimientos.BuscarPorConsecutivo(Conse);
            DetallePedidoRetorno.Consecutivo = Utilitario.Decriptar(DetallePedidoRetorno.Consecutivo, Utilitario.Llave);
            DetallePedidoRetorno.IdOrden = Utilitario.Decriptar(DetallePedidoRetorno.IdOrden, Utilitario.Llave);
            DetallePedidoRetorno.Producto = Utilitario.Decriptar(DetallePedidoRetorno.Producto, Utilitario.Llave);
            DetallePedidoRetorno.ObservacionesDT = Utilitario.Decriptar(DetallePedidoRetorno.ObservacionesDT, Utilitario.Llave);
            return DetallePedidoRetorno;
        }

        public DATOS.DetallePedido BuscarPorPedido(string Orden)
        {
            Orden = Utilitario.Encriptar(Orden, Utilitario.Llave);
            DATOS.DetallePedido DetallePedidoRetorno = Pedprocedimientos.BuscarPorPedido(Orden);
            DetallePedidoRetorno.Consecutivo = Utilitario.Decriptar(DetallePedidoRetorno.Consecutivo, Utilitario.Llave);
            DetallePedidoRetorno.IdOrden = Utilitario.Decriptar(DetallePedidoRetorno.IdOrden, Utilitario.Llave);
            DetallePedidoRetorno.Producto = Utilitario.Decriptar(DetallePedidoRetorno.Producto, Utilitario.Llave);
            DetallePedidoRetorno.ObservacionesDT = Utilitario.Decriptar(DetallePedidoRetorno.ObservacionesDT, Utilitario.Llave);
            return DetallePedidoRetorno;
        }

        public DATOS.DetallePedido BuscarPorProducto(string Producto)
        {
            Producto = Utilitario.Encriptar(Producto, Utilitario.Llave);
            DATOS.DetallePedido DetallePedidoRetorno = Pedprocedimientos.BuscarPorProducto(Producto);
            DetallePedidoRetorno.Consecutivo = Utilitario.Decriptar(DetallePedidoRetorno.Consecutivo, Utilitario.Llave);
            DetallePedidoRetorno.IdOrden = Utilitario.Decriptar(DetallePedidoRetorno.IdOrden, Utilitario.Llave);
            DetallePedidoRetorno.Producto = Utilitario.Decriptar(DetallePedidoRetorno.Producto, Utilitario.Llave);
            DetallePedidoRetorno.ObservacionesDT = Utilitario.Decriptar(DetallePedidoRetorno.ObservacionesDT, Utilitario.Llave);
            return DetallePedidoRetorno;
        }

        public bool ExisteDetalle(string IdProducto, string Orden)
        {
            IdProducto = Utilitario.Encriptar(IdProducto, Utilitario.Llave);
            Orden = Utilitario.Encriptar(Orden, Utilitario.Llave);
            return Pedprocedimientos.ExisteDetalle(IdProducto, Orden);
        }

        public List<DATOS.DetallePedido> ListarDetallesPedido()
        {
            List<DATOS.DetallePedido> ListaRetorno = Pedprocedimientos.ListarDetallesPedido();
            foreach (var item in ListaRetorno)
            {
                item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
                item.IdOrden = Utilitario.Decriptar(item.IdOrden, Utilitario.Llave);
                item.Producto = Utilitario.Decriptar(item.Producto, Utilitario.Llave);
                item.ObservacionesDT = Utilitario.Decriptar(item.ObservacionesDT, Utilitario.Llave);
            }
            return ListaRetorno;
        }

        public void EliminarDetalleDeOrden(DATOS.DetallePedido Detalle)
        {
            Detalle.Consecutivo = Utilitario.Encriptar(Detalle.Consecutivo, Utilitario.Llave);
            Detalle.IdOrden = Utilitario.Encriptar(Detalle.IdOrden, Utilitario.Llave);
            Detalle.Producto = Utilitario.Encriptar(Detalle.Producto, Utilitario.Llave);
            Detalle.ObservacionesDT = Utilitario.Encriptar(Detalle.ObservacionesDT, Utilitario.Llave);
            Pedprocedimientos.EliminarDetalleDeOrden(Detalle);
        }
    }
}

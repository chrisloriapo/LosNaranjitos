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
        public void ActualizarDetalleOrden(DATOS.DetallePedido DetalleOrden)
        {
            throw new NotImplementedException();
        }

        public void AgregarDetalle(DATOS.DetallePedido DetalleOrden)
        {
            throw new NotImplementedException();
        }

        public DATOS.DetallePedido BuscarPorPedido(int Orden)
        {
            throw new NotImplementedException();
        }

        public DATOS.DetallePedido BuscarPorProducto(string Producto)
        {
            throw new NotImplementedException();
        }

        public bool ExisteDetalle(string IdProducto, int Orden)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.DetallePedido> ListarDetallesPedido()
        {
            throw new NotImplementedException();
        }
    }
}

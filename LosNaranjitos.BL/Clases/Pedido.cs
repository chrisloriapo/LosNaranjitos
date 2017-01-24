using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Pedido : IPedido
    {
        public DS.Interfaces.IPedido PedidProdc = new DS.Clases.Pedido();
        public void ActualizarPedido(DATOS.Pedido Orden)
        {
            PedidProdc.ActualizarPedido(Orden);
        }

        public void AgregarPedido(DATOS.Pedido Orden)
        {
            PedidProdc.AgregarPedido(Orden);
        }

        public DATOS.Pedido BuscarPedido(int IdPedido)
        {
            return PedidProdc.BuscarPedido(IdPedido);
        }

        public DATOS.Pedido BuscarProductoCliente(string IdCliente)
        {
            return PedidProdc.BuscarProductoCliente(IdCliente);
        }

        public bool ExistePedido(int IdPedido)
        {
            return PedidProdc.ExistePedido(IdPedido);
        }

        public void Inactivar(DATOS.Pedido Orden)
        {
            Orden.Activo = false;
            PedidProdc.Inactivar(Orden);
        }

        public List<DATOS.Pedido> ListarPedido()
        {
            return PedidProdc.ListarPedido();
        }
    }
}

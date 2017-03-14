using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IPedido
    {
        List<DATOS.Pedido> ListarPedido();

        DATOS.Pedido BuscarPedido(string IdPedido);

        DATOS.Pedido BuscarProductoCliente(string IdCliente);

        DATOS.Pedido BuscarProductoConsecutivo(string Consec);

        void AgregarPedido(DATOS.Pedido Orden);

        void ActualizarPedido(DATOS.Pedido Orden);

        void Inactivar(DATOS.Pedido Orden);

        bool ExistePedido(string IdPedido);

        bool ExisteConsecutivo(string Consecutivo);

    }
}

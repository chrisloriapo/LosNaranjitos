using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface IPedido
    {
        List<DATOS.Pedido> ListarPedido();

        DATOS.Pedido BuscarPedido(int IdPedido);

        DATOS.Pedido BuscarProductoCliente(string IdCliente);

        DATOS.Pedido BuscarProductoConsecutivo(int Consec);

        void AgregarPedido(DATOS.Pedido Orden);

        void ActualizarPedido(DATOS.Pedido Orden);

        void Inactivar(DATOS.Pedido Orden);

        bool ExistePedido(int IdPedido);

        bool ExisteConsecutivo(int Consecutivo);

    }
}

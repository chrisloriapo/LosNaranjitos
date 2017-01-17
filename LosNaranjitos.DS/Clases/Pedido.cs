using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS.Interfaces;

namespace LosNaranjitos.DS.Clases
{
    public class Pedido : IPedido
    {
        public void ActualizarPedido(DATOS.Pedido Orden)
        {
            throw new NotImplementedException();
        }

        public void AgregarPedido(DATOS.Pedido Orden)
        {
            throw new NotImplementedException();
        }

        public DATOS.Pedido BuscarPedido(int IdPedido)
        {
            throw new NotImplementedException();
        }

        public DATOS.Pedido BuscarProductoCliente(string IdCliente)
        {
            throw new NotImplementedException();
        }

        public bool ExistePedido(int IdPedido)
        {
            throw new NotImplementedException();
        }

        public void Inactivar(DATOS.Pedido Orden)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.Pedido> ListarPedido()
        {
            throw new NotImplementedException();
        }
    }
}

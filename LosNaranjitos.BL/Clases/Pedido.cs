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
        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return PedidProdc.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarPedido(DATOS.Pedido Orden)
        {
            //Orden.Consecutivo = Utilitario.Encriptar(Orden.Consecutivo, Utilitario.Llave);
            //Orden.IdCliente = Utilitario.Encriptar(Orden.IdCliente, Utilitario.Llave);
            Orden.Operador = Utilitario.Encriptar(Orden.Operador, Utilitario.Llave);
            //if (Orden.Observaciones != null)
            //{
            //    Orden.Observaciones = Utilitario.Encriptar(Orden.Observaciones, Utilitario.Llave);
            //}
            PedidProdc.ActualizarPedido(Orden);
        }

        public void AgregarPedido(DATOS.Pedido Orden)
        {
            //Orden.Consecutivo = Utilitario.Encriptar(Orden.Consecutivo, Utilitario.Llave);
            //Orden.IdCliente = Utilitario.Encriptar(Orden.IdCliente, Utilitario.Llave);
            Orden.Operador = Utilitario.Encriptar(Orden.Operador, Utilitario.Llave);
            //if (Orden.Observaciones != null)
            //{
            //    Orden.Observaciones = Utilitario.Encriptar(Orden.Observaciones, Utilitario.Llave);
            //}
            PedidProdc.AgregarPedido(Orden);
        }

        public DATOS.Pedido BuscarPedido(int IdPedido)
        {
            //IdPedido = Utilitario.Encriptar(IdPedido, Utilitario.Llave);
            DATOS.Pedido PedidoRetorno = PedidProdc.BuscarPedido(IdPedido);
            //PedidoRetorno.Consecutivo = Utilitario.Decriptar(PedidoRetorno.Consecutivo, Utilitario.Llave);
            //PedidoRetorno.IdCliente = Utilitario.Decriptar(PedidoRetorno.IdCliente, Utilitario.Llave);
            PedidoRetorno.Operador = Utilitario.Decriptar(PedidoRetorno.Operador, Utilitario.Llave);
            //if (PedidoRetorno.Observaciones != null)
            //{
            //    PedidoRetorno.Observaciones = Utilitario.Decriptar(PedidoRetorno.Observaciones, Utilitario.Llave);
            //}
            return PedidoRetorno;
        }

        public DATOS.Pedido BuscarProductoCliente(string IdCliente)
        {
            //IdCliente = Utilitario.Encriptar(IdCliente, Utilitario.Llave);
            DATOS.Pedido PedidoRetorno = PedidProdc.BuscarProductoCliente(IdCliente);
            //PedidoRetorno.Consecutivo = Utilitario.Decriptar(PedidoRetorno.Consecutivo, Utilitario.Llave);
            //PedidoRetorno.IdCliente = Utilitario.Decriptar(PedidoRetorno.IdCliente, Utilitario.Llave);
            PedidoRetorno.Operador = Utilitario.Decriptar(PedidoRetorno.Operador, Utilitario.Llave);
            //if (PedidoRetorno.Observaciones != null)
            //{
            //    PedidoRetorno.Observaciones = Utilitario.Decriptar(PedidoRetorno.Observaciones, Utilitario.Llave);
            //}
            return PedidoRetorno;
        }

        public DATOS.Pedido BuscarProductoConsecutivo(int Consec)
        {
            //Consec = Utilitario.Encriptar(Consec, Utilitario.Llave);
            DATOS.Pedido PedidoRetorno = PedidProdc.BuscarProductoConsecutivo(Consec);
            //PedidoRetorno.Consecutivo = Utilitario.Decriptar(PedidoRetorno.Consecutivo, Utilitario.Llave);
            //PedidoRetorno.IdCliente = Utilitario.Decriptar(PedidoRetorno.IdCliente, Utilitario.Llave);
            PedidoRetorno.Operador = Utilitario.Decriptar(PedidoRetorno.Operador, Utilitario.Llave);
            //if (PedidoRetorno.Observaciones != null)
            //{
            //    PedidoRetorno.Observaciones = Utilitario.Decriptar(PedidoRetorno.Observaciones, Utilitario.Llave);
            //}
            return PedidoRetorno;
        }

        public bool ExistePedido(int IdPedido)
        {
            //IdPedido = Utilitario.Encriptar(IdPedido, Utilitario.Llave);
            return PedidProdc.ExistePedido(IdPedido);
        }

        public void Inactivar(DATOS.Pedido Orden)
        {
            //Orden.Consecutivo = Utilitario.Encriptar(Orden.Consecutivo, Utilitario.Llave);
            //Orden.IdCliente = Utilitario.Encriptar(Orden.IdCliente, Utilitario.Llave);
            Orden.Operador = Utilitario.Encriptar(Orden.Operador, Utilitario.Llave);
            //if (Orden.Observaciones != null)
            //{
            //    Orden.Observaciones = Utilitario.Encriptar(Orden.Observaciones, Utilitario.Llave);
            //}
            Orden.Activo = false;
            PedidProdc.Inactivar(Orden);
        }

        public List<DATOS.Pedido> ListarPedido()
        {
            List<DATOS.Pedido> ListaRetorno = PedidProdc.ListarPedido();
            foreach (var item in ListaRetorno)
            {
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.IdCliente = Utilitario.Decriptar(item.IdCliente, Utilitario.Llave);
                item.Operador = Utilitario.Decriptar(item.Operador, Utilitario.Llave);
            //    if (item.Observaciones != null)
            //    {
            //        item.Observaciones = Utilitario.Decriptar(item.Observaciones, Utilitario.Llave);
            //    }
            }
            return ListaRetorno;
        }
    }
}

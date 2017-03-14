using LosNaranjitos.DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS;
using ServiceStack.OrmLite;


namespace LosNaranjitos.DS.Clases
{
    public class DetallePedido : IDetallePedido
    {
        public void ActualizarDetalleOrden(DATOS.DetallePedido DetalleOrden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(DetalleOrden);
        }

        public void AgregarDetalle(DATOS.DetallePedido DetalleOrden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(DetalleOrden);
        }

        public DATOS.DetallePedido BuscarPorConsecutivo(string Conse)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.DetallePedido BusPed = db.Select<DATOS.DetallePedido>(x => x.Consecutivo == Conse).FirstOrDefault();
            return BusPed;
        }

        public DATOS.DetallePedido BuscarPorPedido(string Orden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.DetallePedido BusPed = db.Select<DATOS.DetallePedido>(x => x.IdOrden == Orden).FirstOrDefault();
            return BusPed;
        }

        public DATOS.DetallePedido BuscarPorProducto(string Producto)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.DetallePedido BuscProd = db.Select<DATOS.DetallePedido>(x => x.Producto == Producto).FirstOrDefault();
            return BuscProd;
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.DetallePedido Us = db.Select<DATOS.DetallePedido>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

                if (Us.Consecutivo == Consecutivo)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ExisteDetalle(string IdProducto, string Orden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.DetallePedido Us = db.Select<DATOS.DetallePedido>(x => x.IdOrden == Orden).FirstOrDefault();

                if (Us.Producto == IdProducto)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<DATOS.DetallePedido> ListarDetallesPedido()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.DetallePedido> ListPed = db.Select<DATOS.DetallePedido>();
            return ListPed;
        }
    }
}

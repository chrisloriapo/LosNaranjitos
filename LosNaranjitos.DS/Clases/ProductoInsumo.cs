using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS.Interfaces;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class ProductoInsumo : IProductoInsumo
    {
        public void ActualizarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(ProductoINSUMO);
        }

        public void AgregarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(ProductoINSUMO);
        }

        public DATOS.ProductoInsumo BuscarPorConsecutivo(string Consec)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.ProductoInsumo Us = db.Select<DATOS.ProductoInsumo>(x => x.Consecutivo == Consec).FirstOrDefault();
            return Us;
        }

        public DATOS.ProductoInsumo BuscarPorInsumo(string Insumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.ProductoInsumo Us = db.Select<DATOS.ProductoInsumo>(x => x.IdInsumo == Insumo).FirstOrDefault();
            return Us;
        }

        public DATOS.ProductoInsumo BuscarPorProducto(string Producto)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.ProductoInsumo Us = db.Select<DATOS.ProductoInsumo>(x => x.CodigoProducto == Producto).FirstOrDefault();
            return Us;
        }

        public void EliminarInsumodeProducto(DATOS.ProductoInsumo ProductoINSUMO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Delete(ProductoINSUMO);
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.ProductoInsumo Us = db.Select<DATOS.ProductoInsumo>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public bool ExisteProductoINSUMO(string IdProducto, string IdInsumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.ProductoInsumo Us = db.Select<DATOS.ProductoInsumo>(x => x.IdInsumo == IdInsumo).FirstOrDefault();

                if (Us.IdInsumo == IdInsumo)
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

        public List<DATOS.ProductoInsumo> ListarProductoInsumo()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.ProductoInsumo> Producto = db.Select<DATOS.ProductoInsumo>();
            return Producto;
        }
    }
}

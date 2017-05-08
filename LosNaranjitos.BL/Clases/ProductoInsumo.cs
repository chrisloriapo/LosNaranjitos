using System;
using System.Collections.Generic;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS;

namespace LosNaranjitos.BL.Clases
{
    public class ProductoInsumo : IProductoInsumo
    {
        public DS.Interfaces.IProductoInsumo ProdInsumProcd = new DS.Clases.ProductoInsumo();

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ProdInsumProcd.ExisteConsecutivo(Consecutivo);
        }

        public void ActualizarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
        //    ProductoINSUMO.Consecutivo = Utilitario.Encriptar(ProductoINSUMO.Consecutivo, Utilitario.Llave);
        //    ProductoINSUMO.CodigoProducto = Utilitario.Encriptar(ProductoINSUMO.CodigoProducto, Utilitario.Llave);
        //    ProductoINSUMO.IdInsumo = Utilitario.Encriptar(ProductoINSUMO.IdInsumo, Utilitario.Llave);
            ProdInsumProcd.ActualizarProductoInsumo(ProductoINSUMO);
        }

        public void AgregarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            //ProductoINSUMO.Consecutivo = Utilitario.Encriptar(ProductoINSUMO.Consecutivo, Utilitario.Llave);
            //ProductoINSUMO.CodigoProducto = Utilitario.Encriptar(ProductoINSUMO.CodigoProducto, Utilitario.Llave);
            //ProductoINSUMO.IdInsumo = Utilitario.Encriptar(ProductoINSUMO.IdInsumo, Utilitario.Llave);
            ProdInsumProcd.AgregarProductoInsumo(ProductoINSUMO);
        }

        public DATOS.ProductoInsumo BuscarPorConsecutivo(int Consec)
        {
            //Consec = Utilitario.Encriptar(Consec, Utilitario.Llave);
            DATOS.ProductoInsumo PIRetorno = ProdInsumProcd.BuscarPorConsecutivo(Consec);
            //PIRetorno.Consecutivo = Utilitario.Decriptar(PIRetorno.Consecutivo, Utilitario.Llave);
            //PIRetorno.CodigoProducto = Utilitario.Decriptar(PIRetorno.CodigoProducto, Utilitario.Llave);
            //PIRetorno.IdInsumo = Utilitario.Decriptar(PIRetorno.IdInsumo, Utilitario.Llave);
            return PIRetorno;
        }

        public DATOS.ProductoInsumo BuscarPorInsumo(string Insumo)
        {
            //Insumo = Utilitario.Encriptar(Insumo, Utilitario.Llave);
            DATOS.ProductoInsumo PIRetorno = ProdInsumProcd.BuscarPorInsumo(Insumo);
            //PIRetorno.Consecutivo = Utilitario.Decriptar(PIRetorno.Consecutivo, Utilitario.Llave);
            //PIRetorno.CodigoProducto = Utilitario.Decriptar(PIRetorno.CodigoProducto, Utilitario.Llave);
            //PIRetorno.IdInsumo = Utilitario.Decriptar(PIRetorno.IdInsumo, Utilitario.Llave);
            return PIRetorno;
        }

        public DATOS.ProductoInsumo BuscarPorProducto(string Producto)
        {
            //Producto = Utilitario.Encriptar(Producto, Utilitario.Llave);
            DATOS.ProductoInsumo PIRetorno = ProdInsumProcd.BuscarPorProducto(Producto);
            //PIRetorno.Consecutivo = Utilitario.Decriptar(PIRetorno.Consecutivo, Utilitario.Llave);
            //PIRetorno.CodigoProducto = Utilitario.Decriptar(PIRetorno.CodigoProducto, Utilitario.Llave);
            //PIRetorno.IdInsumo = Utilitario.Decriptar(PIRetorno.IdInsumo, Utilitario.Llave);
            return PIRetorno;
        }

        public bool ExisteProductoINSUMO(string IdProducto, string IdInsumo)
        {
            //IdProducto = Utilitario.Encriptar(IdProducto, Utilitario.Llave);
            //IdInsumo = Utilitario.Encriptar(IdInsumo, Utilitario.Llave);
            return ProdInsumProcd.ExisteProductoINSUMO(IdProducto, IdInsumo);
        }

        public List<DATOS.ProductoInsumo> ListarProductoInsumo()
        {
            List<DATOS.ProductoInsumo> ListaRetorno = ProdInsumProcd.ListarProductoInsumo();
            //foreach (var item in ListaRetorno)
            //{
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.CodigoProducto = Utilitario.Decriptar(item.CodigoProducto, Utilitario.Llave);
            //    item.IdInsumo = Utilitario.Decriptar(item.IdInsumo, Utilitario.Llave);

            //}
            return ListaRetorno;
        }

        public void EliminarInsumodeProducto(DATOS.ProductoInsumo ProductoINSUMO)
        {
        //    ProductoINSUMO.Consecutivo = Utilitario.Encriptar(ProductoINSUMO.Consecutivo, Utilitario.Llave);
        //    ProductoINSUMO.CodigoProducto = Utilitario.Encriptar(ProductoINSUMO.CodigoProducto, Utilitario.Llave);
        //    ProductoINSUMO.IdInsumo = Utilitario.Encriptar(ProductoINSUMO.IdInsumo, Utilitario.Llave);
         ProdInsumProcd.EliminarInsumodeProducto(ProductoINSUMO);
        }
    }
}

using System;
using System.Collections.Generic;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DS;

namespace LosNaranjitos.BL.Clases
{
    public class ProductoInsumo : IProductoInsumo
    {
        public DS.Interfaces.IProductoInsumo ProdInsumProcd = new DS.Clases.ProductoInsumo();
        public void ActualizarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            ProdInsumProcd.ActualizarProductoInsumo(ProductoINSUMO);
        }

        public void AgregarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            ProdInsumProcd.ActualizarProductoInsumo(ProductoINSUMO);
        }

        public DATOS.ProductoInsumo BuscarPorInsumo(string Insumo)
        {
            return ProdInsumProcd.BuscarPorInsumo(Insumo);
        }

        public DATOS.ProductoInsumo BuscarPorProducto(string Producto)
        {
            return ProdInsumProcd.BuscarPorProducto(Producto);
        }

        public bool ExisteProductoINSUMO(string IdProducto, string IdInsumo)
        {
            return ProdInsumProcd.ExisteProductoINSUMO(IdProducto, IdInsumo);
        }

        public List<DATOS.ProductoInsumo> ListarProductoInsumo()
        {
            return ProdInsumProcd.ListarProductoInsumo();
        }
    }
}

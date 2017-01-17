using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class ProductoInsumo : IProductoInsumo
    {
        public void ActualizarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            throw new NotImplementedException();
        }

        public void AgregarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO)
        {
            throw new NotImplementedException();
        }

        public DATOS.ProductoInsumo BuscarPorInsumo(string Insumo)
        {
            throw new NotImplementedException();
        }

        public DATOS.ProductoInsumo BuscarPorProducto(string Producto)
        {
            throw new NotImplementedException();
        }

        public bool ExisteProductoINSUMO(string IdProducto, string IdInsumo)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.ProductoInsumo> ListarProductoInsumo()
        {
            throw new NotImplementedException();
        }
    }
}

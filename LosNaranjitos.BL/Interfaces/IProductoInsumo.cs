using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IProductoInsumo
    {
        List<DATOS.ProductoInsumo> ListarProductoInsumo();

        DATOS.ProductoInsumo BuscarPorProducto(string Producto);

        DATOS.ProductoInsumo BuscarPorInsumo(string Insumo);

        DATOS.ProductoInsumo BuscarPorConsecutivo(int Consec);

        void AgregarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO);

        void ActualizarProductoInsumo(DATOS.ProductoInsumo ProductoINSUMO);

        bool ExisteProductoINSUMO(string IdProducto, string IdInsumo);

        bool ExisteConsecutivo(int Consecutivo);

        void EliminarInsumodeProducto(DATOS.ProductoInsumo ProductoINSUMO);

    }
}

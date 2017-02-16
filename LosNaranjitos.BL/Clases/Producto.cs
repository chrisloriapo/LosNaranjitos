using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Producto : IProducto
    {
        public DS.Interfaces.IProducto ProductProcd = new DS.Clases.Producto();
        public bool ExisteConsecutivo(string Consecutivo)
        {
            return ProductProcd.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarProductO(DATOS.Producto Product)
        {
            ProductProcd.ActualizarProductO(Product);
        }

        public void AgregarProducto(DATOS.Producto Product)
        {
            ProductProcd.AgregarProducto(Product);
        }

        public DATOS.Producto BuscarProducto(string IdProducto)
        {
            return ProductProcd.BuscarProducto(IdProducto);
        }

        public DATOS.Producto BuscarProductoPorConsecutivo(string Consec)
        {
            return ProductProcd.BuscarProductoPorConsecutivo(Consec);
        }

        public DATOS.Producto BuscarProductoPorNombre(string ProductoNombre)
        {
            return ProductProcd.BuscarProductoPorNombre(ProductoNombre);
        }

        public bool ExisteProducto(string IdPro)
        {
            return ProductProcd.ExisteProducto(IdPro);
        }

        public void Inactivar(DATOS.Producto Product)
        {
            Product.Activo = false;
            ProductProcd.Inactivar(Product);
        }

        public List<DATOS.Producto> ListarProductos()
        {
            return ProductProcd.ListarProductos();
        }
    }
}

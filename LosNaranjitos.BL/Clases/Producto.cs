using System.Collections.Generic;
using LosNaranjitos.BL.Interfaces;

namespace LosNaranjitos.BL.Clases
{
    public class Producto : IProducto
    {
        public DS.Interfaces.IProducto ProductProcd = new DS.Clases.Producto();
        public bool ExisteConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ProductProcd.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarProductO(DATOS.Producto Product)
        {
            Product.Consecutivo = Utilitario.Encriptar(Product.Consecutivo, Utilitario.Llave);
            Product.Codigo = Utilitario.Encriptar(Product.Codigo, Utilitario.Llave);
            Product.Nombre = Utilitario.Encriptar(Product.Nombre, Utilitario.Llave);
            Product.Descripcion = Utilitario.Encriptar(Product.Descripcion, Utilitario.Llave);
            Product.Categoria = Utilitario.Encriptar(Product.Categoria, Utilitario.Llave);
            ProductProcd.ActualizarProductO(Product);
        }

        public void AgregarProducto(DATOS.Producto Product)
        {
            Product.Consecutivo = Utilitario.Encriptar(Product.Consecutivo, Utilitario.Llave);
            Product.Codigo = Utilitario.Encriptar(Product.Codigo, Utilitario.Llave);
            Product.Nombre = Utilitario.Encriptar(Product.Nombre, Utilitario.Llave);
            Product.Descripcion = Utilitario.Encriptar(Product.Descripcion, Utilitario.Llave);
            Product.Categoria = Utilitario.Encriptar(Product.Categoria, Utilitario.Llave);
            ProductProcd.AgregarProducto(Product);
        }

        public DATOS.Producto BuscarProducto(string IdProducto)
        {
            IdProducto = Utilitario.Encriptar(IdProducto, Utilitario.Llave);
            DATOS.Producto ProductoRetorno = ProductProcd.BuscarProducto(IdProducto);
            ProductoRetorno.Consecutivo = Utilitario.Decriptar(ProductoRetorno.Consecutivo, Utilitario.Llave);
            ProductoRetorno.Codigo = Utilitario.Decriptar(ProductoRetorno.Codigo, Utilitario.Llave);
            ProductoRetorno.Nombre = Utilitario.Decriptar(ProductoRetorno.Nombre, Utilitario.Llave);
            ProductoRetorno.Descripcion = Utilitario.Decriptar(ProductoRetorno.Descripcion, Utilitario.Llave);
            ProductoRetorno.Categoria = Utilitario.Decriptar(ProductoRetorno.Categoria, Utilitario.Llave);

            return ProductoRetorno;
        }

        public DATOS.Producto BuscarProductoPorConsecutivo(string Consec)
        {
            Consec = Utilitario.Encriptar(Consec, Utilitario.Llave);
            DATOS.Producto ProductoRetorno = ProductProcd.BuscarProductoPorConsecutivo(Consec);
            ProductoRetorno.Consecutivo = Utilitario.Decriptar(ProductoRetorno.Consecutivo, Utilitario.Llave);
            ProductoRetorno.Codigo = Utilitario.Decriptar(ProductoRetorno.Codigo, Utilitario.Llave);
            ProductoRetorno.Nombre = Utilitario.Decriptar(ProductoRetorno.Nombre, Utilitario.Llave);
            ProductoRetorno.Descripcion = Utilitario.Decriptar(ProductoRetorno.Descripcion, Utilitario.Llave);
            ProductoRetorno.Categoria = Utilitario.Decriptar(ProductoRetorno.Categoria, Utilitario.Llave);
            return ProductoRetorno;
        }

        public DATOS.Producto BuscarProductoPorNombre(string ProductoNombre)
        {
            ProductoNombre = Utilitario.Encriptar(ProductoNombre, Utilitario.Llave);
            DATOS.Producto ProductoRetorno = ProductProcd.BuscarProductoPorNombre(ProductoNombre);
            ProductoRetorno.Consecutivo = Utilitario.Decriptar(ProductoRetorno.Consecutivo, Utilitario.Llave);
            ProductoRetorno.Codigo = Utilitario.Decriptar(ProductoRetorno.Codigo, Utilitario.Llave);
            ProductoRetorno.Nombre = Utilitario.Decriptar(ProductoRetorno.Nombre, Utilitario.Llave);
            ProductoRetorno.Descripcion = Utilitario.Decriptar(ProductoRetorno.Descripcion, Utilitario.Llave);
            ProductoRetorno.Categoria = Utilitario.Decriptar(ProductoRetorno.Categoria, Utilitario.Llave);
            return ProductoRetorno;
        }

        public bool ExisteProducto(string IdPro)
        {
            IdPro = Utilitario.Encriptar(IdPro, Utilitario.Llave);
            return ProductProcd.ExisteProducto(IdPro);
        }

        public void Inactivar(DATOS.Producto Product)
        {
            Product.Consecutivo = Utilitario.Encriptar(Product.Consecutivo, Utilitario.Llave);
            Product.Codigo = Utilitario.Encriptar(Product.Codigo, Utilitario.Llave);
            Product.Nombre = Utilitario.Encriptar(Product.Nombre, Utilitario.Llave);
            Product.Descripcion = Utilitario.Encriptar(Product.Descripcion, Utilitario.Llave);
            Product.Categoria = Utilitario.Encriptar(Product.Categoria, Utilitario.Llave);
            Product.Activo = false;
            ProductProcd.Inactivar(Product);
        }

        public List<DATOS.Producto> ListarProductos()
        {
            List<DATOS.Producto> ListaRetorno = ProductProcd.ListarProductos();
            foreach (var item in ListaRetorno)
            {
                item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
                item.Codigo = Utilitario.Decriptar(item.Codigo, Utilitario.Llave);
                item.Nombre = Utilitario.Decriptar(item.Nombre, Utilitario.Llave);
                item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);
                item.Categoria = Utilitario.Decriptar(item.Categoria, Utilitario.Llave);
            }
            return ListaRetorno;
        }
    }
}

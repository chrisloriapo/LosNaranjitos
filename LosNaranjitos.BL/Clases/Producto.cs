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
        public void ActualizarProductO(DATOS.Producto Product)
        {
            throw new NotImplementedException();
        }

        public void AgregarProducto(DATOS.Producto Product)
        {
            throw new NotImplementedException();
        }

        public DATOS.Producto BuscarProducto(string IdProducto)
        {
            throw new NotImplementedException();
        }

        public DATOS.Producto BuscarProductoPorNombre(string ProductoNombre)
        {
            throw new NotImplementedException();
        }

        public bool ExisteProducto(string IdPro)
        {
            throw new NotImplementedException();
        }

        public void Inactivar(DATOS.Producto Product)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.Producto> ListarProductos()
        {
            throw new NotImplementedException();
        }
    }
}

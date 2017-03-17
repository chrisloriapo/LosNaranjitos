using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface IProducto
    {

        List<DATOS.Producto> ListarProductos();

        DATOS.Producto BuscarProducto(string IdProducto);

        DATOS.Producto BuscarProductoPorNombre(string ProductoNombre);

        DATOS.Producto BuscarProductoPorConsecutivo(string Consec);

        void AgregarProducto(DATOS.Producto Product);

        void ActualizarProductO(DATOS.Producto Product);

        void Inactivar(DATOS.Producto Product);

        bool ExisteProducto(string IdPro);

        bool ExisteProductoPorNombre(string Nombre);

        bool ExisteConsecutivo(string Consecutivo);

    }
}

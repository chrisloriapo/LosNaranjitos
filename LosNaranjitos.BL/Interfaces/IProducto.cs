using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IProducto
    {

        List<DATOS.Producto> ListarProductos();

        DATOS.Producto BuscarProducto(string IdProducto);

        DATOS.Producto BuscarProductoPorNombre(string ProductoNombre);

        DATOS.Producto BuscarProductoPorConsecutivo(string Consec);

        bool ExisteProductoPorNombre(string Nombre);

        void AgregarProducto(DATOS.Producto Product);

        void ActualizarProductO(DATOS.Producto Product);

        void Inactivar(DATOS.Producto Product);

        bool ExisteProducto(string IdPro);

        bool ExisteConsecutivo(string Consecutivo);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IProveedor
    {

        List<DATOS.Proveedor> ListarProveedores();

        DATOS.Proveedor BuscarProveedor(string IdProveedor);

        DATOS.Proveedor BuscarProveedorPorConsecutivo(string Consecutivo);

        DATOS.Proveedor BuscarProveedorPorNombre(string IdProveedor);

        void AgregarProveedor(DATOS.Proveedor Pro);

        void ActualizarProveedor(DATOS.Proveedor Pro);

        void Inactivar(DATOS.Proveedor Pro);

        bool ExisteProveedor(string Pro);

        bool ExisteConsecutivo(string Consecutivo);

    }
}

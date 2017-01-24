using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;


namespace LosNaranjitos.BL.Clases
{
    public class Proveedor : IProveedor
    {
        public DS.Interfaces.IProveedor ProvProcd = new DS.Clases.Proveedor();
        public void ActualizarProveedor(DATOS.Proveedor Pro)
        {
            ProvProcd.ActualizarProveedor(Pro);
        }

        public void AgregarProveedor(DATOS.Proveedor Pro)
        {
            ProvProcd.AgregarProveedor(Pro);
        }

        public DATOS.Proveedor BuscarProveedor(string IdProveedor)
        {
            return ProvProcd.BuscarProveedor(IdProveedor);
        }

        public DATOS.Proveedor BuscarProveedorPorNombre(string IdProveedor)
        {
            return ProvProcd.BuscarProveedorPorNombre(IdProveedor);
        }

        public bool ExisteProveedor(string Pro)
        {
            return ProvProcd.ExisteProveedor(Pro);
        }

        public void Inactivar(DATOS.Proveedor Pro)
        {
            Pro.Activo = false;
            ProvProcd.Inactivar(Pro);
        }

        public List<DATOS.Proveedor> ListarProveedores()
        {
            return ProvProcd.ListarProveedores();
        }
    }
}

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

        public bool ExisteConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ProvProcd.ExisteConsecutivo(Consecutivo);
        }

        public void ActualizarProveedor(DATOS.Proveedor Pro)
        {
            Pro.Consecutivo = Utilitario.Encriptar(Pro.Consecutivo, Utilitario.Llave);
            Pro.IdProveedor = Utilitario.Encriptar(Pro.IdProveedor, Utilitario.Llave);
            Pro.Nombre = Utilitario.Encriptar(Pro.Nombre, Utilitario.Llave);
            Pro.Telefono = Utilitario.Encriptar(Pro.Telefono, Utilitario.Llave);
            if (Pro.Correo != null)
            {
                Pro.Correo = Utilitario.Encriptar(Pro.Correo, Utilitario.Llave);
            }
            ProvProcd.ActualizarProveedor(Pro);
        }

        public void AgregarProveedor(DATOS.Proveedor Pro)
        {
            Pro.Consecutivo = Utilitario.Encriptar(Pro.Consecutivo, Utilitario.Llave);
            Pro.IdProveedor = Utilitario.Encriptar(Pro.IdProveedor, Utilitario.Llave);
            Pro.Nombre = Utilitario.Encriptar(Pro.Nombre, Utilitario.Llave);
            Pro.Telefono = Utilitario.Encriptar(Pro.Telefono, Utilitario.Llave);
            if (Pro.Correo != null)
            {
                Pro.Correo = Utilitario.Encriptar(Pro.Correo, Utilitario.Llave);
            }
            ProvProcd.AgregarProveedor(Pro);
        }

        public DATOS.Proveedor BuscarProveedor(string IdProveedor)
        {
            IdProveedor = Utilitario.Encriptar(IdProveedor, Utilitario.Llave);
            DATOS.Proveedor ProveedorRetorno = ProvProcd.BuscarProveedor(IdProveedor);
            ProveedorRetorno.Consecutivo = Utilitario.Decriptar(ProveedorRetorno.Consecutivo, Utilitario.Llave);
            ProveedorRetorno.IdProveedor = Utilitario.Decriptar(ProveedorRetorno.IdProveedor, Utilitario.Llave);
            ProveedorRetorno.Nombre = Utilitario.Decriptar(ProveedorRetorno.Nombre, Utilitario.Llave);
            ProveedorRetorno.Telefono = Utilitario.Decriptar(ProveedorRetorno.Telefono, Utilitario.Llave);
            if (ProveedorRetorno.Correo != null)
            {
                ProveedorRetorno.Correo = Utilitario.Decriptar(ProveedorRetorno.Correo, Utilitario.Llave);
            }
            return ProveedorRetorno;
        }

        public DATOS.Proveedor BuscarProveedorPorConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            DATOS.Proveedor ProveedorRetorno = ProvProcd.BuscarProveedorPorConsecutivo(Consecutivo);
            ProveedorRetorno.Consecutivo = Utilitario.Decriptar(ProveedorRetorno.Consecutivo, Utilitario.Llave);
            ProveedorRetorno.IdProveedor = Utilitario.Decriptar(ProveedorRetorno.IdProveedor, Utilitario.Llave);
            ProveedorRetorno.Nombre = Utilitario.Decriptar(ProveedorRetorno.Nombre, Utilitario.Llave);
            ProveedorRetorno.Telefono = Utilitario.Decriptar(ProveedorRetorno.Telefono, Utilitario.Llave);
            if (ProveedorRetorno.Correo != null)
            {
                ProveedorRetorno.Correo = Utilitario.Decriptar(ProveedorRetorno.Correo, Utilitario.Llave);
            }
            return ProveedorRetorno;
        }

        public DATOS.Proveedor BuscarProveedorPorNombre(string IdProveedor)
        {
            IdProveedor = Utilitario.Encriptar(IdProveedor, Utilitario.Llave);
            DATOS.Proveedor ProveedorRetorno = ProvProcd.BuscarProveedorPorNombre(IdProveedor);
            ProveedorRetorno.Consecutivo = Utilitario.Decriptar(ProveedorRetorno.Consecutivo, Utilitario.Llave);
            ProveedorRetorno.IdProveedor = Utilitario.Decriptar(ProveedorRetorno.IdProveedor, Utilitario.Llave);
            ProveedorRetorno.Nombre = Utilitario.Decriptar(ProveedorRetorno.Nombre, Utilitario.Llave);
            ProveedorRetorno.Telefono = Utilitario.Decriptar(ProveedorRetorno.Telefono, Utilitario.Llave);
            if (ProveedorRetorno.Correo != null)
            {
                ProveedorRetorno.Correo = Utilitario.Decriptar(ProveedorRetorno.Correo, Utilitario.Llave);
            }
            return ProveedorRetorno;
        }

        public bool ExisteProveedor(string Pro)
        {
            Pro = Utilitario.Encriptar(Pro, Utilitario.Llave);
            return ProvProcd.ExisteProveedor(Pro);
        }

        public void Inactivar(DATOS.Proveedor Pro)
        {
            Pro.Consecutivo = Utilitario.Encriptar(Pro.Consecutivo, Utilitario.Llave);
            Pro.IdProveedor = Utilitario.Encriptar(Pro.IdProveedor, Utilitario.Llave);
            Pro.Nombre = Utilitario.Encriptar(Pro.Nombre, Utilitario.Llave);
            Pro.Telefono = Utilitario.Encriptar(Pro.Telefono, Utilitario.Llave);
            if (Pro.Correo != null)
            {
                Pro.Correo = Utilitario.Encriptar(Pro.Correo, Utilitario.Llave);
            }
            Pro.Activo = false;
            ProvProcd.Inactivar(Pro);
        }

        public List<DATOS.Proveedor> ListarProveedores()
        {
            List<DATOS.Proveedor> ListaRetorno = ProvProcd.ListarProveedores();
            foreach (var item in ListaRetorno)
            {
                item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
                item.IdProveedor = Utilitario.Decriptar(item.IdProveedor, Utilitario.Llave);
                item.Nombre = Utilitario.Decriptar(item.Nombre, Utilitario.Llave);
                item.Telefono = Utilitario.Decriptar(item.Telefono, Utilitario.Llave);
                if (item.Correo != null)
                {
                    item.Correo = Utilitario.Decriptar(item.Correo, Utilitario.Llave);
                }
            }
            return ListaRetorno;
        }
    }
}

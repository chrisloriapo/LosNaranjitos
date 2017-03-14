using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
namespace LosNaranjitos.BL.Clases
{
    public class RolUsuario : IRolUsuario
    {
        public DS.Interfaces.IRolUsuario ROLUSER = new DS.Clases.RolUsuario();

        public bool ExisteRol(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ROLUSER.ExisteRol(Consecutivo);
        }

        public void ActualizarRolUsuario(DATOS.RolUsuario Rol)
        {
            Rol.IdRol = Utilitario.Encriptar(Rol.IdRol, Utilitario.Llave);
            Rol.Descripcion = Utilitario.Encriptar(Rol.Descripcion, Utilitario.Llave);
            ROLUSER.ActualizarRolUsuario(Rol);
        }

        public void AgregarRolUsuario(DATOS.RolUsuario Rol)
        {
            Rol.IdRol = Utilitario.Encriptar(Rol.IdRol, Utilitario.Llave);
            Rol.Descripcion = Utilitario.Encriptar(Rol.Descripcion, Utilitario.Llave);
            ROLUSER.ActualizarRolUsuario(Rol);
        }

        public DATOS.RolUsuario BuscarRol(string IdRol)
        {
            IdRol = Utilitario.Encriptar(IdRol, Utilitario.Llave);
            DATOS.RolUsuario RolRetorno = ROLUSER.BuscarRol(IdRol);
            RolRetorno.IdRol = Utilitario.Decriptar(RolRetorno.IdRol, Utilitario.Llave);
            RolRetorno.Descripcion = Utilitario.Decriptar(RolRetorno.Descripcion, Utilitario.Llave);
            return RolRetorno;
        }

        public DATOS.RolUsuario BuscarRolPorDescripcion(string Descripcion)
        {

            Descripcion = Utilitario.Encriptar(Descripcion, Utilitario.Llave);
            DATOS.RolUsuario RolRetorno = ROLUSER.BuscarRolPorDescripcion(Descripcion);
            RolRetorno.IdRol = Utilitario.Decriptar(RolRetorno.IdRol, Utilitario.Llave);
            RolRetorno.Descripcion = Utilitario.Decriptar(RolRetorno.Descripcion, Utilitario.Llave);
            return RolRetorno;
        }

        public void Inactivar(DATOS.RolUsuario Rol)
        {
            Rol.IdRol = Utilitario.Encriptar(Rol.IdRol, Utilitario.Llave);
            Rol.Descripcion = Utilitario.Encriptar(Rol.Descripcion, Utilitario.Llave);
            Rol.Activo = false;
            ROLUSER.Inactivar(Rol);
        }

        public List<DATOS.RolUsuario> ListarRoles()
        {
            List<DATOS.RolUsuario> ListaRetorno = ROLUSER.ListarRoles();
            foreach (var item in ListaRetorno)
            {
                item.IdRol = Utilitario.Decriptar(item.IdRol, Utilitario.Llave);
                item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);
            }

            return ListaRetorno;
        }
    }
}

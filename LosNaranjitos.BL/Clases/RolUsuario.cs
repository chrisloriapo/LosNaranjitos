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

        public void ActualizarRolUsuario(DATOS.RolUsuario Rol)
        {
            ROLUSER.ActualizarRolUsuario(Rol);
        }

        public void AgregarRolUsuario(DATOS.RolUsuario Rol)
        {
            ROLUSER.ActualizarRolUsuario(Rol);
        }

        public DATOS.RolUsuario BuscarRol(int IdRol)
        {
            return ROLUSER.BuscarRol(IdRol);

        }

        public DATOS.RolUsuario BuscarRolPorDescripcion(string Descripcion)
        {

            return ROLUSER.BuscarRolPorDescripcion(Descripcion);
        }

        public bool ExisteRol(int Rol)
        {
            return ROLUSER.ExisteRol(Rol);
        }

        public void Inactivar(DATOS.RolUsuario Rol)
        {
            Rol.Activo = false;
            ROLUSER.Inactivar(Rol);
        }

        public List<DATOS.RolUsuario> ListarRoles()
        {
            return ROLUSER.ListarRoles();
        }
    }
}

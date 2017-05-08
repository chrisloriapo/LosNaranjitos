using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface IRolUsuario
    {
        List<DATOS.RolUsuario> ListarRoles();

        DATOS.RolUsuario BuscarRol(int IdRol);

        DATOS.RolUsuario BuscarRolPorDescripcion(string Descripcion);

        void AgregarRolUsuario(DATOS.RolUsuario Rol);

        void ActualizarRolUsuario(DATOS.RolUsuario Rol);

        void Inactivar(DATOS.RolUsuario Rol);

        bool ExisteRol(int Rol);


    }
}

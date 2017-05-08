using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IUsuario
    {
        List<DATOS.Usuario> ListarUsuarios();

        DATOS.Usuario BuscarUsuario(string iduser);

        DATOS.Usuario BuscarUsuarioXUsername(string username);

        DATOS.Usuario BuscarUsuarioPorConsecutivo(int Consecutv);

        void AgregarUsuario(DATOS.Usuario User);

        void ActualizarUsuario(DATOS.Usuario User);

        void Inactivar(DATOS.Usuario User);

        bool ExisteUsuario(string username);

        bool ExisteConsecutivo(int Consecutivo);

    }
}

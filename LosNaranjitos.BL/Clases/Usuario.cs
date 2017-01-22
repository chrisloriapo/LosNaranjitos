using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Usuario : IUsuario
    {
        public DS.Interfaces.IUsuario USUARIO = new DS.Clases.Usuario();
        public void ActualizarUsuario(DATOS.Usuario User)
        {
            USUARIO.ActualizarUsuario(User);


        }

        public void AgregarUsuario(DATOS.Usuario User)
        {
            USUARIO.AgregarUsuario(User);

        }

        public DATOS.Usuario BuscarUsuario(string iduser)
        {
            return USUARIO.BuscarUsuario(iduser);
        }

        public DATOS.Usuario BuscarUsuarioXUsername(string username)
        {
            return USUARIO.BuscarUsuarioXUsername(username);
        }

        public bool ExisteUsuario(string username)
        {
            return USUARIO.ExisteUsuario(username);
        }

        public void Inactivar(DATOS.Usuario User)
        {
            User.Activo = false;
            USUARIO.Inactivar(User);
        }

        public List<DATOS.Usuario> ListarUsuarios()
        {
            return USUARIO.ListarUsuarios();
        }
    }
}

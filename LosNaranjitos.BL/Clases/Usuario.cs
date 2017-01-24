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
            List<DATOS.Usuario> ListaRetorno = USUARIO.ListarUsuarios();

            foreach (var item in ListaRetorno)
            {
                item.Nombre = Utilitario.Decriptar(item.Nombre, Utilitario.Llave);
                item.Apellido1 = Utilitario.Decriptar(item.Apellido1, Utilitario.Llave);
                item.IdPersonal = Utilitario.Decriptar(item.IdPersonal, Utilitario.Llave);
                item.IdUsuario = Utilitario.Decriptar(item.IdUsuario, Utilitario.Llave);
                item.Telefono = Utilitario.Decriptar(item.Telefono, Utilitario.Llave);
                item.Correo = Utilitario.Decriptar(item.Correo, Utilitario.Llave);
                if (item.Apellido2 != null)
                {
                    item.Apellido2 = Utilitario.Decriptar(item.Apellido2, Utilitario.Llave);
                }
                
                item.Direccion = item.Direccion;
                
            }

            return ListaRetorno;
        }
    }
}

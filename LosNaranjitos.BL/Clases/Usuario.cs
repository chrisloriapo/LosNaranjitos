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
            //User.Consecutivo = Utilitario.Encriptar(User.Consecutivo, Utilitario.Llave);
            User.Username = Utilitario.Encriptar(User.Username, Utilitario.Llave);
            User.Nombre = Utilitario.Encriptar(User.Nombre, Utilitario.Llave);
            User.Apellido1 = Utilitario.Encriptar(User.Apellido1, Utilitario.Llave);
            User.Apellido2 = Utilitario.Encriptar(User.Apellido2, Utilitario.Llave);
            User.Contrasena = Utilitario.Encriptar(User.Contrasena, Utilitario.Llave);
            User.IdPersonal = Utilitario.Encriptar(User.IdPersonal, Utilitario.Llave);
            User.Telefono = Utilitario.Encriptar(User.Telefono, Utilitario.Llave);
            User.Correo = Utilitario.Encriptar(User.Correo, Utilitario.Llave);
            //User.Rol = Utilitario.Encriptar(User.Rol, Utilitario.Llave);
            USUARIO.ActualizarUsuario(User);

        }

        public void AgregarUsuario(DATOS.Usuario User)
        {
            //User.Consecutivo = Utilitario.Encriptar(User.Consecutivo, Utilitario.Llave);
            User.Username = Utilitario.Encriptar(User.Username, Utilitario.Llave);
            User.Nombre = Utilitario.Encriptar(User.Nombre, Utilitario.Llave);
            User.Apellido1 = Utilitario.Encriptar(User.Apellido1, Utilitario.Llave);
            User.Apellido2 = Utilitario.Encriptar(User.Apellido2, Utilitario.Llave);
            User.Contrasena = Utilitario.Encriptar(User.Contrasena, Utilitario.Llave);
            User.IdPersonal = Utilitario.Encriptar(User.IdPersonal, Utilitario.Llave);
            User.Telefono = Utilitario.Encriptar(User.Telefono, Utilitario.Llave);
            User.Correo = Utilitario.Encriptar(User.Correo, Utilitario.Llave);
            //User.Rol = Utilitario.Encriptar(User.Rol, Utilitario.Llave);
            USUARIO.AgregarUsuario(User);

        }

        public DATOS.Usuario BuscarUsuario(string iduser)
        {
            iduser = Utilitario.Encriptar(iduser, Utilitario.Llave);
            DATOS.Usuario User = USUARIO.BuscarUsuario(iduser);
            //User.Consecutivo = Utilitario.Decriptar(User.Consecutivo, Utilitario.Llave);
            User.Username = Utilitario.Decriptar(User.Username, Utilitario.Llave);
            User.Nombre = Utilitario.Decriptar(User.Nombre, Utilitario.Llave);
            User.Apellido1 = Utilitario.Decriptar(User.Apellido1, Utilitario.Llave);
            User.Apellido2 = Utilitario.Decriptar(User.Apellido2, Utilitario.Llave);
            User.Contrasena = Utilitario.Decriptar(User.Contrasena, Utilitario.Llave);
            User.IdPersonal = Utilitario.Decriptar(User.IdPersonal, Utilitario.Llave);
            User.Telefono = Utilitario.Decriptar(User.Telefono, Utilitario.Llave);
            User.Correo = Utilitario.Decriptar(User.Correo, Utilitario.Llave);
            //User.Rol = Utilitario.Decriptar(User.Rol, Utilitario.Llave);
            return User;
        }

        public DATOS.Usuario BuscarUsuarioPorConsecutivo(int Consecutv)
        {
            //Consecutv = Utilitario.Encriptar(Consecutv, Utilitario.Llave);
            DATOS.Usuario User = USUARIO.BuscarUsuarioPorConsecutivo(Consecutv);
            //User.Consecutivo = Utilitario.Decriptar(User.Consecutivo, Utilitario.Llave);
            User.Username = Utilitario.Decriptar(User.Username, Utilitario.Llave);
            User.Nombre = Utilitario.Decriptar(User.Nombre, Utilitario.Llave);
            User.Apellido1 = Utilitario.Decriptar(User.Apellido1, Utilitario.Llave);
            User.Apellido2 = Utilitario.Decriptar(User.Apellido2, Utilitario.Llave);
            User.Contrasena = Utilitario.Decriptar(User.Contrasena, Utilitario.Llave);
            User.IdPersonal = Utilitario.Decriptar(User.IdPersonal, Utilitario.Llave);
            User.Telefono = Utilitario.Decriptar(User.Telefono, Utilitario.Llave);
            User.Correo = Utilitario.Decriptar(User.Correo, Utilitario.Llave);
            //User.Rol = Utilitario.Decriptar(User.Rol, Utilitario.Llave);
            return User;
        }

        public DATOS.Usuario BuscarUsuarioXUsername(string username)
        {
            username = Utilitario.Encriptar(username, Utilitario.Llave);
            DATOS.Usuario User = USUARIO.BuscarUsuarioXUsername(username);
            //User.Consecutivo = Utilitario.Decriptar(User.Consecutivo, Utilitario.Llave);
            User.Username = Utilitario.Decriptar(User.Username, Utilitario.Llave);
            User.Nombre = Utilitario.Decriptar(User.Nombre, Utilitario.Llave);
            User.Apellido1 = Utilitario.Decriptar(User.Apellido1, Utilitario.Llave);
            User.Apellido2 = Utilitario.Decriptar(User.Apellido2, Utilitario.Llave);
            User.Contrasena = Utilitario.Decriptar(User.Contrasena, Utilitario.Llave);
            User.IdPersonal = Utilitario.Decriptar(User.IdPersonal, Utilitario.Llave);
            User.Telefono = Utilitario.Decriptar(User.Telefono, Utilitario.Llave);
            User.Correo = Utilitario.Decriptar(User.Correo, Utilitario.Llave);
            //User.Rol = Utilitario.Decriptar(User.Rol, Utilitario.Llave);
            return User;
        }

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return USUARIO.ExisteConsecutivo(Consecutivo);
        }

        public bool ExisteUsuario(string username)
        {
            username = Utilitario.Encriptar(username, Utilitario.Llave);
            return USUARIO.ExisteUsuario(username);
        }

        public void Inactivar(DATOS.Usuario User)
        {
            //User.Consecutivo = Utilitario.Encriptar(User.Consecutivo, Utilitario.Llave);
            User.Username = Utilitario.Encriptar(User.Username, Utilitario.Llave);
            User.Nombre = Utilitario.Encriptar(User.Nombre, Utilitario.Llave);
            User.Apellido1 = Utilitario.Encriptar(User.Apellido1, Utilitario.Llave);
            User.Apellido2 = Utilitario.Encriptar(User.Apellido2, Utilitario.Llave);
            User.Contrasena = Utilitario.Encriptar(User.Contrasena, Utilitario.Llave);
            User.IdPersonal = Utilitario.Encriptar(User.IdPersonal, Utilitario.Llave);
            User.Telefono = Utilitario.Encriptar(User.Telefono, Utilitario.Llave);
            User.Correo = Utilitario.Encriptar(User.Correo, Utilitario.Llave);
            //User.Rol = Utilitario.Encriptar(User.Rol, Utilitario.Llave);
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
                item.Username = Utilitario.Decriptar(item.Username, Utilitario.Llave);
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

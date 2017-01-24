using LosNaranjitos.DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class Usuario : IUsuario
    {
        public void ActualizarUsuario(DATOS.Usuario User)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(User);
        }

        public void AgregarUsuario(DATOS.Usuario User)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(User);
        }

        public DATOS.Usuario BuscarUsuario(string iduser)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Usuario Us = db.Select<DATOS.Usuario>(x => x.IdPersonal == iduser).FirstOrDefault();
            return Us;
        }

        public DATOS.Usuario BuscarUsuarioXUsername(string username)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Usuario Us = db.Select<DATOS.Usuario>(x => x.IdUsuario == username).FirstOrDefault();
            return Us;
        }

        public bool ExisteUsuario(string username)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Usuario Us = db.Select<DATOS.Usuario>(x => x.IdUsuario == username).FirstOrDefault();

                if (Us.IdUsuario == username)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Inactivar(DATOS.Usuario User)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(User);
        }

        public List<DATOS.Usuario> ListarUsuarios()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Usuario> Usuarios = db.Select<DATOS.Usuario>();

            return Usuarios;
        }
    }
}

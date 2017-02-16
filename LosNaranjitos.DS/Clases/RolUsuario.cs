using LosNaranjitos.DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class RolUsuario : IRolUsuario
    {
        public void ActualizarRolUsuario(DATOS.RolUsuario Rol)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Rol);
        }

        public void AgregarRolUsuario(DATOS.RolUsuario Rol)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Rol);
        }

        public DATOS.RolUsuario BuscarRol(string IdRol)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.RolUsuario ROL = db.Select<DATOS.RolUsuario>(x => x.IdRol == IdRol).FirstOrDefault();
            return ROL;
        }

        public DATOS.RolUsuario BuscarRolPorDescripcion(string Descripcion)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.RolUsuario ROL = db.Select<DATOS.RolUsuario>(x => x.Descripcion == Descripcion).FirstOrDefault();
            return ROL;
        }

        public bool ExisteRol(string Rol)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.RolUsuario ROL = db.Select<DATOS.RolUsuario>(x => x.IdRol == Rol).FirstOrDefault();

                if (ROL.IdRol == Rol)
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

        public void Inactivar(DATOS.RolUsuario Rol)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Rol);
        }

        public List<DATOS.RolUsuario> ListarRoles()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.RolUsuario> Roles = db.Select<DATOS.RolUsuario>();
            return Roles;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS.Interfaces;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class Consecutivo : IConsecutivo
    {
        public void ActualizarConsecutivo(DATOS.Consecutivo Consecutivox)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Consecutivox);
        }

        public void AgregarConsecutivo(DATOS.Consecutivo Consec)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Consec);
        }

        public DATOS.Consecutivo BuscarConsecutivo(string Prefijo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Consecutivo Buscar = db.Select<DATOS.Consecutivo>(x => x.Prefijo == Prefijo).FirstOrDefault();
            return Buscar;
        }

        public DATOS.Consecutivo BuscarConsecutivoPorTipo(string Tipo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Consecutivo Buscar = db.Select<DATOS.Consecutivo>(x => x.Tipo == Tipo).FirstOrDefault();
            return Buscar;        }

        public void EliminarConsecutivo(DATOS.Consecutivo Consec)
        {

            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Delete(Consec);
        }

        public bool ExisteConsecutivo(string Prefijo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Consecutivo Us = db.Select<DATOS.Consecutivo>(x => x.Prefijo == Prefijo).FirstOrDefault();

                if (Us.Prefijo == Prefijo)
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

        public List<DATOS.Consecutivo> ListarConsecutivos()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Consecutivo> ListConse = db.Select<DATOS.Consecutivo>();
            return ListConse;

        }
    }

}

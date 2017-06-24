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
    public class Caja : ICaja
    {
        public void ActualizarCajas(DATOS.Caja CAJA)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(CAJA);
        }

        public void AgregarCaja(DATOS.Caja CAJA)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(CAJA);
        }

        public DATOS.Caja BuscarCaja(int IdCaja)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Caja CAJA = db.Select<DATOS.Caja>(x => x.Consecutivo == IdCaja).FirstOrDefault();
            return CAJA;
        }
/*
        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Caja Us = db.Select<DATOS.Caja>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

                if (Us.Consecutivo == Consecutivo)
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
*/
        public List<DATOS.Caja> ListarCajas()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Caja> caja = db.Select<DATOS.Caja>();
            return caja;
        }
    }
}

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
    public class Cierre : ICierre
    {
        public void ActualizarCierre(DATOS.Cierre CIERRE)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(CIERRE);
        }

        public DATOS.Cierre BuscarCierre(int IdCierre)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Cierre CIERRE = db.Select<DATOS.Cierre>(x => x.Consecutivo == IdCierre).FirstOrDefault();
            return CIERRE;
        }

        public bool ExisteCierreDiario(DateTime Dia)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Cierre Us = db.Select<DATOS.Cierre>(x => x.Fecha == Dia).FirstOrDefault();

                if (Us.Fecha == Dia)
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

        public bool ExisteConsecutivo(int Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Cierre Us = db.Select<DATOS.Cierre>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public List<DATOS.Cierre> ListarRegistros()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Cierre> cierre = db.Select<DATOS.Cierre>();
            return cierre;
        }

        public void NuevoCierre(DATOS.Cierre CIERRE)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(CIERRE);
        }
    }
}

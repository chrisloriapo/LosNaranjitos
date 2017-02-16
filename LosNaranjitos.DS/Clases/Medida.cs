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
    public class Medida : IMedida
    {
        public void ActualizarMEdida(DATOS.Medida MEdida)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(MEdida);
        }

        public void AgregarMedida(DATOS.Medida MEdida)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(MEdida);
        }

        public DATOS.Medida BuscarConsecutivo(string IdMedida)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Medida BuscMed = db.Select<DATOS.Medida>(x => x.Consecutivo == IdMedida).FirstOrDefault();
            return BuscMed;
        }

        public DATOS.Medida BuscarMedida(string IdMedida)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Medida BuscMed = db.Select<DATOS.Medida>(x => x.IdMedida == IdMedida).FirstOrDefault();
            return BuscMed;
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Medida Us = db.Select<DATOS.Medida>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public bool ExisteMEdida(String IdMedida)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Medida Us = db.Select<DATOS.Medida>(x => x.IdMedida == IdMedida).FirstOrDefault();

                if (Us.IdMedida == IdMedida) 
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

        public List<DATOS.Medida> ListarMedidas()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Medida> ListMed = db.Select<DATOS.Medida>();
            return ListMed;
        }
    }
}

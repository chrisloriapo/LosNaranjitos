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
    public class Error : IError
    {
        public void AgregarError(DATOS.Error ERROR)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(ERROR);
        }

        public DATOS.Error BuscarError(int IdError)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Error BuscErr = db.Select<DATOS.Error>(x => x.IdError == IdError).FirstOrDefault();
            return BuscErr;
        }

        public bool ExisteConsecutivo(int Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Error Us = db.Select<DATOS.Error>(x => x.IdError == Consecutivo).FirstOrDefault();

                if (Us.IdError == Consecutivo)
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

        public List<DATOS.Error> ListarErrores()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Error> ListErr = db.Select<DATOS.Error>();
            return ListErr;
        }
    }
}

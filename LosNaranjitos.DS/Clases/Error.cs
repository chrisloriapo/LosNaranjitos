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

        public List<DATOS.Error> ListarErrores()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Error> ListErr = db.Select<DATOS.Error>();
            return ListErr;
        }
    }
}

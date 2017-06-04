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
    public class Parametros : IParametros
    {
        public void ActualizarParametro(DATOS.Parametros Parametro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Parametro);
        }

        public void AgregarParametro(DATOS.Parametros Parametro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Parametro);
        }

        public DATOS.Parametros BuscarParametro(int IDParametro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Parametros Buscar = db.Select<DATOS.Parametros>(x => x.Consecutivo == IDParametro).FirstOrDefault();
            return Buscar;
        }

        public List<DATOS.Parametros> ListarRegistros()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            var Lista = db.Select<DATOS.Parametros>();
            return Lista.ToList();
        }
    }
}

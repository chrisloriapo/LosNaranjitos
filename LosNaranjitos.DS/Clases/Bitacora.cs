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
    public class Bitacora : IBitacora
    {
        public void AgregarBitacora(DATOS.Bitacora BitacorA)
        {

            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(BitacorA);
        }

        public DATOS.Bitacora BuscarBitacora(int IdBitacora)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Bitacora Buscar = db.Select<DATOS.Bitacora>(x => x.IdBitacora == IdBitacora).FirstOrDefault();
            return Buscar;
        }

        public List<DATOS.Bitacora> ListarRegistros()
        {

            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Bitacora> Lista = db.Select<DATOS.Bitacora>();
            return Lista;
        }
    }
}

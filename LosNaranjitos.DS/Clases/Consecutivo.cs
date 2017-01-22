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
        public List<DATOS.Consecutivo> ListarConsecutivos()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Consecutivo> ListConse = db.Select<DATOS.Consecutivo>();
            return ListConse;
        }
    }
}

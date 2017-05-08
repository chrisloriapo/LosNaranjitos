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
            db.Insert(BitacorA);
        }

        public DATOS.Bitacora BuscarBitacora(int IdBitacora)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Bitacora Buscar = db.Select<DATOS.Bitacora>(x => x.IdBitacora == IdBitacora).FirstOrDefault();
            return Buscar;
        }

      /*  public bool ExisteConsecutivo(string consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Bitacora Bit = db.Select<DATOS.Bitacora>(x => x.IdBitacora == consecutivo).FirstOrDefault();

                if (Bit.IdBitacora == consecutivo)
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
        public List<DATOS.Bitacora> ListarRegistros()
        {

            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            var Lista = db.Select<DATOS.Bitacora>().OrderBy(x=>x.Fecha).Take(100);
            return Lista.ToList();
        }
    }
}

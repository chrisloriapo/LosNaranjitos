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
    public class ComboProducto : IComboProducto
    {
        public void ActualizarComboProducto(DATOS.ComboProducto ComboProductos)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(ComboProductos);
        }

        public void AgregarComboProducto(DATOS.ComboProducto ComboProductos)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(ComboProductos);
        }

        public DATOS.ComboProducto BuscarCodigoCombo(string Combo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.ComboProducto BuscarCodComb = db.Select<DATOS.ComboProducto>(x => x.CodCombo == Combo).FirstOrDefault();
            return BuscarCodComb;
        }

        public DATOS.ComboProducto BuscarCodigoConsecutivo(int Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.ComboProducto BuscarCodComb = db.Select<DATOS.ComboProducto>(x => x.Consecutivo == Consecutivo).FirstOrDefault();
            return BuscarCodComb;
        }

        public DATOS.ComboProducto BuscarCodigoProducto(string Producto)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.ComboProducto BuscarCodProd = db.Select<DATOS.ComboProducto>(x => x.CodProducto == Producto).FirstOrDefault();
            return BuscarCodProd;
        }

        public void EliminarProductodeCombo(DATOS.ComboProducto ComboProducto)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Delete(ComboProducto);
        }

        public bool ExisteComboProducto(string Combo, string Producto)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.ComboProducto Us = db.Select<DATOS.ComboProducto>(x => x.CodCombo == Combo).FirstOrDefault();

                if (Us.CodProducto == Producto)
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
                DATOS.ComboProducto Us = db.Select<DATOS.ComboProducto>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public List<DATOS.ComboProducto> ListarComboProductos()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.ComboProducto> LisProd = db.Select<DATOS.ComboProducto>();
            return LisProd;
        }
    }
}

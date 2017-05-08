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
    public class Insumos : IInsumos
    {
        public void ActualizarInsumo(DATOS.Insumos Insumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Insumo);
        }

        public void AgregarInsumo(DATOS.Insumos Insumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Insumo);
        }

        public DATOS.Insumos BuscarInsumoPorConsecutivo(int Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Insumos BuscProv = db.Select<DATOS.Insumos>(x => x.Consecutivo == Consecutivo).FirstOrDefault();
            return BuscProv;
        }

        public DATOS.Insumos BuscarInsumoPorProveedor(string IdProveedor)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Insumos BuscProv = db.Select<DATOS.Insumos>(x => x.Proveedor == IdProveedor).FirstOrDefault();
            return BuscProv;
        }

        public DATOS.Insumos BuscarInsumos(string IdInsumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Insumos BuscInsumo = db.Select<DATOS.Insumos>(x => x.IdInsumo == IdInsumo).FirstOrDefault();
            return BuscInsumo;
        }

        public bool ExisteConsecutivo(int Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Insumos Us = db.Select<DATOS.Insumos>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public bool ExisteInsumo(string IdInsumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Insumos Us = db.Select<DATOS.Insumos>(x => x.IdInsumo == IdInsumo).FirstOrDefault();

                if (Us.IdInsumo == IdInsumo)
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

        public void Inactivar(DATOS.Insumos Insumo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Insumo);
        }

        public List<DATOS.Insumos> ListarInsumos()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Insumos> ListInsum = db.Select<DATOS.Insumos>();
            return ListInsum;
        }
    }
}

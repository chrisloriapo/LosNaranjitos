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
    public class Cargas : ICargas
    {
        public void ActualizarCargas(DATOS.Cargas Carga)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Carga);
        }

        public void AgregarCargas(DATOS.Cargas Carga)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Carga);
        }

        public DATOS.Cargas BuscarCarga(string IdCarga)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Cargas Carga = db.Select<DATOS.Cargas>(x => x.Consecutivo == IdCarga).FirstOrDefault();
            return Carga;
        }

        public DATOS.Cargas BuscarCargaPorDescripcion(string Descripcion)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Cargas Carga = db.Select<DATOS.Cargas>(x => x.Descripcion == Descripcion).FirstOrDefault();
            return Carga;
        }

        public bool ExisteCarga(string IdCarga)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Cargas Carga = db.Select<DATOS.Cargas>(x => x.Consecutivo == IdCarga).FirstOrDefault();

                if (Carga.Consecutivo == IdCarga)
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

        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Cargas Us = db.Select<DATOS.Cargas>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public void Inactivar(DATOS.Cargas Carga)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Carga);
        }

        public List<DATOS.Cargas> ListarCargas()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Cargas> Cargas = db.Select<DATOS.Cargas>();
            return Cargas;
        }
    }
}

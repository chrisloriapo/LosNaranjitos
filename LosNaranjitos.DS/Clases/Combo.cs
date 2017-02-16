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
    public class Combo : ICombo
    {
        public void ActualizarCombo(DATOS.Combo CombO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(CombO);
        }

        public void AgregarCombo(DATOS.Combo CombO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(CombO);
        }

        public DATOS.Combo BuscarCombo(string IdCombo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Combo Buscar = db.Select<DATOS.Combo>(x => x.Codigo == IdCombo).FirstOrDefault();
            return Buscar;
        }

        public DATOS.Combo BuscarComboPorConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Combo Buscarname = db.Select<DATOS.Combo>(x => x.Consecutivo == Consecutivo).FirstOrDefault();
            return Buscarname;
        }

        public DATOS.Combo BuscarComboPorNombre(string ComboNombre)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Combo Buscarname = db.Select<DATOS.Combo>(x => x.Nombre == ComboNombre).FirstOrDefault();
            return Buscarname;
        }

        public bool ExisteCombo(string CombO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Combo Us = db.Select<DATOS.Combo>(x => x.Codigo == CombO).FirstOrDefault();

                if (Us.Codigo == CombO)
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
                DATOS.Combo Us = db.Select<DATOS.Combo>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public void Inactivar(DATOS.Combo CombO)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(CombO);
        }

        public List<DATOS.Combo> ListarCombo()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Combo> LisUsuarios = db.Select<DATOS.Combo>();
            return LisUsuarios;
        }
    }
}

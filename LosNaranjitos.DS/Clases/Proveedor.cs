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
    public class Proveedor : IProveedor
    {
        public void ActualizarProveedor(DATOS.Proveedor Pro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Pro);
        }

        public void AgregarProveedor(DATOS.Proveedor Pro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Pro);
        }

        public DATOS.Proveedor BuscarProveedor(string IdProveedor)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Proveedor BuscProvId = db.Select<DATOS.Proveedor>(x => x.IdProveedor == IdProveedor).FirstOrDefault();
            return BuscProvId;
        }

        public DATOS.Proveedor BuscarProveedorPorConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Proveedor BuscProvNom = db.Select<DATOS.Proveedor>(x => x.Consecutivo == Consecutivo).FirstOrDefault();
            return BuscProvNom;
        }

        public DATOS.Proveedor BuscarProveedorPorNombre(string IdProveedor)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Proveedor BuscProvNom = db.Select<DATOS.Proveedor>(x => x.Nombre == IdProveedor).FirstOrDefault();
            return BuscProvNom;
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Proveedor Us = db.Select<DATOS.Proveedor>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public bool ExisteProveedor(string Pro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Proveedor Us = db.Select<DATOS.Proveedor>(x => x.IdProveedor == Pro).FirstOrDefault();

                if (Us.IdProveedor == Pro)
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

        public void Inactivar(DATOS.Proveedor Pro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Pro);
        }

        public List<DATOS.Proveedor> ListarProveedores()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Proveedor> ListProv = db.Select<DATOS.Proveedor>();
            return ListProv;
        }
    }
}

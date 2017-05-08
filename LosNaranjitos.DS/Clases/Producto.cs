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
    public class Producto : IProducto
    {
        public void ActualizarProductO(DATOS.Producto Product)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Product);
        }

        public void AgregarProducto(DATOS.Producto Product)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Product);
        }

        public DATOS.Producto BuscarProducto(string IdProducto)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Producto Us = db.Select<DATOS.Producto>(x => x.Codigo == IdProducto).FirstOrDefault();
            return Us;
        }

        public DATOS.Producto BuscarProductoPorConsecutivo(int Consec)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Producto BuscProd = db.Select<DATOS.Producto>(x => x.Consecutivo == Consec).FirstOrDefault();
            return BuscProd;
        }

        public DATOS.Producto BuscarProductoPorNombre(string ProductoNombre)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Producto BuscProd = db.Select<DATOS.Producto>(x => x.Nombre == ProductoNombre).FirstOrDefault();
            return BuscProd;
        }

        public bool ExisteConsecutivo(int Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Producto Us = db.Select<DATOS.Producto>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

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

        public bool ExisteProducto(string IdPro)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Producto Us = db.Select<DATOS.Producto>(x => x.Codigo == IdPro).FirstOrDefault();

                if (Us.Codigo == IdPro)
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

        public bool ExisteProductoPorNombre(string Nombre)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Producto Us = db.Select<DATOS.Producto>(x => x.Nombre == Nombre).FirstOrDefault();

                if (Us.Nombre == Nombre)
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

        public void Inactivar(DATOS.Producto Product)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Product);
        }

        public List<DATOS.Producto> ListarProductos()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Producto> ListProd = db.Select<DATOS.Producto>();
            return ListProd;
        }
    }
}

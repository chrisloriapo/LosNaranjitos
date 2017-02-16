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
    public class CategoriaProductos : ICategoriaProductos
    {
        public void ActualizarCategoriaProductosE(DATOS.CategoriaProductos Categoria)
        {

            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Categoria);
        }

        public void AgregarCategoriaProductos(DATOS.CategoriaProductos Categoria)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Categoria);
        }

        public DATOS.CategoriaProductos BuscarCategoriaProductos(string IDCategoria)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.CategoriaProductos Buscar = db.Select<DATOS.CategoriaProductos>(x => x.IdTipo == IDCategoria).FirstOrDefault();
            return Buscar;
        }

        public bool ExisteCategoriaProductos(string IDCategoria)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.CategoriaProductos Existe = db.Select<DATOS.CategoriaProductos>(x => x.IdTipo == IDCategoria).FirstOrDefault();

                if (Existe.IdTipo == IDCategoria)
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

        public void Inactivar(DATOS.CategoriaProductos Categoria)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Categoria);
        }

        public List<DATOS.CategoriaProductos> ListarCategorias()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.CategoriaProductos> Categoria = db.Select<DATOS.CategoriaProductos>();
            return Categoria;
        }
    }
}

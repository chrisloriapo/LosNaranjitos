using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class CategoriaProductos : ICategoriaProductos
    {
        public DS.Interfaces.ICategoriaProductos CPProcedimiento = new DS.Clases.CategoriaProductos();

        public void ActualizarCategoriaProductosE(DATOS.CategoriaProductos Categoria)
        {
            //Categoria.IdTipo = Utilitario.Encriptar(Categoria.IdTipo, Utilitario.Llave);
            //Categoria.Descripcion = Utilitario.Encriptar(Categoria.Descripcion, Utilitario.Llave);
            CPProcedimiento.ActualizarCategoriaProductosE(Categoria);
        }

        public void AgregarCategoriaProductos(DATOS.CategoriaProductos Categoria)
        {
            //Categoria.IdTipo = Utilitario.Encriptar(Categoria.IdTipo, Utilitario.Llave);
            //Categoria.Descripcion = Utilitario.Encriptar(Categoria.Descripcion, Utilitario.Llave);
            CPProcedimiento.AgregarCategoriaProductos(Categoria);
        }

        public DATOS.CategoriaProductos BuscarCategoriaPorDescripcion(string CategoriaName)
        {
            DATOS.CategoriaProductos CategoriaProductosLocal = new DATOS.CategoriaProductos();
            CategoriaProductosLocal = CPProcedimiento.BuscarCategoriaPorDescripcion(CategoriaName);
            return CategoriaProductosLocal;

        }

        public DATOS.CategoriaProductos BuscarCategoriaProductos(int IDCategoria)
        {
            //IDCategoria = Utilitario.Encriptar(IDCategoria, Utilitario.Llave);
            DATOS.CategoriaProductos CategoriaProductosLocal = new DATOS.CategoriaProductos();
            CategoriaProductosLocal = CPProcedimiento.BuscarCategoriaProductos(IDCategoria);
           // DATOS.CategoriaProductos CategoriaProductosRetorno = new DATOS.CategoriaProductos();
            //CategoriaProductosRetorno.IdTipo = Utilitario.Decriptar(CategoriaProductosLocal.IdTipo, Utilitario.Llave);
            //CategoriaProductosRetorno.Descripcion = Utilitario.Decriptar(CategoriaProductosLocal.Descripcion, Utilitario.Llave);
         //   CategoriaProductosRetorno.Activo = CategoriaProductosLocal.Activo;
            return CategoriaProductosLocal;
        }

        public bool ExisteCategoriaProductos(int IDCategoria)
        {
            //IDCategoria = Utilitario.Encriptar(IDCategoria, Utilitario.Llave);
            return CPProcedimiento.ExisteCategoriaProductos(IDCategoria);
        }

        public void Inactivar(DATOS.CategoriaProductos Categoria)
        {
            //Categoria.IdTipo = Utilitario.Encriptar(Categoria.IdTipo, Utilitario.Llave);
            //Categoria.Descripcion = Utilitario.Encriptar(Categoria.Descripcion, Utilitario.Llave);
            Categoria.Activo = false;
            CPProcedimiento.Inactivar(Categoria);

        }

        public List<DATOS.CategoriaProductos> ListarCategorias()
        {
            List<DATOS.CategoriaProductos> ListaRetorno = CPProcedimiento.ListarCategorias();
            //foreach (var item in ListaRetorno)
            //{
            //    item.IdTipo = Utilitario.Decriptar(item.IdTipo, Utilitario.Llave);
            //    item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);

            //}
            return ListaRetorno;
        }
    }
}

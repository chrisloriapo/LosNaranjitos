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
            CPProcedimiento.ActualizarCategoriaProductosE(Categoria);


        }

        public void AgregarCategoriaProductos(DATOS.CategoriaProductos Categoria)
        {
            CPProcedimiento.AgregarCategoriaProductos(Categoria);
        }

        public DATOS.CategoriaProductos BuscarCategoriaProductos(int IDCategoria)
        {
            return CPProcedimiento.BuscarCategoriaProductos(IDCategoria);
        }

        public bool ExisteCategoriaProductos(int IDCategoria)
        {
            return CPProcedimiento.ExisteCategoriaProductos(IDCategoria);
        }

        public void Inactivar(DATOS.CategoriaProductos Categoria)
        {
            Categoria.Activo = false;
            CPProcedimiento.Inactivar(Categoria);

        }

        public List<DATOS.CategoriaProductos> ListarCategorias()
        {
            return CPProcedimiento.ListarCategorias();
        }
    }
}

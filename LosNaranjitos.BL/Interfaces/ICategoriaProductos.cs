﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
   public interface ICategoriaProductos
    {

        List<DATOS.CategoriaProductos> ListarCategorias();

        DATOS.CategoriaProductos BuscarCategoriaProductos(int IDCategoria);

        void AgregarCategoriaProductos(DATOS.CategoriaProductos Categoria);

        void ActualizarCategoriaProductosE(DATOS.CategoriaProductos Categoria);

        void Inactivar(DATOS.CategoriaProductos Categoria);

        bool ExisteCategoriaProductos(int IDCategoria);

        DATOS.CategoriaProductos BuscarCategoriaPorDescripcion(string CategoriaName);

    }
}

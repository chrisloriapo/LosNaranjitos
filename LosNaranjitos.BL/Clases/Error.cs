﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Error : IError
    {
        public DS.Interfaces.IError ErrorProces = new DS.Clases.Error();
        public void AgregarError(DATOS.Error ERROR)
        {
            ErrorProces.AgregarError(ERROR);
        }

        public DATOS.Error BuscarError(int IdError)
        {
            return ErrorProces.BuscarError(IdError);
        }

        public List<DATOS.Error> ListarErrores()
        {
            return ErrorProces.ListarErrores();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface ICierre
    {
        List<DATOS.Cierre> ListarRegistros();

        DATOS.Cierre BuscarCierre(string IdCierre);

        void NuevoCierre(DATOS.Cierre CIERRE);

        void ActualizarCierre(DATOS.Cierre CIERRE);

        bool ExisteConsecutivo(string Consecutivo);

    }
}
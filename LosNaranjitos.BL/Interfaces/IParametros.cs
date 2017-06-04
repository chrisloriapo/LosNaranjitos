using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IParametros
    {
        List<DATOS.Parametros> ListarRegistros();

        DATOS.Parametros BuscarParametro(int IDParametro);

        void AgregarParametro(DATOS.Parametros Parametro);

        void ActualizarParametro(DATOS.Parametros Parametro);
    }
}

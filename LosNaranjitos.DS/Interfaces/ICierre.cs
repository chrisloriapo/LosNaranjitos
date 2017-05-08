using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface ICierre
    {
        List<DATOS.Cierre> ListarRegistros();

        DATOS.Cierre BuscarCierre(int IdCierre);

        void NuevoCierre(DATOS.Cierre CIERRE);

        void ActualizarCierre(DATOS.Cierre CIERRE);

        bool ExisteConsecutivo(int Consecutivo);

        bool ExisteCierreDiario(DateTime Dia);


    }
}

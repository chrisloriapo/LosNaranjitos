using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface IConsecutivo

    {
        List<DATOS.Consecutivo> ListarConsecutivos();

        DATOS.Consecutivo BuscarConsecutivo(string Prefijo);

        DATOS.Consecutivo BuscarConsecutivoPorTipo(string Tipo);


        void AgregarConsecutivo(DATOS.Consecutivo Consec);

        void EliminarConsecutivo(DATOS.Consecutivo Consec);
        
        void ActualizarConsecutivo(DATOS.Consecutivo Consecutivox);

        bool ExisteConsecutivo(string Prefijo);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface IBitacora
    {
        List<DATOS.Bitacora> ListarRegistros();

        DATOS.Bitacora BuscarBitacora(int IdBitacora);
                
        void AgregarBitacora(DATOS.Bitacora BitacorA);

       // bool ExisteConsecutivo(int consecutivo);

    }
}

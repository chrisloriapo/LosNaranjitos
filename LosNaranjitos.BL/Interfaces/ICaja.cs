using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface ICaja
    {
        List<DATOS.Caja> ListarCajas();

        DATOS.Caja BuscarCaja(int IdCaja);

        void AgregarCaja(DATOS.Caja CAJA);

        void ActualizarCajas(DATOS.Caja CAJA);

        //bool ExisteConsecutivo(string Consecutivo);
    }
}

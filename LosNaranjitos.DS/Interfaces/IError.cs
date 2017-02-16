using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
 public   interface IError
    {
        List<DATOS.Error> ListarErrores();

        DATOS.Error BuscarError(string IdError);

        void AgregarError(DATOS.Error ERROR);

        bool ExisteConsecutivo(string Consecutivo);


    }
}

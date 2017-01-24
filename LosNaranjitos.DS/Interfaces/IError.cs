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

        DATOS.Error BuscarError(int IdError);

        void AgregarError(DATOS.Error ERROR);

    }
}

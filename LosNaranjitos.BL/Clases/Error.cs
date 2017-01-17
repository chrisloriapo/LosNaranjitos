using System;
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
        public void AgregarError(DATOS.Error ERROR)
        {
            throw new NotImplementedException();
        }

        public DATOS.Error BuscarError(int IdError)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.Error> ListarErrores()
        {
            throw new NotImplementedException();
        }
    }
}

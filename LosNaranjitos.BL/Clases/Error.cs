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
        public DS.Interfaces.IError ErrorProces = new DS.Clases.Error();

        public void AgregarError(DATOS.Error ERROR)
        {
            //ERROR.IdError = Utilitario.Encriptar(ERROR.IdError, Utilitario.Llave);
            //ERROR.Tipo = Utilitario.Encriptar(ERROR.Tipo, Utilitario.Llave);
            //ERROR.Descripcion = Utilitario.Encriptar(ERROR.Descripcion, Utilitario.Llave);
            ErrorProces.AgregarError(ERROR);
        }

        public DATOS.Error BuscarError(int IdError)
        {
            //IdError = Utilitario.Encriptar(IdError, Utilitario.Llave);
            DATOS.Error ErrorRetorno = ErrorProces.BuscarError(IdError);
            //ErrorRetorno.IdError = Utilitario.Decriptar(ErrorRetorno.IdError, Utilitario.Llave);
            //ErrorRetorno.Tipo = Utilitario.Decriptar(ErrorRetorno.Tipo, Utilitario.Llave);
            //ErrorRetorno.Descripcion = Utilitario.Decriptar(ErrorRetorno.Descripcion, Utilitario.Llave);
            return ErrorRetorno;
        }

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ErrorProces.ExisteConsecutivo(Consecutivo);
        }

        public List<DATOS.Error> ListarErrores()
        {
            List<DATOS.Error> ListaRetorno = ErrorProces.ListarErrores();
            //foreach (var item in ListaRetorno)
            //{
            //    item.IdError = Utilitario.Decriptar(item.IdError, Utilitario.Llave);
            //    item.Tipo = Utilitario.Decriptar(item.Tipo, Utilitario.Llave);
            //    item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);
            //  }
            return ListaRetorno;
        }
    }
}

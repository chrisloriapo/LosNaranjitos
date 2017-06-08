using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Parametros : IParametros
    {
        public DS.Interfaces.IParametros ParametrosProcedure = new DS.Clases.Parametros();

        public void ActualizarParametro(DATOS.Parametros Parametro)
        {
            Parametro.Operador = Utilitario.Encriptar(Parametro.Operador, Utilitario.Llave);
            ParametrosProcedure.ActualizarParametro(Parametro);
        }

        public void AgregarParametro(DATOS.Parametros Parametro)
        {
            Parametro.Operador = Utilitario.Encriptar(Parametro.Operador, Utilitario.Llave);
            ParametrosProcedure.AgregarParametro(Parametro);
        }

        public DATOS.Parametros BuscarParametro(int IDParametro)
        {
            DATOS.Parametros ParametroRetorno = ParametrosProcedure.BuscarParametro(IDParametro);
            ParametroRetorno.Operador = Utilitario.Decriptar(ParametroRetorno.Operador, Utilitario.Llave);
            return ParametroRetorno;
        }

        public DATOS.Parametros BuscarParametrosPorNombre(string ParameterName)
        {
            DATOS.Parametros ParametroRetorno = ParametrosProcedure.BuscarParametrosPorNombre(ParameterName);
            ParametroRetorno.Operador = Utilitario.Decriptar(ParametroRetorno.Operador, Utilitario.Llave);
            return ParametroRetorno;
        }

        public List<DATOS.Parametros> ListarRegistros()
        {
            List<DATOS.Parametros> ListaRetorno = ParametrosProcedure.ListarRegistros();
            foreach (var item in ListaRetorno)
            {

                item.Operador = Utilitario.Decriptar(item.Operador, Utilitario.Llave);
            }
            return ListaRetorno;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Consecutivo : IConsecutivo
    {

        public DS.Interfaces.IConsecutivo Consecs = new DS.Clases.Consecutivo();

        public void ActualizarConsecutivo(DATOS.Consecutivo Consecutivox)
        {
            Consecutivox.Prefijo = Utilitario.Encriptar(Consecutivox.Prefijo, Utilitario.Llave);
            Consecutivox.Tipo = Utilitario.Encriptar(Consecutivox.Tipo, Utilitario.Llave);
            Consecs.ActualizarConsecutivo(Consecutivox);
        }

        public void AgregarConsecutivo(DATOS.Consecutivo Consec)
        {
            Consec.Prefijo = Utilitario.Encriptar(Consec.Prefijo, Utilitario.Llave);
            Consec.Tipo = Utilitario.Encriptar(Consec.Tipo, Utilitario.Llave);
            Consecs.AgregarConsecutivo(Consec);
        }

        public DATOS.Consecutivo BuscarConsecutivo(string Prefijo)
        {
            Prefijo = Utilitario.Encriptar(Prefijo, Utilitario.Llave);
            DATOS.Consecutivo ConsecutivoRetorno = Consecs.BuscarConsecutivo(Prefijo);
            ConsecutivoRetorno.Prefijo = Utilitario.Decriptar(ConsecutivoRetorno.Prefijo, Utilitario.Llave);
            ConsecutivoRetorno.Tipo = Utilitario.Decriptar(ConsecutivoRetorno.Tipo, Utilitario.Llave);
            return ConsecutivoRetorno;
        }

        public DATOS.Consecutivo BuscarConsecutivoPorTipo(string Tipo)
        {
            Tipo = Utilitario.Encriptar(Tipo, Utilitario.Llave);
            DATOS.Consecutivo ConsecutivoRetorno = Consecs.BuscarConsecutivoPorTipo(Tipo);
            ConsecutivoRetorno.Prefijo = Utilitario.Decriptar(ConsecutivoRetorno.Prefijo, Utilitario.Llave);
            ConsecutivoRetorno.Tipo = Utilitario.Decriptar(ConsecutivoRetorno.Tipo, Utilitario.Llave);
            return ConsecutivoRetorno;
        }

        public void EliminarConsecutivo(DATOS.Consecutivo Consec)
        {
            Consec.Prefijo = Utilitario.Encriptar(Consec.Prefijo, Utilitario.Llave);
            Consec.Tipo = Utilitario.Encriptar(Consec.Tipo, Utilitario.Llave);
            Consecs.EliminarConsecutivo(Consec);
        }

        public bool ExisteConsecutivo(string Prefijo)
        {
            Prefijo = Utilitario.Encriptar(Prefijo, Utilitario.Llave);
            return Consecs.ExisteConsecutivo(Prefijo);
        }

        public List<DATOS.Consecutivo> ListarConsecutivos()
        {
            List<DATOS.Consecutivo> ListaRetorno = Consecs.ListarConsecutivos();
            foreach (var item in ListaRetorno)
            {
                item.Prefijo = Utilitario.Decriptar(item.Prefijo, Utilitario.Llave);
                item.Tipo = Utilitario.Decriptar(item.Tipo, Utilitario.Llave);
            }
            return ListaRetorno;
        }
    }
}

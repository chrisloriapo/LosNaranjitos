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
            Consecs.ActualizarConsecutivo(Consecutivox);
        }

        public void AgregarConsecutivo(DATOS.Consecutivo Consec)
        {
            Consecs.AgregarConsecutivo(Consec);
        }

        public DATOS.Consecutivo BuscarConsecutivo(string Prefijo)
        {
            return BuscarConsecutivo(Prefijo);
        }

        public void EliminarConsecutivo(DATOS.Consecutivo Consec)
        {
            Consecs.EliminarConsecutivo(Consec);
        }

        public bool ExisteConsecutivo(string Prefijo)
        {
            return Consecs.ExisteConsecutivo(Prefijo);
        }

        public List<DATOS.Consecutivo> ListarConsecutivos()
        {
            return Consecs.ListarConsecutivos();
        }
    }
}

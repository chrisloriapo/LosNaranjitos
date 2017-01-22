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
        public List<DATOS.Consecutivo> ListarConsecutivos()
        {
            return Consecs.ListarConsecutivos();
        }
    }
}

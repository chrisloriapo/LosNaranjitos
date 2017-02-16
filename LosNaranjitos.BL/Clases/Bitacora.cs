using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Bitacora : IBitacora
    {
        public DS.Interfaces.IBitacora BProcedimiento = new DS.Clases.Bitacora();
        public void AgregarBitacora(DATOS.Bitacora BitacorA)
        {
            BProcedimiento.AgregarBitacora(BitacorA);

        }

        public DATOS.Bitacora BuscarBitacora(string IdBitacora)
        {
            return BProcedimiento.BuscarBitacora(IdBitacora);
        }

        public bool ExisteConsecutivo(string consecutivo)
        {
            return BProcedimiento.ExisteConsecutivo(consecutivo);
        }

        public List<DATOS.Bitacora> ListarRegistros()
        {
            return BProcedimiento.ListarRegistros();
        }
    }
}

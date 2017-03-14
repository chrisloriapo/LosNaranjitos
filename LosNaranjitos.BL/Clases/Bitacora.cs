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
            BitacorA.IdBitacora = Utilitario.Encriptar(BitacorA.IdBitacora, Utilitario.Llave);
            BitacorA.Accion = Utilitario.Encriptar(BitacorA.Accion, Utilitario.Llave);
            BitacorA.Usuario = Utilitario.Encriptar(BitacorA.Usuario, Utilitario.Llave);
            BProcedimiento.AgregarBitacora(BitacorA);
        }

        public DATOS.Bitacora BuscarBitacora(string IdBitacora)
        {
            IdBitacora = Utilitario.Encriptar(IdBitacora, Utilitario.Llave);
            DATOS.Bitacora BitacoraRetorno = BProcedimiento.BuscarBitacora(IdBitacora);
            BitacoraRetorno.IdBitacora = Utilitario.Decriptar(BitacoraRetorno.IdBitacora, Utilitario.Llave);
            BitacoraRetorno.Accion = Utilitario.Decriptar(BitacoraRetorno.Accion, Utilitario.Llave);
            BitacoraRetorno.Usuario = Utilitario.Decriptar(BitacoraRetorno.Usuario, Utilitario.Llave);
            return BitacoraRetorno;
        }

        public bool ExisteConsecutivo(string consecutivo)
        {
            consecutivo = Utilitario.Encriptar(consecutivo, Utilitario.Llave);
            return BProcedimiento.ExisteConsecutivo(consecutivo);
        }

        public List<DATOS.Bitacora> ListarRegistros()
        {
            List<DATOS.Bitacora> ListaRetorno = BProcedimiento.ListarRegistros();
            foreach (var item in ListaRetorno)
            {
                item.Accion = Utilitario.Decriptar(item.Accion, Utilitario.Llave);
                item.IdBitacora = Utilitario.Decriptar(item.IdBitacora, Utilitario.Llave);
                item.Usuario = Utilitario.Decriptar(item.Usuario, Utilitario.Llave);
            }
            return ListaRetorno;
        }
    }
}

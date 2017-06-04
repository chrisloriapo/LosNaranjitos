using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Clases
{
    public class Cierre : ICierre
    {
        public DS.Interfaces.ICierre CierreOp = new DS.Clases.Cierre();

        public void ActualizarCierre(DATOS.Cierre CIERRE)
        {
            //CIERRE.Consecutivo = Utilitario.Encriptar(CIERRE.Consecutivo, Utilitario.Llave);
            //CIERRE.Tipo = Utilitario.Encriptar(CIERRE.Tipo, Utilitario.Llave);
            CIERRE.Usuario = Utilitario.Encriptar(CIERRE.Usuario, Utilitario.Llave);
            CierreOp.ActualizarCierre(CIERRE);
        }

        public DATOS.Cierre BuscarCierre(int IdCierre)
        {
            //IdCierre = Utilitario.Encriptar(IdCierre, Utilitario.Llave);
            DATOS.Cierre CierresRetorno = CierreOp.BuscarCierre(IdCierre);
            //CierresRetorno.Consecutivo = Utilitario.Decriptar(CierresRetorno.Consecutivo, Utilitario.Llave);
            //CierresRetorno.Tipo = Utilitario.Decriptar(CierresRetorno.Tipo, Utilitario.Llave);
            CierresRetorno.Usuario = Utilitario.Decriptar(CierresRetorno.Usuario, Utilitario.Llave);
            return CierresRetorno;
        }

        public bool ExisteCierreDiario(DateTime Dia)
        {
            return CierreOp.ExisteCierreDiario(Dia);
        }

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return CierreOp.ExisteConsecutivo(Consecutivo);
        }

        public List<DATOS.Cierre> ListarRegistros()
        {
            List<DATOS.Cierre> ListaRetorno = CierreOp.ListarRegistros();
            foreach (var item in ListaRetorno)
            {
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.Tipo = Utilitario.Decriptar(item.Tipo, Utilitario.Llave);
               item.Usuario = Utilitario.Decriptar(item.Usuario, Utilitario.Llave);
            }
            return ListaRetorno;
        }

        public void NuevoCierre(DATOS.Cierre CIERRE)
        {
            //CIERRE.Consecutivo = Utilitario.Encriptar(CIERRE.Consecutivo, Utilitario.Llave);
            //CIERRE.Tipo = Utilitario.Encriptar(CIERRE.Tipo, Utilitario.Llave);
            CIERRE.Usuario = Utilitario.Encriptar(CIERRE.Usuario, Utilitario.Llave);
            CierreOp.NuevoCierre(CIERRE);
        }
    }
}

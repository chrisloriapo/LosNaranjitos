using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Caja : ICaja
    {
        public DS.Interfaces.ICaja CajaOP = new DS.Clases.Caja();

        public void ActualizarCajas(DATOS.Caja CAJA)
        {
            //CAJA.Consecutivo = Utilitario.Encriptar(CAJA.Consecutivo, Utilitario.Llave);
            //CAJA.OperadorActual = Utilitario.Encriptar(CAJA.OperadorActual, Utilitario.Llave);
            CajaOP.ActualizarCajas(CAJA);
        }

        public void AgregarCaja(DATOS.Caja CAJA)
        {
            //CAJA.Consecutivo = Utilitario.Encriptar(CAJA.Consecutivo, Utilitario.Llave);
            //CAJA.OperadorActual = Utilitario.Encriptar(CAJA.OperadorActual, Utilitario.Llave);
            CajaOP.AgregarCaja(CAJA);
        }

        public DATOS.Caja BuscarCaja(int IdCaja)
        {
            //IdCaja = Utilitario.Encriptar(IdCaja, Utilitario.Llave);
            DATOS.Caja CajasRetorno = CajaOP.BuscarCaja(IdCaja);
            //CajasRetorno.Consecutivo = Utilitario.Decriptar(CajasRetorno.Consecutivo, Utilitario.Llave);
            //CajasRetorno.OperadorActual = Utilitario.Decriptar(CajasRetorno.OperadorActual, Utilitario.Llave);
            return CajasRetorno;
        }

        //public bool ExisteConsecutivo(int Consecutivo)
        //{
        //    //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
        //    return CajaOP.ExisteConsecutivo(Consecutivo);
        //}

        public List<DATOS.Caja> ListarCajas()
        {
            List<DATOS.Caja> ListaRetorno = CajaOP.ListarCajas();
            //foreach (var item in ListaRetorno)
            //{
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.OperadorActual = Utilitario.Decriptar(item.OperadorActual, Utilitario.Llave);
            //}
            return ListaRetorno;
        }
    }
}

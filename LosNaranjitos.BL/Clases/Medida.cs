using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Medida : IMedida
    {
        public DS.Interfaces.IMedida MedProced = new DS.Clases.Medida();

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return MedProced.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarMEdida(DATOS.Medida MEdida)
        {
            //MEdida.Consecutivo = Utilitario.Encriptar(MEdida.Consecutivo, Utilitario.Llave);
            //MEdida.Descripcion = Utilitario.Encriptar(MEdida.Descripcion, Utilitario.Llave);
            //MEdida.IdMedida = Utilitario.Encriptar(MEdida.IdMedida, Utilitario.Llave);
            MedProced.ActualizarMEdida(MEdida);
        }

        public void AgregarMedida(DATOS.Medida MEdida)
        {
            //MEdida.Consecutivo = Utilitario.Encriptar(MEdida.Consecutivo, Utilitario.Llave);
            //MEdida.Descripcion = Utilitario.Encriptar(MEdida.Descripcion, Utilitario.Llave);
            //MEdida.IdMedida = Utilitario.Encriptar(MEdida.IdMedida, Utilitario.Llave);
            MedProced.AgregarMedida(MEdida);
        }

        public DATOS.Medida BuscarConsecutivo(int IdMedida)
        {
            //IdMedida = Utilitario.Encriptar(IdMedida, Utilitario.Llave);
            DATOS.Medida MedidaRetorno = MedProced.BuscarConsecutivo(IdMedida);
            //MedidaRetorno.Consecutivo = Utilitario.Decriptar(MedidaRetorno.Consecutivo, Utilitario.Llave);
            //MedidaRetorno.IdMedida = Utilitario.Decriptar(MedidaRetorno.IdMedida, Utilitario.Llave);
            //MedidaRetorno.Descripcion = Utilitario.Decriptar(MedidaRetorno.Descripcion, Utilitario.Llave);
            return MedidaRetorno;
        }

        public DATOS.Medida BuscarMedida(string IdMedida)
        {
            //IdMedida = Utilitario.Encriptar(IdMedida, Utilitario.Llave);
            DATOS.Medida MedidaRetorno = MedProced.BuscarMedida(IdMedida);
            //MedidaRetorno.Consecutivo = Utilitario.Decriptar(MedidaRetorno.Consecutivo, Utilitario.Llave);
            //MedidaRetorno.IdMedida = Utilitario.Decriptar(MedidaRetorno.IdMedida, Utilitario.Llave);
            //MedidaRetorno.Descripcion = Utilitario.Decriptar(MedidaRetorno.Descripcion, Utilitario.Llave);
            return MedidaRetorno;
        }

        public bool ExisteMEdida(string IdMedida)
        {
            //IdMedida = Utilitario.Encriptar(IdMedida, Utilitario.Llave);
            return MedProced.ExisteMEdida(IdMedida);
        }

        public List<DATOS.Medida> ListarMedidas()
        {
            List<DATOS.Medida> ListaRetorno = MedProced.ListarMedidas();
            //foreach (var item in ListaRetorno)
            //{
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);
            //    item.IdMedida = Utilitario.Decriptar(item.IdMedida, Utilitario.Llave);
            //}
            return ListaRetorno; ;
        }
    }
}

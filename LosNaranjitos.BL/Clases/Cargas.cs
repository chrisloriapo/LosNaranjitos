using LosNaranjitos.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Cargas : ICargas
    {
        public DS.Interfaces.ICargas CargasOP = new DS.Clases.Cargas();

        public void ActualizarCargas(DATOS.Cargas Carga)
        {
            Carga.Consecutivo = Utilitario.Encriptar(Carga.Consecutivo, Utilitario.Llave);
            Carga.Descripcion = Utilitario.Encriptar(Carga.Descripcion, Utilitario.Llave);
            CargasOP.ActualizarCargas(Carga);
        }

        public void AgregarCargas(DATOS.Cargas Carga)
        {
            Carga.Consecutivo = Utilitario.Encriptar(Carga.Consecutivo, Utilitario.Llave);
            Carga.Descripcion = Utilitario.Encriptar(Carga.Descripcion, Utilitario.Llave);
            CargasOP.AgregarCargas(Carga);
        }

        public DATOS.Cargas BuscarCarga(string IdCarga)
        {
            IdCarga = Utilitario.Encriptar(IdCarga, Utilitario.Llave);
            DATOS.Cargas CargasRetorno = CargasOP.BuscarCarga(IdCarga);
            CargasRetorno.Consecutivo = Utilitario.Decriptar(CargasRetorno.Consecutivo, Utilitario.Llave);
            CargasRetorno.Descripcion = Utilitario.Decriptar(CargasRetorno.Descripcion, Utilitario.Llave);
            return CargasRetorno;
        }

        public DATOS.Cargas BuscarCargaPorDescripcion(string Descripcion)
        {
            Descripcion = Utilitario.Encriptar(Descripcion, Utilitario.Llave);
            DATOS.Cargas CargasRetorno = CargasOP.BuscarCargaPorDescripcion(Descripcion);
            CargasRetorno.Consecutivo = Utilitario.Decriptar(CargasRetorno.Consecutivo, Utilitario.Llave);
            CargasRetorno.Descripcion = Utilitario.Decriptar(CargasRetorno.Descripcion, Utilitario.Llave);
            return CargasRetorno;
        }

        public bool ExisteCarga(string IdCarga)
        {
            IdCarga = Utilitario.Encriptar(IdCarga, Utilitario.Llave);
            return CargasOP.ExisteCarga(IdCarga);
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return CargasOP.ExisteConsecutivo(Consecutivo);
        }

        public void Inactivar(DATOS.Cargas Carga)
        {
            Carga.Consecutivo = Utilitario.Encriptar(Carga.Consecutivo, Utilitario.Llave);
            Carga.Descripcion = Utilitario.Encriptar(Carga.Descripcion, Utilitario.Llave);
            Carga.Activo = false;
            CargasOP.ActualizarCargas(Carga);
        }

        public List<DATOS.Cargas> ListarCargas()
        {
            List<DATOS.Cargas> ListaRetorno = CargasOP.ListarCargas();
            foreach (var item in ListaRetorno)
            {
                item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
                item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);
            }
            return ListaRetorno;
        }
    }
}

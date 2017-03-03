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
            CargasOP.ActualizarCargas(Carga);
        }

        public void AgregarCargas(DATOS.Cargas Carga)
        {
            CargasOP.AgregarCargas(Carga);
        }

        public DATOS.Cargas BuscarCarga(string IdCarga)
        {
            return CargasOP.BuscarCarga(IdCarga);
        }

        public DATOS.Cargas BuscarCargaPorDescripcion(string Descripcion)
        {
            return CargasOP.BuscarCargaPorDescripcion(Descripcion);
        }

        public bool ExisteCarga(string IdCarga)
        {
            return CargasOP.ExisteCarga(IdCarga);
        }

        public void Inactivar(DATOS.Cargas Carga)
        {
            CargasOP.ActualizarCargas(Carga);
        }

        public List<DATOS.Cargas> ListarCargas()
        {
            return CargasOP.ListarCargas();
        }
    }
}

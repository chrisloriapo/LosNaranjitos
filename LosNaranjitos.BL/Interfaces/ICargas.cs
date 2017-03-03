using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface ICargas
    {
        List<DATOS.Cargas> ListarCargas();

        DATOS.Cargas BuscarCarga(string IdCarga);

        DATOS.Cargas BuscarCargaPorDescripcion(string Descripcion);

        void AgregarCargas(DATOS.Cargas Carga);

        void ActualizarCargas(DATOS.Cargas Carga);

        void Inactivar(DATOS.Cargas Carga);

        bool ExisteCarga(string IdCarga);
    }
}

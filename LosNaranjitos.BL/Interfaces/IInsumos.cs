using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IInsumos
    {
        List<DATOS.Insumos> ListarInsumos();

        DATOS.Insumos BuscarInsumos(string IdInsumo);

        DATOS.Insumos BuscarInsumoPorProveedor(string IdProveedor);

        void AgregarInsumo(DATOS.Insumos Insumo);

        void ActualizarInsumo(DATOS.Insumos Insumo);

        void Inactivar(DATOS.Insumos Insumo);

        bool ExisteInsumo(string IdInsumo);
    }
}

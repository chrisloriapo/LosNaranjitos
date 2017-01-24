using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Insumos : IInsumos
    {
        public DS.Interfaces.IInsumos IsumosProcde = new DS.Clases.Insumos();
        public void ActualizarInsumo(DATOS.Insumos Insumo)
        {
            IsumosProcde.ActualizarInsumo(Insumo);
        }

        public void AgregarInsumo(DATOS.Insumos Insumo)
        {
            IsumosProcde.AgregarInsumo(Insumo);
        }

        public DATOS.Insumos BuscarInsumoPorProveedor(string IdProveedor)
        {
            return IsumosProcde.BuscarInsumoPorProveedor(IdProveedor);
        }

        public DATOS.Insumos BuscarInsumos(string IdInsumo)
        {
            return IsumosProcde.BuscarInsumos(IdInsumo);
        }

        public bool ExisteInsumo(string IdInsumo)
        {
            return IsumosProcde.ExisteInsumo(IdInsumo);
        }

        public void Inactivar(DATOS.Insumos Insumo)
        {
            Insumo.Activo = false;
            IsumosProcde.Inactivar(Insumo);
        }

        public List<DATOS.Insumos> ListarInsumos()
        {
            return IsumosProcde.ListarInsumos();
        }
    }
}

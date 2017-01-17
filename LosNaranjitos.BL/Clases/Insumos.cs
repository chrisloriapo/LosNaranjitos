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
        public void ActualizarInsumo(DATOS.Insumos Insumo)
        {
            throw new NotImplementedException();
        }

        public void AgregarInsumo(DATOS.Insumos Insumo)
        {
            throw new NotImplementedException();
        }

        public DATOS.Insumos BuscarInsumoPorProveedor(string IdProveedor)
        {
            throw new NotImplementedException();
        }

        public DATOS.Insumos BuscarInsumos(string IdInsumo)
        {
            throw new NotImplementedException();
        }

        public bool ExisteInsumo(string IdInsumo)
        {
            throw new NotImplementedException();
        }

        public void Inactivar(DATOS.Insumos Insumo)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.Insumos> ListarInsumos()
        {
            throw new NotImplementedException();
        }
    }
}

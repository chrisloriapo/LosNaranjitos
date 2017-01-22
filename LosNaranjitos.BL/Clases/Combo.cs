using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Combo : ICombo
    {
        public DS.Interfaces.ICombo Cprocedimientos = new DS.Clases.Combo();
        public void ActualizarCombo(DATOS.Combo CombO)
        {
            Cprocedimientos.ActualizarCombo(CombO);
        }

        public void AgregarCombo(DATOS.Combo CombO)
        {
            Cprocedimientos.AgregarCombo(CombO);
        }

        public DATOS.Combo BuscarCombo(string IdCombo)
        {
            return Cprocedimientos.BuscarCombo(IdCombo);
        }

        public DATOS.Combo BuscarComboPorNombre(string ComboNombre)
        {
            return Cprocedimientos.BuscarComboPorNombre(ComboNombre);
        }

        public bool ExisteCombo(string CombO)
        {
            return Cprocedimientos.ExisteCombo(CombO);
        }

        public void Inactivar(DATOS.Combo CombO)
        {
            CombO.Activo = false;
            Cprocedimientos.Inactivar(CombO);
        }

        public List<DATOS.Combo> ListarCombo()
        {
            return Cprocedimientos.ListarCombo();
        }
    }
}

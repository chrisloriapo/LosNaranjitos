using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface ICombo
    {
        List<DATOS.Combo> ListarCombo();

        DATOS.Combo BuscarCombo(string IdCombo);

        DATOS.Combo BuscarComboPorConsecutivo(string Consecutivo);

        DATOS.Combo BuscarComboPorNombre(string ComboNombre);

        void AgregarCombo(DATOS.Combo CombO);

        void ActualizarCombo(DATOS.Combo CombO);

        void Inactivar(DATOS.Combo CombO);

        bool ExisteCombo(string CombO);

        bool ExisteConsecutivo(string Consecutivo);

        bool ExisteComboPorNombre(string Nombre);

    }
}

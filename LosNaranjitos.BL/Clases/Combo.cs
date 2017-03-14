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

        public bool ExisteConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return Cprocedimientos.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarCombo(DATOS.Combo CombO)
        {
            CombO.Consecutivo = Utilitario.Encriptar(CombO.Consecutivo, Utilitario.Llave);
            CombO.Codigo = Utilitario.Encriptar(CombO.Codigo, Utilitario.Llave);
            CombO.Nombre = Utilitario.Encriptar(CombO.Nombre, Utilitario.Llave);
            CombO.Descripcion = Utilitario.Encriptar(CombO.Descripcion, Utilitario.Llave);
            Cprocedimientos.ActualizarCombo(CombO);
        }

        public void AgregarCombo(DATOS.Combo CombO)
        {
            CombO.Consecutivo = Utilitario.Encriptar(CombO.Consecutivo, Utilitario.Llave);
            CombO.Codigo = Utilitario.Encriptar(CombO.Codigo, Utilitario.Llave);
            CombO.Nombre = Utilitario.Encriptar(CombO.Nombre, Utilitario.Llave);
            CombO.Descripcion = Utilitario.Encriptar(CombO.Descripcion, Utilitario.Llave);
            Cprocedimientos.AgregarCombo(CombO);
        }

        public DATOS.Combo BuscarCombo(string IdCombo)
        {
            IdCombo = Utilitario.Encriptar(IdCombo, Utilitario.Llave);
            DATOS.Combo ComboRetorno = Cprocedimientos.BuscarCombo(IdCombo);
            ComboRetorno.Consecutivo = Utilitario.Decriptar(ComboRetorno.Consecutivo, Utilitario.Llave);
            ComboRetorno.Codigo = Utilitario.Decriptar(ComboRetorno.Codigo, Utilitario.Llave);
            ComboRetorno.Nombre = Utilitario.Decriptar(ComboRetorno.Nombre, Utilitario.Llave);
            ComboRetorno.Descripcion = Utilitario.Decriptar(ComboRetorno.Descripcion, Utilitario.Llave);
            return ComboRetorno;
        }

        public DATOS.Combo BuscarComboPorConsecutivo(string Consecutivo)
        {
            Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            DATOS.Combo ComboRetorno = Cprocedimientos.BuscarComboPorConsecutivo(Consecutivo);
            ComboRetorno.Consecutivo = Utilitario.Decriptar(ComboRetorno.Consecutivo, Utilitario.Llave);
            ComboRetorno.Codigo = Utilitario.Decriptar(ComboRetorno.Codigo, Utilitario.Llave);
            ComboRetorno.Nombre = Utilitario.Decriptar(ComboRetorno.Nombre, Utilitario.Llave);
            ComboRetorno.Descripcion = Utilitario.Decriptar(ComboRetorno.Descripcion, Utilitario.Llave);
            return ComboRetorno;
        }

        public DATOS.Combo BuscarComboPorNombre(string ComboNombre)
        {
            ComboNombre = Utilitario.Encriptar(ComboNombre, Utilitario.Llave);
            DATOS.Combo ComboRetorno = Cprocedimientos.BuscarComboPorNombre(ComboNombre);
            ComboRetorno.Consecutivo = Utilitario.Decriptar(ComboRetorno.Consecutivo, Utilitario.Llave);
            ComboRetorno.Codigo = Utilitario.Decriptar(ComboRetorno.Codigo, Utilitario.Llave);
            ComboRetorno.Nombre = Utilitario.Decriptar(ComboRetorno.Nombre, Utilitario.Llave);
            ComboRetorno.Descripcion = Utilitario.Decriptar(ComboRetorno.Descripcion, Utilitario.Llave);
            return ComboRetorno;
        }

        public bool ExisteCombo(string CombO)
        {
            CombO = Utilitario.Encriptar(CombO, Utilitario.Llave);
            return Cprocedimientos.ExisteCombo(CombO);
        }

        public void Inactivar(DATOS.Combo CombO)
        {
            CombO.Consecutivo = Utilitario.Encriptar(CombO.Consecutivo, Utilitario.Llave);
            CombO.Codigo = Utilitario.Encriptar(CombO.Codigo, Utilitario.Llave);
            CombO.Nombre = Utilitario.Encriptar(CombO.Nombre, Utilitario.Llave);
            CombO.Descripcion = Utilitario.Encriptar(CombO.Descripcion, Utilitario.Llave);
            CombO.Activo = false;
            Cprocedimientos.Inactivar(CombO);
        }

        public List<DATOS.Combo> ListarCombo()
        {
            List<DATOS.Combo> ListaRetorno = Cprocedimientos.ListarCombo();
            foreach (var item in ListaRetorno)
            {
                item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
                item.Codigo = Utilitario.Decriptar(item.Codigo, Utilitario.Llave);
                item.Nombre = Utilitario.Decriptar(item.Nombre, Utilitario.Llave);
                item.Descripcion = Utilitario.Decriptar(item.Descripcion, Utilitario.Llave);

            }
            return ListaRetorno;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.BL.Interfaces
{
    public interface IComboProducto
    {
        List<DATOS.ComboProducto> ListarComboProductos();

        DATOS.ComboProducto BuscarCodigoCombo(string Combo);

        DATOS.ComboProducto BuscarCodigoConsecutivo(int Consecutivo);

        DATOS.ComboProducto BuscarCodigoProducto(string Producto);

        void AgregarComboProducto(DATOS.ComboProducto ComboProductos);

        void ActualizarComboProducto(DATOS.ComboProducto ComboProductos);

        bool ExisteComboProducto(string Combo, string Producto);

        bool ExisteConsecutivo(int Consecutivo);

        void EliminarProductodeCombo(DATOS.ComboProducto ComboProducto);



    }
}

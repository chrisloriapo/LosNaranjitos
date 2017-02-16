using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class ComboProducto : IComboProducto
    {
        public DS.Interfaces.IComboProducto ComProcedimietos = new DS.Clases.ComboProducto();
        public bool ExisteConsecutivo(string Consecutivo)
        {
            return ComProcedimietos.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarComboProducto(DATOS.ComboProducto ComboProductos)
        {
            ComProcedimietos.ActualizarComboProducto(ComboProductos);
        }

        public void AgregarComboProducto(DATOS.ComboProducto ComboProductos)
        {
            ComProcedimietos.AgregarComboProducto(ComboProductos);
        }

        public DATOS.ComboProducto BuscarCodigoCombo(string Combo)
        {
            return ComProcedimietos.BuscarCodigoCombo(Combo);
        }

        public DATOS.ComboProducto BuscarCodigoConsecutivo(string Consecutivo)
        {
            return ComProcedimietos.BuscarCodigoConsecutivo(Consecutivo);
        }

        public DATOS.ComboProducto BuscarCodigoProducto(string Producto)
        {
            return ComProcedimietos.BuscarCodigoProducto(Producto);
        }

        public bool ExisteComboProducto(string Combo, string Producto)
        {
            return ComProcedimietos.ExisteComboProducto(Combo, Producto);
        }

        public List<DATOS.ComboProducto> ListarComboProductos()
        {

            return ComProcedimietos.ListarComboProductos();
        }
    }
}

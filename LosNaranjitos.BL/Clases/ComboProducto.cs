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

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ComProcedimietos.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarComboProducto(DATOS.ComboProducto ComboProductos)
        {
            //ComboProductos.Consecutivo = Utilitario.Encriptar(ComboProductos.Consecutivo, Utilitario.Llave);
            //ComboProductos.CodCombo = Utilitario.Encriptar(ComboProductos.CodCombo, Utilitario.Llave);
            //ComboProductos.CodProducto = Utilitario.Encriptar(ComboProductos.CodProducto, Utilitario.Llave);
            //ComboProductos.IdMedida = Utilitario.Encriptar(ComboProductos.IdMedida, Utilitario.Llave);
            ComProcedimietos.ActualizarComboProducto(ComboProductos);
        }

        public void AgregarComboProducto(DATOS.ComboProducto ComboProductos)
        {
            //ComboProductos.Consecutivo = Utilitario.Encriptar(ComboProductos.Consecutivo, Utilitario.Llave);
            //ComboProductos.CodCombo = Utilitario.Encriptar(ComboProductos.CodCombo, Utilitario.Llave);
            //ComboProductos.CodProducto = Utilitario.Encriptar(ComboProductos.CodProducto, Utilitario.Llave);
            //ComboProductos.IdMedida = Utilitario.Encriptar(ComboProductos.IdMedida, Utilitario.Llave);
            ComProcedimietos.AgregarComboProducto(ComboProductos);
        }

        public DATOS.ComboProducto BuscarCodigoCombo(string Combo)
        {
            //Combo = Utilitario.Encriptar(Combo, Utilitario.Llave);
            DATOS.ComboProducto ComboProductoRetorno = ComProcedimietos.BuscarCodigoCombo(Combo);
            //ComboProductoRetorno.Consecutivo = Utilitario.Decriptar(ComboProductoRetorno.Consecutivo, Utilitario.Llave);
            //ComboProductoRetorno.CodProducto = Utilitario.Decriptar(ComboProductoRetorno.CodProducto, Utilitario.Llave);
            //ComboProductoRetorno.CodCombo = Utilitario.Decriptar(ComboProductoRetorno.CodCombo, Utilitario.Llave);
            //ComboProductoRetorno.IdMedida = Utilitario.Decriptar(ComboProductoRetorno.IdMedida, Utilitario.Llave);
            return ComboProductoRetorno;
        }

        public DATOS.ComboProducto BuscarCodigoConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            DATOS.ComboProducto ComboProductoRetorno = ComProcedimietos.BuscarCodigoConsecutivo(Consecutivo);
            //ComboProductoRetorno.Consecutivo = Utilitario.Decriptar(ComboProductoRetorno.Consecutivo, Utilitario.Llave);
            //ComboProductoRetorno.CodProducto = Utilitario.Decriptar(ComboProductoRetorno.CodProducto, Utilitario.Llave);
            //ComboProductoRetorno.CodCombo = Utilitario.Decriptar(ComboProductoRetorno.CodCombo, Utilitario.Llave);
            //ComboProductoRetorno.IdMedida = Utilitario.Decriptar(ComboProductoRetorno.IdMedida, Utilitario.Llave);
            return ComboProductoRetorno;
        }

        public DATOS.ComboProducto BuscarCodigoProducto(string Producto)
        {
            //Producto = Utilitario.Encriptar(Producto, Utilitario.Llave);
            DATOS.ComboProducto ComboProductoRetorno = ComProcedimietos.BuscarCodigoProducto(Producto);
            //ComboProductoRetorno.Consecutivo = Utilitario.Decriptar(ComboProductoRetorno.Consecutivo, Utilitario.Llave);
            //ComboProductoRetorno.CodProducto = Utilitario.Decriptar(ComboProductoRetorno.CodProducto, Utilitario.Llave);
            //ComboProductoRetorno.CodCombo = Utilitario.Decriptar(ComboProductoRetorno.CodCombo, Utilitario.Llave);
            //ComboProductoRetorno.IdMedida = Utilitario.Decriptar(ComboProductoRetorno.IdMedida, Utilitario.Llave);
            return ComboProductoRetorno;
        }

        public bool ExisteComboProducto(string Combo, string Producto)
        {
            //Combo = Utilitario.Encriptar(Combo, Utilitario.Llave);
            //Producto = Utilitario.Encriptar(Producto, Utilitario.Llave);
            return ComProcedimietos.ExisteComboProducto(Combo, Producto);
        }

        public List<DATOS.ComboProducto> ListarComboProductos()
        {

            List<DATOS.ComboProducto> ListaRetorno = ComProcedimietos.ListarComboProductos();
            //foreach (var item in ListaRetorno)
            //{
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.CodProducto = Utilitario.Decriptar(item.CodProducto, Utilitario.Llave);
            //    item.CodCombo = Utilitario.Decriptar(item.CodCombo, Utilitario.Llave);
            //    item.IdMedida = Utilitario.Decriptar(item.IdMedida, Utilitario.Llave);
            //}
            return ListaRetorno;
        }

        public void EliminarProductodeCombo(DATOS.ComboProducto ComboProducto)
        {

            //ComboProducto.Consecutivo = Utilitario.Encriptar(ComboProducto.Consecutivo, Utilitario.Llave);
            //ComboProducto.CodProducto = Utilitario.Encriptar(ComboProducto.CodProducto, Utilitario.Llave);
            //ComboProducto.CodCombo = Utilitario.Encriptar(ComboProducto.CodCombo, Utilitario.Llave);
            //ComboProducto.IdMedida = Utilitario.Encriptar(ComboProducto.IdMedida, Utilitario.Llave);
            ComProcedimietos.EliminarProductodeCombo(ComboProducto);

        }
    }
}

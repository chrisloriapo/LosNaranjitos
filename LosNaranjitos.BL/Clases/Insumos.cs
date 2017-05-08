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

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return IsumosProcde.ExisteConsecutivo(Consecutivo);
        }
        public void ActualizarInsumo(DATOS.Insumos Insumo)
        {
        //    Insumo.Consecutivo = Utilitario.Encriptar(Insumo.Consecutivo, Utilitario.Llave);
        //    Insumo.IdInsumo = Utilitario.Encriptar(Insumo.IdInsumo, Utilitario.Llave);
        //    Insumo.Nombre = Utilitario.Encriptar(Insumo.Nombre, Utilitario.Llave);
        //    Insumo.Proveedor = Utilitario.Encriptar(Insumo.Proveedor, Utilitario.Llave);
        //    Insumo.IdMedida = Utilitario.Encriptar(Insumo.IdMedida, Utilitario.Llave);
            IsumosProcde.ActualizarInsumo(Insumo);
        }

        public void AgregarInsumo(DATOS.Insumos Insumo)
        {
            //Insumo.Consecutivo = Utilitario.Encriptar(Insumo.Consecutivo, Utilitario.Llave);
            //Insumo.IdInsumo = Utilitario.Encriptar(Insumo.IdInsumo, Utilitario.Llave);
            //Insumo.Nombre = Utilitario.Encriptar(Insumo.Nombre, Utilitario.Llave);
            //Insumo.IdMedida = Utilitario.Encriptar(Insumo.IdMedida, Utilitario.Llave);
            //Insumo.Proveedor = Utilitario.Encriptar(Insumo.Proveedor, Utilitario.Llave);
            IsumosProcde.AgregarInsumo(Insumo);
        }

        public DATOS.Insumos BuscarInsumoPorConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            DATOS.Insumos InsumosRetorno = IsumosProcde.BuscarInsumoPorConsecutivo(Consecutivo);
            //InsumosRetorno.Consecutivo = Utilitario.Decriptar(InsumosRetorno.Consecutivo, Utilitario.Llave);
            //InsumosRetorno.Proveedor = Utilitario.Decriptar(InsumosRetorno.Proveedor, Utilitario.Llave);
            //InsumosRetorno.Nombre = Utilitario.Decriptar(InsumosRetorno.Nombre, Utilitario.Llave);
            //InsumosRetorno.IdMedida = Utilitario.Decriptar(InsumosRetorno.IdMedida, Utilitario.Llave);
            //InsumosRetorno.IdInsumo = Utilitario.Decriptar(InsumosRetorno.IdInsumo, Utilitario.Llave);
            return InsumosRetorno;
        }

        public DATOS.Insumos BuscarInsumoPorProveedor(string IdProveedor)
        {
            //IdProveedor = Utilitario.Encriptar(IdProveedor, Utilitario.Llave);
            DATOS.Insumos InsumosRetorno = IsumosProcde.BuscarInsumoPorProveedor(IdProveedor);
            //InsumosRetorno.Consecutivo = Utilitario.Decriptar(InsumosRetorno.Consecutivo, Utilitario.Llave);
            //InsumosRetorno.Proveedor = Utilitario.Decriptar(InsumosRetorno.Proveedor, Utilitario.Llave);
            //InsumosRetorno.Nombre = Utilitario.Decriptar(InsumosRetorno.Nombre, Utilitario.Llave);
            //InsumosRetorno.IdMedida = Utilitario.Decriptar(InsumosRetorno.IdMedida, Utilitario.Llave);
            //InsumosRetorno.IdInsumo = Utilitario.Decriptar(InsumosRetorno.IdInsumo, Utilitario.Llave);
            return InsumosRetorno;
        }

        public DATOS.Insumos BuscarInsumos(string IdInsumo)
        {
            //IdInsumo = Utilitario.Encriptar(IdInsumo, Utilitario.Llave);
            DATOS.Insumos InsumosRetorno = IsumosProcde.BuscarInsumos(IdInsumo);
            //InsumosRetorno.Consecutivo = Utilitario.Decriptar(InsumosRetorno.Consecutivo, Utilitario.Llave);
            //InsumosRetorno.Proveedor = Utilitario.Decriptar(InsumosRetorno.Proveedor, Utilitario.Llave);
            //InsumosRetorno.Nombre = Utilitario.Decriptar(InsumosRetorno.Nombre, Utilitario.Llave);
            //InsumosRetorno.IdMedida = Utilitario.Decriptar(InsumosRetorno.IdMedida, Utilitario.Llave);
            //InsumosRetorno.IdInsumo = Utilitario.Decriptar(InsumosRetorno.IdInsumo, Utilitario.Llave);
            return InsumosRetorno;
        }

        public bool ExisteInsumo(string IdInsumo)
        {
            //IdInsumo = Utilitario.Encriptar(IdInsumo, Utilitario.Llave);
            return IsumosProcde.ExisteInsumo(IdInsumo);
        }

        public void Inactivar(DATOS.Insumos Insumo)
        {
            //Insumo.Consecutivo = Utilitario.Encriptar(Insumo.Consecutivo, Utilitario.Llave);
            //Insumo.IdInsumo = Utilitario.Encriptar(Insumo.IdInsumo, Utilitario.Llave);
            //Insumo.Nombre = Utilitario.Encriptar(Insumo.Nombre, Utilitario.Llave);
            //Insumo.IdMedida = Utilitario.Encriptar(Insumo.IdMedida, Utilitario.Llave);
            Insumo.Activo = false;
            IsumosProcde.Inactivar(Insumo);
        }

        public List<DATOS.Insumos> ListarInsumos()
        {
            List<DATOS.Insumos> ListaRetorno = IsumosProcde.ListarInsumos();
            //foreach (var item in ListaRetorno)
            //{
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.IdInsumo = Utilitario.Decriptar(item.IdInsumo, Utilitario.Llave);
            //    item.Nombre = Utilitario.Decriptar(item.Nombre, Utilitario.Llave);
            //    item.IdMedida = Utilitario.Decriptar(item.IdMedida, Utilitario.Llave);
            //    item.Proveedor = Utilitario.Decriptar(item.Proveedor, Utilitario.Llave);

            //}
            return ListaRetorno;
        }
    }
}

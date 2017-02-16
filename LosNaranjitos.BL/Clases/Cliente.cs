using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Cliente : ICliente
    {
        public DS.Interfaces.ICliente ClietProce = new DS.Clases.Cliente();

        public bool ExisteConsecutivo(string Consecutivo)
        {
            return ClietProce.ExisteConsecutivo(Consecutivo);
        }

        public void ActualizarCLIENTE(DATOS.Cliente CLIENTE)
        {
            ClietProce.ActualizarCLIENTE(CLIENTE);

        }

        public void AgregarCliente(DATOS.Cliente CLIENTE)
        {
            ClietProce.AgregarCliente(CLIENTE);
        }

        public DATOS.Cliente BuscarCliente(string IdPersonal)
        {
            return ClietProce.BuscarCliente(IdPersonal);
        }

        public DATOS.Cliente BuscarClientePorConsecutivo(string Consecutivo)
        {
            return ClietProce.BuscarClientePorConsecutivo(Consecutivo);
        }

        public DATOS.Cliente BuscarClientePorCorreo(string Correo)
        {
            return ClietProce.BuscarClientePorCorreo(Correo);
        }

        public bool ExisteCLIENTE(string IDCLIENTE)
        {
            return ClietProce.ExisteCLIENTE(IDCLIENTE);
        }

        public void Inactivar(DATOS.Cliente CLIENTE)
        {
            CLIENTE.Activo = false;
            ClietProce.Inactivar(CLIENTE);
        }

        public List<DATOS.Cliente> ListarClientes()
        {
            return ClietProce.ListarClientes();
        }
    }
}

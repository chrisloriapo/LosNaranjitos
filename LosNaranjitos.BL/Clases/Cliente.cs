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
        public void ActualizarCLIENTE(DATOS.Cliente CLIENTE)
        {
            throw new NotImplementedException();
        }

        public void AgregarCliente(DATOS.Cliente CLIENTE)
        {
            throw new NotImplementedException();
        }

        public DATOS.Cliente BuscarCliente(string IdPersonal)
        {
            throw new NotImplementedException();
        }

        public DATOS.Cliente BuscarClientePorCorreo(string Correo)
        {
            throw new NotImplementedException();
        }

        public bool ExisteCLIENTE(string IDCLIENTE)
        {
            throw new NotImplementedException();
        }

        public void Inactivar(DATOS.Cliente CLIENTE)
        {
            throw new NotImplementedException();
        }

        public List<DATOS.Cliente> ListarClientes()
        {
            throw new NotImplementedException();
        }
    }
}

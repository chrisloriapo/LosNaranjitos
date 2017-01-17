using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
    public interface ICliente
    {
        List<DATOS.Cliente> ListarClientes();

        DATOS.Cliente BuscarCliente(string IdPersonal);

        DATOS.Cliente BuscarClientePorCorreo(string Correo);

        void AgregarCliente(DATOS.Cliente CLIENTE);

        void ActualizarCLIENTE(DATOS.Cliente CLIENTE);

        void Inactivar(DATOS.Cliente CLIENTE);

        bool ExisteCLIENTE(string IDCLIENTE);
    }
}

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

        public bool ExisteConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);
            return ClietProce.ExisteConsecutivo(Consecutivo);
        }

        public void ActualizarCLIENTE(DATOS.Cliente CLIENTE)
        {
            //CLIENTE.Consecutivo = Utilitario.Encriptar(CLIENTE.Consecutivo, Utilitario.Llave);
            //CLIENTE.Nombre = Utilitario.Encriptar(CLIENTE.Nombre, Utilitario.Llave);
            //CLIENTE.Apellido1 = Utilitario.Encriptar(CLIENTE.Apellido1, Utilitario.Llave);
            //CLIENTE.IdPersonal = Utilitario.Encriptar(CLIENTE.IdPersonal, Utilitario.Llave);
            //CLIENTE.Correo = Utilitario.Encriptar(CLIENTE.Correo, Utilitario.Llave);
            //if (CLIENTE.Apellido2 != null)
            //{
            //    CLIENTE.Apellido2 = Utilitario.Encriptar(CLIENTE.Apellido2, Utilitario.Llave);
            //}
            //if (CLIENTE.Contrasena != null)
            //{
            //    CLIENTE.Contrasena = Utilitario.Encriptar(CLIENTE.Contrasena, Utilitario.Llave);
            //}
            //if (CLIENTE.Telefono != null)
            //{
            //    CLIENTE.Telefono = Utilitario.Encriptar(CLIENTE.Telefono, Utilitario.Llave);
            //}
            //if (CLIENTE.Operadora != null)
            //{
            //    CLIENTE.Operadora = Utilitario.Encriptar(CLIENTE.Operadora, Utilitario.Llave);
            //}
            ClietProce.ActualizarCLIENTE(CLIENTE);

        }

        public void AgregarCliente(DATOS.Cliente CLIENTE)
        {
        //    CLIENTE.Consecutivo = Utilitario.Encriptar(CLIENTE.Consecutivo, Utilitario.Llave);
        //    CLIENTE.Nombre = Utilitario.Encriptar(CLIENTE.Nombre, Utilitario.Llave);
        //    CLIENTE.Apellido1 = Utilitario.Encriptar(CLIENTE.Apellido1, Utilitario.Llave);
        //    CLIENTE.IdPersonal = Utilitario.Encriptar(CLIENTE.IdPersonal, Utilitario.Llave);
        //    CLIENTE.Correo = Utilitario.Encriptar(CLIENTE.Correo, Utilitario.Llave);
        //    if (CLIENTE.Apellido2 != null)
        //    {
        //        CLIENTE.Apellido2 = Utilitario.Encriptar(CLIENTE.Apellido2, Utilitario.Llave);
        //    }
        //    if (CLIENTE.Contrasena != null)
        //    {
        //        CLIENTE.Contrasena = Utilitario.Encriptar(CLIENTE.Contrasena, Utilitario.Llave);
        //    }
        //    if (CLIENTE.Telefono != null)
        //    {
        //        CLIENTE.Telefono = Utilitario.Encriptar(CLIENTE.Telefono, Utilitario.Llave);
        //    }
        //    if (CLIENTE.Operadora != null)
        //    {
        //        CLIENTE.Operadora = Utilitario.Encriptar(CLIENTE.Operadora, Utilitario.Llave);
        //    }
            ClietProce.AgregarCliente(CLIENTE);
        }

        public DATOS.Cliente BuscarCliente(string IdPersonal)
        {
            //IdPersonal = Utilitario.Encriptar(IdPersonal, Utilitario.Llave);
            DATOS.Cliente ClienteRetorno = ClietProce.BuscarCliente(IdPersonal);
            //ClienteRetorno.Consecutivo = Utilitario.Decriptar(ClienteRetorno.Consecutivo, Utilitario.Llave);
            //ClienteRetorno.Nombre = Utilitario.Decriptar(ClienteRetorno.Nombre, Utilitario.Llave);
            //ClienteRetorno.Apellido1 = Utilitario.Decriptar(ClienteRetorno.Apellido1, Utilitario.Llave);
            //ClienteRetorno.IdPersonal = Utilitario.Decriptar(ClienteRetorno.IdPersonal, Utilitario.Llave);
            //ClienteRetorno.Correo = Utilitario.Decriptar(ClienteRetorno.Correo, Utilitario.Llave);
            //if (ClienteRetorno.Apellido2 != null)
            //{
            //    ClienteRetorno.Apellido2 = Utilitario.Decriptar(ClienteRetorno.Apellido2, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Contrasena != null)
            //{
            //    ClienteRetorno.Contrasena = Utilitario.Decriptar(ClienteRetorno.Contrasena, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Telefono != null)
            //{
            //    ClienteRetorno.Telefono = Utilitario.Decriptar(ClienteRetorno.Telefono, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Operadora != null)
            //{
            //    ClienteRetorno.Operadora = Utilitario.Decriptar(ClienteRetorno.Operadora, Utilitario.Llave);
            //}
            return ClienteRetorno;
        }

        public DATOS.Cliente BuscarClientePorConsecutivo(int Consecutivo)
        {
            //Consecutivo = Utilitario.Encriptar(Consecutivo, Utilitario.Llave);

            DATOS.Cliente ClienteRetorno = ClietProce.BuscarClientePorConsecutivo(Consecutivo);
            //ClienteRetorno.Consecutivo = Utilitario.Decriptar(ClienteRetorno.Consecutivo, Utilitario.Llave);
            //ClienteRetorno.Nombre = Utilitario.Decriptar(ClienteRetorno.Nombre, Utilitario.Llave);
            //ClienteRetorno.Apellido1 = Utilitario.Decriptar(ClienteRetorno.Apellido1, Utilitario.Llave);
            //ClienteRetorno.IdPersonal = Utilitario.Decriptar(ClienteRetorno.IdPersonal, Utilitario.Llave);
            //ClienteRetorno.Correo = Utilitario.Decriptar(ClienteRetorno.Correo, Utilitario.Llave);
            //if (ClienteRetorno.Apellido2 != null)
            //{
            //    ClienteRetorno.Apellido2 = Utilitario.Decriptar(ClienteRetorno.Apellido2, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Contrasena != null)
            //{
            //    ClienteRetorno.Contrasena = Utilitario.Decriptar(ClienteRetorno.Contrasena, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Telefono != null)
            //{
            //    ClienteRetorno.Telefono = Utilitario.Decriptar(ClienteRetorno.Telefono, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Operadora != null)
            //{
            //    ClienteRetorno.Operadora = Utilitario.Decriptar(ClienteRetorno.Operadora, Utilitario.Llave);
            //}
            return ClienteRetorno;

        }

        public DATOS.Cliente BuscarClientePorCorreo(string Correo)
        {
            //Correo = Utilitario.Encriptar(Correo, Utilitario.Llave);
            DATOS.Cliente ClienteRetorno = ClietProce.BuscarClientePorCorreo(Correo);
            //ClienteRetorno.Consecutivo = Utilitario.Decriptar(ClienteRetorno.Consecutivo, Utilitario.Llave);
            //ClienteRetorno.Nombre = Utilitario.Decriptar(ClienteRetorno.Nombre, Utilitario.Llave);
            //ClienteRetorno.Apellido1 = Utilitario.Decriptar(ClienteRetorno.Apellido1, Utilitario.Llave);
            //ClienteRetorno.IdPersonal = Utilitario.Decriptar(ClienteRetorno.IdPersonal, Utilitario.Llave);
            //ClienteRetorno.Correo = Utilitario.Decriptar(ClienteRetorno.Correo, Utilitario.Llave);
            //if (ClienteRetorno.Apellido2 != null)
            //{
            //    ClienteRetorno.Apellido2 = Utilitario.Decriptar(ClienteRetorno.Apellido2, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Contrasena != null)
            //{
            //    ClienteRetorno.Contrasena = Utilitario.Decriptar(ClienteRetorno.Contrasena, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Telefono != null)
            //{
            //    ClienteRetorno.Telefono = Utilitario.Decriptar(ClienteRetorno.Telefono, Utilitario.Llave);
            //}
            //if (ClienteRetorno.Operadora != null)
            //{
            //    ClienteRetorno.Operadora = Utilitario.Decriptar(ClienteRetorno.Operadora, Utilitario.Llave);
            //}
            return ClienteRetorno;

        }

        public bool ExisteCLIENTE(string IDCLIENTE)
        {
            //IDCLIENTE = Utilitario.Encriptar(IDCLIENTE, Utilitario.Llave);
            return ClietProce.ExisteCLIENTE(IDCLIENTE);
        }

        public void Inactivar(DATOS.Cliente CLIENTE)
        {
            //CLIENTE.Consecutivo = Utilitario.Encriptar(CLIENTE.Consecutivo, Utilitario.Llave);
            //CLIENTE.Nombre = Utilitario.Encriptar(CLIENTE.Nombre, Utilitario.Llave);
            //CLIENTE.Apellido1 = Utilitario.Encriptar(CLIENTE.Apellido1, Utilitario.Llave);
            //CLIENTE.IdPersonal = Utilitario.Encriptar(CLIENTE.IdPersonal, Utilitario.Llave);
            //CLIENTE.Correo = Utilitario.Encriptar(CLIENTE.Correo, Utilitario.Llave);
            //if (CLIENTE.Apellido2 != null)
            //{
            //    CLIENTE.Apellido2 = Utilitario.Encriptar(CLIENTE.Apellido2, Utilitario.Llave);
            //}
            //if (CLIENTE.Contrasena != null)
            //{
            //    CLIENTE.Contrasena = Utilitario.Encriptar(CLIENTE.Contrasena, Utilitario.Llave);
            //}
            //if (CLIENTE.Telefono != null)
            //{
            //    CLIENTE.Telefono = Utilitario.Encriptar(CLIENTE.Telefono, Utilitario.Llave);
            //}
            //if (CLIENTE.Operadora != null)
            //{
            //    CLIENTE.Operadora = Utilitario.Encriptar(CLIENTE.Operadora, Utilitario.Llave);
            //}
            CLIENTE.Activo = false;
            ClietProce.Inactivar(CLIENTE);
        }

        public List<DATOS.Cliente> ListarClientes()
        {

            List<DATOS.Cliente> ListaRetorno = ClietProce.ListarClientes();

            //foreach (var item in ListaRetorno)
            //{
            //    item.Consecutivo = Utilitario.Decriptar(item.Consecutivo, Utilitario.Llave);
            //    item.Nombre = Utilitario.Decriptar(item.Nombre, Utilitario.Llave);
            //    item.Apellido1 = Utilitario.Decriptar(item.Apellido1, Utilitario.Llave);
            //    item.IdPersonal = Utilitario.Decriptar(item.IdPersonal, Utilitario.Llave);
            //    item.Correo = Utilitario.Decriptar(item.Correo, Utilitario.Llave);
            //    if (item.Apellido2 != null)
            //    {
            //        item.Apellido2 = Utilitario.Decriptar(item.Apellido2, Utilitario.Llave);
            //    }
            //    if (item.Contrasena != null)
            //    {
            //        item.Contrasena = Utilitario.Decriptar(item.Contrasena, Utilitario.Llave);
            //    }
            //    if (item.Telefono != null)
            //    {
            //        item.Telefono = Utilitario.Decriptar(item.Telefono, Utilitario.Llave);
            //    }
            //    if (item.Operadora != null)
            //    {
            //        item.Operadora = Utilitario.Decriptar(item.Operadora, Utilitario.Llave);
            //    }
            //}
            return ListaRetorno;
        }
    }
}

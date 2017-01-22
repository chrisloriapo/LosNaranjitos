using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS.Interfaces;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class Cliente : ICliente
    {
        public void ActualizarCLIENTE(DATOS.Cliente CLIENTE)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(CLIENTE);
        }

        public void AgregarCliente(DATOS.Cliente CLIENTE)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(CLIENTE);
        }

        public DATOS.Cliente BuscarCliente(string IdPersonal)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Cliente Buscar = db.Select<DATOS.Cliente>(x => x.IdPersonal == IdPersonal).FirstOrDefault();
            return Buscar;
        }

        public DATOS.Cliente BuscarClientePorCorreo(string Correo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Cliente Buscarmail = db.Select<DATOS.Cliente>(x => x.Correo == Correo).FirstOrDefault();
            return Buscarmail;
        }

        public bool ExisteCLIENTE(string IDCLIENTE)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Cliente Us = db.Select<DATOS.Cliente>(x => x.IdPersonal == IDCLIENTE).FirstOrDefault();

                if (Us.IdPersonal == IDCLIENTE)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Inactivar(DATOS.Cliente CLIENTE)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(CLIENTE);

        }

        public List<DATOS.Cliente> ListarClientes()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Cliente> ListaCliente = db.Select<DATOS.Cliente>();
            return ListaCliente;
        }
    }
}

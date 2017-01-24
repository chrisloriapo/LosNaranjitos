﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using LosNaranjitos.DS.Interfaces;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class Pedido : IPedido
    {
        public void ActualizarPedido(DATOS.Pedido Orden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Orden);
        }

        public void AgregarPedido(DATOS.Pedido Orden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Orden);
        }

        public DATOS.Pedido BuscarPedido(int IdPedido)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Pedido BuscPed = db.Select<DATOS.Pedido>(x => x.IdPedido == IdPedido).FirstOrDefault();
            return BuscPed;
        }

        public DATOS.Pedido BuscarProductoCliente(string IdCliente)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.Pedido BuscIdClient = db.Select<DATOS.Pedido>(x => x.IdCliente == IdCliente).FirstOrDefault();
            return BuscIdClient;
        }

        public bool ExistePedido(int IdPedido)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.Pedido Us = db.Select<DATOS.Pedido>(x => x.IdPedido == IdPedido).FirstOrDefault();

                if (Us.IdPedido == IdPedido)
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
            throw new NotImplementedException();
        }

        public void Inactivar(DATOS.Pedido Orden)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Orden);
        }

        public List<DATOS.Pedido> ListarPedido()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.Pedido> ListPed = db.Select<DATOS.Pedido>();
            return ListPed;
        }
    }
}

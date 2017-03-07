using LosNaranjitos.DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.DATOS;
using ServiceStack.OrmLite;

namespace LosNaranjitos.DS.Clases
{
    public class FacturaCompra : IFacturaCompra
    {
        public void ActualizarFacturaCompra(DATOS.FacturaCompra Factura_Compra)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Factura_Compra);
        }

        public void AgregarFacturaCompra(DATOS.FacturaCompra Factura_Compra)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Insert(Factura_Compra);
        }

        public DATOS.FacturaCompra BuscarFactura(string IdFactura)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            DATOS.FacturaCompra Factura = db.Select<DATOS.FacturaCompra>(x => x.IdFactura == IdFactura).FirstOrDefault();
            return Factura;
        }

        public bool ExisteConsecutivo(string Consecutivo)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.FacturaCompra FC = db.Select<DATOS.FacturaCompra>(x => x.Consecutivo == Consecutivo).FirstOrDefault();

                if (FC.Consecutivo == Consecutivo)
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

        public bool ExisteFactura(string IdFactura)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            try
            {
                DATOS.FacturaCompra Factura = db.Select<DATOS.FacturaCompra>(x => x.IdFactura == IdFactura).FirstOrDefault();

                if (Factura.IdFactura == IdFactura)
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

        public void Inactivar(DATOS.FacturaCompra Factura_Compra)
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            db.Update(Factura_Compra);
        }

        public List<DATOS.FacturaCompra> ListarFacturas()
        {
            var conexion = _Conexion.CrearConexion();
            var db = conexion.Open();
            List<DATOS.FacturaCompra> Facturas = db.Select<DATOS.FacturaCompra>();
            return Facturas;
        }
    }
}

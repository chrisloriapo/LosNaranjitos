using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Pedido
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Consecutivo { get; set; }

        public string IdCliente { get; set; }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        public string Operador { get; set; }

        public decimal MontoTarjeta { get; set; }

        public decimal MontoEfectivo { get; set; }

        public decimal MontoOtro { get; set; }

        public decimal MontoCambio { get; set; }

        public decimal Subtotal { get; set; }

        public bool Cancelado { get; set; }

        public bool Activo { get; set; }

        public bool CierreOperador { get; set; }

        public bool Cerrado { get; set; }


    }

}

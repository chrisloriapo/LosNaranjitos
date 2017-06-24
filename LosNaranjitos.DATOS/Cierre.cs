using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Cierre
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Consecutivo { get; set; }

        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        public string Usuario { get; set; }

        public string Caja { get; set; }

        public int CantidadVentas { get; set; }

        public decimal MontoTarjeta { get; set; }

        public decimal MontoEfectivo { get; set; }

        public decimal MontroOtro { get; set; }

        public decimal MontoCambio { get; set; }

        public decimal MontoTotal { get; set; }

    }

}

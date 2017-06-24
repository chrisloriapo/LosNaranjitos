using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class FacturaCompra
    {
        [AutoIncrement]
        public int Consecutivo { get; set; }
        [PrimaryKey]
        public string IdFactura { get; set; }

        public string IdProveedor { get; set; }

        public decimal Monto { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public string Operador { get; set; }


    }

}

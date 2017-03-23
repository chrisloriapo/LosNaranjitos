using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{

    public class DetallePedido
    {

        public string IdOrden { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }
        [PrimaryKey]
        public string Consecutivo { get; set; }

        public string ObservacionesDT { get; set; }
    }

}

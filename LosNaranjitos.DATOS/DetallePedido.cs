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
        [AutoIncrement]
        public int Consecutivo { get; set; }
        [PrimaryKey]
        public int IdOrden { get; set; }
        [PrimaryKey]
        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public string ObservacionesDT { get; set; }

        public decimal SubTotal { get; set; }
    }

}

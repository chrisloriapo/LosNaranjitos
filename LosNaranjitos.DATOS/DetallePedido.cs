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
        [Required][PrimaryKey]
        public int IdOrden { get; set; }
        [Required]
        public string Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public string Consecutivo { get; set; }

    }

}

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
        [Required]
        public int IdPedido { get; set; }
        
        public string IdCliente { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }
        [Required]
        public string Operador { get; set; }

        public decimal Subtotal { get; set; }
        [Required]
        public bool Activo { get; set; }

    }

}

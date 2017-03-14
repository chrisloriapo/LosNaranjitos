﻿using System;
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
        public string Consecutivo { get; set; }

        public string IdCliente { get; set; }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        public string Operador { get; set; }

        public decimal Subtotal { get; set; }

        public bool Activo { get; set; }

        public bool Cancelado { get; set; }

    }

}

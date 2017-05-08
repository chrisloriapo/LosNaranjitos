﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class ProductoInsumo
    {
        [AutoIncrement]
        public int Consecutivo { get; set; }
        [PrimaryKey]
        public string CodigoProducto { get; set; }
        [PrimaryKey]
        public string IdInsumo { get; set; }

        public float CantidadRequerida { get; set; }

    }

}

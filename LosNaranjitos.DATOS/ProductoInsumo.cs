using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class ProductoInsumo
    {
        [PrimaryKey]
        [Required]
        public string CodigoProducto { get; set; }
        [PrimaryKey]
        [Required]
        public string IdInsumo { get; set; }
        [Required]
        public string IdMedida { get; set; }
        [Required]
        public float CantidadRequerida { get; set; }
        [Required]
        public float Porcion { get; set; }

    }

}

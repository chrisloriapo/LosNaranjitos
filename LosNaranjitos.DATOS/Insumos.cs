using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Insumos
    {
        [PrimaryKey]
        [Required]
        public string IdInsumo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string IdMedida { get; set; }
        [Required]
        public decimal PrecioCompra { get; set; }
        [Required]
        public float CantInventario { get; set; }
        [Required]
        public string Proveedor { get; set; }
        [Required]
        public bool Activo { get; set; }

    }

}

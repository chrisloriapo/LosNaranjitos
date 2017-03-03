using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Producto
    {
        [PrimaryKey]
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public string Consecutivo { get; set; }

    }

}

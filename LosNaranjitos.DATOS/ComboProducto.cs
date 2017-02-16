using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class ComboProducto
    {
        [Required]
        public string Consecutivo { get; set; }
        
        [PrimaryKey]
        public string CodCombo { get; set; }
        [Required]
        public string CodProducto { get; set; }
        [Required]
        public string IdMedida { get; set; }
        [Required]
        public float CantidadProducto { get; set; }

    }

}

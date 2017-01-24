using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Proveedor
    {
        [PrimaryKey]
        [Required]
        public string IdProveedor { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public char Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public bool Activo { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace LosNaranjitos.DATOS
{
    public class Cliente
    {
        [Required]
        [PrimaryKey]
        public string IdPersonal { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido1 { get; set; }
        
        public string Apellido2 { get; set; }
        
        public char Telefono { get; set; }

        public string Operadora { get; set; }
        [Required]
        public DateTime UltimaVisita { get; set; }

        public decimal? Puntaje { get; set; }
        [Required]
        public bool Activo { get; set; }

    }

}

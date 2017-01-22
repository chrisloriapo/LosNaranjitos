using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Usuario
    {
        [PrimaryKey]
        [Required]
        public string IdUsuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public int Rol { get; set; }
        [Required]
        public string IdPersonal { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public bool Activo { get; set; }

            }

}

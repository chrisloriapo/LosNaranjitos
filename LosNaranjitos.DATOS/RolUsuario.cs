using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class RolUsuario
    {
        [PrimaryKey]
        [Required]
        [AutoIncrement]
        public int IdRol { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
    }

}

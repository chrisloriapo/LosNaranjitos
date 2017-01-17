using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class CategoriaProductos
    {
        [Required][PrimaryKey]
        public int IdTipo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
    }

}

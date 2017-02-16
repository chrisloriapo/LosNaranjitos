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
        public string IdTipo { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }

}

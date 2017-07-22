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
        [PrimaryKey]
        [AutoIncrement]
        public int IdTipo { get; set; }

        public string DescripcionCategoria { get; set; }

        public bool Activo { get; set; }
    }

}

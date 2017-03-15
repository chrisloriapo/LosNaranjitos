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
        
        public string Codigo { get; set; }
        
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Categoria { get; set; }
        
        public decimal Precio { get; set; }
        
        public bool Activo { get; set; }
        
        public string Consecutivo { get; set; }

    }

}

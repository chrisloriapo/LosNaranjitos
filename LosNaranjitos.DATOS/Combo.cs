using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Combo
    {
        
        public string Consecutivo { get; set; }
        
        [PrimaryKey]
        public string Codigo { get; set; }
        
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        public decimal Precio { get; set; }
        
        public bool Activo { get; set; }


    }
}

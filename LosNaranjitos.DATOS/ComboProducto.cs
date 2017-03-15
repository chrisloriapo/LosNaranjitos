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
        
        public string Consecutivo { get; set; }
        
        [PrimaryKey]
        public string CodCombo { get; set; }
        
        public string CodProducto { get; set; }
        
        public string IdMedida { get; set; }
        
        public float CantidadProducto { get; set; }

    }

}

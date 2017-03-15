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
        
        public string IdProveedor { get; set; }
        
        public string Nombre { get; set; }
        
        public string Telefono { get; set; }
        
        public string Correo { get; set; }
        
        public bool Activo { get; set; }
        
        public string Consecutivo { get; set; }
    }

}

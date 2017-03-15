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
        
        public string Username { get; set; }
         
        public string Contrasena { get; set; }
        
        public string Rol { get; set; }
        
        public string IdPersonal { get; set; }
        
        public string Nombre { get; set; }
        
        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
       
        public string Correo { get; set; }
        
        public bool Activo { get; set; }
        
        public string Consecutivo { get; set; }

    }

}

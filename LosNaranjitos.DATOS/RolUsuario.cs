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
        public int IdRol { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }

}

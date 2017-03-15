using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Medida
    {
        [PrimaryKey]
        public string IdMedida { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Consecutivo { get; set; }

    }

}

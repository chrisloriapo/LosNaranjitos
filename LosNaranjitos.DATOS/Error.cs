using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Error
    {
        [Required][PrimaryKey]
        public int IdError { get; set; }
        
        public string Tipo { get; set; }
        
        public string Descripcion { get; set; }

    }

}

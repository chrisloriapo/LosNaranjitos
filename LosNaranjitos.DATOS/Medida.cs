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
        [PrimaryKey][Required]
        public string IdMedida { get; set; }
        [Required]
        public string Descripcion { get; set; }

    }

}

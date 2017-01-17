using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Bitacora
    {
        [Required][PrimaryKey]
        public int IdBitacora { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public DateTime? Fecha2 { get; set; }
        [Required]
        public string Accion { get; set; }
        public string Usuario { get; set; }

    }

}

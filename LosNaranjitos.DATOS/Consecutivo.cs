using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{
    public class Consecutivo
    {
        [Required][PrimaryKey]
        public string Prefijo { get; set; }

        public string Tipo { get; set; }

        public int ConsecutivoActual { get; set; }

    }

}

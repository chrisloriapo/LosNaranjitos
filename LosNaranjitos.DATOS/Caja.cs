using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Caja
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Consecutivo { get; set; }

        public string OperadorActual { get; set; }

        public bool Estado { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public bool Disponible { get; set; }

    }
}

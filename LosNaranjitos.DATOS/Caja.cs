using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Caja
    {
        public string Consecutivo { get; set; }

        public string OperadorActual { get; set; }

        public bool Estado { get; set; }

        public DateTime UltimaModificacion { get; set; }

    }
}

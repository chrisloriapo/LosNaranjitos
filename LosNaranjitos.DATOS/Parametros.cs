using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Parametros
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Consecutivo { get; set; }

        public string Nombre { get; set; }

        public string Valor { get; set; }

        public DateTime Fecha { get; set; }

        public string Operador { get; set; }

    }
}

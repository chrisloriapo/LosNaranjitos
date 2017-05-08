using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DATOS
{
    public class Cargas
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Consecutivo { get; set; }

        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        public bool Activo { get; set; }


    }

}

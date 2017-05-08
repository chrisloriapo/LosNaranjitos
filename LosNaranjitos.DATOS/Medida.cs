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
        [PrimaryKey][AutoIncrement]
        public int Consecutivo { get; set; }

        public string IdMedida { get; set; }

        public string Descripcion { get; set; }

    }

}

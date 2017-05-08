using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;


namespace LosNaranjitos.DATOS
{

    public class Insumos
    {
        [AutoIncrement]
        public int Consecutivo { get; set; }
        [PrimaryKey]
        public string IdInsumo { get; set; }

        public string Nombre { get; set; }

        public string IdMedida { get; set; }

        public decimal PrecioCompra { get; set; }

        public float? RendimientoUM { get; set; }

        public float RendimientoPorcion { get; set; }

        public decimal PrecioMermado { get; set; }

        public float CantInventario { get; set; }

        public string Proveedor { get; set; }

        public bool Activo { get; set; }
    }

}

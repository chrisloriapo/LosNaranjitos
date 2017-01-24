using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS.Interfaces
{
   public interface IMedida
    {
        List<DATOS.Medida> ListarMedidas();

        DATOS.Medida BuscarMedida(string IdMedida);

        void AgregarMedida(DATOS.Medida MEdida);

        void ActualizarMEdida(DATOS.Medida MEdida);

        bool ExisteMEdida(string IdMedida);
    }
}

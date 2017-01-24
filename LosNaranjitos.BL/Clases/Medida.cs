using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosNaranjitos.BL.Interfaces;
using LosNaranjitos.DATOS;

namespace LosNaranjitos.BL.Clases
{
    public class Medida : IMedida
    {
        public DS.Interfaces.IMedida MedProced = new DS.Clases.Medida();
        public void ActualizarMEdida(DATOS.Medida MEdida)
        {
            MedProced.ActualizarMEdida(MEdida);
        }

        public void AgregarMedida(DATOS.Medida MEdida)
        {
            MedProced.AgregarMedida(MEdida);
        }

        public DATOS.Medida BuscarMedida(string IdMedida)
        {
            return MedProced.BuscarMedida(IdMedida);
        }

        public bool ExisteMEdida(string IdMedida)
        {
            return MedProced.ExisteMEdida(IdMedida);
        }

        public List<DATOS.Medida> ListarMedidas()
        {
            return MedProced.ListarMedidas();
        }
    }
}

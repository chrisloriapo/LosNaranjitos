using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS
{
    public class _Conexion
    {
        public static OrmLiteConnectionFactory CrearConexion()
        {

            return new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }

    }
}

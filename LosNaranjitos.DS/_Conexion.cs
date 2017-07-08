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

            return new OrmLiteConnectionFactory(Properties.Settings.Default.conexion, SqlServerDialect.Provider);
        }

    }
}

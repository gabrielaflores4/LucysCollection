using C_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class N_Reportes
    {
        public static DataTable ObtenerReporteVentas(DateTime desdecompleto, DateTime hastacompleto)
        {
            return Reportes.ObtenerReporteVentas(desdecompleto, hastacompleto);
        }
    }
}
